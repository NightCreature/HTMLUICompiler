using System;
using System.Diagnostics;
using System.IO;
using System.Xml;

namespace HTMLUICompiler
{ 
    public class Change
    {
        public Change() {}
    }
    public class HTMLParser
    {
        public struct ParserSettings
        {
            public String m_rootPath;
        }

        public HTMLParser(ParserSettings settings)
        {
            m_settings = settings;
        }

        public void CompileHTMLFile(String inputFileName)
        {
            if (File.Exists(inputFileName))
            {
                XmlDocument document = new XmlDocument();
                document.Load(inputFileName);
                

                HTMLParserContext parseContext = new HTMLParserContext();
                parseContext.IntermediateDocument = new XmlDocument();
                parseContext.IntermediateRootElement = parseContext.IntermediateDocument.CreateNode(XmlNodeType.Element, "xml", "");
                //From here this is recursive
                ProcessCurrentXmlDocument(document, parseContext);
                //Recurse through the includes above for other includes, definitions and styles before moving on to transforming the body element, we might need these to be present before we can read that node
                foreach (String includeFileName in parseContext.getIncludeFileNames()) //this will break when included files start including files :(
                {
                    String fileName = includeFileName;
                    if (!Path.IsPathRooted(fileName))
                    {
                        fileName = m_settings.m_rootPath + includeFileName;
                    }
                    if (File.Exists(fileName))
                    {
                        XmlDocument includedDocument = new XmlDocument();
                        includedDocument.Load(fileName);
                        ProcessCurrentXmlDocument(includedDocument, parseContext);
                    }
                    else
                    {
                        Console.WriteLine("Trying to read file {0}, but the file doesn't exist", includeFileName);
                    }
                }


                foreach(XmlNode childNode in parseContext.IntermediateRootElement.ChildNodes)
                {
                    Console.WriteLine("Body Node being dealt with: {0}", childNode.Name);
                    walkBodyNodes(childNode, parseContext);
                }
                parseContext.IntermediateDocument.Save(m_settings.m_rootPath + "intermediate.xml");
            }
        }

        private void ProcessCurrentXmlDocument(XmlDocument document, HTMLParserContext parseContext)
        {
            //Start looking for include files
            foreach (XmlNode includeNode in document.SelectNodes("//include"))
            {
                foreach (XmlAttribute attribute in includeNode.Attributes)
                {
                    parseContext.addIncludeFile(attribute.Value);
                }
            }
            //Look for definition tags in all of the files and add these to the parse context, we need these to figure out what certain groups mean, might just do a text replace
            foreach (XmlNode definitions in document.SelectNodes("//definition"))
            {
                foreach (XmlNode definitionNode in definitions.ChildNodes)
                {
                    parseContext.addDefinitionNode(definitionNode);
                }
            }
            //Find style tags, these might be in a single external file or anywhere through out the HTML code
            foreach (XmlNode styles in document.SelectNodes("//style"))
            {
                //Should only be one of these and all we want is the inner xml which contain css definitions
                var stylesString = styles.InnerXml.Trim();
                string[] cssEndMark = {"}"};
                string[] stylesStrings = stylesString.Split(cssEndMark, StringSplitOptions.RemoveEmptyEntries);
                foreach (var style in stylesStrings)
                {
                    parseContext.addStyleNode(style);
                }
            }

            //Parse the body for each file with the above information and transform to final output file(s)
            //We are using an intermediate file for each first to replace the shortcut HTML

            XmlNode body_node = document.SelectSingleNode("//body");
            XmlNode importedBodyNode = parseContext.IntermediateDocument.ImportNode(body_node, true);
            foreach (XmlNode child in importedBodyNode.ChildNodes)
            {
                parseContext.IntermediateRootElement.AppendChild(child);
            }

            parseContext.IntermediateDocument.AppendChild(parseContext.IntermediateRootElement);
            parseContext.IntermediateDocument.Save(m_settings.m_rootPath + "intermediate.xml");
        }

        private void walkBodyNodes(XmlNode node, HTMLParserContext parseContext)
        {
            XmlNodeList list = node.ChildNodes;
            for (int index = 0; index < list.Count; ++index )
            {
                XmlNode newNode = parseContext.replaceNode(list[index]);

                if (node.HasChildNodes && node != parseContext.IntermediateRootElement)
                {
                    //if (newNode.HasChildNodes)
                    //{
                    //    walkBodyNodes(newNode, parseContext); //Context of the original attributes is gone here so this should be moved to replaceNode
                    //}
                    node.ReplaceChild(newNode, list[index]);
                }
                else
                {
                    node.AppendChild(newNode);
                }

            }
        }
        private ParserSettings m_settings;
    }
}

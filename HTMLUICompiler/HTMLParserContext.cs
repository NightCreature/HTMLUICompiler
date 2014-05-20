using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HTMLUICompiler
{
    public class HTMLParserContext
    {
        public HTMLParserContext()
        {
            m_includeFiles = new HashSet<String>();
            m_definitionNodes = new Dictionary<String, HTMLDefinitionNode>();
            m_styleNodes = new Dictionary<String, CssDefinition>();
        }

        public void addIncludeFile(String includeFileName)
        {
            m_includeFiles.Add(includeFileName);
        }

        public void addDefinitionNode(XmlNode definitionNode)
        {
            if (!ContainsXmlNode(definitionNode, m_definitionNodes))
            {
                m_definitionNodes.Add(definitionNode.Name, new HTMLDefinitionNode(definitionNode, this));
            }
            else
            {
                Console.WriteLine("Found a redefinition for {0} looks like <{0}>{1}</{0}>", definitionNode.Name, definitionNode.InnerXml);
            }
        }

        public void addStyleNode(string styleNode)
        {
            styleNode = styleNode.Trim();
            CssDefinition cssDef = new CssDefinition(styleNode);
            m_styleNodes.Add(cssDef.Name, cssDef);
        }

        public HashSet<String> getIncludeFileNames()
        {
            return m_includeFiles;
        }

        private bool ContainsXmlNode(XmlNode testNode, Dictionary<String, HTMLDefinitionNode> set)
        {
            foreach (var pair in set)
            {
                if (pair.Key == testNode.Name)
                {
                    return true;
                }
            }

            return false;
        }

        private bool ContainsXmlNode(XmlNode testNode, Dictionary<String, XmlNode> set)
        {
            foreach (var pair in set)
            {
                if (pair.Key == testNode.Name)
                {
                    return true;
                }
            }

            return false;
        }

        public bool hasDefinition(String Name)
        {
            foreach (var pair in m_definitionNodes)
            {
                if (pair.Key == Name)
                {
                    return true;
                }
            }

            return false;
        }

        public HTMLDefinitionNode getDefinitionNode(String Name)
        {
            return m_definitionNodes[Name];
        }

        /// <summary>
        /// THis function needs to replace the recursive definition nodes too, otherwise we miss on the actual attrbutes and overrides
        /// </summary>
        /// <param name="childNode"></param>
        /// <returns></returns>
        public XmlNode replaceNode(XmlNode childNode)
        {
            //XmlTextWriter writer = new XmlTextWriter(Console.Out);
            //writer.Formatting = Formatting.Indented;

            if (hasDefinition(childNode.Name))
            {
                //Modify the original node and replace with the definition on. Have to take care with the definition because it can have embbeded definitions internally.
                var definitionNodeOriginal = getDefinitionNode(childNode.Name); //This needs to be a copy not a reference
                var definitionNode = definitionNodeOriginal.Clone(this);
                if (definitionNode != null)
                {
                    //Console.WriteLine("Child Node");
                    //childNode.WriteTo(writer);
                    //Console.WriteLine("\nDefinition Node");
                    //definitionNode.SourceNode.WriteTo(writer);
                    //Console.WriteLine();
                    foreach (XmlAttribute attribute in childNode.Attributes)
                    {
                        //Instead of checking whether we have this overriden value it is better to change the value based on what the definition node tells us
                        //Doing this should be done on a cloned definitionNode so we can then change the internal sourceNode, after that we can add the source node to the 
                        //intermediate document and write out proper html
                        // Problem is we also have to deal with definition nodes embedded in definition nodes we need to overide these too.
                        definitionNode.FillOutAttribute(attribute);
                    }

                    definitionNode.replaceRecursiveDefinitionNodes(childNode, this);

                    return definitionNode.generateXmlNode(this);
                }

                
            }

            return childNode;
        }

        private HashSet<String> m_includeFiles;
        private Dictionary<String, HTMLDefinitionNode> m_definitionNodes;
        private Dictionary<String, CssDefinition> m_styleNodes;
        public XmlDocument IntermediateDocument { get; set; }
        public XmlNode IntermediateRootElement { get; set; }
    }
}

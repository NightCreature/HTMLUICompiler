using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Collections;

namespace HTMLUICompiler
{

    public class AttributeProperties
    {
        public string m_overrideableAttributeName;
        public string m_defaultAttributeValue;
        public string m_filledOutAttributeValue;
    }

  //<definition>
  //  <Text>
  //    <div class="#style">#actual_text#default</div>
  //  </Text>

  //  <Button id="#id">
  //    <Text stlye="Button_Header1" actual_text="lng_button_header" />
  //    <a class="#link_class" href="#link" />
  //  </Button>
  //</definition>
    public class HTMLDefinitionNode
    {
        private HTMLDefinitionNode()
        {
            m_name = "";
        }

        public HTMLDefinitionNode(XmlNode node, HTMLParserContext context)
        {
            m_sourceNode = node.CloneNode(true);
            m_name = node.Name;
            m_subNodes = new ArrayList();
            m_attributes = new Dictionary<string, AttributeProperties>();

            //Instead of dealing with xml nodes themselves its going to be easier to just deconstruct the whole thing, and recreate XML nodes in the final document
            decodeSourceNode(node, context);
        }

        public HTMLDefinitionNode Clone(HTMLParserContext context)
        {
            HTMLDefinitionNode copiedNode = new HTMLDefinitionNode();
            HTMLDefinitionNode[] nodeArray = new HTMLDefinitionNode[m_subNodes.Count];
            m_subNodes.CopyTo(nodeArray);
            copiedNode.m_subNodes = new ArrayList( nodeArray );
            copiedNode.m_name = m_name;
            copiedNode.m_sourceNode = m_sourceNode.CloneNode(true);
            copiedNode.m_attributes = new Dictionary<string, AttributeProperties>(m_attributes);

            return copiedNode;
        }

        public void FillOutAttribute(XmlAttribute attribute)
        {
            foreach (KeyValuePair<string, AttributeProperties> pair in m_attributes)
            {
                if (pair.Value.m_overrideableAttributeName == attribute.Name)
                {
                    pair.Value.m_filledOutAttributeValue = attribute.Value;
                }
                else
                {
                    foreach (HTMLDefinitionNode node in m_subNodes)
                    {
                        node.FillOutAttribute(attribute);
                    }
                }
            }

        }

        public bool hasOverridenAttributeName(String attributeName)
        {
            if (m_attributes.ContainsKey(attributeName))
            {
                return true;
            }
            else
            {
                foreach (HTMLDefinitionNode node in m_subNodes)
                {
                    return node.hasOverridenAttributeName(attributeName);
                }
            }

            return false;
        }

        public String Name { get { return m_name; } }

        private void decodeSourceNode(XmlNode node, HTMLParserContext context)
        {
            if (node.Attributes != null)
            {
                foreach (XmlAttribute attribute in node.Attributes)
                {
                    AttributeProperties overridableNameAndDefaultValue = new AttributeProperties();
                    if (attribute.Value.Contains("#"))
                    {
                        string attributeValue = attribute.Value;
                        attributeValue = attributeValue.Substring(attributeValue.IndexOf("#") + 1);
                        string[] splitAttributeValues = attributeValue.Split('#'); //0 will be the name of the attribute to get from the childNode, 1 is the default value if it exists which is used if the value is not overriden in the childnode
                        if (splitAttributeValues.Length > 1)
                        {
                            overridableNameAndDefaultValue.m_overrideableAttributeName = splitAttributeValues[0];
                            overridableNameAndDefaultValue.m_defaultAttributeValue = splitAttributeValues[1];
                        }
                        else
                        {
                            overridableNameAndDefaultValue.m_overrideableAttributeName = splitAttributeValues[0];
                            overridableNameAndDefaultValue.m_defaultAttributeValue = "";
                        }
                    }
                    else
                    {
                        //This node is an override of something else so store the actual attribute value
                        overridableNameAndDefaultValue.m_overrideableAttributeName = attribute.Value;
                        overridableNameAndDefaultValue.m_defaultAttributeValue = attribute.Value;
                    }

                    m_attributes.Add(attribute.Name, overridableNameAndDefaultValue);
                }
            }
            //Should deal with inner text here that has no nodes in it. so we can replace this stuff too important for text as that is just a div

            if (node.ChildNodes != null)
            {
                
                foreach (XmlNode childNode in node.ChildNodes)
                {                 
                    m_subNodes.Add(new HTMLDefinitionNode(childNode, context));
                }
            }

            for (int counter = 0; counter < m_subNodes.Count; ++counter )
            {
                //Need to check whether subnodes are definition nodes if they are we need to copy that node and deal with the attributes of that node.
                HTMLDefinitionNode subNode = m_subNodes[counter] as HTMLDefinitionNode;
                if (context.hasDefinition(subNode.m_name))
                {
                    var newSubNode = context.getDefinitionNode(subNode.m_name).Clone(context);
                    foreach (XmlAttribute attribute in subNode.m_sourceNode.Attributes) //Still some issues here definitions in definitions are still broken
                    {
                        newSubNode.FillOutAttribute(attribute);
                        m_subNodes[counter] = newSubNode;
                    }
                    
                }
            }
        }

        public XmlNode generateXmlNode(HTMLParserContext context)
        {
            XmlDocument doc = context.IntermediateDocument;
            var element = doc.CreateNode(XmlNodeType.Element, m_name, "");
            foreach (var pair in m_attributes)
            {
                
                var attribute = doc.CreateAttribute(pair.Key);

                if (pair.Value.m_filledOutAttributeValue != null)
                {
                    if (pair.Value.m_filledOutAttributeValue != "")
                    {
                        attribute.Value = pair.Value.m_filledOutAttributeValue;
                    }
                    else
                    {
                        attribute.Value = pair.Value.m_defaultAttributeValue;
                    }
                }
                else
                {
                    attribute.Value = pair.Value.m_defaultAttributeValue;
                }
                element.Attributes.Append(attribute);
            }

            foreach (HTMLDefinitionNode subnode in m_subNodes)
            {
                element.AppendChild(subnode.generateXmlNode(context));
            }
            
            return element;
        }
        
        /// <summary>
        /// This only works if we recursively replace stuff in the definition node first
        /// </summary>
        /// <param name="childNode"></param>
        public void replaceRecursiveDefinitionNodes(XmlNode childNode, HTMLParserContext context)
        {
            //for (int index = 0; index < m_subNodes.Count; ++index )
            //{
            //    HTMLDefinitionNode subNode = (HTMLDefinitionNode)m_subNodes[index];
            //    if (context.hasDefinition(subNode.m_name))
            //    {
            //        //Modify the original node and replace with the definition on. Have to take care with the definition because it can have embbeded definitions internally.
            //        var definitionNode = context.getDefinitionNode(subNode.m_name); //This needs to be a copy not a reference
            //        var cloned = new HTMLDefinitionNode(definitionNode.SourceNode, context);
            //        if (definitionNode != null)
            //        {
            //            //replace subnode with new definition node
            //            m_subNodes[index] = cloned;
            //        }
            //    }
            //}

            foreach (HTMLDefinitionNode subnode in m_subNodes)
            {
                foreach (XmlAttribute attribute in childNode.Attributes)
                {
                    subnode.FillOutAttribute(attribute);
                }
            }
        }

        public XmlNode SourceNode { get { return m_sourceNode; } }

        private String m_name;
        private ArrayList m_subNodes;

        //This encodes the original attribute name to override able name and default value for that overriden name
        private Dictionary<string, AttributeProperties> m_attributes;

        private XmlNode m_sourceNode;
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLUICompiler
{
    public class CssDefinition
    {
        public CssDefinition(string cssString)
        {
            m_name = "";
            m_properties = new List<CssRule>();
            decodeCssString(cssString);
        }

        private void decodeCssString(string cssString)
        {
            string[] intialSplit = { "{" };
            string[] tokens = cssString.Split(intialSplit, StringSplitOptions.None);
            m_name = tokens[0].Trim();

            decodeCssValues(tokens);
        }

        private void decodeCssValues(string[] tokens)
        {
            string[] lineSplit = { ";" };
            string[] cssValueSplit = { ":" };
            string[] lines = tokens[1].Split(lineSplit, StringSplitOptions.None);
            foreach (var line in lines)
            {
                string[] cssValueTokens = line.Trim().Split(cssValueSplit, StringSplitOptions.None);
                if (cssValueTokens.Count() == 2)
                {
                    //m_properties.Add(cssValueTokens[0], cssValueTokens[1]);
                }
                else
                {
                    Debug.WriteLine("Error in css value");
                }
            }
        }

        public string Name { get { return m_name; } }

        private string m_name;
        private List<CssRule> m_properties;
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLUICompiler
{
    public class CssParser
    {
        public CssParser(string cssString)
        {
            m_name = "";
            m_properties = new List<CssGroup>();
            decodeCssString(cssString);
        }

        private void decodeCssString(string cssString)
        {
            string[] intialSplit = { "{" };
            string[] tokens = cssString.Split(intialSplit, StringSplitOptions.RemoveEmptyEntries);
            m_name = tokens[0].Trim();

            decodeCssValues(tokens);
        }

        private void decodeCssValues(string[] tokens)
        {
            string[] lineSplit = { ";" };
            string[] cssValueSplit = { ":" };
            string[] lines = tokens[1].Split(lineSplit, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                string[] cssValueTokens = line.Trim().Split(cssValueSplit, StringSplitOptions.RemoveEmptyEntries);
                if (cssValueTokens.Count() == 2)
                {
                    //m_properties.Add(cssValueTokens[0], cssValueTokens[1]);
                    CssHelpers.CssCategory cssCategory = CssHelpers.GetStringToCssCategory(cssValueTokens[0]);
                    if (cssCategory != null)
                    {
                        CssGroup cssGroup = GetCssGroup(cssCategory.m_cssGroup);
                        if (cssGroup == null)
                        {
                            cssGroup = (CssGroup)cssCategory.m_cssGroup.GetConstructor(Type.EmptyTypes).Invoke(Type.EmptyTypes);
                        }

                        CssRule cssRule = cssGroup.GetCssRule(cssCategory.m_cssToken);
                        if (cssRule == null)
                        {
                            cssRule = (CssRule)cssCategory.m_cssToken.GetConstructor(Type.EmptyTypes).Invoke(Type.EmptyTypes);
                        }

                        cssRule.decodeCssString(cssValueTokens[1]);
                        cssGroup.AddCssRule(cssRule);
                        m_properties.Add(cssGroup);
                    }
                    else
                    {
                        Debug.WriteLine("Couldn't find a match for css key: " + cssValueTokens[0]);
                    }
                }
                else
                {
                    Debug.Write("Error in css value: ");
                    foreach (var token in cssValueTokens)
                    {
                        Debug.WriteLine(token);
                    }
                }
            }
        }

        public string Name { get { return m_name; } }

        private CssGroup GetCssGroup(Type cssGroupType)
        {
            foreach (var group in m_properties)
            {
                if (group.GetType() == cssGroupType)
                {
                    return group;
                }
            }

            return null;
        }
        private string m_name;
        private List<CssGroup> m_properties;
    }
}

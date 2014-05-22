using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLUICompiler
{
    public abstract class CssGroup
    {
        public CssGroup()
        {
            m_rules = new List<CssRule>();
        }

        public void AddCssRule(CssRule rule)
        {
            m_rules.Add(rule);
        }

        public CssRule GetCssRule(Type cssToken)
        {
            foreach (var rule in m_rules)
            {
                if (rule.GetType() == cssToken)
                {
                    return rule;
                }
            }

            return null;
        }

        private List<CssRule> m_rules;
    }


    public class Color : CssGroup
    { }

    public class BackgroundAndBorders : CssGroup
    { }

    public class BasicBox : CssGroup
    { }

    public class FlexibleBox : CssGroup
    { }

    public class Text : CssGroup
    { }

    public class TextDecoration : CssGroup
    { }

    public class Fonts : CssGroup
    { }

    public class WritingModes : CssGroup
    { }

    public class Table : CssGroup
    { }

    public class ListAndCounters : CssGroup
    { }

    public class Animation : CssGroup
    { }

    public class Transform : CssGroup
    { }

    public class Transition : CssGroup
    { }

    public class BasicUserInterface : CssGroup
    { }

    public class MultiColumn : CssGroup
    { }

    public class PagedMedia : CssGroup
    { }

    public class GeneratedContent : CssGroup
    { }

    public class FilterEffects : CssGroup
    { }

    public class ImageReplacedContent : CssGroup
    { }

    public class Masking : CssGroup
    { }

    public class Speech : CssGroup
    { }

    public class Marquee : CssGroup
    { }
}

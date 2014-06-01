using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLUICompiler
{


    public class BREAKAFTER : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class BREAKBEFORE : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class BREAKINSIDE : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class COLUMNCOUNT : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class COLUMNFILL : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class COLUMNGAP : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class COLUMNRULE : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class COLUMNRULECOLOR : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            BorderColor = CssHelpers.decodeColorString(cssString);
        }

        public Color BorderColor { get; set; }
    }

    public class COLUMNRULESTYLE : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class COLUMNRULEWIDTH : CssWidthRule
    {
    }

    public class COLUMNSPAN : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class COLUMNWIDTH : CssWidthRule
    {
    }

    public class COLUMNS : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class WIDOWS : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }
}

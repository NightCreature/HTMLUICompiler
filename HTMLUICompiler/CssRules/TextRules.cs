using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLUICompiler
{

    public class HANGINGPUNCTUATION : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class HYPHENS : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class LETTERSPACING : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class LINEBREAK : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class LINEHEIGHT : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class OVERFLOWWRAP : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class TABSIZE : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class TEXTALIGN : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class TEXTALIGNLAST : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class TEXTINDENT : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class TEXTJUSTIFY : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class TEXTTRANSFORM : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class WHITESPACE : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class WORDBREAK : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class WORDSPACING : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class WORDWRAP : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class TEXTDECORATION : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class TEXTDECORATIONCOLOR : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            BorderColor = CssHelpers.decodeColorString(cssString);
        }

        public Color BorderColor { get; set; }
    }

    public class TEXTDECORATIONLINE : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class TEXTDECORATIONSTYLE : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class TEXTSHADOW : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class TEXTUNDERLINEPOSITION : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLUICompiler
{

    public class CONTENT : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class CURSOR : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class ICON : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class IMEMODE : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class NAVDOWN : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class NAVINDEX : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class NAVLEFT : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class NAVRIGHT : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class NAVUP : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class OUTLINE : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class OUTLINECOLOR : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            BorderColor = CssHelpers.decodeColorString(cssString);
        }

        public Color BorderColor { get; set; }
    }

    public class OUTLINEOFFSET : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class OUTLINESTYLE : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class OUTLINEWIDTH : CssWidthRule
    {
    }

    public class RESIZE : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class TEXTOVERFLOW : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }
}

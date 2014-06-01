using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLUICompiler
{

    public class BOTTOM : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            Bottom = CssHelpers.decodeCssUnit(cssString);
        }

        public CssUnit Bottom { get; set; }
    }

    public class CLEAR : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class CLIP : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class FLOATING : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class HEIGHT : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            Height = CssHelpers.decodeCssUnit(cssString);
        }

        public CssUnit Height { get; set; }
    }

    public class LEFT : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            Left = CssHelpers.decodeCssUnit(cssString);
        }

        public CssUnit Left { get; set; }
    }

    public class OVERFLOW : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class OVERFLOWX : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class OVERFLOWY : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class PADDING : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class PADDINGBOTTOM : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class PADDINGLEFT : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class PADDINGRIGHT : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class PADDINGTOP : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class POSITION : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class RIGHT : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            Right = CssHelpers.decodeCssUnit(cssString);
        }

        public CssUnit Right { get; set; }
    }

    public class TOP : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            Top = CssHelpers.decodeCssUnit(cssString);
        }

        public CssUnit Top { get; set; }
    }

    public class VISIBILITY : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class WIDTH : CssWidthRule
    {
    }

    public class VERTICALALIGN : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class ZINDEX : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }



    public class ALIGNCONTENT : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class ALIGNITEMS : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class ALIGNSELF : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class DISPLAY : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class FLEX : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class FLEXBASIS : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class FLEXDIRECTION : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class FLEXFLOW : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class FLEXGROW : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class FLEXSHRINK : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class FLEXWRAP : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class JUSTIFYCONTENT : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class MARGIN : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class MARGINBOTTOM : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class MARGINLEFT : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class MARGINRIGHT : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class MARGINTOP : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class MAXHEIGHT : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class MAXWIDTH : CssWidthRule
    {
    }

    public class MINHEIGHT : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class MINWIDTH : CssWidthRule
    {
    }

    public class ORDER : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }
}

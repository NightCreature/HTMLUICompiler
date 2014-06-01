using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLUICompiler
{

    public class Border : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class Borderbottom : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class BorderBottomColor : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            Color = CssHelpers.decodeColorString(cssString);
        }

        public Color Color { get; set; }
    }

    public class BORDERBOTTOMLEFTRADIUS : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            Position.decodeCssString(cssString);
        }

        public CssPosition Position { get; set; }
    }

    public class BORDERBOTTOMRIGHTRADIUS : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            Position.decodeCssString(cssString);
        }

        public CssPosition Position { get; set; }
    }

    public class CssBorderStyle : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            if ("none" == cssString)
            {
                Style = BorderBottomStyle.none;
            }
            else if ("hidden" == cssString)
            {
                Style = BorderBottomStyle.hidden;
            }
            else if ("dotted" == cssString)
            {
                Style = BorderBottomStyle.dotted;
            }
            else if ("dashed" == cssString)
            {
                Style = BorderBottomStyle.dashed;
            }
            else if ("solid" == cssString)
            {
                Style = BorderBottomStyle.solid;
            }
            else if ("double" == cssString)
            {
                Style = BorderBottomStyle.doubleborder;
            }
            else if ("groove" == cssString)
            {
                Style = BorderBottomStyle.groove;
            }
            else if ("ridge" == cssString)
            {
                Style = BorderBottomStyle.ridge;
            }
            else if ("inset" == cssString)
            {
                Style = BorderBottomStyle.inset;
            }
            else if ("outset" == cssString)
            {
                Style = BorderBottomStyle.outset;
            }
        }

        public enum BorderBottomStyle
        {
            none, 	//Specifies no border. This is default 	Play it »	
            hidden, 	//The same as "none", except in border conflict resolution for table elements 	Play it »	
            dotted, 	//Specifies a dotted border 	Play it »	
            dashed, 	//Specifies a dashed border 	Play it »
            solid,	//Specifies a solid border 	Play it »
            doubleborder, 	//Specifies a double border 	Play it »
            groove, 	//Specifies a 3D grooved border. The effect depends on the border-color value 	Play it »
            ridge, 	//Specifies a 3D ridged border. The effect depends on the border-color value 	Play it »
            inset, 	//Specifies a 3D inset border. The effect depends on the border-color value 	Play it »
            outset, 	//Specifies a 3D outset border. The effect depends on the border-color value 	Play it »
        }

        public BorderBottomStyle Style { get; set; }
    }

    public class BORDERBOTTOMSTYLE : CssBorderStyle
    {
    }

    public class CssWidthRule : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }

        public int Width { get; set; }
    }

    public class BORDERBOTTOMWIDTH : CssWidthRule
    {

    }

    public class BORDERCOLOR : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            BorderColor = CssHelpers.decodeColorString(cssString);
        }

        public Color BorderColor { get; set; }
    }

    public class BORDERIMAGE : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            string imgurl = cssString.Replace("url", "");
            imgurl = imgurl.Replace(")", "");
            imgurl = imgurl.Replace("(", "");

            char[] splitchars = { ',' };
            Images = imgurl.Split(splitchars);
        }

        public string[] Images { get; set; }
    }

    public class BORDERIMAGEOUTSET : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class BORDERIMAGEREPEAT : CssRepeatRule
    {
    }

    public class BORDERIMAGESLICE : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class BORDERIMAGESOURCE : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class BORDERIMAGEWIDTH : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class BORDERLEFT : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class BORDERLEFTCOLOR : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            BorderColor = CssHelpers.decodeColorString(cssString);
        }

        public Color BorderColor { get; set; }
    }

    public class BORDERLEFTSTYLE : CssBorderStyle
    {
    }

    public class BORDERLEFTWIDTH : CssWidthRule
    {
    }

    public class BORDERRADIUS : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class BORDERRIGHT : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class BORDERRIGHTCOLOR : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            BorderColor = CssHelpers.decodeColorString(cssString);
        }

        public Color BorderColor { get; set; }
    }

    public class BORDERRIGHTSTYLE : CssBorderStyle
    {
    }

    public class BORDERRIGHTWIDTH : CssWidthRule
    {
    }

    public class BORDERSTYLE : CssBorderStyle
    {
    }

    public class BORDERTOP : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class BORDERTOPCOLOR : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            BorderColor = CssHelpers.decodeColorString(cssString);
        }

        public Color BorderColor { get; set; }
    }

    public class BORDERTOPLEFTRADIUS : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class BORDERTOPRIGHTRADIUS : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class BORDERTOPSTYLE : CssBorderStyle
    {
    }

    public class BORDERTOPWIDTH : CssWidthRule
    {
    }

    public class BORDERWIDTH : CssWidthRule
    {
    }

}

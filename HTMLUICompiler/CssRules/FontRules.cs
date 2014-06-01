using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLUICompiler
{

    public class FONT : CssRule
    {

        public override void decodeCssString(string cssString)
        {

        }
    }

    public class FONTFAMILY : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            char[] splitChars = { ',' };
            FontNames = cssString.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
        }

        public string[] FontNames { get; set; }
    }

    public class FONTFEATURESETTING : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class FONTFEATUREVALUES : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class FONTKERNING : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class FONTLANGUAGEOVERRIDE : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class FONTSYNTHESIS : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class FONTVARIANTALTERNATES : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class FONTVARIANTCAPS : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class FONTVARIANTEASTASIAN : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class FONTVARIANTLIGATURES : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class FONTVARIANTNUMERIC : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class FONTVARIANTPOSITION : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class FONTSIZE : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class FONTSTYLE : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class FONTVARIANT : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }

        //medium 	Sets the font-size to a medium size. This is default 	Play it »
        //xx-small 	Sets the font-size to an xx-small size 	Play it »
        //x-small 	Sets the font-size to an extra small size 	Play it »
        //small 	Sets the font-size to a small size 	Play it »
        //large 	Sets the font-size to a large size 	Play it »
        //x-large 	Sets the font-size to an extra large size 	Play it »
        //xx-large 	Sets the font-size to an xx-large size 	Play it »
        //smaller 	Sets the font-size to a smaller size than the parent element 	Play it »
        //larger 	Sets the font-size to a larger size than the parent element 	Play it »
        //length 	Sets the font-size to a fixed size in px, cm, etc. 	Play it »
        //% 	Sets the font-size to a percent of  the parent element's font size 	Play it »
    }

    public class FONTWEIGHT : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    //No need to support this as games generally only run with known fonts
    public class FONTFACE : CssRule
    {
        public override void decodeCssString(string cssString)
        {
        }
    }

    public class FONTSIZEADJUST : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class FONTSTRETCH : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }
}

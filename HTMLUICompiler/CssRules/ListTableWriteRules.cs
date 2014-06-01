using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLUICompiler
{


    public class DIRECTION : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class TEXTORIENTATION : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class TEXTCOMBINEHORIZONTAL : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class UNICODEBIDI : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class WRITINGMODE : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class BORDERCOLLAPSE : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class BORDERSPACING : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class CAPTIONSIDE : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class EMPTYCELLS : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class TABLELAYOUT : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class COUNTERINCREMENT : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class COUNTERRESET : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class LISTSTYLE : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class LISTSTYLEIMAGE : CssRule
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

    public class LISTSTYLEPOSITION : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class LISTSTYLETYPE : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLUICompiler
{
    public abstract class CssRule
    {
        public CssRule()
        {

        }

        public abstract void decodeCssString(string cssString);
    }



    public class ColorRule : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            Color = CssHelpers.decodeColorString(cssString);
        }

        public Color Color { get; set; }
    }

    public class OpacityGroup : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            float value = 1.0f;
            float.TryParse(cssString, out value);
            Opacity = value;
        }

        public float Opacity { get; set; }
    }

    public class CssPositionRule : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            string positionStr = cssString.Replace("position", "");
            positionStr = positionStr.Replace(")", "");
            positionStr = positionStr.Replace("(", "");

            Position.decodeCssString(positionStr);
        }

        public CssPosition Position { get; set; }
    }

    public class CssImageRule : CssRule
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

    public class BOXDECORATIONBREAK : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class BOXSHADOW : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

}
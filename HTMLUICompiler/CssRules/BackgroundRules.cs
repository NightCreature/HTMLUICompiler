using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLUICompiler
{

    public class BACKGROUND : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

    public class BackgroundAttachment : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            if (cssString == "scroll")
            {
                Style = AttachementStyle.Scroll;
            }
            else if (cssString == "fixed")
            {
                Style = AttachementStyle.Fixed;
            }
            else if (cssString == "local")
            {
                Style = AttachementStyle.Local;
            }
        }

        public enum AttachementStyle
        {
            Scroll, //The background scrolls along with the element. This is default
            Fixed,  //The background is fixed with regard to the view port
            Local   //The background scrolls along with the element's contents
        };

        public AttachementStyle Style { get; set; }
    }

    public class BackgroundColor : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            Color = CssHelpers.decodeColorString(cssString);
        }

        public Color Color { get; set; }
    }

    public class BackgroundImage : CssImageRule
    {
    }

    public class BackgroundPosition : CssPositionRule
    {
    }

    public class CssRepeatRule : CssRule //Double check where this is used it is not always the same rule
    {
        public override void decodeCssString(string cssString)
        {
            if (cssString == "repeat")
            {
                RepeatBackGround = Repeat.repeat;
            }
            else if (cssString == "repeat-x")
            {
                RepeatBackGround = Repeat.repeatx;
            }
            else if (cssString == "repeat-y")
            {
                RepeatBackGround = Repeat.repeaty;
            }
            else if (cssString == "no-repeat")
            {
                RepeatBackGround = Repeat.norepeat;
            }
        }
        public enum Repeat
        {
            repeat, //	The background image will be repeated both vertically and horizontally. This is default 	Play it »
            repeatx, //	The background image will be repeated only horizontally 	Play it »
            repeaty, //	The background image will be repeated only vertically 	Play it »
            norepeat,// 	The background-image will not be repeated
        };

        public Repeat RepeatBackGround { get; set; }
    }

    public class BackgroundRepeat : CssRepeatRule
    { } //Just a typedef

    public class BackgroundClip : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            if (cssString == "border-box")
            {
                Clip = ClipBox.border;
            }
            else if (cssString == "padding-box")
            {
                Clip = ClipBox.padding;
            }
            else if (cssString == "content-box")
            {
                Clip = ClipBox.content;
            }
        }

        public enum ClipBox
        {
            border, 	//Default value. The background is clipped to the border box 	Play it »
            padding, 	//The background is clipped to the padding box 	Play it »
            content,	//The background is clipped to the content box
        };

        public ClipBox Clip { get; set; }
    }

    public class Backgroundorigin : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            if (cssString == "border-box")
            {
                Clip = OriginBox.border;
            }
            else if (cssString == "padding-box")
            {
                Clip = OriginBox.padding;
            }
            else if (cssString == "content-box")
            {
                Clip = OriginBox.content;
            }
        }

        public enum OriginBox
        {
            border, 	//Default value. The background is clipped to the border box 	Play it »
            padding, 	//The background is clipped to the padding box 	Play it »
            content,	//The background is clipped to the content box
        };

        public OriginBox Clip { get; set; }
    }

    public class Backgroundsize : CssRule
    {
        public override void decodeCssString(string cssString)
        {

        }
    }

}

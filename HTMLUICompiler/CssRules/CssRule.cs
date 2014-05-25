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

    public class BackgroundImage : CssRule
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

    public class BackgroundPosition : CssRule
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

    public class BackgroundRepeat : CssRule
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

    public class BORDERBOTTOMSTYLE : CssRule
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

    public class BORDERBOTTOMWIDTH : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
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
            
        }
    }

    public class BORDERIMAGEOUTSET : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class BORDERIMAGEREPEAT : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
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

    public class BORDERLEFTSTYLE : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class BORDERLEFTWIDTH : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
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

    public class BORDERRIGHTSTYLE : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class BORDERRIGHTWIDTH : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class BORDERSTYLE : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
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

    public class BORDERTOPSTYLE : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class BORDERTOPWIDTH : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class BORDERWIDTH : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
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

    public class BOTTOM : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
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
            
        }
    }

    public class LEFT : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
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
            
        }
    }

    public class TOP : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class VISIBILITY : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class WIDTH : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
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

    public class MAXWIDTH : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class MINHEIGHT : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class MINWIDTH : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class ORDER : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

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
            
        }
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
    }

    public class FONTWEIGHT : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

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
            
        }
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

    public class KEYFRAMES : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class ANIMATION : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class ANIMATIONDELAY : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class ANIMATIONDIRECTION : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class ANIMATIONDURATION : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class ANIMATIONFILLMODE : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class ANIMATIONITERATIONCOUNT : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class ANIMATIONNAME : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class ANIMATIONTIMINGFUNCTION : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class ANIMATIONPLAYSTATE : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class BACKFACEVISIBILITY : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class PERSPECTIVE : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class PERSPECTIVEORIGIN : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class TRANSFORM : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class TRANSFORMORIGIN : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class TRANSFORMSTYLE : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class TRANSITIONPROPERTY : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class TRANSITION : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class TRANSITIONDURATION : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class TRANSITIONTIMINGFUNCTION : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class TRANSITIONDELAY : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class BOXSIZING : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

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

    public class OUTLINEWIDTH : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
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

    public class COLUMNRULEWIDTH : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class COLUMNSPAN : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class COLUMNWIDTH : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
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

    public class ORPHANS : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class PAGEBREAKAFTER : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class PAGEBREAKBEFORE : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class PAGEBREAKINSIDE : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class MARKS : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class QUOTES : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class FILTER : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class IMAGEORIENTATION : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class IMAGERENDERING : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class IMAGERESOLUTION : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class OBJECTFIT : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class OBJECTPOSITION : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class MASK : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class MASKTYPE : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class MARK : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class MARKAFTER : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class MARKBEFORE : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class PHONEMES : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class REST : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class RESTAFTER : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class RESTBEFORE : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class VOICEBALANCE : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class VOICEDURATION : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class VOICEPITCH : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class VOICEPITCHRANGE : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class VOICERATE : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class VOICESTRESS : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class VOICEVOLUME : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class MARQUEEDIRECTION : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class MARQUEEPLAYCOUNT : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class MARQUEESPEED : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }

    public class MARQUEESTYLE : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            
        }
    }
}
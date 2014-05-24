using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Drawing;
using System.Diagnostics;

namespace HTMLUICompiler
{
    public class CssHelpers
    {
        public class CssCategory
        {
            public CssCategory(Type cssToken, Type cssGroup)
            {
                m_cssToken = cssToken;
                m_cssGroup = cssGroup;
            }
            public Type m_cssToken;
            public Type m_cssGroup;
        }

        public static Dictionary<string, CssCategory> StringToCssCategory = new Dictionary<string, CssCategory>()
        {
            {"color", new CssCategory(typeof(ColorRule), typeof(CssColor)) }, 
            {"opacity", new CssCategory(typeof(OpacityGroup), typeof(CssColor)) }, 
            {"background", new CssCategory(typeof(BACKGROUND), typeof(BackgroundAndBorders)) }, 
            {"background-attachment", new CssCategory(typeof(BackgroundAttachment), typeof(BackgroundAndBorders)) }, 
            {"background-color", new CssCategory(typeof(BackgroundColor), typeof(BackgroundAndBorders)) }, 
            {"background-image", new CssCategory(typeof(BackgroundImage), typeof(BackgroundAndBorders)) }, 
            {"background-position", new CssCategory(typeof(BackgroundPosition), typeof(BackgroundAndBorders)) }, 
            {"background-repeat", new CssCategory(typeof(BackgroundRepeat), typeof(BackgroundAndBorders)) }, 
            {"background-clip", new CssCategory(typeof(BackgroundClip), typeof(BackgroundAndBorders)) }, 
            {"background-origin", new CssCategory(typeof(Backgroundorigin), typeof(BackgroundAndBorders)) }, 
            {"background-size", new CssCategory(typeof(Backgroundsize), typeof(BackgroundAndBorders)) }, 
            {"border", new CssCategory(typeof(Border), typeof(BackgroundAndBorders)) }, 
            {"border-bottom", new CssCategory(typeof(Borderbottom), typeof(BackgroundAndBorders)) }, 
            {"border-bottom-color", new CssCategory(typeof(BorderBottomColor), typeof(BackgroundAndBorders)) }, 
            {"border-bottom-left-radius", new CssCategory(typeof(BORDERBOTTOMLEFTRADIUS), typeof(BackgroundAndBorders)) }, 
            {"border-bottom-right-radius", new CssCategory(typeof(BORDERBOTTOMRIGHTRADIUS), typeof(BackgroundAndBorders)) }, 
            {"border-bottom-style", new CssCategory(typeof(BORDERBOTTOMSTYLE), typeof(BackgroundAndBorders)) }, 
            {"border-bottom-width", new CssCategory(typeof(BORDERBOTTOMWIDTH), typeof(BackgroundAndBorders)) }, 
            {"border-color", new CssCategory(typeof(BORDERCOLOR), typeof(BackgroundAndBorders)) }, 
            {"border-image", new CssCategory(typeof(BORDERIMAGE), typeof(BackgroundAndBorders)) }, 
            {"border-image-outset", new CssCategory(typeof(BORDERIMAGEOUTSET), typeof(BackgroundAndBorders)) }, 
            {"border-image-repeat", new CssCategory(typeof(BORDERIMAGEREPEAT), typeof(BackgroundAndBorders)) }, 
            {"border-image-slice", new CssCategory(typeof(BORDERIMAGESLICE), typeof(BackgroundAndBorders)) }, 
            {"border-image-source", new CssCategory(typeof(BORDERIMAGESOURCE), typeof(BackgroundAndBorders)) }, 
            {"border-image-width", new CssCategory(typeof(BORDERIMAGEWIDTH), typeof(BackgroundAndBorders)) }, 
            {"border-left", new CssCategory(typeof(BORDERLEFT), typeof(BackgroundAndBorders)) }, 
            {"border-left-color", new CssCategory(typeof(BORDERLEFTCOLOR), typeof(BackgroundAndBorders)) }, 
            {"border-left-style", new CssCategory(typeof(BORDERLEFTSTYLE), typeof(BackgroundAndBorders)) }, 
            {"border-left-width", new CssCategory(typeof(BORDERLEFTWIDTH), typeof(BackgroundAndBorders)) }, 
            {"border-radius", new CssCategory(typeof(BORDERRADIUS), typeof(BackgroundAndBorders)) }, 
            {"border-right", new CssCategory(typeof(BORDERRIGHT), typeof(BackgroundAndBorders)) }, 
            {"border-right-color", new CssCategory(typeof(BORDERRIGHTCOLOR), typeof(BackgroundAndBorders)) }, 
            {"border-right-style", new CssCategory(typeof(BORDERRIGHTSTYLE), typeof(BackgroundAndBorders)) }, 
            {"border-right-width", new CssCategory(typeof(BORDERRIGHTWIDTH), typeof(BackgroundAndBorders)) }, 
            {"border-style", new CssCategory(typeof(BORDERSTYLE), typeof(BackgroundAndBorders)) }, 
            {"border-top", new CssCategory(typeof(BORDERTOP), typeof(BackgroundAndBorders)) }, 
            {"border-top-color", new CssCategory(typeof(BORDERTOPCOLOR), typeof(BackgroundAndBorders)) }, 
            {"border-top-left-radius", new CssCategory(typeof(BORDERTOPLEFTRADIUS), typeof(BackgroundAndBorders)) }, 
            {"border-top-right-radius", new CssCategory(typeof(BORDERTOPRIGHTRADIUS), typeof(BackgroundAndBorders)) }, 
            {"border-top-style", new CssCategory(typeof(BORDERTOPSTYLE), typeof(BackgroundAndBorders)) }, 
            {"border-top-width", new CssCategory(typeof(BORDERTOPWIDTH), typeof(BackgroundAndBorders)) }, 
            {"border-width", new CssCategory(typeof(BORDERWIDTH), typeof(BackgroundAndBorders)) }, 
            {"box-decoration-break", new CssCategory(typeof(BOXDECORATIONBREAK), typeof(BackgroundAndBorders)) }, 
            {"box-shadow", new CssCategory(typeof(BOXSHADOW), typeof(BackgroundAndBorders)) }, 
            {"bottom", new CssCategory(typeof(BOTTOM), typeof(BasicBox)) }, 
            {"clear", new CssCategory(typeof(CLEAR), typeof(BasicBox)) }, 
            {"clip", new CssCategory(typeof(CLIP), typeof(BasicBox)) }, 
            {"display", new CssCategory(typeof(DISPLAY), typeof(BasicBox)) }, 
            {"float", new CssCategory(typeof(FLOATING), typeof(BasicBox)) }, 
            {"height", new CssCategory(typeof(HEIGHT), typeof(BasicBox)) }, 
            {"left", new CssCategory(typeof(LEFT), typeof(BasicBox)) }, 
            {"overflow", new CssCategory(typeof(OVERFLOW), typeof(BasicBox)) }, 
            {"overflow-x", new CssCategory(typeof(OVERFLOWX), typeof(BasicBox)) }, 
            {"overflow-y", new CssCategory(typeof(OVERFLOWY), typeof(BasicBox)) }, 
            {"padding", new CssCategory(typeof(PADDING), typeof(BasicBox)) }, 
            {"padding-bottom", new CssCategory(typeof(PADDINGBOTTOM), typeof(BasicBox)) }, 
            {"padding-left", new CssCategory(typeof(PADDINGLEFT), typeof(BasicBox)) }, 
            {"padding-right", new CssCategory(typeof(PADDINGRIGHT), typeof(BasicBox)) }, 
            {"padding-top", new CssCategory(typeof(PADDINGTOP), typeof(BasicBox)) }, 
            {"position", new CssCategory(typeof(POSITION), typeof(BasicBox)) }, 
            {"right", new CssCategory(typeof(RIGHT), typeof(BasicBox)) }, 
            {"top", new CssCategory(typeof(TOP), typeof(BasicBox)) }, 
            {"visibility", new CssCategory(typeof(VISIBILITY), typeof(BasicBox)) }, 
            {"width", new CssCategory(typeof(WIDTH), typeof(BasicBox)) }, 
            {"vertical-align", new CssCategory(typeof(VERTICALALIGN), typeof(BasicBox)) }, 
            {"z-index", new CssCategory(typeof(ZINDEX), typeof(BasicBox)) }, 
            {"align-content", new CssCategory(typeof(ALIGNCONTENT), typeof(FlexibleBox)) }, 
            {"align-items", new CssCategory(typeof(ALIGNITEMS), typeof(FlexibleBox)) }, 
            {"align-self", new CssCategory(typeof(ALIGNSELF), typeof(FlexibleBox)) }, 
            {"flex", new CssCategory(typeof(FLEX), typeof(FlexibleBox)) }, 
            {"flex-basis", new CssCategory(typeof(FLEXBASIS), typeof(FlexibleBox)) }, 
            {"flex-direction", new CssCategory(typeof(FLEXDIRECTION), typeof(FlexibleBox)) }, 
            {"flex-flow", new CssCategory(typeof(FLEXFLOW), typeof(FlexibleBox)) }, 
            {"flex-grow", new CssCategory(typeof(FLEXGROW), typeof(FlexibleBox)) }, 
            {"flex-shrink", new CssCategory(typeof(FLEXSHRINK), typeof(FlexibleBox)) }, 
            {"flex-wrap", new CssCategory(typeof(FLEXWRAP), typeof(FlexibleBox)) }, 
            {"justify-content", new CssCategory(typeof(JUSTIFYCONTENT), typeof(FlexibleBox)) }, 
            {"margin", new CssCategory(typeof(MARGIN), typeof(FlexibleBox)) }, 
            {"margin-bottom", new CssCategory(typeof(MARGINBOTTOM), typeof(FlexibleBox)) }, 
            {"margin-left", new CssCategory(typeof(MARGINLEFT), typeof(FlexibleBox)) }, 
            {"margin-right", new CssCategory(typeof(MARGINRIGHT), typeof(FlexibleBox)) }, 
            {"margin-top", new CssCategory(typeof(MARGINTOP), typeof(FlexibleBox)) }, 
            {"max-height", new CssCategory(typeof(MAXHEIGHT), typeof(FlexibleBox)) }, 
            {"max-width", new CssCategory(typeof(MAXWIDTH), typeof(FlexibleBox)) }, 
            {"min-height", new CssCategory(typeof(MINHEIGHT), typeof(FlexibleBox)) }, 
            {"min-width", new CssCategory(typeof(MINWIDTH), typeof(FlexibleBox)) }, 
            {"order", new CssCategory(typeof(ORDER), typeof(FlexibleBox)) }, 
            {"hanging-punctuation", new CssCategory(typeof(HANGINGPUNCTUATION), typeof(Text)) }, 
            {"hyphens", new CssCategory(typeof(HYPHENS), typeof(Text)) }, 
            {"letter-spacing", new CssCategory(typeof(LETTERSPACING), typeof(Text)) }, 
            {"line-break", new CssCategory(typeof(LINEBREAK), typeof(Text)) }, 
            {"line-height", new CssCategory(typeof(LINEHEIGHT), typeof(Text)) }, 
            {"overflow-wrap", new CssCategory(typeof(OVERFLOWWRAP), typeof(Text)) }, 
            {"tab-size", new CssCategory(typeof(TABSIZE), typeof(Text)) }, 
            {"text-align", new CssCategory(typeof(TEXTALIGN), typeof(Text)) }, 
            {"text-align-last", new CssCategory(typeof(TEXTALIGNLAST), typeof(Text)) }, 
            {"text-indent", new CssCategory(typeof(TEXTINDENT), typeof(Text)) }, 
            {"text-justify", new CssCategory(typeof(TEXTJUSTIFY), typeof(Text)) }, 
            {"text-transform", new CssCategory(typeof(TEXTTRANSFORM), typeof(Text)) }, 
            {"white-space", new CssCategory(typeof(WHITESPACE), typeof(Text)) }, 
            {"word-break", new CssCategory(typeof(WORDBREAK), typeof(Text)) }, 
            {"word-spacing", new CssCategory(typeof(WORDSPACING), typeof(Text)) }, 
            {"word-wrap", new CssCategory(typeof(WORDWRAP), typeof(Text)) }, 
            {"text-decoration", new CssCategory(typeof(TEXTDECORATION), typeof(TextDecoration)) }, 
            {"text-decoration-color", new CssCategory(typeof(TEXTDECORATIONCOLOR), typeof(TextDecoration)) }, 
            {"text-decoration-line", new CssCategory(typeof(TEXTDECORATIONLINE), typeof(TextDecoration)) }, 
            {"text-decoration-style", new CssCategory(typeof(TEXTDECORATIONSTYLE), typeof(TextDecoration)) }, 
            {"text-shadow", new CssCategory(typeof(TEXTSHADOW), typeof(TextDecoration)) }, 
            {"text-underline-position", new CssCategory(typeof(TEXTUNDERLINEPOSITION), typeof(TextDecoration)) }, 
            {"font", new CssCategory(typeof(FONT), typeof(Fonts)) }, 
            {"font-family", new CssCategory(typeof(FONTFAMILY), typeof(Fonts)) }, 
            {"font-feature-setting", new CssCategory(typeof(FONTFEATURESETTING), typeof(Fonts)) }, 
            {"@font-feature-values", new CssCategory(typeof(FONTFEATUREVALUES), typeof(Fonts)) }, 
            {"font-kerning", new CssCategory(typeof(FONTKERNING), typeof(Fonts)) }, 
            {"font-language-override", new CssCategory(typeof(FONTLANGUAGEOVERRIDE), typeof(Fonts)) }, 
            {"font-synthesis", new CssCategory(typeof(FONTSYNTHESIS), typeof(Fonts)) }, 
            {"font-variant-alternates", new CssCategory(typeof(FONTVARIANTALTERNATES), typeof(Fonts)) }, 
            {"font-variant-caps", new CssCategory(typeof(FONTVARIANTCAPS), typeof(Fonts)) }, 
            {"font-variant-east-asian", new CssCategory(typeof(FONTVARIANTEASTASIAN), typeof(Fonts)) }, 
            {"font-variant-ligatures", new CssCategory(typeof(FONTVARIANTLIGATURES), typeof(Fonts)) }, 
            {"font-variant-numeric", new CssCategory(typeof(FONTVARIANTNUMERIC), typeof(Fonts)) }, 
            {"font-variant-position", new CssCategory(typeof(FONTVARIANTPOSITION), typeof(Fonts)) }, 
            {"font-size", new CssCategory(typeof(FONTSIZE), typeof(Fonts)) }, 
            {"font-style", new CssCategory(typeof(FONTSTYLE), typeof(Fonts)) }, 
            {"font-variant", new CssCategory(typeof(FONTVARIANT), typeof(Fonts)) }, 
            {"font-weight", new CssCategory(typeof(FONTWEIGHT), typeof(Fonts)) }, 
            {"@font-face", new CssCategory(typeof(FONTFACE), typeof(Fonts)) }, 
            {"font-size-adjust", new CssCategory(typeof(FONTSIZEADJUST), typeof(Fonts)) }, 
            {"font-stretch", new CssCategory(typeof(FONTSTRETCH), typeof(Fonts)) }, 
            {"direction", new CssCategory(typeof(DIRECTION), typeof(WritingModes)) }, 
            {"text-orientation", new CssCategory(typeof(TEXTORIENTATION), typeof(WritingModes)) }, 
            {"text-combine-horizontal", new CssCategory(typeof(TEXTCOMBINEHORIZONTAL), typeof(WritingModes)) }, 
            {"unicode-bidi", new CssCategory(typeof(UNICODEBIDI), typeof(WritingModes)) }, 
            {"writing-mode", new CssCategory(typeof(WRITINGMODE), typeof(WritingModes)) }, 
            {"border-collapse", new CssCategory(typeof(BORDERCOLLAPSE), typeof(Table)) }, 
            {"border-spacing", new CssCategory(typeof(BORDERSPACING), typeof(Table)) }, 
            {"caption-side", new CssCategory(typeof(CAPTIONSIDE), typeof(Table)) }, 
            {"empty-cells", new CssCategory(typeof(EMPTYCELLS), typeof(Table)) }, 
            {"table-layout", new CssCategory(typeof(TABLELAYOUT), typeof(Table)) }, 
            {"counter-increment", new CssCategory(typeof(COUNTERINCREMENT), typeof(ListAndCounters)) }, 
            {"counter-reset", new CssCategory(typeof(COUNTERRESET), typeof(ListAndCounters)) }, 
            {"list-style", new CssCategory(typeof(LISTSTYLE), typeof(ListAndCounters)) }, 
            {"list-style-image", new CssCategory(typeof(LISTSTYLEIMAGE), typeof(ListAndCounters)) }, 
            {"list-style-position", new CssCategory(typeof(LISTSTYLEPOSITION), typeof(ListAndCounters)) }, 
            {"list-style-type", new CssCategory(typeof(LISTSTYLETYPE), typeof(ListAndCounters)) }, 
            {"@keyframes", new CssCategory(typeof(KEYFRAMES), typeof(Animation)) }, 
            {"animation", new CssCategory(typeof(ANIMATION), typeof(Animation)) }, 
            {"animation-delay", new CssCategory(typeof(ANIMATIONDELAY), typeof(Animation)) }, 
            {"animation-direction", new CssCategory(typeof(ANIMATIONDIRECTION), typeof(Animation)) }, 
            {"animation-duration", new CssCategory(typeof(ANIMATIONDURATION), typeof(Animation)) }, 
            {"animation-fill-mode", new CssCategory(typeof(ANIMATIONFILLMODE), typeof(Animation)) }, 
            {"animation-iteration-count", new CssCategory(typeof(ANIMATIONITERATIONCOUNT), typeof(Animation)) }, 
            {"animation-name", new CssCategory(typeof(ANIMATIONNAME), typeof(Animation)) }, 
            {"animation-timing-function", new CssCategory(typeof(ANIMATIONTIMINGFUNCTION), typeof(Animation)) }, 
            {"animation-play-state", new CssCategory(typeof(ANIMATIONPLAYSTATE), typeof(Animation)) }, 
            {"backface-visibility", new CssCategory(typeof(BACKFACEVISIBILITY), typeof( Transform )) }, 
            {"perspective", new CssCategory(typeof(PERSPECTIVE), typeof( Transform )) }, 
            {"perspective-origin", new CssCategory(typeof(PERSPECTIVEORIGIN), typeof( Transform )) }, 
            {"transform", new CssCategory(typeof(TRANSFORM), typeof( Transform )) }, 
            {"transform-origin", new CssCategory(typeof(TRANSFORMORIGIN), typeof( Transform )) }, 
            {"transform-style", new CssCategory(typeof(TRANSFORMSTYLE), typeof( Transform )) }, 
            {"transition", new CssCategory(typeof(TRANSITION), typeof( Transition )) }, 
            {"transition-property", new CssCategory(typeof(TRANSITIONPROPERTY), typeof( Transition )) }, 
            {"transition-duration", new CssCategory(typeof(TRANSITIONDURATION), typeof( Transition )) }, 
            {"transition-timing-function", new CssCategory(typeof(TRANSITIONTIMINGFUNCTION), typeof( Transition )) }, 
            {"transition-delay", new CssCategory(typeof(TRANSITIONDELAY), typeof( Transition )) }, 
            {"box-sizing", new CssCategory(typeof(BOXSIZING), typeof( BasicUserInterface )) }, 
            {"content", new CssCategory(typeof(CONTENT), typeof( BasicUserInterface )) }, 
            {"cursor", new CssCategory(typeof(CURSOR), typeof( BasicUserInterface )) }, 
            {"icon", new CssCategory(typeof(ICON), typeof( BasicUserInterface )) }, 
            {"ime-mode", new CssCategory(typeof(IMEMODE), typeof( BasicUserInterface )) }, 
            {"nav-down", new CssCategory(typeof(NAVDOWN), typeof( BasicUserInterface )) }, 
            {"nav-index", new CssCategory(typeof(NAVINDEX), typeof( BasicUserInterface )) }, 
            {"nav-left", new CssCategory(typeof(NAVLEFT), typeof( BasicUserInterface )) }, 
            {"nav-right", new CssCategory(typeof(NAVRIGHT), typeof( BasicUserInterface )) }, 
            {"nav-up", new CssCategory(typeof(NAVUP), typeof( BasicUserInterface )) }, 
            {"outline", new CssCategory(typeof(OUTLINE), typeof( BasicUserInterface )) }, 
            {"outline-color", new CssCategory(typeof(OUTLINECOLOR), typeof( BasicUserInterface )) }, 
            {"outline-offset", new CssCategory(typeof(OUTLINEOFFSET), typeof( BasicUserInterface )) }, 
            {"outline-style", new CssCategory(typeof(OUTLINESTYLE), typeof( BasicUserInterface )) }, 
            {"outline-width", new CssCategory(typeof(OUTLINEWIDTH), typeof( BasicUserInterface )) }, 
            {"resize", new CssCategory(typeof(RESIZE), typeof( BasicUserInterface )) }, 
            {"text-overflow", new CssCategory(typeof(TEXTOVERFLOW), typeof( BasicUserInterface )) }, 
            {"break-after", new CssCategory(typeof(BREAKAFTER), typeof( MultiColumn )) }, 
            {"break-before", new CssCategory(typeof(BREAKBEFORE), typeof( MultiColumn )) }, 
            {"break-inside", new CssCategory(typeof(BREAKINSIDE), typeof( MultiColumn )) }, 
            {"column-count", new CssCategory(typeof(COLUMNCOUNT), typeof( MultiColumn )) }, 
            {"column-fill", new CssCategory(typeof(COLUMNFILL), typeof( MultiColumn )) }, 
            {"column-gap", new CssCategory(typeof(COLUMNGAP), typeof( MultiColumn )) }, 
            {"column-rule", new CssCategory(typeof(COLUMNRULE), typeof( MultiColumn )) }, 
            {"column-rule-color", new CssCategory(typeof(COLUMNRULECOLOR), typeof( MultiColumn )) }, 
            {"column-rule-style", new CssCategory(typeof(COLUMNRULESTYLE), typeof( MultiColumn )) }, 
            {"column-rule-width", new CssCategory(typeof(COLUMNRULEWIDTH), typeof( MultiColumn )) }, 
            {"column-span", new CssCategory(typeof(COLUMNSPAN), typeof( MultiColumn )) }, 
            {"column-width", new CssCategory(typeof(COLUMNWIDTH), typeof( MultiColumn )) }, 
            {"columns", new CssCategory(typeof(COLUMNS), typeof( MultiColumn )) }, 
            {"widows", new CssCategory(typeof(WIDOWS), typeof( MultiColumn )) }, 
            {"orphans", new CssCategory(typeof(ORPHANS), typeof( PagedMedia )) }, 
            {"page-break-after", new CssCategory(typeof(PAGEBREAKAFTER), typeof( PagedMedia )) }, 
            {"page-break-before", new CssCategory(typeof(PAGEBREAKBEFORE), typeof( PagedMedia )) }, 
            {"page-break-inside", new CssCategory(typeof(PAGEBREAKINSIDE), typeof( PagedMedia )) }, 
            {"marks", new CssCategory(typeof(MARKS), typeof( GeneratedContent )) }, 
            {"quotes", new CssCategory(typeof(QUOTES), typeof( GeneratedContent )) }, 
            {"filter", new CssCategory(typeof(FILTER), typeof(FilterEffects)) }, 
            {"image-orientation", new CssCategory(typeof(IMAGEORIENTATION), typeof( ImageReplacedContent )) }, 
            {"image-rendering", new CssCategory(typeof(IMAGERENDERING), typeof( ImageReplacedContent )) }, 
            {"image-resolution", new CssCategory(typeof(IMAGERESOLUTION), typeof( ImageReplacedContent )) }, 
            {"object-fit", new CssCategory(typeof(OBJECTFIT), typeof( ImageReplacedContent )) }, 
            {"object-position", new CssCategory(typeof(OBJECTPOSITION), typeof( ImageReplacedContent )) }, 
            {"mask", new CssCategory(typeof(MASK), typeof( Masking )) }, 
            {"mask-type", new CssCategory(typeof(MASKTYPE), typeof( Masking )) }, 
            {"mark", new CssCategory(typeof(MARK), typeof( Speech )) }, 
            {"mark-after", new CssCategory(typeof(MARKAFTER), typeof( Speech )) }, 
            {"mark-before", new CssCategory(typeof(MARKBEFORE), typeof( Speech )) }, 
            {"phonemes", new CssCategory(typeof(PHONEMES), typeof( Speech )) }, 
            {"rest", new CssCategory(typeof(REST), typeof( Speech )) }, 
            {"rest-after", new CssCategory(typeof(RESTAFTER), typeof( Speech )) }, 
            {"rest-before", new CssCategory(typeof(RESTBEFORE), typeof( Speech )) }, 
            {"voice-balance", new CssCategory(typeof(VOICEBALANCE), typeof( Speech )) }, 
            {"voice-duration", new CssCategory(typeof(VOICEDURATION), typeof( Speech )) }, 
            {"voice-pitch", new CssCategory(typeof(VOICEPITCH), typeof( Speech )) }, 
            {"voice-pitch-range", new CssCategory(typeof(VOICEPITCHRANGE), typeof( Speech )) }, 
            {"voice-rate", new CssCategory(typeof(VOICERATE), typeof( Speech )) }, 
            {"voice-stress", new CssCategory(typeof(VOICESTRESS), typeof( Speech )) }, 
            {"voice-volume", new CssCategory(typeof(VOICEVOLUME), typeof( Speech )) }, 
            {"marquee-direction", new CssCategory(typeof(MARQUEEDIRECTION), typeof( Marquee )) }, 
            {"marquee-play-count", new CssCategory(typeof(MARQUEEPLAYCOUNT), typeof( Marquee )) }, 
            {"marquee-speed", new CssCategory(typeof(MARQUEESPEED), typeof( Marquee )) }, 
            {"marquee-style", new CssCategory(typeof(MARQUEESTYLE), typeof( Marquee )) }
        };

        public static CssCategory GetStringToCssCategory(string cssStringKey)
        {
            if (StringToCssCategory.Keys.Contains(cssStringKey))
            {
                return StringToCssCategory[cssStringKey];
            }

            return null;
        }

        public static Color decodeColorString(string colorString)
        {
            Color returnValue = new Color();
            if (colorString[0] == '#')
            {
                colorString = colorString.Replace("#", "");
                //Hex color value
                int hexValue = 0;
                if (int.TryParse(colorString, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out hexValue))
                {
                    returnValue = Color.FromArgb(hexValue);
                }
            }
            else if (colorString.Contains("rgb"))
            {
                int[] numbers = extractColorNumbers(colorString, "rgb", "");
                if (numbers.Count() == 3)
                {
                    returnValue = Color.FromArgb(numbers[0], numbers[1], numbers[2]);
                }
                else
                {
                    returnValue = Color.FromArgb(numbers[0], numbers[1], numbers[2], numbers[3]);
                }
            }
            else if (colorString.Contains("hsl"))
            {
                int[] numbers = extractColorNumbers(colorString, "rgb", "");
                if (numbers.Count() == 3)
                {
                    returnValue = Color.FromArgb(numbers[0], numbers[1], numbers[2]);
                }
                else
                {
                    returnValue = Color.FromArgb(numbers[0], numbers[1], numbers[2], numbers[3]);
                }
            }
            else
            {
                try
                {
                    returnValue = Color.FromName(colorString);
                }
                catch (System.Exception ex)
                {
                    Debug.Write(ex.Message);
                }
                returnValue = new Color();
            }

            return returnValue;
        }

        public static int decodePositionString(string positionStr)
        {
            return 0;
        }

        private static int decodeIntFromString(string numberString)
        {
            int returnValue = 0;

            int.TryParse(numberString, out returnValue);

            return returnValue;
        }

        private static int[] extractColorNumbers(string str, string replaceString, string additionalRemovalStrings)
        {
            str = str.Replace(replaceString, "");
            if (str.Contains("a"))
            {
                str = str.Replace("a", "");
            }

            str = str.Replace("(", "");
            str = str.Replace(")", "");
            if (additionalRemovalStrings != "")
            {
                str = str.Replace(additionalRemovalStrings, "");
            }

            char[] spiltChars = { ',' };
            string[] tokens = str.Split(spiltChars, StringSplitOptions.RemoveEmptyEntries);

            int[] numbers = new int[tokens.Count()];
            for (int counter = 0; counter < tokens.Count(); ++counter)
            {
                float value = 0.0f;
                if (float.TryParse(tokens[counter], out value))
                {
                    if (counter < 3)
                    {
                        numbers[counter] = (int)value;
                    }
                    else
                    {
                        numbers[counter] = (int)(value * 255);
                    }
                }
                else
                {
                    numbers[counter] = 0;
                }
            }
            return numbers;
        }
    }
}

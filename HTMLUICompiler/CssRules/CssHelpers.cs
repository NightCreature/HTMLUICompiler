﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HTMLUICompiler.CssRuleGroups
{
    public class CssHelpers
    {
        public enum CssRuleGroups
        {
            COLOR,
            BACKGROUNDANDBORDERS,
            BASICBOX,
            FLEXIBLEBOX,
            TEXT,
            TEXTDECORATION,
            FONTS,
            WRITINGMODES,
            TABLE,
            LISTSANDCOUNTERS,
            ANIMATION,
            TRANSFORM,
            TRANSITION,
            BASICUSERINTERFACE,
            MULTICOLUMN,
            PAGEDMEDIA,
            GENERATEDCONTENT,
            FILTEREFFECTS,
            IMAGEREPLACEDCONTENT,
            MASKING,
            SPEECH,
            MARQUEE
        };

        public enum CssRuleTokens
        {
            COLOR,
            OPACITY,
            BACKGROUND,
            BACKGROUNDATTACHMENT,
            BACKGROUNDCOLOR,
            BACKGROUNDIMAGE,
            BACKGROUNDPOSITION,
            BACKGROUNDREPEAT,
            BACKGROUNDCLIP,
            BACKGROUNDORIGIN,
            BACKGROUNDSIZE,
            BORDER,
            BORDERBOTTOM,
            BORDERBOTTOMCOLOR,
            BORDERBOTTOMLEFTRADIUS,
            BORDERBOTTOMRIGHTRADIUS,
            BORDERBOTTOMSTYLE,
            BORDERBOTTOMWIDTH,
            BORDERCOLOR,
            BORDERIMAGE,
            BORDERIMAGEOUTSET,
            BORDERIMAGEREPEAT,
            BORDERIMAGESLICE,
            BORDERIMAGESOURCE,
            BORDERIMAGEWIDTH,
            BORDERLEFT,
            BORDERLEFTCOLOR,
            BORDERLEFTSTYLE,
            BORDERLEFTWIDTH,
            BORDERRADIUS,
            BORDERRIGHT,
            BORDERRIGHTCOLOR,
            BORDERRIGHTSTYLE,
            BORDERRIGHTWIDTH,
            BORDERSTYLE,
            BORDERTOP,
            BORDERTOPCOLOR,
            BORDERTOPLEFTRADIUS,
            BORDERTOPRIGHTRADIUS,
            BORDERTOPSTYLE,
            BORDERTOPWIDTH,
            BORDERWIDTH,
            BOXDECORATIONBREAK,
            BOXSHADOW,
            BOTTOM,
            CLEAR,
            CLIP,
            FLOATING,
            HEIGHT,
            LEFT,
            OVERFLOW,
            OVERFLOWX,
            OVERFLOWY,
            PADDING,
            PADDINGBOTTOM,
            PADDINGLEFT,
            PADDINGRIGHT,
            PADDINGTOP,
            POSITION,
            RIGHT,
            TOP,
            VISIBILITY,
            WIDTH,
            VERTICALALIGN,
            ZINDEX,
            ALIGNCONTENT,
            ALIGNITEMS,
            ALIGNSELF,
            DISPLAY,
            FLEX,
            FLEXBASIS,
            FLEXDIRECTION,
            FLEXFLOW,
            FLEXGROW,
            FLEXSHRINK,
            FLEXWRAP,
            JUSTIFYCONTENT,
            MARGIN,
            MARGINBOTTOM,
            MARGINLEFT,
            MARGINRIGHT,
            MARGINTOP,
            MAXHEIGHT,
            MAXWIDTH,
            MINHEIGHT,
            MINWIDTH,
            ORDER,
            HANGINGPUNCTUATION,
            HYPHENS,
            LETTERSPACING,
            LINEBREAK,
            LINEHEIGHT,
            OVERFLOWWRAP,
            TABSIZE,
            TEXTALIGN,
            TEXTALIGNLAST,
            TEXTINDENT,
            TEXTJUSTIFY,
            TEXTTRANSFORM,
            WHITESPACE,
            WORDBREAK,
            WORDSPACING,
            WORDWRAP,
            TEXTDECORATION,
            TEXTDECORATIONCOLOR,
            TEXTDECORATIONLINE,
            TEXTDECORATIONSTYLE,
            TEXTSHADOW,
            TEXTUNDERLINEPOSITION,
            FONT,
            FONTFAMILY,
            FONTFEATURESETTING,
            FONTFEATUREVALUES,
            FONTKERNING,
            FONTLANGUAGEOVERRIDE,
            FONTSYNTHESIS,
            FONTVARIANTALTERNATES,
            FONTVARIANTCAPS,
            FONTVARIANTEASTASIAN,
            FONTVARIANTLIGATURES,
            FONTVARIANTNUMERIC,
            FONTVARIANTPOSITION,
            FONTSIZE,
            FONTSTYLE,
            FONTVARIANT,
            FONTWEIGHT,
            FONTFACE,
            FONTSIZEADJUST,
            FONTSTRETCH,
            DIRECTION,
            TEXTORIENTATION,
            TEXTCOMBINEHORIZONTAL,
            UNICODEBIDI,
            WRITINGMODE,
            BORDERCOLLAPSE,
            BORDERSPACING,
            CAPTIONSIDE,
            EMPTYCELLS,
            TABLELAYOUT,
            COUNTERINCREMENT,
            COUNTERRESET,
            LISTSTYLE,
            LISTSTYLEIMAGE,
            LISTSTYLEPOSITION,
            LISTSTYLETYPE,
            KEYFRAMES,
            ANIMATION,
            ANIMATIONDELAY,
            ANIMATIONDIRECTION,
            ANIMATIONDURATION,
            ANIMATIONFILLMODE,
            ANIMATIONITERATIONCOUNT,
            ANIMATIONNAME,
            ANIMATIONTIMINGFUNCTION,
            ANIMATIONPLAYSTATE,
            BACKFACEVISIBILITY,
            PERSPECTIVE,
            PERSPECTIVEORIGIN,
            TRANSFORM,
            TRANSFORMORIGIN,
            TRANSFORMSTYLE,
            TRANSITIONPROPERTY,
            TRANSITION,
            TRANSITIONDURATION,
            TRANSITIONTIMINGFUNCTION,
            TRANSITIONDELAY,
            BOXSIZING,
            CONTENT,
            CURSOR,
            ICON,
            IMEMODE,
            NAVDOWN,
            NAVINDEX,
            NAVLEFT,
            NAVRIGHT,
            NAVUP,
            OUTLINE,
            OUTLINECOLOR,
            OUTLINEOFFSET,
            OUTLINESTYLE,
            OUTLINEWIDTH,
            RESIZE,
            TEXTOVERFLOW,
            BREAKAFTER,
            BREAKBEFORE,
            BREAKINSIDE,
            COLUMNCOUNT,
            COLUMNFILL,
            COLUMNGAP,
            COLUMNRULE,
            COLUMNRULECOLOR,
            COLUMNRULESTYLE,
            COLUMNRULEWIDTH,
            COLUMNSPAN,
            COLUMNWIDTH,
            COLUMNS,
            WIDOWS,
            ORPHANS,
            PAGEBREAKAFTER,
            PAGEBREAKBEFORE,
            PAGEBREAKINSIDE,
            MARKS,
            QUOTES,
            FILTER,
            IMAGEORIENTATION,
            IMAGERENDERING,
            IMAGERESOLUTION,
            OBJECTFIT,
            OBJECTPOSITION,
            MASK,
            MASKTYPE,
            MARK,
            MARKAFTER,
            MARKBEFORE,
            PHONEMES,
            REST,
            RESTAFTER,
            RESTBEFORE,
            VOICEBALANCE,
            VOICEDURATION,
            VOICEPITCH,
            VOICEPITCHRANGE,
            VOICERATE,
            VOICESTRESS,
            VOICEVOLUME,
            MARQUEEDIRECTION,
            MARQUEEPLAYCOUNT,
            MARQUEESPEED,
            MARQUEESTYLE
        };

        public class CssCategory
        {
            public CssCategory(CssRuleTokens cssToken, CssRuleGroups cssGroup)
            {
                m_cssToken = cssToken;
                m_cssGroup = cssGroup;
            }
            public CssRuleTokens m_cssToken;
            public CssRuleGroups m_cssGroup;
        }

        public static Dictionary<string, CssCategory> StringToCssCategory = new Dictionary<string, CssCategory>()
        {
            {"color", new CssCategory(CssRuleTokens.COLOR, CssRuleGroups.COLOR) }, 
            {"opacity", new CssCategory(CssRuleTokens.OPACITY, CssRuleGroups.COLOR) }, 
            {"background", new CssCategory(CssRuleTokens.BACKGROUND, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"background-attachment", new CssCategory(CssRuleTokens.BACKGROUNDATTACHMENT, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"background-color", new CssCategory(CssRuleTokens.BACKGROUNDCOLOR, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"background-image", new CssCategory(CssRuleTokens.BACKGROUNDIMAGE, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"background-position", new CssCategory(CssRuleTokens.BACKGROUNDPOSITION, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"background-repeat", new CssCategory(CssRuleTokens.BACKGROUNDREPEAT, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"background-clip", new CssCategory(CssRuleTokens.BACKGROUNDCLIP, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"background-origin", new CssCategory(CssRuleTokens.BACKGROUNDORIGIN, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"background-size", new CssCategory(CssRuleTokens.BACKGROUNDSIZE, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"border", new CssCategory(CssRuleTokens.BORDER, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"border-bottom", new CssCategory(CssRuleTokens.BORDERBOTTOM, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"border-bottom-color", new CssCategory(CssRuleTokens.BORDERBOTTOMCOLOR, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"border-bottom-left-radius", new CssCategory(CssRuleTokens.BORDERBOTTOMLEFTRADIUS, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"border-bottom-right-radius", new CssCategory(CssRuleTokens.BORDERBOTTOMRIGHTRADIUS, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"border-bottom-style", new CssCategory(CssRuleTokens.BORDERBOTTOMSTYLE, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"border-bottom-width", new CssCategory(CssRuleTokens.BORDERBOTTOMWIDTH, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"border-color", new CssCategory(CssRuleTokens.BORDERCOLOR, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"border-image", new CssCategory(CssRuleTokens.BORDERIMAGE, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"border-image-outset", new CssCategory(CssRuleTokens.BORDERIMAGEOUTSET, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"border-image-repeat", new CssCategory(CssRuleTokens.BORDERIMAGEREPEAT, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"border-image-slice", new CssCategory(CssRuleTokens.BORDERIMAGESLICE, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"border-image-source", new CssCategory(CssRuleTokens.BORDERIMAGESOURCE, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"border-image-width", new CssCategory(CssRuleTokens.BORDERIMAGEWIDTH, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"border-left", new CssCategory(CssRuleTokens.BORDERLEFT, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"border-left-color", new CssCategory(CssRuleTokens.BORDERLEFTCOLOR, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"border-left-style", new CssCategory(CssRuleTokens.BORDERLEFTSTYLE, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"border-left-width", new CssCategory(CssRuleTokens.BORDERLEFTWIDTH, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"border-radius", new CssCategory(CssRuleTokens.BORDERRADIUS, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"border-right", new CssCategory(CssRuleTokens.BORDERRIGHT, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"border-right-color", new CssCategory(CssRuleTokens.BORDERRIGHTCOLOR, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"border-right-style", new CssCategory(CssRuleTokens.BORDERRIGHTSTYLE, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"border-right-width", new CssCategory(CssRuleTokens.BORDERRIGHTWIDTH, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"border-style", new CssCategory(CssRuleTokens.BORDERSTYLE, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"border-top", new CssCategory(CssRuleTokens.BORDERTOP, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"border-top-color", new CssCategory(CssRuleTokens.BORDERTOPCOLOR, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"border-top-left-radius", new CssCategory(CssRuleTokens.BORDERTOPLEFTRADIUS, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"border-top-right-radius", new CssCategory(CssRuleTokens.BORDERTOPRIGHTRADIUS, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"border-top-style", new CssCategory(CssRuleTokens.BORDERTOPSTYLE, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"border-top-width", new CssCategory(CssRuleTokens.BORDERTOPWIDTH, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"border-width", new CssCategory(CssRuleTokens.BORDERWIDTH, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"box-decoration-break", new CssCategory(CssRuleTokens.BOXDECORATIONBREAK, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"box-shadow", new CssCategory(CssRuleTokens.BOXSHADOW, CssRuleGroups.BACKGROUNDANDBORDERS) }, 
            {"bottom", new CssCategory(CssRuleTokens.BOTTOM, CssRuleGroups.BASICBOX) }, 
            {"clear", new CssCategory(CssRuleTokens.CLEAR, CssRuleGroups.BASICBOX) }, 
            {"clip", new CssCategory(CssRuleTokens.CLIP, CssRuleGroups.BASICBOX) }, 
            {"display", new CssCategory(CssRuleTokens.DISPLAY, CssRuleGroups.BASICBOX) }, 
            {"float", new CssCategory(CssRuleTokens.FLOATING, CssRuleGroups.BASICBOX) }, 
            {"height", new CssCategory(CssRuleTokens.HEIGHT, CssRuleGroups.BASICBOX) }, 
            {"left", new CssCategory(CssRuleTokens.LEFT, CssRuleGroups.BASICBOX) }, 
            {"overflow", new CssCategory(CssRuleTokens.OVERFLOW, CssRuleGroups.BASICBOX) }, 
            {"overflow-x", new CssCategory(CssRuleTokens.OVERFLOWX, CssRuleGroups.BASICBOX) }, 
            {"overflow-y", new CssCategory(CssRuleTokens.OVERFLOWY, CssRuleGroups.BASICBOX) }, 
            {"padding", new CssCategory(CssRuleTokens.PADDING, CssRuleGroups.BASICBOX) }, 
            {"padding-bottom", new CssCategory(CssRuleTokens.PADDINGBOTTOM, CssRuleGroups.BASICBOX) }, 
            {"padding-left", new CssCategory(CssRuleTokens.PADDINGLEFT, CssRuleGroups.BASICBOX) }, 
            {"padding-right", new CssCategory(CssRuleTokens.PADDINGRIGHT, CssRuleGroups.BASICBOX) }, 
            {"padding-top", new CssCategory(CssRuleTokens.PADDINGTOP, CssRuleGroups.BASICBOX) }, 
            {"position", new CssCategory(CssRuleTokens.POSITION, CssRuleGroups.BASICBOX) }, 
            {"right", new CssCategory(CssRuleTokens.RIGHT, CssRuleGroups.BASICBOX) }, 
            {"top", new CssCategory(CssRuleTokens.TOP, CssRuleGroups.BASICBOX) }, 
            {"visibility", new CssCategory(CssRuleTokens.VISIBILITY, CssRuleGroups.BASICBOX) }, 
            {"width", new CssCategory(CssRuleTokens.WIDTH, CssRuleGroups.BASICBOX) }, 
            {"vertical-align", new CssCategory(CssRuleTokens.VERTICALALIGN, CssRuleGroups.BASICBOX) }, 
            {"z-index", new CssCategory(CssRuleTokens.ZINDEX, CssRuleGroups.BASICBOX) }, 
            {"align-content", new CssCategory(CssRuleTokens.ALIGNCONTENT, CssRuleGroups.FLEXIBLEBOX) }, 
            {"align-items", new CssCategory(CssRuleTokens.ALIGNITEMS, CssRuleGroups.FLEXIBLEBOX) }, 
            {"align-self", new CssCategory(CssRuleTokens.ALIGNSELF, CssRuleGroups.FLEXIBLEBOX) }, 
            {"flex", new CssCategory(CssRuleTokens.FLEX, CssRuleGroups.FLEXIBLEBOX) }, 
            {"flex-basis", new CssCategory(CssRuleTokens.FLEXBASIS, CssRuleGroups.FLEXIBLEBOX) }, 
            {"flex-direction", new CssCategory(CssRuleTokens.FLEXDIRECTION, CssRuleGroups.FLEXIBLEBOX) }, 
            {"flex-flow", new CssCategory(CssRuleTokens.FLEXFLOW, CssRuleGroups.FLEXIBLEBOX) }, 
            {"flex-grow", new CssCategory(CssRuleTokens.FLEXGROW, CssRuleGroups.FLEXIBLEBOX) }, 
            {"flex-shrink", new CssCategory(CssRuleTokens.FLEXSHRINK, CssRuleGroups.FLEXIBLEBOX) }, 
            {"flex-wrap", new CssCategory(CssRuleTokens.FLEXWRAP, CssRuleGroups.FLEXIBLEBOX) }, 
            {"justify-content", new CssCategory(CssRuleTokens.JUSTIFYCONTENT, CssRuleGroups.FLEXIBLEBOX) }, 
            {"margin", new CssCategory(CssRuleTokens.MARGIN, CssRuleGroups.FLEXIBLEBOX) }, 
            {"margin-bottom", new CssCategory(CssRuleTokens.MARGINBOTTOM, CssRuleGroups.FLEXIBLEBOX) }, 
            {"margin-left", new CssCategory(CssRuleTokens.MARGINLEFT, CssRuleGroups.FLEXIBLEBOX) }, 
            {"margin-right", new CssCategory(CssRuleTokens.MARGINRIGHT, CssRuleGroups.FLEXIBLEBOX) }, 
            {"margin-top", new CssCategory(CssRuleTokens.MARGINTOP, CssRuleGroups.FLEXIBLEBOX) }, 
            {"max-height", new CssCategory(CssRuleTokens.MAXHEIGHT, CssRuleGroups.FLEXIBLEBOX) }, 
            {"max-width", new CssCategory(CssRuleTokens.MAXWIDTH, CssRuleGroups.FLEXIBLEBOX) }, 
            {"min-height", new CssCategory(CssRuleTokens.MINHEIGHT, CssRuleGroups.FLEXIBLEBOX) }, 
            {"min-width", new CssCategory(CssRuleTokens.MINWIDTH, CssRuleGroups.FLEXIBLEBOX) }, 
            {"order", new CssCategory(CssRuleTokens.ORDER, CssRuleGroups.FLEXIBLEBOX) }, 
            {"hanging-punctuation", new CssCategory(CssRuleTokens.HANGINGPUNCTUATION, CssRuleGroups.TEXT) }, 
            {"hyphens", new CssCategory(CssRuleTokens.HYPHENS, CssRuleGroups.TEXT) }, 
            {"letter-spacing", new CssCategory(CssRuleTokens.LETTERSPACING, CssRuleGroups.TEXT) }, 
            {"line-break", new CssCategory(CssRuleTokens.LINEBREAK, CssRuleGroups.TEXT) }, 
            {"line-height", new CssCategory(CssRuleTokens.LINEHEIGHT, CssRuleGroups.TEXT) }, 
            {"overflow-wrap", new CssCategory(CssRuleTokens.OVERFLOWWRAP, CssRuleGroups.TEXT) }, 
            {"tab-size", new CssCategory(CssRuleTokens.TABSIZE, CssRuleGroups.TEXT) }, 
            {"text-align", new CssCategory(CssRuleTokens.TEXTALIGN, CssRuleGroups.TEXT) }, 
            {"text-align-last", new CssCategory(CssRuleTokens.TEXTALIGNLAST, CssRuleGroups.TEXT) }, 
            {"text-indent", new CssCategory(CssRuleTokens.TEXTINDENT, CssRuleGroups.TEXT) }, 
            {"text-justify", new CssCategory(CssRuleTokens.TEXTJUSTIFY, CssRuleGroups.TEXT) }, 
            {"text-transform", new CssCategory(CssRuleTokens.TEXTTRANSFORM, CssRuleGroups.TEXT) }, 
            {"white-space", new CssCategory(CssRuleTokens.WHITESPACE, CssRuleGroups.TEXT) }, 
            {"word-break", new CssCategory(CssRuleTokens.WORDBREAK, CssRuleGroups.TEXT) }, 
            {"word-spacing", new CssCategory(CssRuleTokens.WORDSPACING, CssRuleGroups.TEXT) }, 
            {"word-wrap", new CssCategory(CssRuleTokens.WORDWRAP, CssRuleGroups.TEXT) }, 
            {"text-decoration", new CssCategory(CssRuleTokens.TEXTDECORATION, CssRuleGroups.TEXTDECORATION) }, 
            {"text-decoration-color", new CssCategory(CssRuleTokens.TEXTDECORATIONCOLOR, CssRuleGroups.TEXTDECORATION) }, 
            {"text-decoration-line", new CssCategory(CssRuleTokens.TEXTDECORATIONLINE, CssRuleGroups.TEXTDECORATION) }, 
            {"text-decoration-style", new CssCategory(CssRuleTokens.TEXTDECORATIONSTYLE, CssRuleGroups.TEXTDECORATION) }, 
            {"text-shadow", new CssCategory(CssRuleTokens.TEXTSHADOW, CssRuleGroups.TEXTDECORATION) }, 
            {"text-underline-position", new CssCategory(CssRuleTokens.TEXTUNDERLINEPOSITION, CssRuleGroups.TEXTDECORATION) }, 
            {"font", new CssCategory(CssRuleTokens.FONT, CssRuleGroups.FONTS) }, 
            {"font-family", new CssCategory(CssRuleTokens.FONTFAMILY, CssRuleGroups.FONTS) }, 
            {"font-feature-setting", new CssCategory(CssRuleTokens.FONTFEATURESETTING, CssRuleGroups.FONTS) }, 
            {"@font-feature-values", new CssCategory(CssRuleTokens.FONTFEATUREVALUES, CssRuleGroups.FONTS) }, 
            {"font-kerning", new CssCategory(CssRuleTokens.FONTKERNING, CssRuleGroups.FONTS) }, 
            {"font-language-override", new CssCategory(CssRuleTokens.FONTLANGUAGEOVERRIDE, CssRuleGroups.FONTS) }, 
            {"font-synthesis", new CssCategory(CssRuleTokens.FONTSYNTHESIS, CssRuleGroups.FONTS) }, 
            {"font-variant-alternates", new CssCategory(CssRuleTokens.FONTVARIANTALTERNATES, CssRuleGroups.FONTS) }, 
            {"font-variant-caps", new CssCategory(CssRuleTokens.FONTVARIANTCAPS, CssRuleGroups.FONTS) }, 
            {"font-variant-east-asian", new CssCategory(CssRuleTokens.FONTVARIANTEASTASIAN, CssRuleGroups.FONTS) }, 
            {"font-variant-ligatures", new CssCategory(CssRuleTokens.FONTVARIANTLIGATURES, CssRuleGroups.FONTS) }, 
            {"font-variant-numeric", new CssCategory(CssRuleTokens.FONTVARIANTNUMERIC, CssRuleGroups.FONTS) }, 
            {"font-variant-position", new CssCategory(CssRuleTokens.FONTVARIANTPOSITION, CssRuleGroups.FONTS) }, 
            {"font-size", new CssCategory(CssRuleTokens.FONTSIZE, CssRuleGroups.FONTS) }, 
            {"font-style", new CssCategory(CssRuleTokens.FONTSTYLE, CssRuleGroups.FONTS) }, 
            {"font-variant", new CssCategory(CssRuleTokens.FONTVARIANT, CssRuleGroups.FONTS) }, 
            {"font-weight", new CssCategory(CssRuleTokens.FONTWEIGHT, CssRuleGroups.FONTS) }, 
            {"@font-face", new CssCategory(CssRuleTokens.FONTFACE, CssRuleGroups.FONTS) }, 
            {"font-size-adjust", new CssCategory(CssRuleTokens.FONTSIZEADJUST, CssRuleGroups.FONTS) }, 
            {"font-stretch", new CssCategory(CssRuleTokens.FONTSTRETCH, CssRuleGroups.FONTS) }, 
            {"direction", new CssCategory(CssRuleTokens.DIRECTION, CssRuleGroups.WRITINGMODES) }, 
            {"text-orientation", new CssCategory(CssRuleTokens.TEXTORIENTATION, CssRuleGroups.WRITINGMODES) }, 
            {"text-combine-horizontal", new CssCategory(CssRuleTokens.TEXTCOMBINEHORIZONTAL, CssRuleGroups.WRITINGMODES) }, 
            {"unicode-bidi", new CssCategory(CssRuleTokens.UNICODEBIDI, CssRuleGroups.WRITINGMODES) }, 
            {"writing-mode", new CssCategory(CssRuleTokens.WRITINGMODE, CssRuleGroups.WRITINGMODES) }, 
            {"border-collapse", new CssCategory(CssRuleTokens.BORDERCOLLAPSE, CssRuleGroups.TABLE) }, 
            {"border-spacing", new CssCategory(CssRuleTokens.BORDERSPACING, CssRuleGroups.TABLE) }, 
            {"caption-side", new CssCategory(CssRuleTokens.CAPTIONSIDE, CssRuleGroups.TABLE) }, 
            {"empty-cells", new CssCategory(CssRuleTokens.EMPTYCELLS, CssRuleGroups.TABLE) }, 
            {"table-layout", new CssCategory(CssRuleTokens.TABLELAYOUT, CssRuleGroups.TABLE) }, 
            {"counter-increment", new CssCategory(CssRuleTokens.COUNTERINCREMENT, CssRuleGroups.LISTSANDCOUNTERS) }, 
            {"counter-reset", new CssCategory(CssRuleTokens.COUNTERRESET, CssRuleGroups.LISTSANDCOUNTERS) }, 
            {"list-style", new CssCategory(CssRuleTokens.LISTSTYLE, CssRuleGroups.LISTSANDCOUNTERS) }, 
            {"list-style-image", new CssCategory(CssRuleTokens.LISTSTYLEIMAGE, CssRuleGroups.LISTSANDCOUNTERS) }, 
            {"list-style-position", new CssCategory(CssRuleTokens.LISTSTYLEPOSITION, CssRuleGroups.LISTSANDCOUNTERS) }, 
            {"list-style-type", new CssCategory(CssRuleTokens.LISTSTYLETYPE, CssRuleGroups.LISTSANDCOUNTERS) }, 
            {"@keyframes", new CssCategory(CssRuleTokens.KEYFRAMES, CssRuleGroups.ANIMATION) }, 
            {"animation", new CssCategory(CssRuleTokens.ANIMATION, CssRuleGroups.ANIMATION) }, 
            {"animation-delay", new CssCategory(CssRuleTokens.ANIMATIONDELAY, CssRuleGroups.ANIMATION) }, 
            {"animation-direction", new CssCategory(CssRuleTokens.ANIMATIONDIRECTION, CssRuleGroups.ANIMATION) }, 
            {"animation-duration", new CssCategory(CssRuleTokens.ANIMATIONDURATION, CssRuleGroups.ANIMATION) }, 
            {"animation-fill-mode", new CssCategory(CssRuleTokens.ANIMATIONFILLMODE, CssRuleGroups.ANIMATION) }, 
            {"animation-iteration-count", new CssCategory(CssRuleTokens.ANIMATIONITERATIONCOUNT, CssRuleGroups.ANIMATION) }, 
            {"animation-name", new CssCategory(CssRuleTokens.ANIMATIONNAME, CssRuleGroups.ANIMATION) }, 
            {"animation-timing-function", new CssCategory(CssRuleTokens.ANIMATIONTIMINGFUNCTION, CssRuleGroups.ANIMATION) }, 
            {"animation-play-state", new CssCategory(CssRuleTokens.ANIMATIONPLAYSTATE, CssRuleGroups.ANIMATION) }, 
            {"backface-visibility", new CssCategory(CssRuleTokens.BACKFACEVISIBILITY, CssRuleGroups.TRANSFORM) }, 
            {"perspective", new CssCategory(CssRuleTokens.PERSPECTIVE, CssRuleGroups.TRANSFORM) }, 
            {"perspective-origin", new CssCategory(CssRuleTokens.PERSPECTIVEORIGIN, CssRuleGroups.TRANSFORM) }, 
            {"transform", new CssCategory(CssRuleTokens.TRANSFORM, CssRuleGroups.TRANSFORM) }, 
            {"transform-origin", new CssCategory(CssRuleTokens.TRANSFORMORIGIN, CssRuleGroups.TRANSFORM) }, 
            {"transform-style", new CssCategory(CssRuleTokens.TRANSFORMSTYLE, CssRuleGroups.TRANSFORM) }, 
            {"transition", new CssCategory(CssRuleTokens.TRANSITION, CssRuleGroups.TRANSITION) }, 
            {"transition-property", new CssCategory(CssRuleTokens.TRANSITIONPROPERTY, CssRuleGroups.TRANSITION) }, 
            {"transition-duration", new CssCategory(CssRuleTokens.TRANSITIONDURATION, CssRuleGroups.TRANSITION) }, 
            {"transition-timing-function", new CssCategory(CssRuleTokens.TRANSITIONTIMINGFUNCTION, CssRuleGroups.TRANSITION) }, 
            {"transition-delay", new CssCategory(CssRuleTokens.TRANSITIONDELAY, CssRuleGroups.TRANSITION) }, 
            {"box-sizing", new CssCategory(CssRuleTokens.BOXSIZING, CssRuleGroups.BASICUSERINTERFACE) }, 
            {"content", new CssCategory(CssRuleTokens.CONTENT, CssRuleGroups.BASICUSERINTERFACE) }, 
            {"cursor", new CssCategory(CssRuleTokens.CURSOR, CssRuleGroups.BASICUSERINTERFACE) }, 
            {"icon", new CssCategory(CssRuleTokens.ICON, CssRuleGroups.BASICUSERINTERFACE) }, 
            {"ime-mode", new CssCategory(CssRuleTokens.IMEMODE, CssRuleGroups.BASICUSERINTERFACE) }, 
            {"nav-down", new CssCategory(CssRuleTokens.NAVDOWN, CssRuleGroups.BASICUSERINTERFACE) }, 
            {"nav-index", new CssCategory(CssRuleTokens.NAVINDEX, CssRuleGroups.BASICUSERINTERFACE) }, 
            {"nav-left", new CssCategory(CssRuleTokens.NAVLEFT, CssRuleGroups.BASICUSERINTERFACE) }, 
            {"nav-right", new CssCategory(CssRuleTokens.NAVRIGHT, CssRuleGroups.BASICUSERINTERFACE) }, 
            {"nav-up", new CssCategory(CssRuleTokens.NAVUP, CssRuleGroups.BASICUSERINTERFACE) }, 
            {"outline", new CssCategory(CssRuleTokens.OUTLINE, CssRuleGroups.BASICUSERINTERFACE) }, 
            {"outline-color", new CssCategory(CssRuleTokens.OUTLINECOLOR, CssRuleGroups.BASICUSERINTERFACE) }, 
            {"outline-offset", new CssCategory(CssRuleTokens.OUTLINEOFFSET, CssRuleGroups.BASICUSERINTERFACE) }, 
            {"outline-style", new CssCategory(CssRuleTokens.OUTLINESTYLE, CssRuleGroups.BASICUSERINTERFACE) }, 
            {"outline-width", new CssCategory(CssRuleTokens.OUTLINEWIDTH, CssRuleGroups.BASICUSERINTERFACE) }, 
            {"resize", new CssCategory(CssRuleTokens.RESIZE, CssRuleGroups.BASICUSERINTERFACE) }, 
            {"text-overflow", new CssCategory(CssRuleTokens.TEXTOVERFLOW, CssRuleGroups.BASICUSERINTERFACE) }, 
            {"break-after", new CssCategory(CssRuleTokens.BREAKAFTER, CssRuleGroups.MULTICOLUMN) }, 
            {"break-before", new CssCategory(CssRuleTokens.BREAKBEFORE, CssRuleGroups.MULTICOLUMN) }, 
            {"break-inside", new CssCategory(CssRuleTokens.BREAKINSIDE, CssRuleGroups.MULTICOLUMN) }, 
            {"column-count", new CssCategory(CssRuleTokens.COLUMNCOUNT, CssRuleGroups.MULTICOLUMN) }, 
            {"column-fill", new CssCategory(CssRuleTokens.COLUMNFILL, CssRuleGroups.MULTICOLUMN) }, 
            {"column-gap", new CssCategory(CssRuleTokens.COLUMNGAP, CssRuleGroups.MULTICOLUMN) }, 
            {"column-rule", new CssCategory(CssRuleTokens.COLUMNRULE, CssRuleGroups.MULTICOLUMN) }, 
            {"column-rule-color", new CssCategory(CssRuleTokens.COLUMNRULECOLOR, CssRuleGroups.MULTICOLUMN) }, 
            {"column-rule-style", new CssCategory(CssRuleTokens.COLUMNRULESTYLE, CssRuleGroups.MULTICOLUMN) }, 
            {"column-rule-width", new CssCategory(CssRuleTokens.COLUMNRULEWIDTH, CssRuleGroups.MULTICOLUMN) }, 
            {"column-span", new CssCategory(CssRuleTokens.COLUMNSPAN, CssRuleGroups.MULTICOLUMN) }, 
            {"column-width", new CssCategory(CssRuleTokens.COLUMNWIDTH, CssRuleGroups.MULTICOLUMN) }, 
            {"columns", new CssCategory(CssRuleTokens.COLUMNS, CssRuleGroups.MULTICOLUMN) }, 
            {"widows", new CssCategory(CssRuleTokens.WIDOWS, CssRuleGroups.MULTICOLUMN) }, 
            {"orphans", new CssCategory(CssRuleTokens.ORPHANS, CssRuleGroups.PAGEDMEDIA) }, 
            {"page-break-after", new CssCategory(CssRuleTokens.PAGEBREAKAFTER, CssRuleGroups.PAGEDMEDIA) }, 
            {"page-break-before", new CssCategory(CssRuleTokens.PAGEBREAKBEFORE, CssRuleGroups.PAGEDMEDIA) }, 
            {"page-break-inside", new CssCategory(CssRuleTokens.PAGEBREAKINSIDE, CssRuleGroups.PAGEDMEDIA) }, 
            {"marks", new CssCategory(CssRuleTokens.MARKS, CssRuleGroups.GENERATEDCONTENT) }, 
            {"quotes", new CssCategory(CssRuleTokens.QUOTES, CssRuleGroups.GENERATEDCONTENT) }, 
            {"filter", new CssCategory(CssRuleTokens.FILTER, CssRuleGroups.FILTEREFFECTS) }, 
            {"image-orientation", new CssCategory(CssRuleTokens.IMAGEORIENTATION, CssRuleGroups.IMAGEREPLACEDCONTENT) }, 
            {"image-rendering", new CssCategory(CssRuleTokens.IMAGERENDERING, CssRuleGroups.IMAGEREPLACEDCONTENT) }, 
            {"image-resolution", new CssCategory(CssRuleTokens.IMAGERESOLUTION, CssRuleGroups.IMAGEREPLACEDCONTENT) }, 
            {"object-fit", new CssCategory(CssRuleTokens.OBJECTFIT, CssRuleGroups.IMAGEREPLACEDCONTENT) }, 
            {"object-position", new CssCategory(CssRuleTokens.OBJECTPOSITION, CssRuleGroups.IMAGEREPLACEDCONTENT) }, 
            {"mask", new CssCategory(CssRuleTokens.MASK, CssRuleGroups.MASKING) }, 
            {"mask-type", new CssCategory(CssRuleTokens.MASKTYPE, CssRuleGroups.MASKING) }, 
            {"mark", new CssCategory(CssRuleTokens.MARK, CssRuleGroups.SPEECH) }, 
            {"mark-after", new CssCategory(CssRuleTokens.MARKAFTER, CssRuleGroups.SPEECH) }, 
            {"mark-before", new CssCategory(CssRuleTokens.MARKBEFORE, CssRuleGroups.SPEECH) }, 
            {"phonemes", new CssCategory(CssRuleTokens.PHONEMES, CssRuleGroups.SPEECH) }, 
            {"rest", new CssCategory(CssRuleTokens.REST, CssRuleGroups.SPEECH) }, 
            {"rest-after", new CssCategory(CssRuleTokens.RESTAFTER, CssRuleGroups.SPEECH) }, 
            {"rest-before", new CssCategory(CssRuleTokens.RESTBEFORE, CssRuleGroups.SPEECH) }, 
            {"voice-balance", new CssCategory(CssRuleTokens.VOICEBALANCE, CssRuleGroups.SPEECH) }, 
            {"voice-duration", new CssCategory(CssRuleTokens.VOICEDURATION, CssRuleGroups.SPEECH) }, 
            {"voice-pitch", new CssCategory(CssRuleTokens.VOICEPITCH, CssRuleGroups.SPEECH) }, 
            {"voice-pitch-range", new CssCategory(CssRuleTokens.VOICEPITCHRANGE, CssRuleGroups.SPEECH) }, 
            {"voice-rate", new CssCategory(CssRuleTokens.VOICERATE, CssRuleGroups.SPEECH) }, 
            {"voice-stress", new CssCategory(CssRuleTokens.VOICESTRESS, CssRuleGroups.SPEECH) }, 
            {"voice-volume", new CssCategory(CssRuleTokens.VOICEVOLUME, CssRuleGroups.SPEECH) }, 
            {"marquee-direction", new CssCategory(CssRuleTokens.MARQUEEDIRECTION, CssRuleGroups.MARQUEE) }, 
            {"marquee-play-count", new CssCategory(CssRuleTokens.MARQUEEPLAYCOUNT, CssRuleGroups.MARQUEE) }, 
            {"marquee-speed", new CssCategory(CssRuleTokens.MARQUEESPEED, CssRuleGroups.MARQUEE) }, 
            {"marquee-style", new CssCategory(CssRuleTokens.MARQUEESTYLE, CssRuleGroups.MARQUEE) }
        };

    }
}

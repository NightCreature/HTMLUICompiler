﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Diagnostics;

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

            Position = new CssPosition();
            Position.decodeCssString(positionStr);
        }

        public CssPosition Position { get; set; }
    }

    public class CssWidthRule : CssRule
    {
        public override void decodeCssString(string cssString)
        {
            Width = CssHelpers.decodeCssUnit(cssString);
        }

        public CssUnit Width { get; set; }
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

    //Has no definition in the standard
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
            Inset = false;

            char[] splitChars = { ' ' };
            string[] tokens = cssString.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);

            if (tokens.Length < 2)
            {
                Debug.WriteLine("Error in BoxShadow css rule need to have a h and v position");
                return;
            }
            string position = tokens[0] + " " + tokens[1];
            ShadowPosition = new CssPosition();
            ShadowPosition.decodeCssString(position);

            if (tokens.Length >= 3)
            {
                Regex regex = new Regex("\\d");
                string blurSpread = "";
                if (regex.IsMatch(tokens[2]))
                {
                    blurSpread = tokens[2];
                }
                else
                {
                    ShadowColor = CssHelpers.decodeColorString(tokens[2]);
                }

                if (tokens.Length >= 4)
                {
                    if (regex.IsMatch(tokens[3]))
                    {
                        blurSpread += " " + tokens[3];
                    }
                    else
                    {
                        ShadowColor = CssHelpers.decodeColorString(tokens[3]);
                    }
                }

                BlurSpread = new CssPosition();
                BlurSpread.decodeCssString(blurSpread);

                if (tokens.Length >= 6)
                {
                    ShadowColor = CssHelpers.decodeColorString(tokens[4]);
                    if (tokens[5] == "inset")
                    {
                        Inset = true;
                    }
                }
                else
                {
                    ShadowColor = CssHelpers.decodeColorString(tokens[4]);
                }
            }

            
        }

        public CssPosition ShadowPosition { get; set; }
        public CssPosition BlurSpread { get; set; }
        public Color ShadowColor { get; set; }
        public bool Inset { get; set; }
    }

}
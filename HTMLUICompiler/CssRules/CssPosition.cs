using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace HTMLUICompiler
{
    public class CssUnit
    {
        public enum ValueType
        {
            percentage, //percentage
            inch, //inch
            cm, //centimeter
            mm, //millimeter
            em, //1em is equal to the current font size. 2em means 2 times the size of the current font. E.g., if an element is displayed with a font of 12 pt, then '2em' is 24 pt. The 'em' is a very useful unit in CSS, since it can adapt automatically to the font that the reader uses
            ex, //one ex is the x-height of a font (x-height is usually about half the font-size)
            pt, //point (1 pt is the same as 1/72 inch)
            pc, //pica (1 pc is the same as 12 points)
            px, //pixels (a dot on the computer screen)
        };

        public static Dictionary<String, ValueType> PositionTable = new Dictionary<String, ValueType>()
            {
                {"%", ValueType.percentage},
                {"in", ValueType.inch},
                {"cm", ValueType.cm},
                {"mm", ValueType.mm},
                {"em", ValueType.em},
                {"ex", ValueType.ex},
                {"pc", ValueType.pc},
                {"px", ValueType.px}
            };

        public float value;
        public ValueType valueType;
    }

    public class CssPoint
    {
        public CssUnit xValue;
        public CssUnit yValue;
    }

    public class CssPosition
    {
        public CssPosition()
        {
        }

        public void decodeCssString(string cssString)
        {
            if (PositionTable.ContainsKey(cssString))
            {
                ScreenPosition = PositionTable[cssString];
            }
            else
            {
                //Dealing with a real position
                //x% y% 	The first value is the horizontal position and the second value is the vertical. The top left corner is 0% 0%. The right bottom corner is 100% 100%. If you only specify one value, the other value will be 50%. . Default value is: 0% 0% 	Play it »
                //xpos ypos 	The first value is the horizontal position and the second value is the vertical. The top left corner is 0 0. Units can be pixels (0px 0px) or any other CSS units. If you only specify one value, the other value will be 50%. You can mix % and positions
                char[] splitChars = { ' ' };
                string[] positionTokens = cssString.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
                Regex regex = new Regex("(?<number>\\d)(?<suffix>.*)", RegexOptions.IgnoreCase);
                if (positionTokens.Count() == 1)
                {
                    var match = regex.Match(positionTokens[0]);
                    float value = 0.0f;
                    float.TryParse(match.Groups["number"].Value, out value);
                    Position.xValue.value = value;
                    if (CssUnit.PositionTable.ContainsKey(match.Groups["suffix"].Value))
                    {
                        Position.xValue.valueType = CssUnit.PositionTable[match.Groups["suffix"].Value];
                    }
                    else
                    {
                        Debug.WriteLine("Error: no suffix was found on a numerical position definition");
                    }

                    Position.yValue.value = 50.0f;
                    Position.yValue.valueType = CssUnit.ValueType.percentage;
                }
                else if (positionTokens.Count() == 2)
                {
                    var match = regex.Match(positionTokens[0]);
                    float value = 0.0f;
                    float.TryParse(match.Groups["number"].Value, out value);
                    Position.xValue.value = value;
                    if (CssUnit.PositionTable.ContainsKey(match.Groups["suffix"].Value))
                    {
                        Position.xValue.valueType = CssUnit.PositionTable[match.Groups["suffix"].Value];
                    }
                    else
                    {
                        Debug.WriteLine("Error: no suffix was found on a numerical position definition");
                    }

                    float.TryParse(match.Groups["number"].Value, out value);
                    Position.yValue.value = value;
                    if (CssUnit.PositionTable.ContainsKey(match.Groups["suffix"].Value))
                    {
                        Position.yValue.valueType = CssUnit.PositionTable[match.Groups["suffix"].Value];
                    }
                    else
                    {
                        Debug.WriteLine("Error: no suffix was found on a numerical position definition");
                    }
                }
                else
                {
                    Debug.Write("Missing or malformed position definition: ");
                    Debug.WriteLine(cssString);
                }
            }

        }

        public enum NamedPosition
        {
            lefttop,
            leftcenter,
            leftbottom,
            righttop,
            rightcenter,
            rightbottom,
            centertop,
            centercenter,
            centerbottom
        }

        public NamedPosition ScreenPosition { get; set; }
        public CssPoint Position { get; set; }

        private static Dictionary<String, NamedPosition> PositionTable = new Dictionary<String, NamedPosition>()
        {
            {"left", NamedPosition.leftcenter},
            {"left top", NamedPosition.lefttop},
            {"left center", NamedPosition.leftcenter},
            {"left bottom", NamedPosition.leftbottom},
            {"right", NamedPosition.rightcenter},
            {"right top", NamedPosition.righttop},
            {"right center", NamedPosition.rightcenter},
            {"right bottom", NamedPosition.rightbottom},
            {"center", NamedPosition.centercenter},
            {"center top", NamedPosition.centertop},
            {"center center", NamedPosition.centercenter},
            {"center bottom", NamedPosition.centerbottom},
        };
    }
}

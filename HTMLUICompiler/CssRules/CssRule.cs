using System;
using System.Collections.Generic;
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
}

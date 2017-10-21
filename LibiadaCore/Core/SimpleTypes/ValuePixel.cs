using ImageSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibiadaCore.Core.SimpleTypes
{
    public class ValuePixel : IBaseObject
    {
        private readonly Point value;

        public ValuePixel(Point value)
        {
            this.value = value;
        }

        public IBaseObject Clone()
        {
            return new ValuePixel(value);
        }
    }
}

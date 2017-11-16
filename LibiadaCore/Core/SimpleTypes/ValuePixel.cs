using SixLabors.ImageSharp;

namespace LibiadaCore.Core.SimpleTypes
{
    public class ValuePixel : IBaseObject
    {
        private readonly Rgba32 value;

        public ValuePixel(Rgba32 value)
        {
            this.value = value;
        }

        public IBaseObject Clone()
        {
            return new ValuePixel(value);
        }

        public override bool Equals(object other)
        {
            if (other is ValuePixel)
            {
                return value.Equals(((ValuePixel)other).value);
            }
            else
            {
                return false;
            }
        }
    }
}

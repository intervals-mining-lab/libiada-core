using ImageSharp;

namespace LibiadaCore.Core.SimpleTypes
{
    public class ValuePixel : IBaseObject
    {
        private readonly Color value;

        public ValuePixel(Color value)
        {
            this.value = value;
        }

        public IBaseObject Clone()
        {
            return new ValuePixel(value);
        }
    }
}

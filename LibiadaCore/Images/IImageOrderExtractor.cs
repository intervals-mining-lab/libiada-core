using LibiadaCore.Core;
using ImageSharp;

namespace LibiadaCore.Images
{
    public interface IImageOrderExtractor
    {
        BaseChain ExtractOrder(Point[,] image);
    }
}

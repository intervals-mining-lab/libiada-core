namespace LibiadaCore.Images
{
    using LibiadaCore.Core;
    using SixLabors.ImageSharp;

    public interface IImageOrderExtractor
    {
        BaseChain ExtractOrder(Rgba32[,] image);
    }
}

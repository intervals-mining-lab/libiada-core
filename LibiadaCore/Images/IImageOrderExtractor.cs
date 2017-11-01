namespace LibiadaCore.Images
{
    using ImageSharp;

    using LibiadaCore.Core;

    public interface IImageOrderExtractor
    {
        BaseChain ExtractOrder(Color[,] image);
    }
}

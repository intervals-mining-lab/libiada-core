using SixLabors.ImageSharp;

namespace LibiadaCore.Images
{
    public interface IMatrixTransformer
    {
        Rgba32[,] Transform(Rgba32[,] image);
    }
}

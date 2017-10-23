using ImageSharp;

namespace LibiadaCore.Images
{
    public interface IMatrixTransformer
    {
        Color[,] Transform(Color[,] image);
    }
}

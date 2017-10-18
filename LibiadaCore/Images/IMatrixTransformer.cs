using ImageSharp;

namespace LibiadaCore.Images
{
    public interface IMatrixTransformer
    {
        Point[,] Transform(Point[,] image);
    }
}

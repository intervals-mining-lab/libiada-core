namespace LibiadaCore.Images
{
    using ImageSharp;

    public interface IMatrixTransformer
    {
        Color[,] Transform(Color[,] image);
    }
}

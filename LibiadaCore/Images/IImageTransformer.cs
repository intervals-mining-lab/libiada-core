namespace LibiadaCore.Images
{
    using ImageSharp;

    public interface IImageTransformer
    {
        Image Transform(Image image);
    }
}

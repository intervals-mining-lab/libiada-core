namespace LibiadaCore.Images
{
    using SixLabors.ImageSharp;

    public interface IImageTransformer
    {
        Image<Rgba32> Transform(Image<Rgba32> image);
    }
}

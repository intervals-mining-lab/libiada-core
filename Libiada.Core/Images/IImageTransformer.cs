namespace LibiadaCore.Images
{
    using SixLabors.ImageSharp;
    using SixLabors.ImageSharp.PixelFormats;

    /// <summary>
    /// The ImageTransformer interface.
    /// </summary>
    public interface IImageTransformer
    {
        /// <summary>
        /// Transforms image.
        /// </summary>
        /// <param name="image">
        /// The image.
        /// </param>
        /// <returns>
        /// The <see cref="Image"/>.
        /// </returns>
        Image<Rgba32> Transform(Image<Rgba32> image);
    }
}

namespace LibiadaCore.Images
{
    using SixLabors.ImageSharp;
    using SixLabors.ImageSharp.PixelFormats;
    using SixLabors.ImageSharp.Processing;

    /// <summary>
    /// The image resizer.
    /// </summary>
    public class ImageResizer : IImageTransformer
    {
        /// <summary>
        /// The width after resize.
        /// </summary>
        private readonly int destinationWidth;

        /// <summary>
        /// The height after resize.
        /// </summary>
        private readonly int destinationHeight;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageResizer"/> class.
        /// </summary>
        /// <param name="newWidth">
        /// The new width.
        /// </param>
        /// <param name="newHeight">
        /// The new height.
        /// </param>
        public ImageResizer(int newWidth, int newHeight)
        {
            destinationWidth = newWidth;
            destinationHeight = newHeight;
        }

        /// <summary>
        /// Create resized image.
        /// </summary>
        /// <param name="image">
        /// The image.
        /// </param>
        /// <returns>
        /// The <see cref="Image"/>.
        /// </returns>
        public Image<Rgba32> Transform(Image<Rgba32> image)
        {
            var result = image.Clone();
            result.Mutate(i => i.Resize(new Size(destinationWidth, destinationHeight)));
            return result;
        }
    }
}

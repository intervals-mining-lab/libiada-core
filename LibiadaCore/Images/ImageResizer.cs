namespace LibiadaCore.Images
{
    using SixLabors.ImageSharp;
    using SixLabors.Primitives;

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
        /// <param name="newHight">
        /// The new hight.
        /// </param>
        public ImageResizer(int newWidth, int newHight)
        {
            destinationWidth = newWidth;
            destinationHeight = newHight;
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

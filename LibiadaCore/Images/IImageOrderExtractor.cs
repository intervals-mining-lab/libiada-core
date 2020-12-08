using LibiadaCore.Core;
using SixLabors.ImageSharp.PixelFormats;

namespace LibiadaCore.Images
{
    /// <summary>
    /// The ImageOrderExtractor interface.
    /// </summary>
    public interface IImageOrderExtractor
    {
        /// <summary>
        /// Extracts order of image.
        /// </summary>
        /// <param name="image">
        /// The image.
        /// </param>
        /// <returns>
        /// The <see cref="BaseChain"/>.
        /// </returns>
        BaseChain ExtractOrder(Rgba32[,] image);
    }
}

namespace Libiada.Core.Images;

using Libiada.Core.Core;
using SixLabors.ImageSharp.PixelFormats;

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
    /// The <see cref="Sequence"/>.
    /// </returns>
    Sequence ExtractOrder(Rgba32[,] image);
}

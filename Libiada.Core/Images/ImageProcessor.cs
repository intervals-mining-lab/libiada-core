namespace Libiada.Core.Images;

using Libiada.Core.Core;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

/// <summary>
/// The image processor.
/// </summary>
public static class ImageProcessor
{
    /// <summary>
    /// Processes the image.
    /// </summary>
    /// <param name="image">
    /// The image.
    /// </param>
    /// <param name="imageTransformers">
    /// The image transformers.
    /// </param>
    /// <param name="matrixTransformers">
    /// The matrix transformers.
    /// </param>
    /// <param name="orderExtractor">
    /// The order extractor.
    /// </param>
    /// <returns>
    /// The <see cref="BaseChain"/>.
    /// </returns>
    public static BaseChain ProcessImage(Image<Rgba32> image, IImageTransformer[] imageTransformers, IMatrixTransformer[] matrixTransformers, IImageOrderExtractor orderExtractor)
    {
        for (int i = 0; i < imageTransformers.Length; i++)
        {
            image = imageTransformers[i].Transform(image);
        }

        var points = new Rgba32[image.Width, image.Height];

        for (int i = 0; i < image.Width; i++)
        {
            for (int j = 0; j < image.Height; j++)
            {
                points[i, j] = image[i, j];
            }
        }

        for (int i = 0; i < matrixTransformers.Length; i++)
        {
            points = matrixTransformers[i].Transform(points);
        }

        return orderExtractor.ExtractOrder(points);
    }
}

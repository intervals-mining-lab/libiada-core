using ImageSharp;
using LibiadaCore.Core;

namespace LibiadaCore.Images
{
    public class ImageProcessor
    {
        public static BaseChain ProcessImage(Image image, IImageTransformer[] imageTransformers, IMatrixTransformer[] matrixTransformers, IImageOrderExtractor orderExtractor)
        {
            for (int i = 0; i < imageTransformers.Length; i++)
            {
                image = imageTransformers[i].Transform(image);
            }

            Color[,] points = new Color[image.Height, image.Width];

            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    points[i, j] = image.Pixels[i * image.Width + j];
                }
            }
            for (int i = 0; i < matrixTransformers.Length; i++)
            {
                points = matrixTransformers[i].Transform(points);
            }
            return orderExtractor.ExtractOrder(points);
        }
    }
}

using ImageSharp;

namespace LibiadaCore.Images
{
    public class ImageProcessor
    {
        public void ProcessImage(Image image, IImageTransformer[] imageTransformers, IMatrixTransformer[] matrixTransformers, IImageOrderExtractor orderExtractor)
        {
            for (int i=0; i<imageTransformers.Length; i++)
            {
                image = imageTransformers[i].Transform(image);
            }

            Point[,] points = null;
            for (int i = 0; i < matrixTransformers.Length; i++)
            {
                points = matrixTransformers[i].Transform(points);
            }
            var result = orderExtractor.ExtractOrder(points);
        }
    }
}

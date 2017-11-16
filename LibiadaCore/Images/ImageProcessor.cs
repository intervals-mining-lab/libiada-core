namespace LibiadaCore.Images
{

    using LibiadaCore.Core;
    using SixLabors.ImageSharp;

    public static class ImageProcessor
    {
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
}

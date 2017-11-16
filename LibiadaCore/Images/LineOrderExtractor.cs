namespace LibiadaCore.Images
{

    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;
    using SixLabors.ImageSharp;

    public class LineOrderExtractor : IImageOrderExtractor
    {
        public BaseChain ExtractOrder(Rgba32[,] image)
        {
            var order = new int[image.GetLength(0) * image.GetLength(1)];
            var alphabet = new Alphabet { NullValue.Instance() };

            for (int i = 0; i < image.GetLength(0); i++)
            {
                for (int j = 0; j < image.GetLength(1); j++)
                {
                    var pixelIndex = alphabet.IndexOf(new ValuePixel(image[i, j]));
                    if (pixelIndex == -1)
                    {
                        alphabet.Add(new ValuePixel(image[i, j]));
                        pixelIndex = alphabet.IndexOf(new ValuePixel(image[i, j]));
                    }

                    order[i * image.GetLength(1) + j] = pixelIndex;
                }
            }

            return new BaseChain(order, alphabet);
        }
    }
}

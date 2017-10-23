using ImageSharp;
using LibiadaCore.Core;
using LibiadaCore.Core.SimpleTypes;

namespace LibiadaCore.Images
{
    public class LineOrderExtractor : IImageOrderExtractor
    {
        public BaseChain ExtractOrder(Color[,] image)
        {
            int[] order = new int[image.GetLength(0) * image.GetLength(1)];
            Alphabet alphabet = new Alphabet();
            for (int i = 0; i < image.GetLength(0); i++)
            {
                for (int j = 0; j < image.GetLength(1); j++)
                {
                    var pixelIndex = alphabet.IndexOf(new ValuePixel(image[i, j]));
                    if (pixelIndex == -1)
                    {
                        alphabet.Add(new ValuePixel(image[i, j]));
                    }
                    else
                    {
                        pixelIndex = alphabet.IndexOf(new ValuePixel(image[i, j]));
                    }

                    order[i * image.GetLength(1) + j] = pixelIndex;
                }
            }
            return new BaseChain(order, alphabet);
        }
    }
}

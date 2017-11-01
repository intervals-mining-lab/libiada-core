using ImageSharp;
using LibiadaCore.Core;
using LibiadaCore.Core.SimpleTypes;

namespace LibiadaCore.Images
{
    public class ZigzagOrderExtractor : IImageOrderExtractor
    {
        public BaseChain ExtractOrder(Color[,] image)
        {
            int[] order = new int[image.GetLength(0) * image.GetLength(1)];
            Alphabet alphabet = new Alphabet { NullValue.Instance() };


            for (int i = 0; i < image.GetLength(0); i++)
            {
                if (i % 2 == 0)
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
                else
                {
                    for (int j = image.GetLength(1) - 1, k = 0; j >= 0; j--, k++)
                    {
                        var pixelIndex = alphabet.IndexOf(new ValuePixel(image[i, j]));
                        if (pixelIndex == -1)
                        {
                            alphabet.Add(new ValuePixel(image[i, j]));
                            pixelIndex = alphabet.IndexOf(new ValuePixel(image[i, j]));
                        }

                        order[i * image.GetLength(1) + k] = pixelIndex;
                    }
                }
            }

            return new BaseChain(order, alphabet);
        }
    }
}

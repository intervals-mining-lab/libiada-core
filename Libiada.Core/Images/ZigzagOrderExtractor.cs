﻿namespace Libiada.Core.Images;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;

using SixLabors.ImageSharp.PixelFormats;

/// <summary>
/// The zigzag order extractor.
/// </summary>
public class ZigzagOrderExtractor : IImageOrderExtractor
{
    /// <summary>
    /// Extracts order moving in zigzags horizontally.
    /// </summary>
    /// <param name="image">
    /// The image.
    /// </param>
    /// <returns>
    /// The <see cref="Sequence"/>.
    /// </returns>
    public Sequence ExtractOrder(Rgba32[,] image)
    {
        int[] order = new int[image.GetLength(0) * image.GetLength(1)];
        Alphabet alphabet = [NullValue.Instance()];


        for (int i = 0; i < image.GetLength(0); i++)
        {
            if (i % 2 == 0)
            {
                for (int j = 0; j < image.GetLength(1); j++)
                {
                    int pixelIndex = alphabet.IndexOf(new ValuePixel(image[i, j]));
                    if (pixelIndex == -1)
                    {
                        alphabet.Add(new ValuePixel(image[i, j]));
                        pixelIndex = alphabet.Cardinality - 1; ;
                    }

                    order[i * image.GetLength(1) + j] = pixelIndex;
                }
            }
            else
            {
                for (int j = image.GetLength(1) - 1, k = 0; j >= 0; j--, k++)
                {
                    int pixelIndex = alphabet.IndexOf(new ValuePixel(image[i, j]));
                    if (pixelIndex == -1)
                    {
                        alphabet.Add(new ValuePixel(image[i, j]));
                        pixelIndex = alphabet.IndexOf(new ValuePixel(image[i, j]));
                    }

                    order[i * image.GetLength(1) + k] = pixelIndex;
                }
            }
        }

        return new Sequence(order, alphabet);
    }
}

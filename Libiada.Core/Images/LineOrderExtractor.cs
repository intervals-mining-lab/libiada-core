﻿namespace Libiada.Core.Images;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;

using SixLabors.ImageSharp.PixelFormats;

/// <summary>
/// The line order extractor.
/// </summary>
public class LineOrderExtractor : IImageOrderExtractor
{
    /// <summary>
    /// Extracts order line by line.
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
            for (int j = 0; j < image.GetLength(1); j++)
            {
                // TODO: refactor this to use standard Sequence constructor
                int pixelIndex = alphabet.IndexOf(new ValuePixel(image[i, j]));
                if (pixelIndex == -1)
                {
                    alphabet.Add(new ValuePixel(image[i, j]));
                    pixelIndex = alphabet.Cardinality - 1; ;
                }

                order[i * image.GetLength(1) + j] = pixelIndex;
            }
        }

        return new Sequence(order, alphabet);
    }
}

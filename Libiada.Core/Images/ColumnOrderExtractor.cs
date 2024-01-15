namespace Libiada.Core.Images;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;

using SixLabors.ImageSharp.PixelFormats;

public class ColumnOrderExtractor : IImageOrderExtractor
{
    /// <summary>
 /// Extracts order by columns.
 /// </summary>
 /// <param name="image">
 /// The source image as <see cref="Rgba32"/> two dimensional array.
 /// </param>
 /// <returns>
 /// The <see cref="BaseChain"/>.
 /// </returns>
    public BaseChain ExtractOrder(Rgba32[,] image)
    {
        var order = new int[image.GetLength(0) * image.GetLength(1)];
        var alphabet = new Alphabet { NullValue.Instance() };

        for (int i = 0; i < image.GetLength(1); i++)
        {
            for (int j = 0; j < image.GetLength(0); j++)
            {
                var pixelIndex = alphabet.IndexOf(new ValuePixel(image[j, i]));
                if (pixelIndex == -1)
                {
                    alphabet.Add(new ValuePixel(image[j, i]));
                    pixelIndex = alphabet.Cardinality - 1; ;
                }

                order[i * image.GetLength(0) + j] = pixelIndex;
            }
        }

        return new BaseChain(order, alphabet);
    }
}

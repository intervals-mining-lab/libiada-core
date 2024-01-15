namespace LibiadaCore.Images
{
    using SixLabors.ImageSharp.PixelFormats;

    /// <summary>
    /// The MatrixTransformer interface.
    /// </summary>
    public interface IMatrixTransformer
    {
        /// <summary>
        /// Matrix transformation method.
        /// </summary>
        /// <param name="image">
        /// The image.
        /// </param>
        /// <returns>
        /// The <see cref="T:Rgba32[,]"/>.
        /// </returns>
        Rgba32[,] Transform(Rgba32[,] image);
    }
}

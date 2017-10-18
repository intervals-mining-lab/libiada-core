using ImageSharp;

namespace LibiadaCore.Images
{
    public interface IImageTransformer
    {
        Image Transform(Image image);
    }
   
}

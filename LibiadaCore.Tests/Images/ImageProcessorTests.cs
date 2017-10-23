using ImageSharp;
using LibiadaCore.Core;
using LibiadaCore.Core.SimpleTypes;
using LibiadaCore.Images;
using NUnit.Framework;

namespace LibiadaCore.Tests.Images
{
    [TestFixture]
    public class ImageProcessorTests
    {
        [Test]
        public void SimpleTest()
        {
            Image image = new Image(2, 3);
            image.InitPixels(2, 3);
            image.Pixels[0] = Color.Black;
            image.Pixels[1] = Color.White;
            image.Pixels[2] = Color.Black;
            image.Pixels[3] = Color.White;
            image.Pixels[4] = Color.Black;
            image.Pixels[5] = Color.White;

            BaseChain actual = ImageProcessor.ProcessImage(image, new IImageTransformer[0], new IMatrixTransformer[0], new LineOrderExtractor());

            ValuePixel black = new ValuePixel(Color.Black);
            ValuePixel white = new ValuePixel(Color.White);

            BaseChain expected = new BaseChain(6);

            expected[0] = black;
            expected[1] = white;
            expected[2] = black;
            expected[3] = white;
            expected[4] = black;
            expected[5] = white;

            Assert.AreEqual(expected, actual);
        }
    }
}


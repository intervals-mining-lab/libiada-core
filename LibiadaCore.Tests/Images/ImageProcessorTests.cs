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

        [Test]
        public void SecondSimpleTest()
        {
            Image image = new Image(2, 2);
            image.InitPixels(2, 2);
            image.Pixels[0] = Color.Gray;
            image.Pixels[1] = Color.Blue;
            image.Pixels[2] = Color.Red;
            image.Pixels[3] = Color.Brown;


            BaseChain actual = ImageProcessor.ProcessImage(image, new IImageTransformer[0], new IMatrixTransformer[0], new LineOrderExtractor());

            ValuePixel gray = new ValuePixel(Color.Gray);
            ValuePixel blue = new ValuePixel(Color.Blue);
            ValuePixel red = new ValuePixel(Color.Red);
            ValuePixel brown = new ValuePixel(Color.Brown);

            BaseChain expected = new BaseChain(4);

            expected[0] = gray;
            expected[1] = blue;
            expected[2] = red;
            expected[3] = brown;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ThirdSimpleTest()
        {
            Image image = new Image(1, 4);
            image.InitPixels(1, 4);
            image.Pixels[0] = Color.Gray;
            image.Pixels[1] = Color.Blue;
            image.Pixels[2] = Color.Red;
            image.Pixels[3] = Color.Brown;


            BaseChain actual = ImageProcessor.ProcessImage(image, new IImageTransformer[0], new IMatrixTransformer[0], new LineOrderExtractor());

            ValuePixel gray = new ValuePixel(Color.Gray);
            ValuePixel blue = new ValuePixel(Color.Blue);
            ValuePixel red = new ValuePixel(Color.Red);
            ValuePixel brown = new ValuePixel(Color.Brown);

            BaseChain expected = new BaseChain(4);

            expected[0] = gray;
            expected[1] = blue;
            expected[2] = red;
            expected[3] = brown;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FiveSimpleTest()
        {
            Image image = new Image(4, 1);
            image.InitPixels(4, 1);
            image.Pixels[0] = Color.Gray;
            image.Pixels[1] = Color.Blue;
            image.Pixels[2] = Color.Red;
            image.Pixels[3] = Color.Brown;


            BaseChain actual = ImageProcessor.ProcessImage(image, new IImageTransformer[0], new IMatrixTransformer[0], new LineOrderExtractor());

            ValuePixel gray = new ValuePixel(Color.Gray);
            ValuePixel blue = new ValuePixel(Color.Blue);
            ValuePixel red = new ValuePixel(Color.Red);
            ValuePixel brown = new ValuePixel(Color.Brown);

            BaseChain expected = new BaseChain(4);

            expected[0] = gray;
            expected[1] = blue;
            expected[2] = red;
            expected[3] = brown;

            Assert.AreEqual(expected, actual);
        }
    }
}


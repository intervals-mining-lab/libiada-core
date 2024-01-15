using LibiadaCore.Core;
using LibiadaCore.Core.SimpleTypes;
using LibiadaCore.Images;

using NUnit.Framework;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace LibiadaCore.Tests.Images
{
    [TestFixture]
    public class ImageProcessorTests
    {
        [Test]
        public void SimpleTest()
        {
            Image<Rgba32> image = new Image<Rgba32>(2, 3);
            image[0, 0] = Color.Black;
            image[0, 1] = Color.White;
            image[0, 2] = Color.Black;
            image[1, 0] = Color.White;
            image[1, 1] = Color.Black;
            image[1, 2] = Color.White;

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
            Image<Rgba32> image = new Image<Rgba32>(2, 2);
            image[0, 0] = Color.Gray;
            image[0, 1] = Color.Blue;
            image[1, 0] = Color.Red;
            image[1, 1] = Color.Brown;


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
            Image<Rgba32> image = new Image<Rgba32>(1, 4);
            image[0, 0] = Color.Gray;
            image[0, 1] = Color.Blue;
            image[0, 2] = Color.Red;
            image[0, 3] = Color.Brown;


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
        public void FourthSimpleTest()
        {
            Image<Rgba32> image = new Image<Rgba32>(4, 1);
            image[0, 0] = Color.Gray;
            image[1, 0] = Color.Blue;
            image[2, 0] = Color.Red;
            image[3, 0] = Color.Brown;


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


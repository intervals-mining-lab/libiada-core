namespace LibiadaCore.Tests.Images
{

    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.Images;

    using NUnit.Framework;
    using SixLabors.ImageSharp;

    [TestFixture]
    public class ImageProcessorTests
    {
        [Test]
        public void SimpleTest()
        {
            Image<Rgba32> image = new Image<Rgba32>(2, 3);
            image[0, 0] = Rgba32.Black;
            image[0, 1] = Rgba32.White;
            image[0, 2] = Rgba32.Black;
            image[1, 0] = Rgba32.White;
            image[1, 1] = Rgba32.Black;
            image[1, 2] = Rgba32.White;

            BaseChain actual = ImageProcessor.ProcessImage(image, new IImageTransformer[0], new IMatrixTransformer[0], new LineOrderExtractor());

            ValuePixel black = new ValuePixel(Rgba32.Black);
            ValuePixel white = new ValuePixel(Rgba32.White);

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
            image[0, 0] = Rgba32.Gray;
            image[0, 1] = Rgba32.Blue;
            image[1, 0] = Rgba32.Red;
            image[1, 1] = Rgba32.Brown;


            BaseChain actual = ImageProcessor.ProcessImage(image, new IImageTransformer[0], new IMatrixTransformer[0], new LineOrderExtractor());

            ValuePixel gray = new ValuePixel(Rgba32.Gray);
            ValuePixel blue = new ValuePixel(Rgba32.Blue);
            ValuePixel red = new ValuePixel(Rgba32.Red);
            ValuePixel brown = new ValuePixel(Rgba32.Brown);

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
            image[0, 0] = Rgba32.Gray;
            image[0, 1] = Rgba32.Blue;
            image[0, 2] = Rgba32.Red;
            image[0, 3] = Rgba32.Brown;


            BaseChain actual = ImageProcessor.ProcessImage(image, new IImageTransformer[0], new IMatrixTransformer[0], new LineOrderExtractor());

            ValuePixel gray = new ValuePixel(Rgba32.Gray);
            ValuePixel blue = new ValuePixel(Rgba32.Blue);
            ValuePixel red = new ValuePixel(Rgba32.Red);
            ValuePixel brown = new ValuePixel(Rgba32.Brown);

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
            image[0, 0] = Rgba32.Gray;
            image[1, 0] = Rgba32.Blue;
            image[2, 0] = Rgba32.Red;
            image[3, 0] = Rgba32.Brown;


            BaseChain actual = ImageProcessor.ProcessImage(image, new IImageTransformer[0], new IMatrixTransformer[0], new LineOrderExtractor());

            ValuePixel gray = new ValuePixel(Rgba32.Gray);
            ValuePixel blue = new ValuePixel(Rgba32.Blue);
            ValuePixel red = new ValuePixel(Rgba32.Red);
            ValuePixel brown = new ValuePixel(Rgba32.Brown);

            BaseChain expected = new BaseChain(4);

            expected[0] = gray;
            expected[1] = blue;
            expected[2] = red;
            expected[3] = brown;

            Assert.AreEqual(expected, actual);
        }
    }
}


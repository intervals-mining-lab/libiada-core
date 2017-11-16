namespace LibiadaCore.Tests.Images
{

    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.Images;

    using NUnit.Framework;
    using SixLabors.ImageSharp;

    [TestFixture]
    public class ZigzagOrderExtractorTests
    {
        [Test]
        public void ZigzagSimpleTest()
        {
            Image<Rgba32> image = new Image<Rgba32>(2, 3);
            image[0, 0] = Rgba32.Black;
            image[0, 1] = Rgba32.White;
            image[0, 2] = Rgba32.Black;
            image[1, 0] = Rgba32.White;
            image[1, 1] = Rgba32.Black;
            image[1, 2] = Rgba32.White;

            BaseChain actual = ImageProcessor.ProcessImage(image, new IImageTransformer[0], new IMatrixTransformer[0], new ZigzagOrderExtractor());

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
        public void ZigzagSecondSimpleTest()
        {
            Image<Rgba32> image = new Image<Rgba32>(2, 2);
            image[0, 0] = Rgba32.Black;
            image[0, 1] = Rgba32.Blue;
            image[1, 0] = Rgba32.Red;
            image[1, 1] = Rgba32.White;


            BaseChain actual = ImageProcessor.ProcessImage(image, new IImageTransformer[0], new IMatrixTransformer[0], new ZigzagOrderExtractor());

            ValuePixel black = new ValuePixel(Rgba32.Black);
            ValuePixel blue = new ValuePixel(Rgba32.Blue);
            ValuePixel red = new ValuePixel(Rgba32.Red);
            ValuePixel white = new ValuePixel(Rgba32.White);

            BaseChain expected = new BaseChain(4);

            expected[0] = black;
            expected[1] = blue;
            expected[2] = white;
            expected[3] = red;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ZigzagThirdSimpleTest()
        {
            Image<Rgba32> image = new Image<Rgba32>(1, 4);
            image[0, 0] = Rgba32.Black;
            image[0, 1] = Rgba32.Blue;
            image[0, 2] = Rgba32.Red;
            image[0, 3] = Rgba32.White;


            BaseChain actual = ImageProcessor.ProcessImage(image, new IImageTransformer[0], new IMatrixTransformer[0], new ZigzagOrderExtractor());

            ValuePixel black = new ValuePixel(Rgba32.Black);
            ValuePixel blue = new ValuePixel(Rgba32.Blue);
            ValuePixel red = new ValuePixel(Rgba32.Red);
            ValuePixel white = new ValuePixel(Rgba32.White);

            BaseChain expected = new BaseChain(4);

            expected[0] = black;
            expected[1] = blue;
            expected[2] = red;
            expected[3] = white;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ZigzagFourthSimpleTest()
        {
            Image<Rgba32> image = new Image<Rgba32>(4, 1);
            image[0, 0] = Rgba32.Black;
            image[1, 0] = Rgba32.Blue;
            image[2, 0] = Rgba32.Red;
            image[3, 0] = Rgba32.White;



            BaseChain actual = ImageProcessor.ProcessImage(image, new IImageTransformer[0], new IMatrixTransformer[0], new ZigzagOrderExtractor());

            ValuePixel black = new ValuePixel(Rgba32.Black);
            ValuePixel blue = new ValuePixel(Rgba32.Blue);
            ValuePixel red = new ValuePixel(Rgba32.Red);
            ValuePixel white = new ValuePixel(Rgba32.White);

            BaseChain expected = new BaseChain(4);

            expected[0] = black;
            expected[1] = blue;
            expected[2] = red;
            expected[3] = white;

            Assert.AreEqual(expected, actual);

        }
    }
}
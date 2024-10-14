namespace Libiada.Core.Tests.Images;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;
using Libiada.Core.Images;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

[TestFixture]
public class ImageProcessorTests
{
    [Test]
    public void SimpleTest()
    {
        Image<Rgba32> image = new(2, 3);
        image[0, 0] = Color.Black;
        image[0, 1] = Color.White;
        image[0, 2] = Color.Black;
        image[1, 0] = Color.White;
        image[1, 1] = Color.Black;
        image[1, 2] = Color.White;

        BaseChain actual = ImageProcessor.ProcessImage(image, [], [], new LineOrderExtractor());

        ValuePixel black = new(Color.Black);
        ValuePixel white = new(Color.White);

        BaseChain expected = new(6);

        expected[0] = black;
        expected[1] = white;
        expected[2] = black;
        expected[3] = white;
        expected[4] = black;
        expected[5] = white;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void SecondSimpleTest()
    {
        Image<Rgba32> image = new(2, 2);
        image[0, 0] = Color.Gray;
        image[0, 1] = Color.Blue;
        image[1, 0] = Color.Red;
        image[1, 1] = Color.Brown;


        BaseChain actual = ImageProcessor.ProcessImage(image, [], [], new LineOrderExtractor());

        ValuePixel gray = new(Color.Gray);
        ValuePixel blue = new(Color.Blue);
        ValuePixel red = new(Color.Red);
        ValuePixel brown = new(Color.Brown);

        BaseChain expected = new(4);

        expected[0] = gray;
        expected[1] = blue;
        expected[2] = red;
        expected[3] = brown;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void ThirdSimpleTest()
    {
        Image<Rgba32> image = new(1, 4);
        image[0, 0] = Color.Gray;
        image[0, 1] = Color.Blue;
        image[0, 2] = Color.Red;
        image[0, 3] = Color.Brown;


        BaseChain actual = ImageProcessor.ProcessImage(image, [], [], new LineOrderExtractor());

        ValuePixel gray = new(Color.Gray);
        ValuePixel blue = new(Color.Blue);
        ValuePixel red = new(Color.Red);
        ValuePixel brown = new(Color.Brown);

        BaseChain expected = new(4);

        expected[0] = gray;
        expected[1] = blue;
        expected[2] = red;
        expected[3] = brown;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void FourthSimpleTest()
    {
        Image<Rgba32> image = new(4, 1);
        image[0, 0] = Color.Gray;
        image[1, 0] = Color.Blue;
        image[2, 0] = Color.Red;
        image[3, 0] = Color.Brown;


        BaseChain actual = ImageProcessor.ProcessImage(image, [], [], new LineOrderExtractor());

        ValuePixel gray = new(Color.Gray);
        ValuePixel blue = new(Color.Blue);
        ValuePixel red = new(Color.Red);
        ValuePixel brown = new(Color.Brown);

        BaseChain expected = new(4);

        expected[0] = gray;
        expected[1] = blue;
        expected[2] = red;
        expected[3] = brown;

        Assert.That(actual, Is.EqualTo(expected));
    }
}

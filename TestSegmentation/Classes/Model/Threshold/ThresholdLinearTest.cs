using NUnit.Framework;
using Segmentation.Classes.Model.Criterion;
using Segmentation.Classes.Model.Threshold;

namespace TestSegmentation.Classes.Model.Threshold
{
    [TestFixture]
    public class ThresholdLinearTest
    {
        [Test]
        public void testNext()
        {
            double left = 0;
            double right = 1;
            double step = 0.10;
            double current;
            double[] steps = {1.0, 0.9, 0.8, 0.7, 0.6, 0.5, 0.4, 0.3, 0.2, 0.1, 0.0};
            int index = 0;
            Criterion criterion = null;
            ThresholdLinear threshold = null;
            threshold = new ThresholdLinear(left, right, step);

            while ((current = threshold.next(criterion)) > 0)
            {
                Assert.True((current - steps[index++]) < step);
            }
        }
    }
}
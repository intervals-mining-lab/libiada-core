namespace Libiada.Segmenter.Tests.Model.Threshold;

using NUnit.Framework;

using Segmenter.Model.Criterion;
using Segmenter.Model.Threshold;

/// <summary>
/// The threshold linear test.
/// </summary>
[TestFixture]
public class ThresholdLinearTests
{
    /// <summary>
    /// The next test.
    /// </summary>
    [Test]
    public void NextTest()
    {
        double left = 0;
        double right = 1;
        double step = 0.10;
        double current;
        double[] steps = { 1.0, 0.9, 0.8, 0.7, 0.6, 0.5, 0.4, 0.3, 0.2, 0.1, 0.0 };
        int index = 0;
        Criterion criterion = null;
        var threshold = new ThresholdLinear(left, right, step);

        while ((current = threshold.Next(criterion)) > 0)
        {
            Assert.True((current - steps[index++]) < step);
        }
    }
}

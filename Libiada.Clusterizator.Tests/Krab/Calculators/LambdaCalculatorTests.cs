namespace Libiada.Clusterizator.Tests.Krab.Calculators;

using Clusterizator.Krab;
using Clusterizator.Krab.Calculators;

/// <summary>
/// The lambda calculator test.
/// </summary>
[TestFixture]
public class LambdaCalculatorTests
{
    /// <summary>
    /// The three points test.
    /// </summary>
    [Test]
    public void ThreePointsTest()
    {
        GraphElement node1 = new([15.0], "node1");
        GraphElement node2 = new([10.0], "node2");
        GraphElement node3 = new([-3.0], "node3");

        List<GraphElement> el = [node1, node2, node3];

        Connection conn1 = new(0, 1);
        Connection conn2 = new(0, 2);
        Connection conn3 = new(1, 2);

        List<Connection> graph = [conn1, conn2, conn3];

        GraphManager gm = new(graph, el);

        ICalculator calculator = new LinearCalculator();
        calculator.Calculate(gm);
        calculator = new NormalizedLinearCalculator();
        calculator.Calculate(gm);
        calculator = new TauStarCalculator();
        calculator.Calculate(gm);
        calculator = new TauCalculator();
        calculator.Calculate(gm);
        LambdaCalculator lambdaCalculator = new();
        lambdaCalculator.Calculate(gm, 2, 1);

        Assert.Multiple(() =>
        {
            Assert.That(gm.Connections[0].Lambda, Is.EqualTo(0.057).Within(0.0001d));
            Assert.That(gm.Connections[1].Lambda, Is.EqualTo(18));
            Assert.That(gm.Connections[2].Lambda, Is.EqualTo(6.78).Within(0.001d));
        });
    }

    /// <summary>
    /// The three points 3 d test.
    /// </summary>
    [Test]
    public void ThreePoints3DTest()
    {
        GraphElement node1 = new([15.0, 1.0, -20.0], "node1");
        GraphElement node2 = new([0.0, -3.0, -4.0], "node2");
        GraphElement node3 = new([15.0, 1.0, -25.0], "node3");

        List<GraphElement> el = [node1, node2, node3];

        Connection conn1 = new(0, 1);
        Connection conn2 = new(0, 2);
        Connection conn3 = new(1, 2);

        List<Connection> graph = [conn1, conn2, conn3];

        GraphManager gm = new(graph, el);

        ICalculator calculator = new LinearCalculator();
        calculator.Calculate(gm);
        calculator = new NormalizedLinearCalculator();
        calculator.Calculate(gm);
        calculator = new TauStarCalculator();
        calculator.Calculate(gm);
        calculator = new TauCalculator();
        calculator.Calculate(gm);
        LambdaCalculator lambdaCalculator = new();
        lambdaCalculator.Calculate(gm, 2, 1);

        Assert.Multiple(() =>
        {
            Assert.That(gm.Connections[0].Lambda, Is.EqualTo(16.25).Within(0.01d));
            Assert.That(gm.Connections[1].Lambda, Is.EqualTo(0.009).Within(0.001d));
            Assert.That(gm.Connections[2].Lambda, Is.EqualTo(26.12).Within(0.01d));
        });
    }
}

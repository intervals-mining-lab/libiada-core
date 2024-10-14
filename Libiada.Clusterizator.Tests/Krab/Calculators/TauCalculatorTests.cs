namespace Libiada.Clusterizator.Tests.Krab.Calculators;

using Clusterizator.Krab;
using Clusterizator.Krab.Calculators;

/// <summary>
/// The tau calculator test.
/// </summary>
[TestFixture]
public class TauCalculatorTests
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

        Assert.Multiple(() =>
        {
            Assert.That(gm.Connections[0].Tau, Is.EqualTo(0.107).Within(0.001d));
            Assert.That(gm.Connections[1].Tau, Is.EqualTo(1));
            Assert.That(gm.Connections[2].Tau, Is.EqualTo(0.722).Within(0.001d));
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

        Assert.Multiple(() =>
        {
            Assert.That(gm.Connections[0].Tau, Is.EqualTo(0.854).Within(0.001d));
            Assert.That(gm.Connections[1].Tau, Is.EqualTo(0.043).Within(0.001d));
            Assert.That(gm.Connections[2].Tau, Is.EqualTo(1));
        });
    }
}

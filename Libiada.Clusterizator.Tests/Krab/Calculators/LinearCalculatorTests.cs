namespace Libiada.Clusterizator.Tests.Krab.Calculators;

using Clusterizator.Krab;
using Clusterizator.Krab.Calculators;

/// <summary>
/// The linear calculator test.
/// </summary>
[TestFixture]
public class LinearCalculatorTests
{
    /// <summary>
    /// The two points test.
    /// </summary>
    [Test]
    public void TwoPointsTest()
    {
        GraphElement node1 = new([15.0], "node1");
        GraphElement node2 = new([15.0], "node2");

        List<GraphElement> el = [node1, node2];

        Connection conn1 = new(0, 1);
        List<Connection> con = [conn1];

        GraphManager gm = new(con, el);

        LinearCalculator calculator = new();
        calculator.Calculate(gm);
        Assert.That(gm.Connections[0].Distance, Is.Zero);
    }

    /// <summary>
    /// The two integer points test.
    /// </summary>
    [Test]
    public void TwoIntPointsTest()
    {
        GraphElement node1 = new([15.0], "node1");
        GraphElement node2 = new([15.0], "node2");
        List<GraphElement> el = [node1, node2];

        Connection conn1 = new(0, 1);
        List<Connection> con = [conn1];

        GraphManager gm = new(con, el);

        LinearCalculator calculator = new();
        calculator.Calculate(gm);
        Assert.That(gm.Connections[0].Distance, Is.Zero);
    }

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
        Connection conn2 = new(1, 2);
        Connection conn3 = new(0, 2);

        List<Connection> con = [conn1, conn2, conn3];

        GraphManager gm = new(con, el);

        LinearCalculator calculator = new();
        calculator.Calculate(gm);

        Assert.Multiple(() =>
        {
            Assert.That(gm.Connections[0].Distance, Is.EqualTo(5));
            Assert.That(gm.Connections[1].Distance, Is.EqualTo(13));
            Assert.That(gm.Connections[2].Distance, Is.EqualTo(18));
        });
    }

    /// <summary>
    /// The two points 3 d test.
    /// </summary>
    [Test]
    public void TwoPoints3DTest()
    {
        GraphElement node1 = new([15.0, 1.0, -20.0], "node1");
        GraphElement node2 = new([0.0, -3.0, -4.0], "node2");

        List<GraphElement> el = [node1, node2];

        Connection conn1 = new(0, 1);

        List<Connection> con = [conn1];

        GraphManager gm = new(con, el);

        LinearCalculator calculator = new();
        calculator.Calculate(gm);

        Assert.That(gm.Connections[0].Distance, Is.EqualTo(22.293).Within(0.001d));
    }

    /// <summary>
    /// The three points 3 d test.
    /// </summary>
    [Test]
    public void ThreePoints3DTest()
    {
        GraphElement node1 = new([15.0, 1.0, -20.0], "node1");
        GraphElement node2 = new([0.0, -3.0, -4.0], "node2");
        GraphElement node3 = new([15.0, 1.0, -20.0], "node3");

        List<GraphElement> el = [node1, node2, node3];

        Connection conn1 = new(0, 1);
        Connection conn2 = new(0, 2);
        Connection conn3 = new(1, 2);
        List<Connection> con = [conn1, conn2, conn3];

        GraphManager gm = new(con, el);

        LinearCalculator calculator = new();
        calculator.Calculate(gm);

        Assert.Multiple(() =>
        {
            Assert.That(gm.Connections[0].Distance, Is.EqualTo(22.293).Within(0.001d));
            Assert.That(gm.Connections[1].Distance, Is.Zero);
            Assert.That(gm.Connections[2].Distance, Is.EqualTo(22.293).Within(0.001d));
        });
    }
}

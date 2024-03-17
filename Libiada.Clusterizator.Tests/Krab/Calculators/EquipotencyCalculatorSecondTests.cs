namespace Libiada.Clusterizator.Tests.Krab.Calculators;

using Libiada.Clusterizator.Krab.Calculators;
using Libiada.Clusterizator.Krab;

/// <summary>
/// The equipotency calculator second test.
/// </summary>
[TestFixture]
public class EquipotencyCalculatorSecondTests
{
    /// <summary>
    /// The manager.
    /// </summary>
    private GraphManager manager;

    /// <summary>
    /// Test initialization method.
    /// </summary>
    [SetUp]
    public void Initialization()
    {
        List<GraphElement> elements =
        [
            new GraphElement([0.0, 10.0], "1"),
            new GraphElement([2.0, 15.0], "2"),
            new GraphElement([5.0, 25.0], "3"),
            new GraphElement([6.0, 15.0], "4"),
            new GraphElement([6.0, 18.0], "5")
        ];

        List<Connection> connections =
        [
            new Connection(0, 1),
            new Connection(0, 2),
            new Connection(0, 3),
            new Connection(0, 4),
            new Connection(1, 2),
            new Connection(1, 3),
            new Connection(1, 4),
            new Connection(2, 3),
            new Connection(2, 4),
            new Connection(3, 4)
        ];

        manager = new GraphManager(connections, elements);
    }

    /// <summary>
    /// The four points zero test.
    /// </summary>
    [Test]
    public void FourPointsZeroTest()
    {
        bool[] connected = [true, false, false, false, true, false, false, true, false, false];

        for (int i = 0; i < connected.Length; i++)
        {
            manager.Connections[i].Connected = connected[i];
        }

        int[] taxonNumbers = [1, 1, 1, 1, 2];

        for (int i = 0; i < taxonNumbers.Length; i++)
        {
            manager.Elements[i].TaxonNumber = taxonNumbers[i];
        }

        double d = EquipotencyCalculator.Calculate(manager);
        d = Math.Round(d * 100) / 100;
        Assert.That(d, Is.EqualTo(0.64));
    }

    /// <summary>
    /// The four points one test.
    /// </summary>
    [Test]
    public void FourPointsOneTest()
    {
        bool[] connected = [true, false, false, false, false, false, false, false, false, true];

        for (int i = 0; i < connected.Length; i++)
        {
            manager.Connections[i].Connected = connected[i];
        }

        int[] taxonNumbers = [1, 1, 3, 2, 2];

        for (int i = 0; i < taxonNumbers.Length; i++)
        {
            manager.Elements[i].TaxonNumber = taxonNumbers[i];
        }

        double d = EquipotencyCalculator.Calculate(manager);
        d = Math.Round(d * 100) / 100;
        Assert.That(d, Is.EqualTo(0.86));
    }

    /// <summary>
    /// The four points six test.
    /// </summary>
    [Test]
    public void FourPointsSixTest()
    {
        for (int i = 0; i < 6; i++)
        {
            manager.Connections[i].Connected = false;
        }

        for (int i = 0; i < 4; i++)
        {
            manager.Elements[i].TaxonNumber = i + 1;
        }

        Assert.That(EquipotencyCalculator.Calculate(manager), Is.EqualTo(1));
    }
}

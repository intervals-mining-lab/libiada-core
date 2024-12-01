namespace Libiada.Clusterizator.Tests.Krab.Calculators;

using Clusterizator.Krab;
using Clusterizator.Krab.Calculators;

/// <summary>
/// The equipotency calculator test.
/// </summary>
[TestFixture]
public class EquipotencyCalculatorTests
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
                               new([0.0], "1"),
                               new([2.0], "2"),
                               new([5.0], "3"),
                               new([6.0], "4")
                           ];

        List<Connection> connections =
        [
                                  new(0, 1),
                                  new(0, 2),
                                  new(0, 3),
                                  new(1, 2),
                                  new(1, 3),
                                  new(2, 3)
                              ];

        manager = new GraphManager(connections, elements);
    }

    /// <summary>
    /// The four points zero test.
    /// </summary>
    [Test]
    public void FourPointsZeroTest()
    {
        bool[] connected = [true, false, false, true, false, false];

        for (int i = 0; i < connected.Length; i++)
        {
            manager.Connections[i].Connected = connected[i];
        }

        int[] taxonNumbers = [1, 1, 1, 2];

        for (int i = 0; i < taxonNumbers.Length; i++)
        {
            manager.Elements[i].TaxonNumber = taxonNumbers[i];
        }

        Assert.That(EquipotencyCalculator.Calculate(manager), Is.EqualTo(0.75));
    }

    /// <summary>
    /// The four points one test.
    /// </summary>
    [Test]
    public void FourPointsOneTest()
    {
        bool[] connected = [true, false, false, false, false, true];

        for (int i = 0; i < connected.Length; i++)
        {
            manager.Connections[i].Connected = connected[i];
        }

        int[] taxonNumbers = [1, 1, 2, 2];

        for (int i = 0; i < taxonNumbers.Length; i++)
        {
            manager.Elements[i].TaxonNumber = taxonNumbers[i];
        }

        Assert.That(EquipotencyCalculator.Calculate(manager), Is.EqualTo(1));
    }

    /// <summary>
    /// The four points two test.
    /// </summary>
    [Test]
    public void FourPointsTwoTest()
    {
        bool[] connected = [false, false, false, true, false, true];

        for (int i = 0; i < connected.Length; i++)
        {
            manager.Connections[i].Connected = connected[i];
        }

        int[] taxonNumbers = [1, 2, 2, 2];

        for (int i = 0; i < taxonNumbers.Length; i++)
        {
            manager.Elements[i].TaxonNumber = taxonNumbers[i];
        }

        Assert.That(EquipotencyCalculator.Calculate(manager), Is.EqualTo(0.75));
    }

    /// <summary>
    /// The four points three test.
    /// </summary>
    [Test]
    public void FourPointsThreeTest()
    {
        bool[] connected = [true, false, false, false, false, false];

        for (int i = 0; i < connected.Length; i++)
        {
            manager.Connections[i].Connected = connected[i];
        }

        int[] taxonNumbers = [1, 1, 2, 3];

        for (int i = 0; i < taxonNumbers.Length; i++)
        {
            manager.Elements[i].TaxonNumber = taxonNumbers[i];
        }

        Assert.That(EquipotencyCalculator.Calculate(manager), Is.EqualTo(0.84375));
    }

    /// <summary>
    /// The four points four test.
    /// </summary>
    [Test]
    public void FourPointsFourTest()
    {
        bool[] connected = [false, false, false, true, false, false];

        for (int i = 0; i < connected.Length; i++)
        {
            manager.Connections[i].Connected = connected[i];
        }

        int[] taxonNumbers = [1, 2, 2, 3];

        for (int i = 0; i < taxonNumbers.Length; i++)
        {
            manager.Elements[i].TaxonNumber = taxonNumbers[i];
        }

        Assert.That(EquipotencyCalculator.Calculate(manager), Is.EqualTo(0.84375));
    }

    /// <summary>
    /// The four points five test.
    /// </summary>
    [Test]
    public void FourPointsFiveTest()
    {
        bool[] connected = [false, false, false, true, false, true];

        for (int i = 0; i < connected.Length; i++)
        {
            manager.Connections[i].Connected = connected[i];
        }

        int[] taxonNumbers = [1, 2, 3, 3];

        for (int i = 0; i < taxonNumbers.Length; i++)
        {
            manager.Elements[i].TaxonNumber = taxonNumbers[i];
        }

        Assert.That(EquipotencyCalculator.Calculate(manager) ,Is.EqualTo(0.84375));
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

    /// <summary>
    /// The four points seven test.
    /// </summary>
    [Test]
    public void FourPointsSevenTest()
    {
        bool[] connected = [false, true, false, false, true, false];

        for (int i = 0; i < connected.Length; i++)
        {
            manager.Connections[i].Connected = connected[i];
        }

        int[] taxonNumbers = [1, 2, 1, 2];

        for (int i = 0; i < taxonNumbers.Length; i++)
        {
            manager.Elements[i].TaxonNumber = taxonNumbers[i];
        }

        Assert.That(EquipotencyCalculator.Calculate(manager), Is.EqualTo(1));
    }

    /// <summary>
    /// The four points eleven test.
    /// </summary>
    [Test]
    public void FourPointsElevenTest()
    {
        bool[] connected = [false, true, false, false, true, false];

        for (int i = 0; i < connected.Length; i++)
        {
            manager.Connections[i].Connected = connected[i];
        }

        int[] taxonNumbers = [1, 2, 1, 2];

        for (int i = 0; i < taxonNumbers.Length; i++)
        {
            manager.Elements[i].TaxonNumber = taxonNumbers[i];
        }

        Assert.That(EquipotencyCalculator.Calculate(manager), Is.EqualTo(1));
    }
}

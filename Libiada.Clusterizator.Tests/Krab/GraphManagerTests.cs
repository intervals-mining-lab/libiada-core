namespace Libiada.Clusterizator.Tests.Krab;

using Clusterizator.Krab;

/// <summary>
/// The graph manager test.
/// </summary>
[TestFixture]
public class GraphManagerTests
{
    /// <summary>
    /// The connections list.
    /// </summary>
    private List<Connection> connectionsList;

    /// <summary>
    /// The elements list.
    /// </summary>
    private List<GraphElement> elementsList;

    /// <summary>
    /// Test initialization method.
    /// </summary>
    [SetUp]
    public void Initialization()
    {
        elementsList = [
                            new GraphElement([2.0, 3.0], "1"),
                            new GraphElement([3.0, 5.0], "2"),
                            new GraphElement([6.0, 2.0], "3"),
                            new GraphElement([6.0, 5.0], "4"),
                            new GraphElement([7.0, 4.0], "5"),
                            new GraphElement([8.0, 3.0], "6")
                       ];

        connectionsList = [
                            new Connection(0, 1),
                            new Connection(0, 2),
                            new Connection(0, 3),
                            new Connection(0, 4),
                            new Connection(0, 5),
                            new Connection(1, 2),
                            new Connection(1, 3),
                            new Connection(1, 4),
                            new Connection(1, 5),
                            new Connection(2, 3),
                            new Connection(2, 4),
                            new Connection(2, 5),
                            new Connection(3, 4),
                            new Connection(3, 5),
                            new Connection(4, 5)
                          ];

        connectionsList[0].Connected = true;
        connectionsList[14].Connected = true;
        elementsList[0].TaxonNumber = 1;
        elementsList[1].TaxonNumber = 1;
        elementsList[4].TaxonNumber = 2;
        elementsList[5].TaxonNumber = 2;
    }

    /// <summary>
    /// The un connected graphs test.
    /// </summary>
    [Test]
    public void UnConnectedGraphsTest()
    {
        GraphManager connector = new(connectionsList, elementsList);
        connector.Connect(2, 3);

        Assert.That(connectionsList[9].Connected, Is.True);
        Assert.That(elementsList[2].TaxonNumber, Is.EqualTo(3));
        Assert.That(elementsList[3].TaxonNumber, Is.EqualTo(3));
    }

    /// <summary>
    /// The search connection test.
    /// </summary>
    [Test]
    public void SearchConnectionTest()
    {
        GraphManager connector = new(connectionsList, elementsList);
        Assert.That(connector.SearchConnection(elementsList[0], elementsList[0]), Is.EqualTo(-1));
        Assert.That(connector.SearchConnection(elementsList[4], elementsList[4]), Is.EqualTo(-1));
        Assert.That(connector.SearchConnection(elementsList[0], elementsList[1]), Is.Zero);
        Assert.That(connector.SearchConnection(elementsList[1], elementsList[0]), Is.Zero);
        Assert.That(connector.SearchConnection(elementsList[4], elementsList[5]), Is.EqualTo(14));
        Assert.That(connector.SearchConnection(elementsList[5], elementsList[4]), Is.EqualTo(14));
        Assert.That(connector.SearchConnection(elementsList[1], elementsList[0]), Is.Zero);
    }

    /// <summary>
    /// The one connected graph test.
    /// </summary>
    [Test]
    public void OneConnectedGraphTest()
    {
        GraphManager connector = new(connectionsList, elementsList);
        connector.Connect(0, 2);

        Assert.That(connectionsList[1].Connected, Is.True);
        Assert.That(elementsList[0].TaxonNumber, Is.EqualTo(1));
        Assert.That(elementsList[1].TaxonNumber, Is.EqualTo(1));
        Assert.That(elementsList[2].TaxonNumber, Is.EqualTo(1));
    }

    /// <summary>
    /// The both connection graph test.
    /// </summary>
    [Test]
    public void BothConnectionGraphTest()
    {
        GraphManager connector = new(connectionsList, elementsList);
        connector.Connect(1, 5);
        Assert.That(connectionsList[8].Connected, Is.True);
        Assert.That(elementsList[0].TaxonNumber, Is.EqualTo(1));
        Assert.That(elementsList[1].TaxonNumber, Is.EqualTo(1));
        Assert.That(elementsList[4].TaxonNumber, Is.EqualTo(1));
        Assert.That(elementsList[5].TaxonNumber, Is.EqualTo(1));
    }

    /// <summary>
    /// The un both connection graph test.
    /// </summary>
    [Test]
    public void UnBothConnectionGraphTest()
    {
        GraphManager connector = new(connectionsList, elementsList);
        connectionsList[1].Connected = true;
        elementsList[2].TaxonNumber = 1;
        connector.Connect(1, 2);

        Assert.That(connectionsList[5].Connected, Is.False);
        Assert.That(elementsList[0].TaxonNumber, Is.EqualTo(1));
        Assert.That(elementsList[1].TaxonNumber, Is.EqualTo(1));
        Assert.That(elementsList[2].TaxonNumber, Is.EqualTo(1));
    }

    /// <summary>
    /// The cut graph test.
    /// </summary>
    [Test]
    public void CutGraphTest()
    {
        GraphManager connector = new(connectionsList, elementsList);
        connector.Cut(elementsList[0], elementsList[1]);

        Assert.That(connectionsList[0].Connected, Is.False);
        Assert.That(elementsList[0].TaxonNumber, Is.EqualTo(3));
        Assert.That(elementsList[1].TaxonNumber, Is.EqualTo(1));
        Assert.That(elementsList[4].TaxonNumber, Is.EqualTo(2));
        Assert.That(elementsList[5].TaxonNumber, Is.EqualTo(2));
    }

    /// <summary>
    /// The cut graph trio test.
    /// </summary>
    [Test]
    public void CutGraphTrioTest()
    {
        GraphManager connector = new(connectionsList, elementsList);
        connectionsList[1].Connected = true;
        elementsList[2].TaxonNumber = 1;
        connector.Cut(elementsList[0], elementsList[2]);

        Assert.That(connectionsList[1].Connected, Is.False);
        Assert.That(elementsList[0].TaxonNumber, Is.EqualTo(3));
        Assert.That(elementsList[1].TaxonNumber, Is.EqualTo(3));
        Assert.That(elementsList[2].TaxonNumber, Is.EqualTo(1));
    }

    /// <summary>
    /// The clone test.
    /// </summary>
    [Test]
    public void CloneTest()
    {
        GraphManager connector = new(connectionsList, elementsList);
        GraphManager connector2 = connector.Clone();

        Assert.That(connector2, Is.TypeOf(typeof(GraphManager)));
        Assert.That(connector2.Connections[0], Is.TypeOf(typeof(Connection)));
        Assert.That(connector2.Elements[1], Is.TypeOf(typeof(GraphElement)));
        Assert.That(connector, Is.Not.SameAs(connector2));
        Assert.That(connector.Elements[0], Is.Not.SameAs(connector2.Elements[0]));
        Assert.That(connector.Connections[1], Is.Not.SameAs(connector2.Connections[1]));
    }

    /// <summary>
    /// The graph connection test.
    /// </summary>
    [Test]
    public void GraphConnectionTest()
    {
        connectionsList[0].Connected = false;
        connectionsList[14].Connected = false;

        for (int i = 0; i < connectionsList.Count; i++)
        {
            elementsList[connectionsList[i].FirstElementIndex].TaxonNumber = 0;
            elementsList[connectionsList[i].SecondElementIndex].TaxonNumber = 0;
        }

        int[] lambdas = [10, 20, 15, 21, 6, 11, 12, 27, 16, 9, 25, 26, 13, 21, 22];

        for (int i = 0; i < lambdas.Length; i++)
        {
            connectionsList[i].Lambda = lambdas[i];
        }

        GraphManager connector = new(connectionsList, elementsList);
        connector.ConnectGraph();

        Assert.That(connectionsList[0].Connected, Is.True);
        Assert.That(connectionsList[4].Connected, Is.True);
        Assert.That(connectionsList[5].Connected, Is.True);
        Assert.That(connectionsList[9].Connected, Is.True);
        Assert.That(connectionsList[12].Connected, Is.True);
        Assert.That(connectionsList[1].Connected, Is.False);
        Assert.That(connectionsList[2].Connected, Is.False);
        Assert.That(connectionsList[3].Connected, Is.False);
        Assert.That(connectionsList[6].Connected, Is.False);
        Assert.That(connectionsList[7].Connected, Is.False);
        Assert.That(connectionsList[8].Connected, Is.False);
        Assert.That(connectionsList[10].Connected, Is.False);
        Assert.That(connectionsList[11].Connected, Is.False);
        Assert.That(connectionsList[13].Connected, Is.False);
        Assert.That(connectionsList[14].Connected, Is.False);
    }

    /// <summary>
    /// The cut connection test.
    /// </summary>
    [Test]
    public void CutConnectionTest()
    {
        GraphManager connector = new(connectionsList, elementsList);
        connector.Cut(connector.Connections[0]);

        Assert.That(connectionsList[0].Connected, Is.False);
        Assert.That(elementsList[0].TaxonNumber, Is.EqualTo(3));
        Assert.That(elementsList[1].TaxonNumber, Is.EqualTo(1));
        Assert.That(elementsList[4].TaxonNumber, Is.EqualTo(2));
        Assert.That(elementsList[5].TaxonNumber, Is.EqualTo(2));
    }

    /// <summary>
    /// The cut connection trio test.
    /// </summary>
    [Test]
    public void CutConnectionTrioTest()
    {
        GraphManager connector = new(connectionsList, elementsList);
        connectionsList[1].Connected = true;
        elementsList[2].TaxonNumber = 1;
        connector.Cut(connector.Connections[1]);

        Assert.That(connectionsList[1].Connected, Is.False);
        Assert.That(elementsList[0].TaxonNumber, Is.EqualTo(3));
        Assert.That(elementsList[1].TaxonNumber, Is.EqualTo(3));
        Assert.That(elementsList[2].TaxonNumber, Is.EqualTo(1));
    }
}

namespace Libiada.Clusterizator.Tests.Krab;

using Clusterizator.Krab;

/// <summary>
/// The connection test.
/// </summary>
[TestFixture]
public class ConnectionTests
{
    /// <summary>
    /// The connection one test.
    /// </summary>
    [Test]
    public void ConnectionOneTest()
    {
        Connection connection = new(0, 1);
        Assert.That(connection.Connected, Is.False);
    }

    /// <summary>
    /// The clone one test.
    /// </summary>
    [Test]
    public void CloneOneTest()
    {
        Connection connection = new(2, 5)
                        {
                            Connected = false,
                            Distance = 6,
                            NormalizedDistance = 0.5,
                            Tau = 3,
                            TauStar = 7,
                            Lambda = 13
                        };
        Connection secondConnection = connection.Clone();
        Assert.Multiple(() =>
        {
            Assert.That(connection.Connected, Is.EqualTo(secondConnection.Connected));
            Assert.That(connection.FirstElementIndex, Is.EqualTo(secondConnection.FirstElementIndex));
            Assert.That(connection.SecondElementIndex, Is.EqualTo(secondConnection.SecondElementIndex));
            Assert.That(connection.Distance, Is.EqualTo(secondConnection.Distance));
            Assert.That(connection.NormalizedDistance, Is.EqualTo(secondConnection.NormalizedDistance));
            Assert.That(connection.Tau, Is.EqualTo(secondConnection.Tau));
            Assert.That(connection.TauStar, Is.EqualTo(secondConnection.TauStar));
            Assert.That(connection.Lambda, Is.EqualTo(secondConnection.Lambda));
            Assert.That(secondConnection, Is.TypeOf(typeof(Connection)));
            Assert.That(secondConnection, Is.Not.SameAs(connection));
        });
        
    }

    /// <summary>
    /// The clone two test.
    /// </summary>
    [Test]
    public void CloneTwoTest()
    {
        Connection connection = new(2, 3)
                        {
                            Connected = true,
                            Distance = 1,
                            NormalizedDistance = 0.1,
                            Tau = 44,
                            TauStar = 0,
                            Lambda = 5
                        };
        Connection secondConnection = connection.Clone();
        Assert.Multiple(() =>
        {
            Assert.That(connection.Connected, Is.EqualTo(secondConnection.Connected));
            Assert.That(connection.FirstElementIndex, Is.EqualTo(secondConnection.FirstElementIndex));
            Assert.That(connection.SecondElementIndex, Is.EqualTo(secondConnection.SecondElementIndex));
            Assert.That(connection.Distance, Is.EqualTo(secondConnection.Distance));
            Assert.That(connection.NormalizedDistance, Is.EqualTo(secondConnection.NormalizedDistance));
            Assert.That(connection.Tau, Is.EqualTo(secondConnection.Tau));
            Assert.That(connection.TauStar, Is.EqualTo(secondConnection.TauStar));
            Assert.That(connection.Lambda, Is.EqualTo(secondConnection.Lambda));
            Assert.That(secondConnection, Is.TypeOf(typeof(Connection)));
            Assert.That(secondConnection, Is.Not.SameAs(connection));
        });
    }
}

namespace Libiada.Clusterizator.Tests.Krab;

using Clusterizator.Krab;

/// <summary>
/// The graph element test.
/// </summary>
[TestFixture]
public class GraphElementTests
{
    /// <summary>
    /// The node test.
    /// </summary>
    [Test]
    public void NodeTest()
    {
        GraphElement node = new([15.0], "node");

        Assert.That(node.Content[0], Is.EqualTo(15));
        Assert.That(node.TaxonNumber, Is.Zero);
    }

    /// <summary>
    /// The node two test.
    /// </summary>
    [Test]
    public void NodeTwoTest()
    {
        GraphElement node = new([15.0], 1) { TaxonNumber = 5 };

        Assert.That(node.Content[0], Is.EqualTo(15));

        node.Content = [-8.0];

        Assert.That(node.Content[0], Is.EqualTo(-8));
        Assert.That(node.TaxonNumber, Is.EqualTo(5));

        node.TaxonNumber = -5;
        Assert.That(node.TaxonNumber, Is.EqualTo(5));
    }

    /// <summary>
    /// The clone test.
    /// </summary>
    [Test]
    public void CloneTest()
    {
        GraphElement node = new([15.0], "node");
        GraphElement nodeClone = node.Clone();

        Assert.Multiple(() =>
        {
            Assert.That(nodeClone.Content, Is.EqualTo(node.Content));
            Assert.That(nodeClone.Id, Is.EqualTo(node.Id));
            Assert.That(nodeClone, Is.Not.SameAs(node));
            Assert.That(nodeClone, Is.TypeOf(typeof(GraphElement)));
        });
        
    }
}

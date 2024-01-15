namespace Libiada.Clusterizator.Tests.Krab;

using Clusterizator.Krab;

using NUnit.Framework;

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
        var node = new GraphElement(new[] { 15.0 }, "node");

        Assert.AreEqual(15, node.Content[0]);
        Assert.AreEqual(0, node.TaxonNumber);
    }

    /// <summary>
    /// The node two test.
    /// </summary>
    [Test]
    public void NodeTwoTest()
    {
        var node = new GraphElement(new[] { 15.0 }, 1) { TaxonNumber = 5 };

        Assert.AreEqual(15, node.Content[0]);

        node.Content = new[] { -8.0 };

        Assert.AreEqual(-8, node.Content[0]);

        Assert.AreEqual(5, node.TaxonNumber);

        node.TaxonNumber = -5;
        Assert.AreEqual(5, node.TaxonNumber);
    }

    /// <summary>
    /// The clone test.
    /// </summary>
    [Test]
    public void CloneTest()
    {
        var node = new GraphElement(new[] { 15.0 }, "node");
        var nodeClone = node.Clone();
        Assert.AreEqual(node.Content, nodeClone.Content);
        Assert.AreEqual(node.Id, nodeClone.Id);
        Assert.AreNotSame(node, nodeClone);
        Assert.IsInstanceOf(typeof(GraphElement), nodeClone);
    }
}

namespace Libiada.SequenceGenerator.Tests;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// The non-redundant strict sequence generator tests.
/// </summary>
[TestFixture]
public class NonRedundantStrictSequenceGeneratorTests
{
    /// <summary>
    /// The generator test.
    /// </summary>
    [Test]
    public void GeneratorTest()
    {
        ValueInt one = new(1);
        ValueInt two = new(2);
        ValueInt three = new(3);
        List<BaseChain> expected =
        [
            new(new List<IBaseObject> { two, one, one }),
            new(new List<IBaseObject> { one, two, one }),
            new(new List<IBaseObject> { two, two, one }),
            new(new List<IBaseObject> { one, one, two }),
            new(new List<IBaseObject> { two, one, two }),
            new(new List<IBaseObject> { one, two, two })
        ];
        NonRedundantStrictSequenceGenerator strictSequenceGenerator = new();
        List<BaseChain> actual = strictSequenceGenerator.GenerateSequences(3, 2);
        Assert.That(actual, Is.EqualTo(expected));
        expected =
                       [
                           new(new List<IBaseObject> { one, one, one })
                       ];
        actual = strictSequenceGenerator.GenerateSequences(3, 1);
        Assert.That(actual, Is.EqualTo(expected));
        expected =
                       [
                           new(new List<IBaseObject> { three, two, one }),
                           new(new List<IBaseObject> { two, three, one }),
                           new(new List<IBaseObject> { three, one, two }),
                           new(new List<IBaseObject> { one, three, two }),
                           new(new List<IBaseObject> { two, one, three }),
                           new(new List<IBaseObject> { one, two, three })
                       ];
        actual = strictSequenceGenerator.GenerateSequences(3, 3);
        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// The complete generator test.
    /// </summary>
    [Test]
    public void CompleteGeneratorTest()
    {
        ValueInt one = new(1);
        ValueInt two = new(2);
        ValueInt three = new(3);
        List<BaseChain> expected =
        [
            new(new List<IBaseObject> { one, one, one }),
            new(new List<IBaseObject> { two, one, one }),
            new(new List<IBaseObject> { one, two, one }),
            new(new List<IBaseObject> { two, two, one }),
            new(new List<IBaseObject> { one, one, two }),
            new(new List<IBaseObject> { two, one, two }),
            new(new List<IBaseObject> { one, two, two }),
            new(new List<IBaseObject> { three, two, one }),
            new(new List<IBaseObject> { two, three, one }),
            new(new List<IBaseObject> { three, one, two }),
            new(new List<IBaseObject> { one, three, two }),
            new(new List<IBaseObject> { two, one, three }),
            new(new List<IBaseObject> { one, two, three }),
        ];
        NonRedundantStrictSequenceGenerator strictSequenceGenerator = new();
        List<BaseChain> actual = strictSequenceGenerator.GenerateSequences(3);
        Assert.That(actual, Is.EqualTo(expected));
    }
}

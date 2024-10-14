namespace Libiada.SequenceGenerator.Tests;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// The sequence generator tests.
/// </summary>
[TestFixture]
public class SequenceGeneratorTests
{
    /// <summary>
    /// The generator test.
    /// </summary>
    [Test]
    public void GeneratorTest()
    {
        ValueInt one = new(1);
        ValueInt two = new(2);
        List<BaseChain> expected =
        [
            new(new List<IBaseObject> { one, one, one }),
            new(new List<IBaseObject> { two, one, one }),
            new(new List<IBaseObject> { one, two, one }),
            new(new List<IBaseObject> { two, two, one }),
            new(new List<IBaseObject> { one, one, two }),
            new(new List<IBaseObject> { two, one, two }),
            new(new List<IBaseObject> { one, two, two }),
            new(new List<IBaseObject> { two, two, two })
        ];
        SequenceGenerator sequenceGenerator = new();
        List<BaseChain> actual = sequenceGenerator.GenerateSequences(3, 2);
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
            new(new List<IBaseObject> { three, one, one }),
            new(new List<IBaseObject> { one, two, one }),
            new(new List<IBaseObject> { two, two, one }),
            new(new List<IBaseObject> { three, two, one }),
            new(new List<IBaseObject> { one, three, one }),
            new(new List<IBaseObject> { two, three, one }),
            new(new List<IBaseObject> { three, three, one }),
            new(new List<IBaseObject> { one, one, two }),
            new(new List<IBaseObject> { two, one, two }),
            new(new List<IBaseObject> { three, one, two }),
            new(new List<IBaseObject> { one, two, two }),
            new(new List<IBaseObject> { two, two, two }),
            new(new List<IBaseObject> { three, two, two }),
            new(new List<IBaseObject> { one, three, two }),
            new(new List<IBaseObject> { two, three, two }),
            new(new List<IBaseObject> { three, three, two }),
            new(new List<IBaseObject> { one, one, three }),
            new(new List<IBaseObject> { two, one, three }),
            new(new List<IBaseObject> { three, one, three }),
            new(new List<IBaseObject> { one, two, three }),
            new(new List<IBaseObject> { two, two, three }),
            new(new List<IBaseObject> { three, two, three }),
            new(new List<IBaseObject> { one, three, three }),
            new(new List<IBaseObject> { two, three, three }),
            new(new List<IBaseObject> { three, three, three })
        ];
        SequenceGenerator sequenceGenerator = new();
        List<BaseChain> actual = sequenceGenerator.GenerateSequences(3);
        Assert.That(actual, Is.EqualTo(expected));
    }
}

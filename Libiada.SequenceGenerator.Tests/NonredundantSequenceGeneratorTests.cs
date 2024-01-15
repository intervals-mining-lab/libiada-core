namespace Libiada.SequenceGenerator.Tests;

using System.Collections.Generic;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;

using NUnit.Framework;

/// <summary>
/// The non redundant sequence generator tests.
/// </summary>
[TestFixture]
public class NonRedundantSequenceGeneratorTests
{
    /// <summary>
    /// The generator test.
    /// </summary>
    [Test]
    public void GeneratorTest()
    {
        var one = new ValueInt(1);
        var two = new ValueInt(2);
        var expected = new List<BaseChain>
        {
            new BaseChain(new List<IBaseObject> { one, one, one }),
            new BaseChain(new List<IBaseObject> { two, one, one }),
            new BaseChain(new List<IBaseObject> { one, two, one }),
            new BaseChain(new List<IBaseObject> { two, two, one }),
            new BaseChain(new List<IBaseObject> { one, one, two }),
            new BaseChain(new List<IBaseObject> { two, one, two }),
            new BaseChain(new List<IBaseObject> { one, two, two }),
        };
        var sequenceGenerator = new NonRedundantSequenceGenerator();
        var actual = sequenceGenerator.GenerateSequences(3, 2);
        Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// The complete generator test.
    /// </summary>
    [Test]
    public void CompleteGeneratorTest()
    {
        var one = new ValueInt(1);
        var two = new ValueInt(2);
        var three = new ValueInt(3);
        var expected = new List<BaseChain>
        {
            new BaseChain(new List<IBaseObject> { one, one, one }),
            new BaseChain(new List<IBaseObject> { two, one, one }),
            new BaseChain(new List<IBaseObject> { one, two, one }),
            new BaseChain(new List<IBaseObject> { two, two, one }),
            new BaseChain(new List<IBaseObject> { three, two, one }),
            new BaseChain(new List<IBaseObject> { two, three, one }),
            new BaseChain(new List<IBaseObject> { one, one, two }),
            new BaseChain(new List<IBaseObject> { two, one, two }),
            new BaseChain(new List<IBaseObject> { three, one, two }),
            new BaseChain(new List<IBaseObject> { one, two, two }),
            new BaseChain(new List<IBaseObject> { one, three, two }),
            new BaseChain(new List<IBaseObject> { two, one, three }),
            new BaseChain(new List<IBaseObject> { one, two, three }),
        };
        var sequenceGenerator = new NonRedundantSequenceGenerator();
        var actual = sequenceGenerator.GenerateSequences(3);
        Assert.AreEqual(expected, actual);
    }
}

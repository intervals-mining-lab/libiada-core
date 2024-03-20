namespace Libiada.PhantomChains.Tests;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;
using Libiada.Core.DataTransformers;
using Libiada.Core.Iterators;

using MarkovChains.MarkovChain.Generators;
using MarkovChains.Tests.MarkovChain.Generators;

/// <summary>
/// The probability phantom chain generator tests.
/// </summary>
[TestFixture]
public class PhantomChainGeneratorTests
{
    /// <summary>
    /// The mother.
    /// </summary>
    private TestObject mother;

    /// <summary>
    /// The initialization method.
    /// </summary>
    [SetUp]
    public void Initialize()
    {
        mother = new TestObject();
    }

    /// <summary>
    /// The first test.
    /// </summary>
    [Test]
    public void FirstTest()
    {
        BaseChain resultChain = new([1, 2, 2, 1, 2, 1, 2, 1, 2, 2], [NullValue.Instance(), mother.PhantomMessageBc[1], mother.PhantomMessageA[0]]);

        PhantomChainGenerator gen = new(mother.SourceChain, new MockGenerator());
        List<BaseChain> result = gen.Generate(1);
        Assert.That(result, Has.Count.EqualTo(1));
        Assert.That(result[0], Is.EqualTo(resultChain));
    }

    /// <summary>
    /// The second test.
    /// </summary>
    [Test]
    public void SecondTest()
    {
        BaseChain resultChain = new(
            [1, 2, 1, 2, 3],
            [NullValue.Instance(), mother.PhantomMessageBc[1], mother.PhantomMessageA[0], mother.PhantomMessageBc[0]]);
        PhantomChainGenerator gen = new(mother.UnnormalizedChain, new MockGenerator());
        List<BaseChain> result = gen.Generate(1);
        Assert.That(result, Has.Count.EqualTo(1));
        Assert.That(result[0], Is.EqualTo(resultChain));
    }

    /// <summary>
    /// The third test.
    /// </summary>
    [Test]
    public void ThirdTest()
    {
        BaseChain resultChain = new(63);
        IteratorWritableStart iterator = new(resultChain);
        iterator.Reset();
        while (iterator.Next())
        {
            iterator.WriteValue(mother.PhantomMessageBc);
        }

        PhantomChainGenerator gen = new(resultChain, new SimpleGenerator());
        List<BaseChain> result = gen.Generate(3000);
        Assert.That(result, Has.Count.EqualTo(3000));
    }

    /// <summary>
    /// The fourth test.
    /// </summary>
    [Test]
    public void FourthTest()
    {
        BaseChain resultChain = new(10);
        IteratorWritableStart iterator = new(resultChain);
        iterator.Reset();
        while (iterator.Next())
        {
            iterator.WriteValue(mother.PhantomMessageBc);
        }

        PhantomChainGenerator gen = new(resultChain, new SimpleGenerator());
        List<BaseChain> res = gen.Generate(1000);
        int counter = 0;
        for (int i = 0; i < 999; i++)
        {
            for (int j = i + 1; j < 1000; j++)
            {
                if (res[i].Equals(res[j]))
                {
                    counter++;
                }
            }
        }

        Assert.That(counter, Is.EqualTo(0));
    }

    /// <summary>
    /// The sixth test.
    /// </summary>
    [Test]
    public void SixthTest()
    {
        BaseChain sourceChain = new(new List<IBaseObject>() { (ValueString)"X", (ValueString)"S", (ValueString)"C" });
        BaseChain forBuild = DnaTransformer.Decode(sourceChain);
        PhantomChainGenerator gen = new(forBuild, new SimpleGenerator());
        List<BaseChain> result = gen.Generate(1);
        Assert.That(result[0].Length, Is.EqualTo(9));
    }
}

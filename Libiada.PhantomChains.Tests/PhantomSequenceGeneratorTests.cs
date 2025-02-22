namespace Libiada.PhantomChains.Tests;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;
using Libiada.Core.DataTransformers;
using Libiada.Core.Iterators;

using MarkovChains.MarkovChain.Generators;
using MarkovChains.Tests.MarkovChain.Generators;

/// <summary>
/// The probability phantom sequence generator tests.
/// </summary>
[TestFixture]
public class PhantomSequenceGeneratorTests
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
        Sequence resultSequence = new([1, 2, 2, 1, 2, 1, 2, 1, 2, 2], [NullValue.Instance(), mother.PhantomMessageBc[1], mother.PhantomMessageA[0]]);

        PhantomSequenceGenerator gen = new(mother.SourceSequence, new MockGenerator());
        List<Sequence> result = gen.Generate(1);
        Assert.That(result, Has.Count.EqualTo(1));
        Assert.That(result[0], Is.EqualTo(resultSequence));
    }

    /// <summary>
    /// The second test.
    /// </summary>
    [Test]
    public void SecondTest()
    {
        Sequence resultSequence = new(
            [1, 2, 1, 2, 3],
            [NullValue.Instance(), mother.PhantomMessageBc[1], mother.PhantomMessageA[0], mother.PhantomMessageBc[0]]);
        PhantomSequenceGenerator gen = new(mother.UnnormalizedSequence, new MockGenerator());
        List<Sequence> result = gen.Generate(1);
        Assert.That(result, Has.Count.EqualTo(1));
        Assert.That(result[0], Is.EqualTo(resultSequence));
    }

    /// <summary>
    /// The third test.
    /// </summary>
    [Test]
    public void ThirdTest()
    {
        Sequence resultCSequence = new(63);
        IteratorWritableStart iterator = new(resultCSequence);
        iterator.Reset();
        while (iterator.Next())
        {
            iterator.WriteValue(mother.PhantomMessageBc);
        }

        PhantomSequenceGenerator gen = new(resultCSequence, new SimpleGenerator());
        List<Sequence> result = gen.Generate(3000);
        Assert.That(result, Has.Count.EqualTo(3000));
    }

    /// <summary>
    /// The fourth test.
    /// </summary>
    [Test]
    public void FourthTest()
    {
        Sequence resultSequence = new(10);
        IteratorWritableStart iterator = new(resultSequence);
        iterator.Reset();
        while (iterator.Next())
        {
            iterator.WriteValue(mother.PhantomMessageBc);
        }

        PhantomSequenceGenerator gen = new(resultSequence, new SimpleGenerator());
        List<Sequence> res = gen.Generate(1000);
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
        Sequence sourceSequence = new(new List<IBaseObject>() { (ValueString)"X", (ValueString)"S", (ValueString)"C" });
        Sequence forBuild = DnaTransformer.Decode(sourceSequence);
        PhantomSequenceGenerator gen = new(forBuild, new SimpleGenerator());
        List<Sequence> result = gen.Generate(1);
        Assert.That(result[0].Length, Is.EqualTo(9));
    }
}

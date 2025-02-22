namespace Libiada.MarkovChains.Tests.MarkovChain;

using Libiada.Core.Core;

using MarkovChains.MarkovChain;
using MarkovChains.MarkovChain.Generators;
using MarkovChains.Tests.MarkovChain.Generators;

/// <summary>
/// Tests of non congeneric markov chain.
/// Non congeneric (heterogeneous) chain is several separated markov chains (matrices)
/// each one is used on separate step.
/// </summary>
[TestFixture]
public class MarkovChainNotCongenericStaticTests
{
    /// <summary>
    /// Source sequence for teaching markov chain.
    /// </summary>
    private ComposedSequence testSequence;

    /// <summary>
    /// Another sequence for teaching markov chain.
    /// </summary>
    private ComposedSequence secondTestSequence;

    /// <summary>
    /// The initialization method.
    /// </summary>
    [SetUp]
    public void Initialize()
    {
        // Creating sequences containing 12 elements.
        testSequence = new ComposedSequence("adbaacbbaaca");
        secondTestSequence = new ComposedSequence("aaaaaabaaaba");
    }

    /// <summary>
    /// The markov chain not congeneric zero rank two test.
    /// </summary>
    [Test]
    public void MarkovChainNotCongenericZeroRankTwoTest()
    {
        // using mock of random generator
        IGenerator generator = new MockGenerator();

        // rank of markov chain is 2 (each element depends on one previous element)
        const int MarkovChainRank = 2;

        // heterogeneity is 1 (there are 2 models - for odd and even positions)
        const int NoCongenericRank = 0;

        // creating markov chain
        MarkovChainNotCongenericStatic markovChain = new(MarkovChainRank, NoCongenericRank, generator);

        // length of generated sequence
        const int Length = 30;

        // teaching markov chain (TeachingMethod.None means there is no preprocessing)
        markovChain.Teach(secondTestSequence, TeachingMethod.Cycle);

        var temp = markovChain.Generate(Length);

        /*
         * 1. Sequence a a a a a a b a a a b a
         *   first level (unconditional probability)
         *
         *    a| 10/12 (0,83333)  not more than 0,83333|
         *    b| 2/12 (0,16667)  not more than 1|
         *
         *   second level (conditional probability taking into account 1 previous element)
         *
         *    |   a  |   b  |
         * ---|------|------|
         *  a |7/9(7)|2/9(2)|
         * ---|------|------|
         *  b |1,0(1)|0,0(0)|
         * ---|------|------|
         */

        // expected result of generation
        ComposedSequence resultTheory = new("aabaabaaaaaabaabaaaaaabaabaaaa");
        // "a" 0.77;
        // "a" 0.15;
        // "b" 0.96;
        // "a" 0.61;
        // "a" 0.15;
        // "b" 0.85;
        // "a" 0.67;
        // "a" 0.51;
        // "a" 0.71;
        // "a" 0.2;
        // "a" 0.77;
        // "a" 0.15;
        // "b" 0.96;
        // "a" 0.61;
        // "a" 0.15;
        // "b" 0.85;
        // "a" 0.67;
        // "a" 0.51;
        // "a" 0.71;
        // "a" 0.2;
        // "a" 0.77;
        // "a" 0.15;
        // "b" 0.96;
        // "a" 0.61;
        // "a" 0.15;
        // "b" 0.85;
        // "a" 0.67;
        // "a" 0.51;
        // "a" 0.71;
        // "a" 0.2;

        Assert.That(resultTheory, Is.EqualTo(temp));
    }

    /// <summary>
    /// The markov chain not congeneric one rank two test.
    /// </summary>
    [Test]
    public void MarkovChainNotCongenericOneRangTwoTest()
    {
        // using mock of random generator
        IGenerator generator = new MockGenerator();

        // rank of markov chain is 2 (each element depends on one previous element)
        const int MarkovChainRank = 2;

        // heterogeneity is 1 (there are 2 models - for odd and even positions)
        const int NoCongenericRank = 1;

        // creating markov chain
        MarkovChainNotCongenericStatic markovChain = new(MarkovChainRank, NoCongenericRank, generator);

        // length of generated sequence
        const int Length = 12;

        // teaching markov chain (TeachingMethod.None means there is no preprocessing)
        markovChain.Teach(testSequence, TeachingMethod.None);

        var temp = markovChain.Generate(Length);

        /*
         * Внутри неоднородной марковской цепи существует n однородных марковских цепей. n - порядок неоднородности цепи
         * порядок данных однородных цепей равен порядку неоднородной цепи
         * однородные цепи используются по очереди как при обучении так и  при генерации.
         *
         * В данном тесте внутри неоднородной марковской цепи есть 2 однородные цепи.
         * Матрицы переходных вероятностей (в скобках указано кол-во входений при обучении) в них такие
         *
         * 1. Sequence
         *   first level (unconditional probability)
         *
         *    a| 1/2 (3) |
         *    b| 1/3 (2) |
         *    c| 1/6 (1) |
         *    d| 0 (0)   |
         *
         *   second level (conditional probability taking into account 1 previous element)
         *
         *    |   a  |   b  |  с   |  d   |
         * ---|------|------|------|------|
         *  a |0,3(1)| 0(0) |0,3(1)|0,3(1)|
         * ---|------|------|------|------|
         *  b |0,5(1)|0,5(1)| 0(0) | 0(0) |
         * ---|------|------|------|------|
         *  c | 1(1) | 0(0) | 0(0) | 0(0) |
         * ---|------|------|------|------|
         *  d | 0(0) | 0(0) | 0(0) | 0(0) |
         * ---|------|------|------|------|
         *
         * 2. Sequence
         *   first level (unconditional probability)
         *
         *    a| 2/5 (2) |
         *    b| 1/5 (1) |
         *    c| 1/5 (1) |
         *    d| 1/5 (1) |
         *
         *   second level (conditional probability taking into account 1 previous element)
         *
         *    |   a  |   b  |  с   |  d   |
         * ---|------|------|------|------|
         *  a |0,5(1)| 0(0) |0,5(1)| 0(0) |
         * ---|------|------|------|------|
         *  b | 1(1) | 0(0) | 0(0) | 0(0) |
         * ---|------|------|------|------|
         *  c | 0(0) | 1(1) | 0(0) | 0(0) |
         * ---|------|------|------|------|
         *  d | 0(0) | 1(1) | 0(0) | 0(0) |
         * ---|------|------|------|------|
         *
         *
         * During teaching pairs are added as folowing
         *   |-| |-| |-| |-| |-|   <>- In second markov chain
         * a d b a a c b b a a c a
         * |_| |_| |_| |_| |_| |_| <>- In first markov chain
         *
         */

        // expected result of generation
        ComposedSequence result = new("bacbacacaacb");
        // 1 chain. цепь вероятность по первому уровню. выпало  0,77 Получаем b
        // 2 chain. вероятность по второму уровню. выпало  0.15 Получаем a
        // 1 chain. вероятность по второму уровню. выпало  0.96 Получаем с
        // 2 chain. вероятность по второму уровню. выпало  0.61 Получаем b
        // 1 chain. вероятность по второму уровню. выпало  0.15 Получаем a
        // 2 chain. вероятность по второму уровню. выпало  0.85 Получаем c
        // 1 chain. вероятность по второму уровню. выпало  0.67 Получаем a
        // 2 chain. вероятность по второму уровню. выпало  0.51 Получаем c
        // 1 chain. вероятность по второму уровню. выпало  0.71 Получаем a
        // 2 chain. вероятность по второму уровню. выпало  0.2 Получаем a
        // 1 chain. вероятность по второму уровню. выпало  0.77 Получаем с
        // 2 chain. вероятность по второму уровню. выпало  0.15 Получаем b

        Assert.That(result, Is.EqualTo(temp));
    }

    /// <summary>
    /// The markov chain not congeneric dynamic zero rank two test.
    /// </summary>
    [Test]
    public void MarkovChainNotCongenericDynamicZeroRangTwoTest()
    {
          // using mock of random generator
        IGenerator generator = new MockGenerator();

        // rank of markov chain is 2 (each element depends on one previous element)
        int markovChainRank = 2;

        // heterogeneity is 1 (there are 2 models - for odd and even positions)
        int notCongenericRank = 0;

        // creating markov chain
        // MarkovChainNotCongenericDynamic<ComposedSequence, ComposedSequence> MarkovChain = new MarkovChainNotCongenericDynamic<ComposedSequence, ComposedSequence>(markovChainRank, notCongenericRank, generator);

        // length of generated sequence
        int length = 30;

        // teaching markov chain (TeachingMethod.None means there is no preprocessing)
        // MarkovChain.Teach(secondTestSequence, TeachingMethod.Cycle);

        // ComposedSequence Temp = MarkovChain.Generate(length);

        /*
         * 1. Sequence a a a a a a b a a a b a
         *   first level (unconditional probability)
         *
         *    a| 10/12 (0,83333) not more than 0,83333|
         *    b| 2/12 (0,16667)  not more than 1|
         *
         *   second level (conditional probability taking into account 1 previous element)
         *
         *    |   a  |   b  |
         * ---|------|------|
         *  a |7/9(7)|2/9(2)|
         * ---|------|------|
         *  b |1,0(1)|0,0(0)|
         * ---|------|------|
         */

        // expected result of generation
        ComposedSequence resultTheory = new("aabaabaaaaaabaabaaaaaabaabaaaa");
        // "a" 0.77;
        // "a" 0.15;
        // "b" 0.96;
        // "a" 0.61;
        // "a" 0.15;
        // "b" 0.85;
        // "a" 0.67;
        // "a" 0.51;
        // "a" 0.71;
        // "a" 0.2;
        // "a" 0.77;
        // "a" 0.15;
        // "b" 0.96;
        // "a" 0.61;
        // "a" 0.15;
        // "b" 0.85;
        // "a" 0.67;
        // "a" 0.51;
        // "a" 0.71;
        // "a" 0.2;
        // "a" 0.77;
        // "a" 0.15;
        // "b" 0.96;
        // "a" 0.61;
        // "a" 0.15;
        // "b" 0.85;
        // "a" 0.67;
        // "a" 0.51;
        // "a" 0.71;
        // "a" 0.2;
    }

    /// <summary>
    /// The markov chain not congeneric dynamic one rank two test.
    /// </summary>
    [Test]
    public void MarkovChainNotCongenericDynamicOneRangTwoTest()
    {
        // using mock of random generator
        IGenerator generator = new MockGenerator();

        // rank of markov chain is 2 (each element depends on one previous element)
        int markovChainRank = 2;

        // heterogeneity is 1 (there are 2 models - for odd and even positions)
        int notCongenericRank = 1;

        // creating markov chain
        // MarkovChainNotCongenericDynamic<ComposedSequence, ComposedSequence> MarkovChain = new MarkovChainNotCongenericDynamic<ComposedSequence, ComposedSequence>(markovChainRank, notCongenericRank, generator);

        // length of generated sequence
        int length = 12;

        // teaching markov chain (TeachingMethod.None means there is no preprocessing)
        // MarkovChain.Teach(testSequence, TeachingMethod.None);

        // ComposedSequence Temp = MarkovChain.Generate(length);

        /**
         * Внутри неоднородной марковской цепи существует n однородных марковских цепей. n - порядок неоднородности цепи
         * порядок данных однородных цепей равен порядку неоднородной цепи
         * однородные цепи используются по очереди как при обучении так и  при генерации.
         *
         * В данном тесте внутри неоднородной марковской цепи есть 2 однородные цепи.
         * Матрицы переходных вероятностей (в скобках указано кол-во входений при обучении) в них такие
         *
         * 1. Sequence
         *   first level (unconditional probability)
         *
         *    a| 1/2 (3) |
         *    b| 1/3 (2) |
         *    c| 1/6 (1) |
         *    d| 0 (0)   |
         *
         *   second level (conditional probability taking into account 1 previous element)
         *
         *    |   a  |   b  |  с   |  d   |
         * ---|------|------|------|------|
         *  a |0,3(1)| 0(0) |0,3(1)|0,3(1)|
         * ---|------|------|------|------|
         *  b |0,5(1)|0,5(1)| 0(0) | 0(0) |
         * ---|------|------|------|------|
         *  c | 1(1) | 0(0) | 0(0) | 0(0) |
         * ---|------|------|------|------|
         *  d | 0(0) | 0(0) | 0(0) | 0(0) |
         * ---|------|------|------|------|
         *
         * 2. Sequence
         *   first level (unconditional probability)
         *
         *    a| 2/5 (2) |
         *    b| 1/5 (1) |
         *    c| 1/5 (1) |
         *    d| 1/5 (1) |
         *
         *   second level (conditional probability taking into account 1 previous element)
         *
         *    |   a  |   b  |  с   |  d   |
         * ---|------|------|------|------|
         *  a |0,5(1)| 0(0) |0,5(1)| 0(0) |
         * ---|------|------|------|------|
         *  b | 1(1) | 0(0) | 0(0) | 0(0) |
         * ---|------|------|------|------|
         *  c | 0(0) | 1(1) | 0(0) | 0(0) |
         * ---|------|------|------|------|
         *  d | 0(0) | 1(1) | 0(0) | 0(0) |
         * ---|------|------|------|------|
         *
         *
         * During teaching pairs are added as folowing
         *   |-| |-| |-| |-| |-|   <>- In second markov chain
         * a d b a a c b b a a c a
         * |_| |_| |_| |_| |_| |_| <>- In first markov chain
         *
         */

        // expected result of generation
        ComposedSequence result = new("bacbacacaacb");
        // 1 chain. вероятность по первому уровню. выпало  0,77 Получаем b
        // 2 chain. вероятность по второму уровню. выпало  0.15 Получаем a
        // 1 chain. вероятность по второму уровню. выпало  0.96 Получаем с
        // 2 chain. вероятность по второму уровню. выпало  0.61 Получаем b
        // 1 chain. вероятность по второму уровню. выпало  0.15 Получаем a
        // 2 chain. вероятность по второму уровню. выпало  0.85 Получаем c
        // 1 chain. вероятность по второму уровню. выпало  0.67 Получаем a
        // 2 chain. вероятность по второму уровню. выпало  0.51 Получаем c
        // 1 chain. вероятность по второму уровню. выпало  0.71 Получаем a
        // 2 chain. вероятность по второму уровню. выпало  0.2 Получаем a
        // 1 chain. вероятность по второму уровню. выпало  0.77 Получаем с
        // 2 chain. вероятность по второму уровню. выпало  0.15 Получаем b
    }
}

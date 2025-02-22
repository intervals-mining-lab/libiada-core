namespace Libiada.MarkovChains.Tests.MarkovChain.Matrices.Probability;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;
using Libiada.Core.Iterators;
using Libiada.Core.SpaceReorganizers;

using MarkovChains.MarkovChain.Matrices.Absolute;
using MarkovChains.MarkovChain.Matrices.Probability;

/// <summary>
/// The iteration matrix tests.
/// </summary>
[TestFixture]
public class ProbabilityMatrixTests
{
    /// <summary>
    /// The test sequence.
    /// </summary>
    private Sequence testSequence;

    /// <summary>
    /// The alphabet.
    /// </summary>
    private Alphabet alphabet;

    /// <summary>
    /// The a.
    /// </summary>
    private ValueString a;

    /// <summary>
    /// The b.
    /// </summary>
    private ValueString b;

    /// <summary>
    /// The c.
    /// </summary>
    private ValueString c;

    /// <summary>
    /// The d.
    /// </summary>
    private ValueString d;

    /// <summary>
    /// The f.
    /// </summary>
    private ValueString f;

    /// <summary>
    /// The sequence.
    /// </summary>
    private Sequence sequence;

    /// <summary>
    /// The matrix.
    /// </summary>
    private Matrix matrix;

    /// <summary>
    /// The initialization method.
    /// </summary>
    [SetUp]
    public void Initialize()
    {
        alphabet = [];
        a = new ValueString('a');
        b = new ValueString('b');
        c = new ValueString('c');
        d = new ValueString('d');
        f = new ValueString('f');

        testSequence = new ComposedSequence("adbaacbbaaca");
    }

    /// <summary>
    /// The add length more than chain rank test.
    /// </summary>
    [Test]
    public void AddLengthMoreThanChainRankTest()
    {
        alphabet = [a, b, c, d];

        sequence = new Sequence("abb");

        matrix = new Matrix(alphabet.Cardinality, 2);
        int[] arrayCh = new int[sequence.Length];
        arrayCh[0] = alphabet.IndexOf(sequence[0]);
        arrayCh[1] = alphabet.IndexOf(sequence[1]);
        arrayCh[2] = alphabet.IndexOf(sequence[2]);
        Assert.Throws<ArgumentException>(() => matrix.Add(arrayCh));
    }

    /// <summary>
    /// The get with indexes test.
    /// </summary>
    [Test]
    public void GetWithIndexesTest()
    {
        alphabet.Add(a); // 0 => a
        alphabet.Add(b); // 1 => b
        alphabet.Add(c); // 2 => c
        alphabet.Add(d); // 3 => d

        sequence = new Sequence("ab");
        Sequence ch1 = new("cb");
        Sequence ch2 = new("ba");
        Sequence ch3 = new("bc");
        Sequence ch4 = new("ac");
        Sequence ch5 = new("b");
        Sequence ch6 = new("a");
        Sequence ch7 = new("c");

        matrix = new Matrix(alphabet.Cardinality, 2);

        int[] arrayToTeach = [alphabet.IndexOf(ch1[0]), alphabet.IndexOf(ch1[1])];
        matrix.Add(arrayToTeach);

        arrayToTeach = new int[2];
        arrayToTeach[0] = alphabet.IndexOf(ch2[0]);
        arrayToTeach[1] = alphabet.IndexOf(ch2[1]);
        matrix.Add(arrayToTeach);

        arrayToTeach = new int[2];
        arrayToTeach[0] = alphabet.IndexOf(sequence[0]);
        arrayToTeach[1] = alphabet.IndexOf(sequence[1]);
        matrix.Add(arrayToTeach);

        arrayToTeach = new int[2];
        arrayToTeach[0] = alphabet.IndexOf(ch3[0]);
        arrayToTeach[1] = alphabet.IndexOf(ch3[1]);
        matrix.Add(arrayToTeach);

        arrayToTeach = new int[2];
        arrayToTeach[0] = alphabet.IndexOf(ch1[0]);
        arrayToTeach[1] = alphabet.IndexOf(ch1[1]);
        matrix.Add(arrayToTeach);

        arrayToTeach = new int[2];
        arrayToTeach[0] = alphabet.IndexOf(ch3[0]);
        arrayToTeach[1] = alphabet.IndexOf(ch3[1]);
        matrix.Add(arrayToTeach);

        arrayToTeach = new int[2];
        arrayToTeach[0] = alphabet.IndexOf(ch1[0]);
        arrayToTeach[1] = alphabet.IndexOf(ch1[1]);
        Assert.That(matrix.FrequencyFromObject(arrayToTeach), Is.EqualTo(2));

        arrayToTeach = new int[2];
        arrayToTeach[0] = alphabet.IndexOf(ch4[0]);
        arrayToTeach[1] = alphabet.IndexOf(ch4[1]);
        Assert.That(matrix.FrequencyFromObject(arrayToTeach), Is.EqualTo(0));

        arrayToTeach = new int[1];
        arrayToTeach[0] = alphabet.IndexOf(ch5[0]);
        Assert.That(matrix.FrequencyFromObject(arrayToTeach), Is.EqualTo(3));

        arrayToTeach = new int[1];
        arrayToTeach[0] = alphabet.IndexOf(ch6[0]);
        Assert.That(matrix.FrequencyFromObject(arrayToTeach), Is.EqualTo(1));

        arrayToTeach = new int[1];
        arrayToTeach[0] = alphabet.IndexOf(ch7[0]);
        Assert.That(matrix.FrequencyFromObject(arrayToTeach), Is.EqualTo(2));
    }

    /// <summary>
    /// The get third level chain test.
    /// </summary>
    [Test]
    public void GetThirdLevelChainTest()
    {
        matrix = new Matrix(testSequence.Alphabet.Cardinality, 3);

        NullCycleSpaceReorganizer reorganizer = new(2);
        testSequence = (Sequence)reorganizer.Reorganize(testSequence);

        IteratorStart it = new(testSequence, 3, 1);
        while (it.Next())
        {
            var currentSequence = it.Current();
            var arrayToTeach = new int[currentSequence.Length];
            for (var i = 0; i < currentSequence.Length; i++)
            {
                arrayToTeach[i] = testSequence.Alphabet.IndexOf(currentSequence[i]);
            }

            matrix.Add(arrayToTeach);
        }

        int[] toGet = [testSequence.Alphabet.IndexOf((ValueString)"a")];
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(6));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"b");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(3));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"c");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(2));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"d");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(1));

        toGet = new int[2];

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"a");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"a");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(3));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"a");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"b");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"a");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"c");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(2));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"a");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"d");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(1));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"b");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"a");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(2));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"b");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"b");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(1));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"b");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"c");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"b");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"d");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"c");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"a");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(1));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"c");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"b");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(1));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"c");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"c");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"c");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"d");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"d");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"a");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"d");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"b");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(1));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"d");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"c");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"d");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"d");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet = new int[3];

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"a");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"a");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"c");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(2));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"a");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"a");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"d");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(1));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"a");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"c");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"a");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(1));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"a");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"c");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"b");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(1));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"a");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"d");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"b");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(1));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"a");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"b");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"b");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"b");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"a");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"a");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(2));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"b");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"a");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"c");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"b");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"b");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"a");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(1));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"b");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"c");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"b");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"b");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"d");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"b");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"b");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"b");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"b");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"c");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"a");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"a");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(1));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"c");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"b");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"b");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(1));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"c");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"b");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"a");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"c");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"c");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"b");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"c");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"d");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"b");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"c");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"d");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"c");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"d");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"b");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"a");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(1));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"d");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"b");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"b");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"d");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"a");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"a");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"d");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"c");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"b");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"d");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"d");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"b");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"d");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"b");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"b");
        Assert.That(matrix.FrequencyFromObject(toGet), Is.EqualTo(0));
    }

    /// <summary>
    /// The get probability matrix test.
    /// </summary>
    [Test]
    public void GetProbabilityMatrixTest()
    {
        matrix = new Matrix(testSequence.Alphabet.Cardinality, 3);

        NullCycleSpaceReorganizer reorganizer = new(2);
        testSequence = (Sequence)reorganizer.Reorganize(testSequence);

        IteratorStart it = new(testSequence, 3, 1);
        while (it.Next())
        {
            var currentSequence = it.Current();
            var arrayToTeach = new int[currentSequence.Length];
            for (var i = 0; i < currentSequence.Length; i++)
            {
                arrayToTeach[i] = testSequence.Alphabet.IndexOf(currentSequence[i]);
            }

            matrix.Add(arrayToTeach);
        }

        var probabilityMatrix = (ProbabilityMatrix)matrix.ProbabilityMatrix();

        int[] toGet = [testSequence.Alphabet.IndexOf((ValueString)"a")];
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(0.5));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"b");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(0.25));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"c");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(0.1666666667d).Within(0.0000000001d));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"d");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(0.0833333333).Within(0.0000000001d));

        toGet = new int[2];

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"a");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"a");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(0.5));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"a");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"b");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"a");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"c");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(0.3333333333).Within(0.0000000001d));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"a");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"d");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(0.1666666667d).Within(0.0000000001d));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"b");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"a");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(0.6666666667).Within(0.0000000001d));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"b");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"b");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(0.3333333333).Within(0.0000000001d));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"b");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"c");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"b");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"d");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"c");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"a");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(0.5));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"c");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"b");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(0.5));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"c");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"c");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"c");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"d");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"d");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"a");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"d");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"b");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(1));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"d");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"c");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"d");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"d");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet = new int[3];

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"a");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"a");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"c");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(0.6666666667).Within(0.0000000001d));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"a");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"a");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"d");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(0.3333333333).Within(0.0000000001d));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"a");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"c");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"a");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(0.5));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"a");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"c");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"b");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(0.5));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"a");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"d");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"b");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(1));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"a");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"b");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"b");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"b");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"a");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"a");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(1));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"b");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"a");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"c");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"b");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"b");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"a");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(1));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"b");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"c");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"b");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"b");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"d");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"b");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"b");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"b");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"b");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"c");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"a");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"a");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(1));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"c");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"b");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"b");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(1));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"c");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"b");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"a");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"c");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"c");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"b");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"c");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"d");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"b");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"c");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"b");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"c");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"d");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"b");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"a");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(1));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"d");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"b");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"b");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"d");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"a");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"a");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"d");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"c");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"b");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"d");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"d");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"b");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(0));

        toGet[0] = testSequence.Alphabet.IndexOf((ValueString)"d");
        toGet[1] = testSequence.Alphabet.IndexOf((ValueString)"b");
        toGet[2] = testSequence.Alphabet.IndexOf((ValueString)"b");
        Assert.That(probabilityMatrix.FrequencyFromObject(toGet), Is.EqualTo(0));
    }

    /// <summary>
    /// The larger n test.
    /// </summary>
    [Test]
    public void LargerNTest()
    {
        alphabet.Add(a);
        alphabet.Add(b);
        alphabet.Add(c);
        alphabet.Add(d);

        sequence = new Sequence("fc");

        matrix = new Matrix(alphabet.Cardinality, 2);
        int[] array = new int[sequence.Length];
        array[0] = alphabet.IndexOf(sequence[0]);
        array[1] = alphabet.IndexOf(sequence[1]);
        Assert.Throws<ArgumentOutOfRangeException>(() => matrix.FrequencyFromObject(array));
    }
}

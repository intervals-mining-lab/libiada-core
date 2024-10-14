namespace Libiada.MarkovChains.Tests.MarkovChain.Generators;

using MarkovChains.MarkovChain.Generators;

/// <summary>
/// The mock generator.
/// </summary>
public class MockGenerator : IGenerator
{
    /// <summary>
    /// The vault.
    /// </summary>
    private readonly double[] vault = new double[30];

    /// <summary>
    /// The step.
    /// </summary>
    private int step = -1;

    /// <summary>
    /// Initializes a new instance of the <see cref="MockGenerator"/> class.
    /// </summary>
    public MockGenerator()
    {
        vault[0] = 0.77;
        vault[1] = 0.15;
        vault[2] = 0.96;
        vault[3] = 0.61;
        vault[4] = 0.15;
        vault[5] = 0.85;
        vault[6] = 0.67;
        vault[7] = 0.51;
        vault[8] = 0.71;
        vault[9] = 0.2;
        vault[10] = 0.77;
        vault[11] = 0.15;
        vault[12] = 0.96;
        vault[13] = 0.61;
        vault[14] = 0.15;
        vault[15] = 0.85;
        vault[16] = 0.67;
        vault[17] = 0.51;
        vault[18] = 0.71;
        vault[19] = 0.2;
        vault[20] = 0.77;
        vault[21] = 0.15;
        vault[22] = 0.96;
        vault[23] = 0.61;
        vault[24] = 0.15;
        vault[25] = 0.85;
        vault[26] = 0.67;
        vault[27] = 0.51;
        vault[28] = 0.71;
        vault[29] = 0.2;
    }

    /// <summary>
    /// The reset.
    /// </summary>
    public void Reset()
    {
        step = -1;
    }

    /// <summary>
    /// The next.
    /// </summary>
    /// <returns>
    /// The <see cref="double"/>.
    /// </returns>
    public double Next()
    {
        step++;
        if (step < vault.Length)
        {
            return vault[step];
        }

        return 0;
    }
}

namespace Libiada.MarkovChains.MarkovChain.Generators;

/// <summary>
/// Random generator based on standart class <see cref="Random"/>.
/// </summary>
public class SimpleGenerator : IGenerator
{
    /// <summary>
    /// The random.
    /// </summary>
    private Random random = new Random();

    /// <summary>
    /// The reset.
    /// </summary>
    public void Reset()
    {
        random = new Random(random.Next());
    }

    /// <summary>
    /// The next.
    /// </summary>
    /// <returns>
    /// The <see cref="double"/>.
    /// </returns>
    public double Next()
    {
        return random.NextDouble();
    }
}

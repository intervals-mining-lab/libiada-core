namespace Libiada.MarkovChains.MarkovChain.Generators;

/// <summary>
/// Random generators factory.
/// </summary>
public static class GeneratorFactory
{
    /// <summary>
    /// Creates random generator of given type.
    /// </summary>
    /// <param name="generator">
    /// Generator type.
    /// </param>
    /// <returns>
    /// Random numbers generator.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown if generator type is unknown.
    /// </exception>
    public static IGenerator Create(GeneratorType generator)
    {
        switch (generator)
        {
            case GeneratorType.SimpleGenerator:
                return new SimpleGenerator();
            default:
                throw new ArgumentException("This type of generator does not registered in system", "generator");
        }
    }
}

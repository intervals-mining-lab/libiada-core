namespace Libiada.SequenceGenerator;

using Libiada.Core.Core;

/// <summary>
/// The SequenceGenerator interface.
/// </summary>
public interface ISequenceGenerator
{
    /// <summary>
    /// Generates sequences using length and alphabet cardinality.
    /// </summary>
    /// <param name="length">
    /// The sequence length.
    /// </param>
    /// <param name="alphabetCardinality">
    /// The sequence alphabet cardinality.
    /// </param>
    /// <returns>
    /// The <see cref="List{Libiada.Core.Core.Sequence}"/>.
    /// </returns>
    List<Sequence> GenerateSequences(int length, int alphabetCardinality);

    /// <summary>
    /// Generates sequences using length.
    /// </summary>
    /// <param name="length">
    /// The sequence length.
    /// </param>
    /// <returns>
    /// The <see cref="List{Libiada.Core.Core.Sequence}"/>.
    /// </returns>
    List<Sequence> GenerateSequences(int length);
}

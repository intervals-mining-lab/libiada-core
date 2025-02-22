namespace Libiada.Segmenter.Model;

using System.Globalization;

using Libiada.Core.Core;

using Segmenter.Base.Collectors;
using Segmenter.Base.Sequences;
using Segmenter.Interfaces;

/// <summary>
/// The main output data.
/// </summary>
public class MainOutputData
{
    /// <summary>
    /// The sequence.
    /// </summary>
    private ComplexSequence sequence;

    /// <summary>
    /// The alphabet.
    /// </summary>
    private FrequencyDictionary alphabet;

    /// <summary>
    /// The parameters.
    /// </summary>
    private Dictionary<string, string> parameters = [];

    /// <summary>
    /// The get sequence method.
    /// </summary>
    /// <returns>
    /// The <see cref="ComposedSequence"/>.
    /// </returns>
    public ComposedSequence GetSequence()
    {
        return sequence;
    }

    /// <summary>
    /// The set sequence method.
    /// </summary>
    /// <param name="sequence">
    /// The sequence.
    /// </param>
    public void SetSequence(ComplexSequence sequence)
    {
        this.sequence = sequence;
    }

    /// <summary>
    /// The get frequency dictionary.
    /// </summary>
    /// <returns>
    /// The <see cref="FrequencyDictionary"/>.
    /// </returns>
    public FrequencyDictionary GetFrequencyDictionary()
    {
        return alphabet;
    }

    /// <summary>
    /// The set frequency dictionary.
    /// </summary>
    /// <param name="alphabet">
    /// The alphabet.
    /// </param>
    public void SetFrequencyDictionary(FrequencyDictionary alphabet)
    {
        this.alphabet = alphabet;
    }

    /// <summary>
    /// The get parameters.
    /// </summary>
    /// <returns>
    /// The <see cref="Dictionary{string, string}"/>.
    /// </returns>
    public Dictionary<string, string> GetParameters()
    {
        return parameters;
    }

    /// <summary>
    /// Allows you add an additional information about research
    /// </summary>
    /// <param name="what">parameter name</param>
    /// <param name="value">string value</param>
    public void AddInfo(IIdentifiable what, IIdentifiable value)
    {
        parameters.Add(what.GetName(), value.GetName());
    }

    /// <summary>
    /// Allows to add an additional information about research
    /// </summary>
    /// <param name="what">parameter name</param>
    /// <param name="value">digit value</param>
    public void AddInfo(IIdentifiable what, IDefinable value)
    {
        parameters.Add(what.GetName(), value.GetValue().ToString(CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// Allows to add an additional information about research.
    /// </summary>
    /// <param name="what">
    /// Parameter name.
    /// </param>
    /// <param name="value">
    /// Digit calculated value.
    /// </param>
    public void AddInfo(IIdentifiable what, double value)
    {
        parameters.Add(what.GetName(), value.ToString(CultureInfo.InvariantCulture));
    }
}

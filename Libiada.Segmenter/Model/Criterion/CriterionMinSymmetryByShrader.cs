﻿namespace Libiada.Segmenter.Model.Criterion;

using Segmenter.Base.Collectors;
using Segmenter.Base.Sequences;
using Segmenter.Model.Threshold;

/// <summary>
/// The criterion of "minimum of symmetry." Calculates the minimum value of the symmetry of the sequence.
/// This is not a master criterion, since, as meron uses the same elements as in the calculation of taxons.
/// </summary>
public class CriterionMinSymmetryByShrader : Criterion
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CriterionMinSymmetryByShrader"/> class.
    /// </summary>
    /// <param name="threshold">
    /// The threshold.
    /// </param>
    /// <param name="precision">
    /// The precision.
    /// </param>
    public CriterionMinSymmetryByShrader(ThresholdVariator threshold, double precision)
        : base(threshold, precision)
    {
        Value = double.MaxValue;
    }

    /// <summary>
    /// The state.
    /// </summary>
    /// <param name="sequence">
    /// The sequence.
    /// </param>
    /// <param name="alphabet">
    /// The alphabet.
    /// </param>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    public override bool State(ComplexSequence sequence, FrequencyDictionary alphabet)
    {
        double current = Symmetry(alphabet);
        if (Value > current)
        {
            Value = current;
            this.sequence = sequence.Clone();
            this.alphabet = alphabet.Clone();
            ThresholdToStop.SaveBest();
        }

        return ThresholdToStop.Distance > ThresholdVariator.Precision;
    }

    /// <summary>
    /// The distortion.
    /// </summary>
    /// <param name="sequence">
    /// The sequence.
    /// </param>
    /// <param name="alphabet">
    /// The alphabet.
    /// </param>
    /// <returns>
    /// The <see cref="double"/>.
    /// </returns>
    public override double Distortion(ComplexSequence sequence, FrequencyDictionary alphabet)
    {
        return -1;
    }

    /// <summary>
    /// The symmetry.
    /// </summary>
    /// <param name="alphabet">
    /// The alphabet.
    /// </param>
    /// <returns>
    /// The <see cref="double"/>.
    /// </returns>
    private double Symmetry(FrequencyDictionary alphabet)
    {
        double taxons = 0;
        double merons = 0;
        int arrayMaxLength = 0;
        List<List<int>> positions = alphabet.GetWordsPositions();

        for (int index = 0; index < alphabet.Count; index++)
        {
            int countT = positions[index].Count;
            // TODO: check if this should be Log2
            taxons += (Math.Log(countT) * countT) - countT;
            int arraySize = positions[index].Count;
            if (arrayMaxLength < arraySize)
            {
                arrayMaxLength = arraySize;
            }
        }

        for (int meronIndex = 0, countM = 0; meronIndex < arrayMaxLength; meronIndex++)
        {
            for (int index = 0; index < alphabet.Count; index++)
            {
                if (positions[index].Count >= meronIndex)
                {
                    countM++;
                }
            }

            // TODO: check if this should be Log2
            merons += (Math.Log(countM) * countM) - countM;
            countM = 0;
        }

        return taxons + merons;
    }
}

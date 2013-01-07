﻿using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.TheoryOfSet;
using Segmentation.Classes.Base;
using Segmentation.Classes.Base.Collectors;
using Segmentation.Classes.Base.Sequencies;
using Segmentation.Classes.Model.Threshold;

namespace Segmentation.Classes.Model.Criterion
{
    /// <summary>
    /// The criterion of "minimum of symmetry." Calculates the minimum value of the symmetry of the chain.
    /// This is not a master criterion, since, as meron uses the same elements as in the calculation of taxons.
    /// </summary>
    public class CriterionMinSymmetryByShrader : Criterion
    {
        public CriterionMinSymmetryByShrader(ThresholdVariator threshold, double precision)
            : base(threshold, precision)
        {
            formalismType = Formalism.CRITERION_MIN_SYMMETRY_SHREDER;
            lastDistortion = Double.MaxValue;
        }

        public override bool state(ComplexChain chain, FrequencyDictionary alphabet)
        {
            double current = symmetry(alphabet);
            if (lastDistortion > current)
            {
                lastDistortion = current;
                this.chain = (ComplexChain)chain.Clone();
                this.alphabet = (FrequencyDictionary)alphabet.Clone();
                thresholdToStop.saveBest();
            }
            return (thresholdToStop.distance() > ThresholdVariator.PRECISION);
        }

        private double symmetry(FrequencyDictionary alphabet)
        {
            double taxons = 0;
            double merons = 0;
            int arrayMaxLength = 0;
            List<List<int>> positions = alphabet.getWordsPositions();

            for (int index = 0, arraySize; index < alphabet.power(); index++)
            {
                int countT = positions[index].Count;
                taxons += Math.Log(countT)*countT - countT;
                if (arrayMaxLength < (arraySize = positions[index].Count)) arrayMaxLength = arraySize;
            }

            for (int meronIndex = 0, countM = 0; meronIndex < arrayMaxLength; meronIndex++)
            {
                for (int index = 0; index < alphabet.power(); index++)
                {
                    if (positions[index].Count >= meronIndex) countM = countM + 1;
                }
                merons += Math.Log(countM)*countM - countM;
                countM = 0;
            }
            return (taxons + merons);
        }


        public override double distortion(ComplexChain chain, FrequencyDictionary alphabet)
        {
            return -1;
        }
    }
}
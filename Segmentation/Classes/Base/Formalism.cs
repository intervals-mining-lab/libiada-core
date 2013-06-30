﻿namespace Segmentation.Classes.Base
{
    public enum Formalism
    {
        Sequence,
        Alphabet,
        CriterionPartialOrlov,
        CriterionMinRegularity,
        CriterionMinSymmetryShreder,
        CriterionMinSymmetryIntervals,
        CriterionAttitudeRemoteness,
        CriterionEqualityDepths,
        ThresholdDichotomicMethod,
        ThresholdLinearMethod,
        ThresholdRandomMethod,
        AlgorithmBase,
        CriterionGoldenRatio
    }
}
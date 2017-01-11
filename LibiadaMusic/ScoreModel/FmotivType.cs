namespace LibiadaMusic.ScoreModel
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The fmotiv type.
    /// </summary>
    public enum FmotivType : byte
    {
        /// <summary>
        /// Temporary state until segmentation algorithm will be refactored.
        /// </summary>
        [Display(Name = "None")]
        [Description("")]
        None = 0,

        /// <summary>
        /// The complete minimal measure.
        /// </summary>
        [Display(Name = "Complete minimal measure")]
        [Description("")]
        CompleteMinimalMeasure = 1,

        /// <summary>
        /// The partial minimal measure.
        /// </summary>
        [Display(Name = "Partial minimal measure")]
        [Description("")]
        PartialMinimalMeasure = 2,

        /// <summary>
        /// The increasing sequence.
        /// </summary>
        [Display(Name = "Increasing sequence")]
        [Description("")]
        IncreasingSequence = 3,

        /// <summary>
        /// The complete minimal metrorhythmic group.
        /// Consists of complete minimal measure followed by increasing sequence.
        /// Can be calculated as sum of both mentioned above.
        /// </summary>
        [Display(Name = "Complete minimal metrorhythmic group")]
        [Description("One of two subtypes of minimal metrorhythmic group with complete minimal measure at the begining")]
        CompleteMinimalMetrorhythmicGroup = 4,

        /// <summary>
        /// The partial minimal metrorhythmic group.
        /// Consists of partial minimal measure followed by increasing sequence.
        /// Can be calculated as sum of both mentioned above.
        /// </summary>
        [Display(Name = "Partial minimal metrorhythmic group")]
        [Description("One of two subtypes of minimal metrorhythmic group with partial minimal measure at the begining")]
        PartialMinimalMetrorhythmicGroup = 5
    }
}

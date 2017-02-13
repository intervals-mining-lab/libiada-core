namespace LibiadaCore.Core.Characteristics.Calculators.AccordanceCalculators
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Static factory of different calculators.
    /// </summary>
    public static class AccordanceCalculatorsFactory
    {
        /// <summary>
        /// The binary calculators.
        /// </summary>
        private static readonly List<Type> AccordanceCalculators = new List<Type>
                                                            {
                                                                typeof(PartialComplianceDegree),
                                                                typeof(MutualComplianceDegree)
                                                            };

        /// <summary>
        ///  Create binary calculator method.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="IAccordanceCalculator"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown if calculator is not found by name.
        /// </exception>
        public static IAccordanceCalculator CreateAccordanceCalculator(string type)
        {
            foreach (var calculator in AccordanceCalculators)
            {
                if (type == calculator.Name)
                {
                    return (IAccordanceCalculator)Activator.CreateInstance(calculator);
                }
            }

            throw new ArgumentException("Unknown calculator", "type");
        }

        /// <summary>
        /// Create binary calculator method.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="IAccordanceCalculator"/>.
        /// </returns>
        public static IAccordanceCalculator CreateAccordanceCalculator(Type type)
        {
            return CreateAccordanceCalculator(type.Name);
        }

        public static IAccordanceCalculator CreateCalculator(AccordanceCharacteristic type)
        {
            switch (type)
            {
                case AccordanceCharacteristic.MutualComplianceDegree:
                    return  new MutualComplianceDegree();
                case AccordanceCharacteristic.PartialComplianceDegree: 
                    return new PartialComplianceDegree();
                default:
                    throw new ArgumentException("Unknown accordance characteristic type");
            }
        }
    }
}

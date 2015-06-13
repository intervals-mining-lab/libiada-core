namespace BuildingsIterator.Statistics
{
    using System.Collections.Generic;

    using BuildingsIterator.Statistics.Calculators;

    /// <summary>
    /// Class storing sample.
    /// </summary>
    public class Sample
    {
        /// <summary>
        /// The values.
        /// </summary>
        private readonly List<double> values;

        /// <summary>
        /// The name.
        /// </summary>
        private readonly string name;

        /// <summary>
        /// Initializes a new instance of the <see cref="Sample"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        public Sample(string name)
        {
            this.name = name;
            values = new List<double>();
        }

        /// <summary>
        /// Adds element to sample.
        /// </summary>
        /// <param name="value">
        /// Element to add.
        /// </param>
        public void Add(double value)
        {
            values.Add(value);
        }

        /// <summary>
        /// Converts sample to string list.
        /// </summary>
        /// <param name="mass">
        /// Array to fill.
        /// </param>
        public void FillList(List<string> mass)
        {
            var iterator = values.GetEnumerator();
            while (iterator.MoveNext())
            {
                mass.Add(iterator.Current.ToString());
            }
        }

        /// <summary>
        /// Calculates given characteristic of sample.
        /// </summary>
        /// <param name="calculator">
        /// Characteristic calculator.
        /// </param>
        /// <returns>
        /// Characteristic value.
        /// </returns>
        public double GetSampleCharacteristic(IOnePicksCalculator calculator)
        {
            return calculator.Calculate(values);
        }
    }
}

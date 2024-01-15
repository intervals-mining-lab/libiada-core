namespace Clusterizator.Krab
{
    using System;

    /// <summary>
    /// Class-container for pair of points and their distances.
    /// </summary>
    public class Connection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Connection"/> class.
        /// </summary>
        /// <param name="firstIndex">
        /// Index of first point.
        /// </param>
        /// <param name="secondIndex">
        /// Index of second point.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if index or indexes are negative.
        /// </exception>
        public Connection(int firstIndex, int secondIndex)
        {
            if ((firstIndex < 0) || (secondIndex < 0))
            {
                throw new ArgumentException("Point index can't be less than 0.");
            }

            Connected = false;
            FirstElementIndex = firstIndex;
            SecondElementIndex = secondIndex;
        }

        /// <summary>
        /// Gets or sets a value indicating whether pair of points connected or not..
        /// </summary>
        public bool Connected { get; set; }

        /// <summary>
        /// Gets or sets euclidean distance.
        /// </summary>
        public double Distance { get; set; }

        /// <summary>
        /// Gets or sets normalized euclidean distance.
        /// </summary>
        public double NormalizedDistance { get; set; }

        /// <summary>
        /// Gets or sets local density of points.
        /// </summary>
        public double TauStar { get; set; }

        /// <summary>
        /// Gets or sets normalized local density of points.
        /// </summary>
        public double Tau { get; set; }

        /// <summary>
        /// Gets or sets the lambda distance.
        /// </summary>
        public double Lambda { get; set; }

        /// <summary>
        /// Gets index of first point.
        /// </summary>
        public int FirstElementIndex { get; private set; }

        /// <summary>
        /// Gets index of second point.
        /// </summary>
        public int SecondElementIndex { get; private set; }

        /// <summary>
        /// Creates copy of Connection.
        /// </summary>
        /// <returns>
        /// Clone of current object.
        /// </returns>
        public Connection Clone()
        {
            var clone = new Connection(FirstElementIndex, SecondElementIndex)
                {
                    Connected = Connected,
                    Distance = Distance,
                    NormalizedDistance = NormalizedDistance,
                    TauStar = TauStar,
                    Tau = Tau,
                    Lambda = Lambda
                };
            return clone;
        }
    }
}

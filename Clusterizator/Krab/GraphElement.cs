namespace Clusterizator.Krab
{
    using System.Collections.Specialized;

    /// <summary>
    /// Point in graph.
    /// </summary>
    public class GraphElement
    {
        /// <summary>
        /// The taxon number.
        /// </summary>
        private int taxonNumber;

        /// <summary>
        /// Initializes a new instance of the <see cref="GraphElement"/> class.
        /// </summary>
        /// <param name="element">
        /// Coordinates of point.
        /// </param>
        /// <param name="name">
        /// Object name.
        /// </param>
        public GraphElement(HybridDictionary element, object name)
        {
            Content = element;
            Id = name;
            taxonNumber = 0;
        }

        /// <summary>
        /// Gets the point name.
        /// </summary>
        public object Id { get; private set; }

        /// <summary>
        /// Gets or sets the point coordinates as HybridDictionary.
        /// </summary>
        public HybridDictionary Content { get; set; }

        /// <summary>
        /// Gets or sets this point taxon number.
        /// </summary>
        public int TaxonNumber
        {
            get
            {
                return taxonNumber;
            }

            set
            {
                if (value >= 0)
                {
                    taxonNumber = value;
                }
            }
        }

        /// <summary>
        /// Creates copy of graph element.
        /// </summary>
        /// <returns>
        /// Clone of current object.
        /// </returns>
        public GraphElement Clone()
        {
            var clone = new GraphElement(Content, Id) { TaxonNumber = taxonNumber };
            return clone;
        }
    }
}

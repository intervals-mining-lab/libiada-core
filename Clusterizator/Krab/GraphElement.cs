namespace Clusterizator.Krab
{
    using System.Collections.Specialized;

    /// <summary>
    /// ������� �����
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
        /// ����������.
        /// </param>
        /// <param name="name"> 
        /// ��� �������.
        /// </param>
        public GraphElement(HybridDictionary element, object name)
        {
            Content = element;
            Id = name;
            taxonNumber = 0;
        }

        /// <summary>
        /// ��� �������
        /// </summary>
        public object Id { get; private set; }

        /// <summary>
        /// ���������� ����� � ���� ���-�������
        /// </summary>
        public HybridDictionary Content { get; set; }

        /// <summary>
        /// ����� �������, �������� ����������� �������
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
        /// ����� ���������� ����� �������
        /// </summary>
        /// <returns>
        /// ����� ������ ������� �����
        /// </returns>
        public GraphElement Clone()
        {
            var clone = new GraphElement(Content, Id) { TaxonNumber = taxonNumber };
            return clone;
        }
    }
}
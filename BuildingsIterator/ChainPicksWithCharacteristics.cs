namespace BuildingsIterator
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    ///  ласс выборки цепочек с характеристиками.
    /// </summary>
    public class ChainPicksWithCharacteristics
    {
        /// <summary>
        /// The characteristics names.
        /// </summary>
        private readonly List<string> characteristicsNames;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChainPicksWithCharacteristics"/> class.
        /// </summary>
        /// <param name="chains">
        /// ’еш таблица с цепочками и вычисленными характеристиками.
        /// </param>
        /// <param name="characters">
        /// ћассив характеристик и прив€зок.
        /// </param>
        public ChainPicksWithCharacteristics(Hashtable chains, List<LinkedCharacteristic> characters)
        {
            characteristicsNames = new List<string>();
            for (int i = 0; i < characters.Count; i++)
            {
                characteristicsNames.Add(characters[i].Calculator.GetType().ToString());
            }
        }
    }
}

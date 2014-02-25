namespace PhantomChains.Classes.PhantomChains
{
    using System.Collections.Generic;

    using LibiadaCore.Classes.Root;
    using LibiadaCore.Classes.Root.SimpleTypes;

    /// <summary>
    /// Класс с данными для построения верева вараинтов.
    /// </summary>
    public class PhantomTable
    {
        /// <summary>
        /// Массив начальных позиций деревьев в фантомной цепочке.
        /// </summary>
        public readonly List<int> StartPositions = new List<int>();

        /// <summary>
        /// The table.
        /// </summary>
        private readonly List<Record> table = new List<Record>();

        /// <summary>
        /// Initializes a new instance of the <see cref="PhantomTable"/> class.
        /// </summary>
        /// <param name="source">
        /// Фантомная цепочка.
        /// </param>
        public PhantomTable(BaseChain source)
        {
            BaseChain internalChain = source;
            ulong v = 1;
            StartPositions.Add(0);
            for (int j = 0; j < internalChain.Length; j++)
            {
                if ((((ValuePhantom)internalChain[j])[0] is ValueString)
                    || (((ValuePhantom)internalChain[j])[0] is BaseChain))
                {
                    StartPositions.Add(StartPositions[j] + ((ValuePhantom)internalChain[j])[0].ToString().Length);
                }
                else
                {
                    StartPositions.Add(StartPositions[j] + 1);
                }

                table.Add(null);
            }

            table.Add(null);
            for (int i = internalChain.Length; i > 0; i--)
            {
                var temp = (ValuePhantom)internalChain[i - 1];
                table[i] = new Record(temp, v);
                v *= (uint)temp.Cardinality;
            }

            // корню дерева не ставится в соответствие фантомное сообщение
            var t = new ValuePhantom { NullValue.Instance() };
            table[0] = new Record(t, v);
        }

        /// <summary>
        /// Позволяет получить количество записей в таблице, 
        /// которое соответствует числу уровней в дереве вариантов
        /// </summary>
        public int Length
        {
            get { return table.Count; }
        }

        /// <summary>
        /// Позволяет получать и устанавиливать значение записи по индексу.
        /// </summary>
        /// <param name="index">
        /// Record index.
        /// </param>
        /// <returns>
        /// The <see cref="Record"/>.
        /// </returns>
        public Record this[int index]
        {
            get { return table[index]; }

            set { table[index] = value; }
        }
    }
}
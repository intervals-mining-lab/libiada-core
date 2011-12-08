using System;
using System.Collections.Generic;
using ChainAnalises.Classes.EventTheory;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.Root.SimpleTypes;

namespace ChainAnalises.Classes.PhantomChains
{
    ///<summary>
    /// Класс с данными для построения верева вараинтов.
    ///</summary>
    public class PhantomTable
    {
        private List<Record> table = new List<Record>();
        private BaseChain InternalChain = null;
        ///<summary>
        /// Массив начальных позиций деревьев в фантомной цепочке.
        ///</summary>
        public List<int> StartPositions = new List<int>();

        ///<summary>
        /// Конструктор.
        ///</summary>
        ///<param name="InputChain">Фантомная цепочка</param>
        public PhantomTable(BaseChain InputChain)
        {
            InternalChain = InputChain;
            UInt64 v=1;
            StartPositions.Add(0);
            for (int j = 0; j < InternalChain.Length; j++)
            {

                if ((((MessagePhantom) InternalChain[j])[0] is ValueString) ||
                    (((MessagePhantom) InternalChain[j])[0] is BaseChain))
                {
                    StartPositions.Add(StartPositions[j] + ((MessagePhantom) InternalChain[j])[0].ToString().Length);
                }
                else
                {
                    StartPositions.Add(StartPositions[j] + 1);
                }
                table.Add(null);
            }
            table.Add(null);
            for(int i=InternalChain.Length;i>0;i--)
            {
                MessagePhantom Temp = (MessagePhantom)InternalChain[i-1];
                table[i] = new Record(Temp, v);
                v *= (uint)Temp.power;
            }
            //корню дерева не ставится в соответствие фантомное сообщение
            MessagePhantom t = new MessagePhantom();
            t.Add(PsevdoValue.Instance());
            table[0] = new Record(t, v);
        }

        ///<summary>
        /// Позволяет получать и устанавиливать значение записи по индексу.
        ///</summary>
        ///<param name="index">Индекс</param>
        public Record this[int index]
        {
            get { return table[index]; }

            set { table[index] = value; }
        }

        ///<summary>
        /// Позволяет получить количество записей в таблице, 
        /// которое соответствует числу уровней в дереве вариантов
        ///</summary>
        public int Length
        {
            get { return table.Count; }
        }
    }
}

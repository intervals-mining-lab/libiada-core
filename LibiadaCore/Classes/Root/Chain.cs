using System.Collections.Generic;
using LibiadaCore.Classes.Misc;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using LibiadaCore.Classes.Root.SimpleTypes;
using LibiadaCore.Classes.TheoryOfSet;

namespace LibiadaCore.Classes.Root
{
    ///<summary>
    /// Класс цепь
    ///</summary>
    public class Chain : BaseChain, IBaseObject
    {
        protected UniformChain[] UniformChains = new UniformChain[0];
        protected Chain[] DissimilarChains;

        ///<summary>
        /// Конструктор 
        /// При указании длинны следует понимать что цепь начинается с 0 элемента.
        ///</summary>
        ///<param name="length">Длинна цепи</param>
        public Chain(int length) : base(length)
        {
        }

        ///<summary>
        ///</summary>
        public Chain()
        {
        }

        ///<summary>
        /// Конструктор, создает цепь из строки символов.
        /// Каждый символ становится элементом.
        ///</summary>
        ///<param name="s">Строка</param>
        public Chain(string s)
            : base(s)
        {
        }

        /// <summary>
        /// Создаёт цепочку с заданным строем и алфавитом.
        /// Проверка корректности не производится!
        /// </summary>
        /// <param name="building">Строй</param>
        /// <param name="alphabet">Алфавит</param>
        public Chain(int[] building, Alphabet alphabet)
            : base(building, alphabet)
        {
            CreateUnformChains();
        }

        /// <summary>
        /// Cоздаёт цепочку из списка элементов.
        /// </summary>
        /// <param name="chain">Коллекция элементов</param>
        public Chain(List<IBaseObject> chain):base(chain)
        {
            CreateUnformChains();
        }

        /// <summary>
        /// Выделяет из полной неоднородной цепи все однородные цепи
        /// и сохраняет их локальнов массив <see cref="UniformChains"/>.
        /// </summary>
        private void CreateUnformChains()
        {
            UniformChains = new UniformChain[this.alphabet.Power - 1];
            for (int i = 0; i < this.alphabet.Power - 1; i++)
            {
                this.UniformChains[i] = new UniformChain(building.Length, this.alphabet[i + 1]);
            }
            for (int j = 0; j < building.Length; j++)
            {
                UniformChains[building[j] - 1][j] = this.alphabet[building[j]];
            }
        }

        public void ClearAndSetNewLength(int length)
        {
            base.ClearAndSetNewLength(length);
            UniformChains = new UniformChain[0];
        }

        public IBaseObject Clone()
        {
            Chain temp = new Chain(Length);
            FillClone(temp);
            return temp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="temp"></param>
        protected void FillClone(IBaseObject temp)
        {
            Chain tempChain = temp as Chain;
            base.FillClone(tempChain);
            if (tempChain != null)
            {
                tempChain.UniformChains = (UniformChain[]) UniformChains.Clone();
            }
        }

        ///<summary>
        /// Возвращает копию однородной цепочки с указанным элементом.
        /// Если такого элемента нет, то возврашщает null.
        ///</summary>
        ///<param name="baseObject">элемент однородной цепочки</param>
        ///<returns></returns>
        public UniformChain UniformChain(IBaseObject baseObject)
        {
            UniformChain result = null;
            int pos = Alphabet.IndexOf(baseObject);
            if (pos != -1)
            {
                result = (UniformChain) (UniformChains[pos]).Clone();
            }
            return result;
        }

        ///<summary>
        /// Возвращает копию однородной цепочки 
        /// с указанным индексом в алфавите полной цепи.
        ///</summary>
        ///<param name="i">Индекс элемента однородной цепочки в алфавите полной цепи</param>
        ///<returns></returns>
        public UniformChain UniformChain(int i)
        {
            return (UniformChain)UniformChains[i].Clone();
        }

        ///<summary>
        /// Свойстово позволяет получить доступ к элементу цепи по индексу
        /// В случае выхода за границы цепи вызывается исключение
        ///</summary>
        ///<param name="index">номер элемента</param>
        public IBaseObject this[int index]
        {
            get { return Get(index); }

            set { Add(value, index); }
        }

        public override void Add(IBaseObject item, int index)
        {
            base.Add(item, index);

            if (UniformChains.Length != (alphabet.Power - 1))
            {
                UniformChain[] temp = new UniformChain[alphabet.Power - 1];
                for (int i = 0; i < UniformChains.Length; i++)
                {
                    temp[i] = UniformChains[i];
                }
                UniformChains = temp;
                UniformChains[UniformChains.Length - 1] = new UniformChain(Length, item);
            }

            foreach (UniformChain chain in UniformChains)
            {
                chain.Add(item, index);
            }
        }

        public void FillDissimilarChains()
        {
            if(DissimilarChains.Length > 0)
                return;
            List<int> counters = new List<int>();
            for (int j = 0; j < Alphabet.Power; j++)
            {
                counters.Add(0);
            }

            for (int i = 0; i < building.Length; i++)
            {
                int element = ++counters[building[i]];
                if(DissimilarChains.Length < element) 
                {
                    Chain[] temp = new Chain[element];
                    for (int j = 0; j < DissimilarChains.Length; j++)
                    {
                        temp[j] = DissimilarChains[j];
                    }
                    DissimilarChains = temp;
                    DissimilarChains[DissimilarChains.Length - 1] = new Chain();
                }
                DissimilarChains[element].Add(new ValueInt(building[i]), i);
            }
        }

        /// <summary>
        /// Возвращает i-ый интервал 
        /// между указанными элементами 
        /// в бинарно-однродной цепи
        /// </summary>
        /// <param name="j">первый элементы пары</param>
        /// <param name="L">второй элемент пары</param>
        /// <param name="entry">номер вхождения начиная с 1</param>
        /// <returns>Длина интервала</returns>
        public int GetBinaryInterval(IBaseObject j, IBaseObject L, int entry)
        {
            int jEntry = Get(j, entry);
            if (jEntry == -1)
            {
                return -1;
            }
            for (int i = jEntry + 1; i < Length; i++)
            {
                if (j.Equals(this[i]))
                {
                    return - 1;
                }
                if (L.Equals(this[i]))
                {
                    return i - jEntry;
                }
            }
            return -1;
        }

        /// <summary>
        /// Возвращает позицию указанного по счёту вхождения указанного элемента.
        /// </summary>
        /// <param name="element">Элемнет</param>
        /// <param name="entry">Номер вхождения элемента в полную цепь</param>
        /// <returns></returns>
        public int Get(IBaseObject element, int entry)
        {
            int entranceCount = 0;
            for (int i = 0; i < building.Length; i++)
            {
                if (this[i].Equals(element))
                {
                    entranceCount++;
                    if (entranceCount == entry)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// Возвращает позицию первого вхождения указанного элемента 
        /// после указанной позиции.
        /// </summary>
        /// <param name="element">Элемнет</param>
        /// <param name="from">Начальная позиция для отсчёта</param>
        /// <returns>Номер позиции или -1, если элемент после указанной позиции не встречается</returns>
        public int GetAfter(IBaseObject element, int from)
        {
            for (int i = from; i < Length; i++)
            {
                if (this[i].Equals(element))
                {
                    return i;
                }
            }
            return -1;
        }

        public int GetPairsCount(IBaseObject j, IBaseObject L)
        {
            int jElementCount = (int)new Count().Calculate(UniformChain(j), LinkUp.Start);
            int pairs = 0;
            for (int i = 1; i <= jElementCount; i++)
            {
                int binaryInterval = GetBinaryInterval(j, L, i);
                if (binaryInterval > 0)
                {
                    pairs++;
                }
            }
            return pairs;
        }

        public IBaseObject DeleteAt(int index)
        {
            IBaseObject element = alphabet[building[index]];
            ICalculator calc = new Count();
            UniformChain tempUniformChain = (UniformChain) this.UniformChain(element);
            if ((int)calc.Calculate(tempUniformChain, LinkUp.End) == 1)
            {
                var temp = UniformChains;
                UniformChains = new UniformChain[temp.Length - 1];
                int j = 0;
                for (int i = 0; i < temp.Length; i++)
                {
                    if (!temp[i].Element.Equals(element))
                    {
                        UniformChains[j] = temp[i];
                        j++;
                    }
                }
                alphabet.Remove(building[index]);
                for (int k = 0; k < building.Length; k++)
                {
                    if (building[index] < building[k])
                    {
                        building[k] = building[k] - 1;
                    }
                }
            }
            for (int l = 0; l < UniformChains.Length; l++)
            {
                UniformChains[l].DeleteAt(index);
            }
            building = ArrayManipulator.DeleteAt(building, index);
            return element;
        }
    }
}
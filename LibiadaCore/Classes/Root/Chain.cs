using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using LibiadaCore.Classes.Root.SimpleTypes;
using LibiadaCore.Classes.TheoryOfSet;

namespace LibiadaCore.Classes.Root
{
    ///<summary>
    /// Класс цепь
    ///</summary>
    [Serializable]
    public class Chain : BaseChain, IBaseObject
    {
        protected UniformChain[] PUniformChains = new UniformChain[0];
        protected Chain[] PNotUniformChains;

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
        /// Конструктор, создает цепь из строки символов
        ///</summary>
        ///<param name="s"></param>
        public Chain(string s)
            : base(s)
        {
        }

        public Chain(int[] building, Alphabet alphabet)
            : base(building, alphabet)
        {
            CreateUnformChains();
        }

        public Chain(List<IBaseObject> chain):base(chain)
        {
            CreateUnformChains();
        }

        private void CreateUnformChains()
        {
            PUniformChains = new UniformChain[this.alphabet.Power - 1];
            for (int i = 0; i < this.alphabet.Power - 1; i++)
            {
                this.PUniformChains[i] = new UniformChain(building.Length, this.alphabet[i + 1]);
            }
            for (int j = 0; j < building.Length; j++)
            {
                PUniformChains[building[j] - 1][j] = this.alphabet[building[j]];
            }
        }

        ///<summary>
        ///</summary>
        ///<param name="length"></param>
        public new void ClearAndSetNewLength(int length)
        {
            base.ClearAndSetNewLength(length);
            PUniformChains = new UniformChain[0];
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
                tempChain.PUniformChains = (UniformChain[]) PUniformChains.Clone();
            }
        }

        ///<summary>
        ///</summary>
        ///<param name="baseObject"></param>
        ///<returns></returns>
        ///<exception cref="NotImplementedException"></exception>
        public UniformChain UniformChain(IBaseObject baseObject)
        {
            UniformChain result = null;
            int pos = Alphabet.IndexOf(baseObject);
            if (pos != -1)
            {
                result = (UniformChain) (PUniformChains[pos]).Clone();
            }
            return result;
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

            if (PUniformChains.Length != (alphabet.Power - 1))
            {
                UniformChain[] temp = new UniformChain[alphabet.Power - 1];
                for (int i = 0; i < PUniformChains.Length; i++)
                {
                    temp[i] = PUniformChains[i];
                }
                PUniformChains = temp;
                PUniformChains[PUniformChains.Length - 1] = new UniformChain(Length, item);
            }

            foreach (UniformChain chain in PUniformChains)
            {
                chain.Add(item, index);
            }
        }

        protected void BuildIntervals()
        {
            foreach (UniformChain uniformChain in PUniformChains)
            {
                BuildIntervals();
            }
        }

        ///<summary>
        ///</summary>
        ///<param name="i"></param>
        ///<returns></returns>
        public UniformChain GetUniformChain(int i)
        {
            return (UniformChain) (PUniformChains[i]).Clone();
        }

        public void FillNotUniformChains()
        {
            if(PNotUniformChains.Length > 0)
                return;
            List<int> counters = new List<int>();
            for (int j = 0; j < Alphabet.Power; j++)
            {
                counters.Add(0);
            }

            for (int i = 0; i < building.Length; i++)
            {
                int element = ++counters[building[i]];
                if(PNotUniformChains.Length < element) 
                {
                    Chain[] temp = new Chain[element];
                    for (int j = 0; j < PNotUniformChains.Length; j++)
                    {
                        temp[j] = PNotUniformChains[j];
                    }
                    PNotUniformChains = temp;
                    PNotUniformChains[PNotUniformChains.Length - 1] = new Chain();
                }
                ((Chain)PNotUniformChains[element]).Add(new ValueInt(building[i]), i);
            }

        }

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
            int jElementCount = (int)UniformChain(j).GetCharacteristic(LinkUp.Start, new Count());
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
            ICharacteristicCalculator calc = new Count();
            UniformChain tempUniformChain = (UniformChain) this.UniformChain(element);
            if ((int)calc.Calculate(tempUniformChain, LinkUp.End) == 1)
            {
                var temp = PUniformChains;
                PUniformChains = new UniformChain[temp.Length - 1];
                int j = 0;
                for (int i = 0; i < temp.Length; i++)
                {
                    if (!temp[i].Message.Equals(element))
                    {
                        PUniformChains[j] = temp[i];
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
            for (int l = 0; l < PUniformChains.Length; l++)
            {
                PUniformChains[l].DeleteAt(index);
            }
            building = RemoveAt(building, index);
            return element;
        }

        public double GetCharacteristic(LinkUp linkUp, ICharacteristicCalculator calculator)
        {
            return calculator.Calculate(this, linkUp);
        }
    }
}
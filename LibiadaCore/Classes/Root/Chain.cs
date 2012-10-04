using System;
using System.Collections;
using System.Collections.Generic;
using LibiadaCore.Classes.Root.Characteristics;
using LibiadaCore.Classes.Root.Characteristics.AuxiliaryInterfaces;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using LibiadaCore.Classes.Root.SimpleTypes;
using LibiadaCore.Classes.TheoryOfSet;

namespace LibiadaCore.Classes.Root
{
    ///<summary>
    /// Класс цепь
    ///</summary>
    [Serializable]
    public class Chain : ChainWithCharacteristic, IChainDataForCalculaton, IBaseObject
    {
        protected UniformChain[] PUniformChains;
        protected Chain[] PNotUniformChains;

        ///<summary>
        /// Конструктор 
        /// При указании длинны следует понимать что цепь начинается с 0 элемента.
        ///</summary>
        ///<param name="length">Длинна цепи</param>
        public Chain(int length) : base(length)
        {
            PUniformChains = new UniformChain[0];
        }

        ///<summary>
        ///</summary>
        public Chain()
        {
            PUniformChains = new UniformChain[0];
        }

        ///<summary>
        ///</summary>
        ///<param name="length"></param>
        public new void ClearAndSetNewLength(int length)
        {
            base.ClearAndSetNewLength(length);
            PUniformChains = new UniformChain[alphabet.Power];
        }

        ///<summary>
        /// Конструктор, создает цепь из строки символов
        ///</summary>
        ///<param name="s"></param>
        public Chain(string s) : base(s)
        {
        }

        public Chain(String building, Alphabet alphabet):base(building, alphabet)
        {
            PUniformChains = new UniformChain[this.alphabet.Power - 1];
        }

        public Chain(int[] building, Alphabet alphabet):base(building, alphabet)
        {
            PUniformChains = new UniformChain[this.alphabet.Power - 1];
            for (int i = 0; i < this.alphabet.Power - 1; i++ )
            {
                this.PUniformChains[i] = new UniformChain(building.Length, this.alphabet[i + 1]);
            }
            for (int j = 0; j < building.Length; j++)
            {
                PUniformChains[building[j] - 1][j] = this.alphabet[building[j]];
            }
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

        public override void CalculateCharacteristicList(ArrayList list)
        {
            base.CalculateCharacteristicList(list);
            foreach (UniformChain uniformChain in PUniformChains)
            {
                uniformChain.CalculateCharacteristicList(list);
            }
        }

        ///<summary>
        ///</summary>
        ///<param name="baseObject"></param>
        ///<returns></returns>
        ///<exception cref="NotImplementedException"></exception>
        public ChainWithCharacteristic UniformChain(IBaseObject baseObject)
        {
            ChainWithCharacteristic result = null;
            int pos = Alphabet.IndexOf(baseObject);
            if (pos != -1)
            {
                result = (UniformChain) ((UniformChain) PUniformChains[pos]).Clone();
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

        protected override void BuildIntervals()
        {
            if (!IntervalsChanged) return;

            IntervalsChanged = false;

            foreach (UniformChain uniformChain in PUniformChains)
            {
                IDataForCalculator dataInterface = uniformChain;
                pIntervals.Sum(dataInterface.CommonIntervals);
                startinterval.Sum(dataInterface.StartInterval);
                endinterval.Sum(dataInterface.EndInterval);
            }
        }

        ///<summary>
        ///</summary>
        ///<param name="i"></param>
        ///<returns></returns>
        public UniformChain GetUniformChain(int i)
        {
            return (UniformChain) ((UniformChain) PUniformChains[i]).Clone();
        }

        ///<summary>
        ///</summary>
        ///<param name="type"></param>
        ///<param name="Link"></param>
        ///<returns></returns>
        public override double InjectIntoCharacteristic(Type type, LinkUp Link)
        {
            return ((Characteristic) CharacteristicSnapshot[type]).Value(this, Link);
        }


        public UniformChain IUniformChain(int i)
        {
            return (UniformChain) PUniformChains[i];
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
        /// 
        /// </summary>
        /// <param name="j">первый элементы пары</param>
        /// <param name="L">второй элемент пары</param>
        /// <param name="entry">номер вхождения начиная с 1</param>
        /// <returns></returns>
        public int GetBinaryInterval(IBaseObject j, IBaseObject L, int entry)
        {
            int jEntry = Get(j, entry);
            if (jEntry == -1)
            {
                return -1;
            }
            for (int i = jEntry + 1; i < length; i++)
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
            for (int i = from; i < length; i++)
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

    }

    ///<summary>
    ///</summary>
    public class ChainBin : IBin
    {
        public ArrayList uniformChains = new ArrayList();

        public new IBaseObject GetInstance()
        {
            return new Chain();
        }
    }
}
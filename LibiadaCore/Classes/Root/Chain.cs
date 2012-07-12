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
        protected ArrayList PUniformChains = new ArrayList();
        protected ArrayList PNotUniformChains = new ArrayList();

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
        ///</summary>
        ///<param name="length"></param>
        public new void ClearAndSetNewLength(int length)
        {
            base.ClearAndSetNewLength(length);
            PUniformChains = new ArrayList();
            PNotUniformChains = new ArrayList();
        }

        ///<summary>
        /// Конструктор, создает цепь из строки символов
        ///</summary>
        ///<param name="s"></param>
        public Chain(string s) : base(s)
        {
        }

        public Chain(String building, Alphabet alphabet)
        {
            string[] stringBuilding = building.Split('|');
            base.ClearAndSetNewLength(stringBuilding.Length);
            for (int i = 0; i < stringBuilding.Length; i++)
            {
                this[i] = alphabet[Convert.ToInt32(stringBuilding[i]) - 1];
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
                tempChain.PUniformChains = (ArrayList) PUniformChains.Clone();
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

        public void AddItem(IBaseObject item, int index)
        {
            base.AddItem(item, index);

            if (PUniformChains.Count != Alphabet.Power)
            {
                PUniformChains.Add(new UniformChain(Length, item));
            }

            foreach (UniformChain chain in PUniformChains)
            {
                chain.AddItem(item, index);
            }
        }

        public void Add(IBaseObject item, int index)
        {
            AddItem(item, index);
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
            if(PNotUniformChains.Count > 0)
                return;
            List<int> counters = new List<int>();
            for (int j = 0; j < Alphabet.Power; j++)
            {
                counters.Add(0);
            }

            for (int i = 0; i < building.Length; i++)
            {
                int element = ++counters[building[i]];
                if(PNotUniformChains.Count < element) 
                {
                    PNotUniformChains.Add(new Chain());
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
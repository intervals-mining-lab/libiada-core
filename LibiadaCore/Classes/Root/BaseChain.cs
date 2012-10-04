using System;
using System.Collections;
using System.Collections.Generic;
using LibiadaCore.Classes.Root.SimpleTypes;
using LibiadaCore.Classes.TheoryOfSet;

namespace LibiadaCore.Classes.Root
{
    ///<summary>
    /// 
    ///</summary>
    [Serializable]
    public class BaseChain : IBaseObject
    {
        protected int[] building;
        protected Alphabet alphabet = new Alphabet();
        protected int length;

        ///<summary>
        ///</summary>
        ///<param name="length">Длинна создаваемой цепочки</param>
        ///<exception cref="Exception"></exception>
        public BaseChain(int length)
        {
            ClearAndSetNewLength(length);
            alphabet.Add(NullValue.Instance());
        }

        ///<summary>
        ///</summary>
        public BaseChain()
        {
            alphabet.Add(NullValue.Instance());
        }

        public BaseChain(List<IBaseObject> chain)
        {
            ClearAndSetNewLength(chain.Count);
            alphabet.Add(NullValue.Instance());
            for (int i = 0; i < this.length; i++)
            {
                this.Add(chain[i], i);
            }
        }

        ///<summary>
        /// Создает цепь из строки символов
        ///</summary>
        ///<param name="s"></param>
        ///<exception cref="NotImplementedException"></exception>
        public BaseChain(string s)
        {
            ClearAndSetNewLength(s.Length);
            alphabet.Add(NullValue.Instance());
            for (int i = 0; i < s.Length; i++)
            {
                Add((ValueChar)s[i], i);
            }
        }

        public BaseChain(String building, Alphabet alphabet)
        {
            string[] stringBuilding = building.Split('|');
            ClearAndSetNewLength(stringBuilding.Length);
            for (int i = 0; i < stringBuilding.Length; i++)
            {
                this[i] = alphabet[Convert.ToInt32(stringBuilding[i]) - 1];
            }
        }

        public BaseChain(int[] building, Alphabet alphabet)
        {
            ClearAndSetNewLength(building.Length);
            this.building = (int[])building.Clone();
            this.alphabet = (Alphabet)alphabet.Clone();
        }

        ///<summary>
        /// Строй.
        ///</summary>
        public int[] Building
        {
            get
            {
                return (int[])building.Clone();
            }
        }

        ///<summary>
        /// Возвращает алфавит на котром определны все элементы пространства.
        /// Алфавит является копией и его последующее изменение не как не скажется на состоянии
        /// пространства. алфавит не содержит псеводовеличины.
        ///</summary>
        public Alphabet Alphabet
        {
            get
            {
                Alphabet Temp = (Alphabet)alphabet.Clone();
                Temp.Remove(0);
                return Temp;
            }
        }

        ///<summary>
        /// Длинна цепи.
        /// Только для чтения
        ///</summary>
        public int Length
        {
            get { return length; }
        }

        ///<summary>
        /// Свойстово позволяет получить доступ к элементу цепи по индексу
        /// В случае выхода за границы цепи вызывается исключение
        ///</summary>
        ///<param name="index">номер элемента</param>
        public virtual IBaseObject this[int index]
        {
            get { return Get(index); }

            set { Add(value, index); }
        }

        ///<summary>
        /// Метод позволяющий получить элемент по индексу
        /// В случае выхода за границы цепи вызывается исключение
        ///</summary>
        ///<param name="index">Индекс элемента</param>
        ///<returns>Возвращает элемент</returns>
        public virtual IBaseObject Get(int index)
        {
            return alphabet[building[index]];
        }

        ///<summary>
        /// Метод похволяющий установить элемент по индексу
        ///</summary>
        ///<param name="item">Устанвалеваемый элемент </param>
        ///<param name="index">Номер позиции в цепи куда устанавливается элемент</param>
        public virtual void Add(IBaseObject item, int index)
        {
            if (item == null)
            {
                throw new NullReferenceException();
            }

            RemoveAt(index);
            int pos = alphabet.IndexOf(item);
            if (-1 == pos)
            {
                alphabet.Add(item);
                pos = alphabet.Power - 1;
            }

            building[index] = pos;
        }

        ///<summary>
        /// Возвращает величину из указанного места
        ///</summary>
        ///<param name="index">Место из которого нужно выбрать величину, принадлежащее протранству</param>
        ///<returns>Возвращает объект типа I если место имеет ну пусто наполнение, в противном случае null</returns>
        ///<exception cref="Exception">В случае если место выходит за пределы пространства вызывается исключение</exception>
        public IBaseObject GetItem(int index)
        {
            return this[index];
        }

        ///<summary>
        /// Метод удаляющий элемент с позиции цепи 
        /// В случае выхода за границы цепи вызывается исключение
        ///</summary>
        ///<param name="index">Номер позиции</param>
        public void RemoveAt(int index)
        {
            building[index] = 0;
        }

        public override string ToString()
        {
            string result = "";

            for (int i = 0; i < Length; i++)
            {
                result += this[i].ToString();
            }
            return result;
        }

        ///<summary>
        ///</summary>
        ///<param name="length"></param>
        ///<exception cref="Exception"></exception>
        public void ClearAndSetNewLength(int length)
        {
            if (length <= 0)
            {
                throw new Exception("Длинна цепи <= 0");
            }
            this.length = length;
            building = new int[length];
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public IBaseObject Clone()
        {
            BaseChain temp = new BaseChain(Length);
            FillClone(temp);
            return temp;
        }

        protected void FillClone(BaseChain temp)
        {
            if (temp != null)
            {
                temp.building = (int[])building.Clone();
                temp.alphabet = (Alphabet)alphabet.Clone();
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj.Equals(NullValue.Instance()))
            {
                for (int i = 0; i < Length; i++)
                {
                    if (!Get(i).Equals(NullValue.Instance()))
                    {
                        return false;
                    }
                }
                return true;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            BaseChain chainObject = (BaseChain)obj;
            if (!alphabet.Equals((chainObject).alphabet))
            {
                return false;
            }
            for (int i = 0; (i < chainObject.length) && (i < length); i++)
            {
                if (!this[i].Equals(chainObject[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
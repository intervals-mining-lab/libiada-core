using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root.SimpleTypes;
using LibiadaCore.Classes.TheoryOfSet;

namespace LibiadaCore.Classes.Root
{
    ///<summary>
    /// 
    ///</summary>
    public class BaseChain : IBaseObject
    {
        protected int[] building;
        protected Alphabet alphabet = new Alphabet();

        ///<summary>
        /// Создаёт пустую цепочку заданной длины.
        ///</summary>
        ///<param name="length">Длинна создаваемой цепочки</param>
        public BaseChain(int length)
        {
            ClearAndSetNewLength(length);
        }

        ///<summary>
        ///</summary>
        public BaseChain()
        {
        }

        /// <summary>
        /// Cоздаёт цепочку из списка элементов.
        /// </summary>
        /// <param name="chain">Коллекция элементов</param>
        public BaseChain(List<IBaseObject> chain) : this(chain.Count)
        {
            for (int i = 0; i < Length; i++)
            {
                Add(chain[i], i);
            }
        }

        ///<summary>
        /// Создает цепь из строки символов.
        /// Каждый символ становится элементом.
        ///</summary>
        ///<param name="s">Строка</param>
        public BaseChain(string s) : this(s.Length)
        {
            for (int i = 0; i < s.Length; i++)
            {
                Add((ValueChar)s[i], i);
            }
        }

        /// <summary>
        /// Создаёт цепочку с заданным строем и алфавитом.
        /// Проверка корректности не производится!
        /// </summary>
        /// <param name="building">Строй</param>
        /// <param name="alphabet">Алфавит</param>
        public BaseChain(int[] building, Alphabet alphabet) : this(building.Length)
        {
            this.building = (int[])building.Clone();
            this.alphabet = (Alphabet)alphabet.Clone();
        }

        ///<summary>
        /// Возвращает копию строя.
        /// Его последующее изменение не как не скажется на состоянии цепочки.
        ///</summary>
        public int[] Building
        {
            get { return (int[]) building.Clone(); }
        }

        ///<summary>
        /// Возвращает алфавит.
        /// Алфавит является копией и его последующее изменение не как не скажется на состоянии цепочки.
        /// Алфавит не содержит псеводовеличины (NullValue).
        ///</summary>
        public Alphabet Alphabet
        {
            get
            {
                Alphabet result = (Alphabet)alphabet.Clone();
                result.Remove(0);
                return result;
            }
        }

        ///<summary>
        /// Длинна цепи.
        /// Только для чтения.
        ///</summary>
        public int Length
        {
            get { return building.Length; }
        }

        ///<summary>
        /// Свойстово позволяет получить доступ к элементу цепи по индексу.
        /// В случае выхода за границы цепи вызывается исключение.
        ///</summary>
        ///<param name="index">номер элемента</param>
        public virtual IBaseObject this[int index]
        {
            get { return Get(index); }

            set { Add(value, index); }
        }

        ///<summary>
        /// Метод позволяющий получить элемент по индексу.
        /// В случае выхода за границы цепи вызывается исключение.
        ///</summary>
        ///<param name="index">Индекс элемента</param>
        ///<returns>Возвращает элемент</returns>
        public virtual IBaseObject Get(int index)
        {
            return alphabet[building[index]];
        }

        ///<summary>
        /// Метод похволяющий установить элемент по индексу.
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
        /// Возвращает элемент из указанной позиции.
        ///</summary>
        ///<param name="index">Место из которого нужно выбрать величину</param>
        ///<returns>Возвращает объект типа <see cref="IBaseObject"/> если место имеет ну пусто наполнение, в противном случае <see cref="NullValue"/> </returns>
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
        /// По сути пересоздаёт цепочки, очищая строй и алфавит,
        /// устанавливая новую длину.
        /// В алфавит добавляется <see cref="NullValue"/>.
        ///</summary>
        ///<param name="length">Новая длина цепочки</param>
        ///<exception cref="Exception">Выбрасывается если длина &lt; 0</exception>
        public virtual void ClearAndSetNewLength(int length)
        {
            if (length < 0)
            {
                throw new Exception("Длинна цепи < 0");
            }

            building = new int[length];
            alphabet = new Alphabet {NullValue.Instance()};
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
            if (obj as BaseChain == null)
            {
                return false;
            }
            BaseChain chainObject = (BaseChain)obj;
            if (!alphabet.Equals((chainObject).alphabet))
            {
                return false;
            }
            for (int i = 0; (i < chainObject.Length) && (i < Length); i++)
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
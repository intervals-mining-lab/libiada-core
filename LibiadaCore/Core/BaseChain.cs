namespace LibiadaCore.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using LibiadaCore.Core.SimpleTypes;

    /// <summary>
    /// The base chain.
    /// </summary>
    public class BaseChain : AbstractChain
    {
        /// <summary>
        /// The building of chain.
        /// </summary>
        protected int[] building;

        /// <summary>
        /// The alphabet of chain.
        /// </summary>
        protected Alphabet alphabet = new Alphabet();

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseChain"/> class.
        /// </summary>
        /// <param name="length">
        /// The length of chain.
        /// </param>
        public BaseChain(int length)
        {
            ClearAndSetNewLength(length);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseChain"/> class with 0 length.
        /// </summary>
        public BaseChain()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseChain"/> class from list of elements.
        /// </summary>
        /// <param name="elements">
        /// The elements.
        /// </param>
        public BaseChain(List<IBaseObject> elements) : this(elements.Count)
        {
            for (int i = 0; i < building.Length; i++)
            {
                Add(elements[i], i);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseChain"/> class from string.
        /// Each character becoms element.
        /// </summary>
        /// <param name="source">
        /// The source string.
        /// </param>
        public BaseChain(string source) : this(source.Length)
        {
            for (int i = 0; i < source.Length; i++)
            {
                Add(new ValueChar(source[i]), i);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseChain"/> class 
        /// with provided building and alphabet.
        /// Only simple validation is made.
        /// </summary>
        /// <param name="building">
        /// The building of chain.
        /// </param>
        /// <param name="alphabet">
        /// The alphabet of chain.
        /// </param>
        public BaseChain(int[] building, Alphabet alphabet) : this(building.Length)
        {
            if (building.Max() + 1 != alphabet.Cardinality)
            {
                throw new ArgumentException("Building max value does not corresponds with alphabet length.");
            }

            this.building = (int[])building.Clone();
            this.alphabet = (Alphabet)alphabet.Clone();
        }

        /// <summary>
        /// Возвращает копию строя.
        /// Его последующее изменение не как не скажется на состоянии цепочки.
        /// </summary>
        public int[] Building
        {
            get
            {
                return (int[])building.Clone();
            }
        }

        /// <summary>
        /// Возвращает алфавит.
        /// Алфавит является копией и его последующее изменение не как не скажется на состоянии цепочки.
        /// Алфавит не содержит псеводовеличины (NullValue).
        /// </summary>
        public Alphabet Alphabet
        {
            get
            {
                var result = (Alphabet)alphabet.Clone();

                // Удаляем NullValue
                result.Remove(0);
                return result;
            }
        }

        /// <summary>
        /// Метод позволяющий получить элемент по индексу.
        /// В случае выхода за границы цепи вызывается исключение.
        /// </summary>
        /// <param name="index">
        /// Индекс элемента
        /// </param>
        /// <returns>
        /// Возвращает элемент
        /// </returns>
        public override IBaseObject Get(int index)
        {
            return alphabet[building[index]];
        }

        /// <summary>
        /// The length of chain.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetLength()
        {
            return building.Length;
        }

        /// <summary>
        /// Метод похволяющий установить элемент по индексу.
        /// </summary>
        /// <param name="item">
        /// Устанвалеваемый элемент 
        /// </param>
        /// <param name="index">
        /// Номер позиции в цепи куда устанавливается элемент
        /// </param>
        public override void Add(IBaseObject item, int index)
        {
            if (item == null)
            {
                throw new NullReferenceException();
            }

            RemoveAt(index);
            int position = alphabet.IndexOf(item);
            if (position == -1)
            {
                alphabet.Add(item);
                position = alphabet.Cardinality - 1;
            }

            building[index] = position;
        }

        /// <summary>
        /// Метод удаляющий элемент с позиции цепи 
        /// В случае выхода за границы цепи вызывается исключение
        /// </summary>
        /// <param name="index">
        /// Номер позиции
        /// </param>
        public override void RemoveAt(int index)
        {
            building[index] = 0;
        }

        /// <summary>
        /// По сути пересоздаёт цепочки, очищая строй и алфавит,
        /// устанавливая новую длину.
        /// В алфавит добавляется <see cref="NullValue"/>.
        /// </summary>
        /// <param name="length">
        /// Новая длина цепочки.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Выбрасывается если длина &lt; 0
        /// </exception>
        public override void ClearAndSetNewLength(int length)
        {
            if (length < 0)
            {
                throw new ArgumentException("Chain length shouldn't be less than 0.");
            }

            building = new int[length];
            alphabet = new Alphabet { NullValue.Instance() };
        }

        /// <summary>
        /// The clone.
        /// </summary>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public override IBaseObject Clone()
        {
            var clone = new BaseChain(building.Length);
            FillClone(clone);
            return clone;
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool Equals(object other)
        {
            if (other == null)
            {
                return false;
            }

            if (other.Equals(NullValue.Instance()))
            {
                for (int i = 0; i < building.Length; i++)
                {
                    if (!Get(i).Equals(NullValue.Instance()))
                    {
                        return false;
                    }
                }

                return true;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (other as BaseChain == null)
            {
                return false;
            }

            var chainObject = (BaseChain)other;
            if (!alphabet.Equals(chainObject.alphabet))
            {
                return false;
            }

            for (int i = 0; (i < chainObject.GetLength()) && (i < building.Length); i++)
            {
                if (!this[i].Equals(chainObject[i]))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// The fill clone.
        /// </summary>
        /// <param name="clone">
        /// The clone.
        /// </param>
        protected void FillClone(BaseChain clone)
        {
            if (clone != null)
            {
                clone.building = (int[])building.Clone();
                clone.alphabet = (Alphabet)alphabet.Clone();
            }
        }
    }
}
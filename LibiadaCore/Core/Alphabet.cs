namespace LibiadaCore.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Данный класс реализует алфавит элементов
    /// Алфавит это список из уникальных элементов
    /// Алфавит является классом организованным в соотвествии с паттреном "Значение"
    /// </summary>
    public class Alphabet : IBaseObject, IEnumerable
    {
        /// <summary>
        /// The elements within alphabet.
        /// </summary>
        protected readonly List<IBaseObject> Elements = new List<IBaseObject>();

        /// <summary>
        /// Свойство возвращает мощность алфавита.
        /// Кол-во элементов в алфавите. 
        /// </summary>
        public int Cardinality
        {
            get
            {
                 return this.Elements.Count;
            }
        }

        /// <summary>
        /// Позволяет получить доступ к элементу алфавита по индексу.
        /// Позволяет записывать и считывать элемент.
        /// При записи происходит проверка на отсутствие данного объекта в алфавите. 
        /// В случае успешной исхода данной проверки элемент добавляется в алфавит, 
        /// в противном этого не происходит, при том класс не уведомляет об этом вненюю среду. 
        /// Если индекс меньше 0  или >= мощности алфавата вызывается исключение.
        /// </summary>
        /// <param name="index">
        /// Индекс элемента в алфавите
        /// </param>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public IBaseObject this[int index]
        {
            get
            {
                return this.Elements[index].Clone();
            }

            set
            {
                if (!this.Elements.Contains(value))
                {
                    this.Elements[index] = value.Clone();
                }
            }
        }

        /// <summary>
        ///  Реализация добавления элемента в алфавит.
        /// </summary>
        /// <param name="baseObject">
        /// Добавляемый элемент
        /// </param>
        /// <returns>
        /// Возвращает его номер в алфавите
        /// </returns>
        /// <exception cref="Exception">
        /// В случае если такой элемент уже содержится алфавите
        /// </exception>
        /// <exception cref="NullReferenceException">
        /// В случае если добавляемый элемент null
        /// </exception>
        public virtual int Add(IBaseObject baseObject)
        {
            if (baseObject == null)
            {
                throw new NullReferenceException();
            }

            if (this.Elements.Contains(baseObject))
            {
                throw new Exception();
            }

            this.Elements.Add(baseObject.Clone());
            return this.Elements.IndexOf(baseObject);
        }

        /// <summary>
        /// Удаление элемента из алфавита по указанному индексу.
        /// Если индекс меньше 0  или >= мощности алфавата вызывается исключение
        /// </summary>
        /// <param name="index">Индекс удаляемого элемента в алфавите</param>
        public virtual void Remove(int index)
        {
            this.Elements.RemoveAt(index);
        }

        /// <summary>
        /// Клонирование алфавита
        /// </summary>
        /// <returns>Копию алфавита</returns>
        public IBaseObject Clone()
        {
            var clone = new Alphabet();
            for (int i = 0; i < this.Elements.Count; i++)
            {
                clone.Add(this.Elements[i]);
            }

            return clone;
        }

        /// <summary>
        /// Сравнение алфавита исходного и заданного в параметре
        /// Два алфавита считаются эквивалентными при условии равномощности алфавитов и эквивалентности их составов
        /// если в качестве второго объекта передается экземпляр класса отличного от алфавита возвращается 
        /// объекты считаются не эквивалентными
        /// </summary>
        /// <param name="other"> 
        /// алфавит сравниваемый с исходным
        /// </param>
        /// <returns>
        /// true если алфавиты эквиваленты, иначе false 
        /// </returns>
        public override bool Equals(object other)
        {
            if (other == null)
            {
                return false;
            }

            if (ReferenceEquals(other, this))
            {
                return true;
            }

            return this.EqualsAsAlphabet(other as Alphabet);
        }

        /// <summary>
        /// Возвращает индекс объекта в алфавите.
        /// В случае, если данного объекта нет в алфавите возвращает -1.
        /// </summary>
        /// <param name="obj">
        /// Объект который ищем в алфавите
        /// </param>
        /// <returns>
        /// Индекс объекта в алфавите
        /// </returns>
        public int IndexOf(IBaseObject obj)
        {
            return this.Elements.IndexOf(obj);
        }

        /// <summary>
        /// Определяет принадлежность объекта к алфавиту
        /// </summary>
        /// <param name="element">
        /// Объект
        /// </param>
        /// <returns>
        /// True если алфавит содержит данный объект, иначе false
        /// </returns>
        public bool Contains(IBaseObject element)
        {
            return this.Elements.Contains(element);
        }

        /// <summary>
        /// The get enumerator.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerator"/>.
        /// </returns>
        public IEnumerator GetEnumerator()
        {
            return this.Elements.GetEnumerator();
        }

        /// <summary>
        /// The to array.
        /// </summary>
        /// <returns>
        /// The <see cref="T:IBaseObject[]"/>.
        /// </returns>
        public IBaseObject[] ToArray()
        {
            var result = new List<IBaseObject>();

            foreach (var vault in this.Elements)
            {
                result.Add(vault.Clone());
            }

            return result.ToArray();
        }

        /// <summary>
        /// The to list.
        /// </summary>
        /// <returns>
        /// The <see cref="List{IBaseObject}"/>.
        /// </returns>
        public List<IBaseObject> ToList()
        {
            var result = new List<IBaseObject>();

            foreach (var vault in this.Elements)
            {
                result.Add(vault.Clone());
            }

            return result;
        }

        /// <summary>
        /// The get hash code.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode()
        {
            int temp = 0;
            foreach (IBaseObject o in this.Elements)
            {
                temp += 29 * o.GetHashCode();
            }

            return temp;
        }

        /// <summary>
        /// Поэлементное сравнение алфавитов
        /// </summary>
        /// <param name="other">алфавит который сравнивают с исходным</param>
        /// <returns>
        /// true, если алфавиты равны, иначе false
        /// </returns>
        private bool EqualsAsAlphabet(Alphabet other)
        {
            if (other == null || this.Cardinality != other.Cardinality)
            {
                return false;
            }

            for (int i = 0; i < this.Cardinality; i++)
            {
                if (!this.Elements.Contains(other.Elements[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
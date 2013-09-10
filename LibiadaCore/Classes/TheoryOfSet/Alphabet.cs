using System;
using System.Collections;
using System.Collections.Generic;
using LibiadaCore.Classes.Root;

namespace LibiadaCore.Classes.TheoryOfSet
{
    ///<summary>
    /// Данный класс реализует алфавит элементов
    /// Алфавит это список из уникальных элементов
    /// Алфавит является классом организованным в соотвествии с паттреном "Значение"
    ///</summary>
    public class Alphabet : IBaseObject, IEnumerable
    {
        protected List<IBaseObject> Vault = new List<IBaseObject>();

        ///<summary>
        /// Свойство возвращает мощность алфавита.
        /// Кол-во элементов в алфавите. 
        ///</summary>
        public int Power
        {
            get
            {
                 return Vault.Count;
            }
        }

        ///<summary>
        ///  Реализация добавления элемента в алфавит.
        ///</summary>
        ///<param name="baseObject">Добавляемый элемент</param>
        ///<returns>Возвращает его номер в алфавите</returns>
        ///<exception cref="Exception">В случае если такой элемент уже содержится алфавите</exception>
        ///<exception cref="NullReferenceException">В случае если добавляемый элемент null</exception>
        public virtual int Add(IBaseObject baseObject)
        {
            if (baseObject == null)
            {
                throw new NullReferenceException();
            }
            if (Vault.Contains((baseObject)))
            {
                throw new Exception();
            }
            Vault.Add(baseObject.Clone());
            return Vault.IndexOf(baseObject);
        }

        ///<summary>
        /// Позволяет получить доступ к элементу алфавита по индексу.
        /// Позволяет записывать и считывать элемент.
        /// При записи происходит проверка на отсутствие данного объекта в алфавите. 
        /// В случае успешной исхода данной проверки элемент добавляется в алфавит, 
        /// в противном этого не происходит, при том класс не уведомляет об этом вненюю среду. 
        /// Если индекс меньше 0  или >= мощности алфавата вызывается исключение.
        ///</summary>
        ///<param name="index">Индекс элемента в алфавите</param>
        public IBaseObject this[int index]
        {
            get { return Vault[index].Clone(); }
            set
            {
                if (!Vault.Contains(value))
                {
                    Vault[index] = value.Clone();
                }
            }
        }

        /// <summary>
        /// Удаление элемента из алфавита по указанному индексу.
        /// Если индекс меньше 0  или >= мощности алфавата вызывается исключение
        /// </summary>
        /// <param name="index">Индекс удаляемого элемента в алфавите</param>
        public virtual void Remove(int index)
        {
            Vault.RemoveAt(index);
        }

        /// <summary>
        /// Клонирование алфавита
        /// </summary>
        /// <returns>Копию алфавита</returns>
        public IBaseObject Clone()
        {
            Alphabet result = new Alphabet {Vault = new List<IBaseObject>(Vault)};
            return result;
        }

        /// <summary>
        /// Сравнение алфавита исходного и заданного в параметре
        /// Два алфавита считаются эквивалентными при условии равномощности алфавитов и эквивалентности их составов
        /// если в качестве второго объекта передается экземпляр класса отличного от алфавита возвращается 
        /// объекты считаются не эквивалентными
        /// </summary>
        /// <param name="obj"> алфавит сравниваемый с исходным</param>
        /// <returns>true если алфавиты эквиваленты, иначе false </returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (ReferenceEquals(obj, this))
            {
                return true;
            }
            return EqualsAsAlphabet(obj as Alphabet);
        }

        /// <summary>
        /// Поэлементное сравнение алфавитов
        /// </summary>
        /// <param name="aObj">алфавит который сравнивают с исходным</param>
        /// <returns>true, если алфавиты равны, иначе false</returns>
        private bool EqualsAsAlphabet(Alphabet aObj)
        {
            if (aObj == null || Power != aObj.Power)
            {
                return false;
            }

            for (int i = 0; i < Power; i++)
            {
                if (!Vault.Contains(aObj.Vault[i]))
                {
                    return false;
                }
            }
            return true;
        }

        ///<summary>
        /// Возвращает индекс объекта в алфавите.
        /// В случае, если данного объекта нет в алфавите возвращает -1.
        ///</summary>
        ///<param name="obj">Объект который ищем в алфавите</param>
        ///<returns>Индекс объекта в алфавите</returns>
        public int IndexOf(IBaseObject obj)
        {
            return Vault.IndexOf(obj);
        }

        ///<summary>
        ///Определяет принадлежность объекта к алфавиту
        ///</summary>
        ///<param name="obj">Объект</param>
        ///<returns>True если алфавит содержит данный объект, иначе false</returns>
        public bool Contains(IBaseObject obj)
        {
            return Vault.Contains(obj);
        }

        public IEnumerator GetEnumerator()
        {
            return Vault.GetEnumerator();
        }

        public IBaseObject[] ToArray()
        {
            return new List<IBaseObject>(Vault).ToArray();
        }

        public List<IBaseObject> ToList()
        {
            return new List<IBaseObject>(Vault);
        }

        public override int GetHashCode()
        {
            int temp = 0;
            foreach (IBaseObject o in Vault)
            {
                temp += 29*o.GetHashCode();
            }
            return temp;
        }
    }
}
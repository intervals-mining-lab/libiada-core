using System;
using System.Collections;
using ChainAnalises.Classes.Root;

namespace ChainAnalises.Classes.TheoryOfSet
{
    ///<summary>
    /// Данный класс реализует алфавит элементов
    /// Алфавит это список из уникальных элементов
    /// Алфавит является классом организованным в соотвествии с паттреном "Значение"
    ///</summary>
    [Serializable]
    public class Alphabet : IBaseObject, IEnumerable
    {
        protected ArrayList vault = new ArrayList();

        ///<summary>
        ///</summary>
        public Alphabet()
        {
        }

        ///<summary>
        ///</summary>
        ///<param name="Bin"></param>
        public Alphabet(AlphabetBin Bin)
        {
            foreach (IBin item in Bin.Items)
            {
                vault.Add(item.GetInstance());
            }
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public IBin GetBin()
        {
            AlphabetBin Temp = new AlphabetBin();
            FillBin(Temp);
            return Temp;
        }

        protected virtual void FillBin(AlphabetBin temp)
        {
            foreach (IBaseObject baseObject in vault)
            {
                temp.Items.Add(baseObject.GetBin());
            }

        }

        ///<summary>
        /// Свойство возвращает мощность алфавита.
        /// Кол-во элементов в алфавите. 
        ///</summary>
        public int power
        {
            get
            {
                 return vault.Count;
            }
        }

        ///<summary>
        ///  Реализация добавления элемента в алфавит.
        ///</summary>
        ///<param name="o">Добавляемый элемент</param>
        ///<returns>Возвращает его номер в алфавите</returns>
        ///<exception cref="Exception">В случае если такой элемент уже содержится алфавите</exception>
        ///<exception cref="NullReferenceException">В случае если добавляемый элемент null</exception>
        public virtual int Add(IBaseObject o)
        {
            if (vault.Contains((o)))
            {
                throw new Exception();
            }
            if (o == null)
            {
                throw new NullReferenceException();
            }
            return vault.Add(o.Clone());
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
            get { return ((IBaseObject) (vault[index])).Clone(); }
            set
            {
                if (!vault.Contains(value))
                {
                    vault[index] = value.Clone();
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
            vault.RemoveAt(index);
        }

        /// <summary>
        /// Клонирование алфавита
        /// </summary>
        /// <returns>Копию алфавита</returns>
        public IBaseObject Clone()
        {
            Alphabet AlNew = new Alphabet();
            AlNew.vault = (ArrayList) vault.Clone();
            return AlNew;
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
        /// <param name="a_obj">алфавит который сравнивают с исходным</param>
        /// <returns>true, если алфавиты равны, иначе false</returns>
        private bool EqualsAsAlphabet(Alphabet a_obj)
        {
            if (a_obj == null || power != a_obj.power)
            {
                return false;
            }

            for (int i = 0; i < power; i++)
            {
                if (!vault.Contains(a_obj.vault[i]))
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
            return vault.IndexOf(obj);
        }

        ///<summary>
        ///Определяет принадлежность объекта к алфавиту
        ///</summary>
        ///<param name="obj">Объект</param>
        ///<returns>True если алфавит содержит данный объект, иначе false</returns>
        public bool Contains(IBaseObject obj)
        {
            return vault.Contains(obj);
        }

        public IEnumerator GetEnumerator()
        {
            return vault.GetEnumerator();
        }

        public override int GetHashCode()
        {
            int temp = 0;
            foreach (object o in vault)
            {
                temp += 29*o.GetHashCode();
            }
            return temp;
        }
    }

    ///<summary>
    ///</summary>
    public class AlphabetBin:IBin
    {
        public ArrayList Items = new ArrayList();

        public IBaseObject GetInstance()
        {
            return new Alphabet(this);
        }
    }
}
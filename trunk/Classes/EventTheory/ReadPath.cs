using System;
using System.Collections;

namespace ChainAnalises.Classes.EventTheory
{
    ///<summary>
    ///Класс реализующий объект Маршрут
    ///</summary>
    [Serializable]
    public class ReadPath : ICloneable
    {
        protected ArrayList vault = new ArrayList();

        protected bool Contains(Place ToRule)
        {
            for (int i = 0; i < vault.Count; i++)
            {
                if (((Place) vault[i]).EqualsAsPlace(ToRule))
                {
                    return true;
                }
            }
            return false;
        }

        ///<summary>
        /// Конструктор
        ///</summary>
        ///<param name="First">первый элемент пути</param>
        public ReadPath(Place First)
        {
            if (First == null)
            {
                throw new NullReferenceException("Первый элемент пути null");
            }
            vault.Add(First.Clone());
        }

        ///<summary>
        /// Метод добавляет Место в путь чтений.
        ///</summary>
        ///<param name="ToRule">место добавляемое в путь чтения. Должно быть совместимым с пространством которому принадлежит данный путь</param>
        ///<exception cref="Exception">В случае если место не совместимо с пространстовом или уже имеется в данном пути вызывается исключение</exception>
        public void Add(Place ToRule)
        {
            if (!ToRule.CompatibleTo((Place) vault[0]))
            {
                throw new Exception("Места принадлежат несовместимым пространствам");
            }

            if (vault.Contains(ToRule) /*|| Contains(ToRule)*/)
            {
                throw new Exception("Путь не должен пересекаться");
            }

            if (!((Place) vault[vault.Count - 1]).Neighbour(ToRule))
            {
                throw new Exception("Путь должен быть непрерывным");
            }

            vault.Add(ToRule.Clone());
        }

        ///<summary>
        /// Свойство позволяющее получить доступ к любому элементу пути
        ///</summary>
        ///<param name="index">Номер элемента</param>
        ///<returns>Объект Место</returns>
        ///<exception cref="Exception">В случае если номер элемента выходит за границы размера массива вызывается исключение</exception>
        public Place this[int index]
        {
            get { return (Place) ((Place) vault[index]).Clone(); }
        }

        ///<summary>
        ///Свойство позволяющее получить паттерн пространства
        ///</summary>
        public Place Pattern
        {
            get { return (Place) ((Place) vault[0]).Clone(); }
        }

        ///<summary>
        /// Удаляет последний элемент пути
        ///</summary>
        public void Remove()
        {
            vault.RemoveAt(vault.Count - 1);
        }

        ///<summary>
        /// Длина пути
        /// Всегда >= 1
        ///</summary>
        public int Length
        {
            get { return vault.Count; }
        }

        ///<summary>
        /// Метод сравнимвающий Пути чтения
        ///</summary>
        ///<param name="b">путь чтения с которым сравниваем</param>
        ///<returns>true если пути состоят из одинаковых элементов</returns>
        ///<exception cref="NullReferenceException">В случае сравнения с null или путем принадлежащем несовместимому пространству вызывается исключение</exception>
        public bool EqualAsReadPath(ReadPath b)
        {
            if (b == null)
            {
                throw  new NullReferenceException("Путь равент null");
            }

            if (!Pattern.CompatibleTo(b.Pattern))
            {
                throw new Exception("Пути принадлежать несовместимым пространствам");
            }

            for (int i = 0; i < vault.Count; i++)
            {
                if (!((Place) vault[i]).EqualsAsPlace(b[i]))
                {
                    return false;
                }
            }
            return true;
        }

        ///<summary>
        ///Creates a new object that is a copy of the current instance.
        ///</summary>
        ///
        ///<returns>
        ///A new object that is a copy of this instance.
        ///</returns>
        ///<filterpriority>2</filterpriority>
        public object Clone()
        {
            ReadPath Temp = new ReadPath((Place) ((Place) vault[0]).Clone());
            Temp.vault = (ArrayList) vault.Clone();
            return Temp;
        }
    }
}
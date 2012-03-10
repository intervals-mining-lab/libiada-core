using System;
using System.Collections;

namespace LibiadaCore.Classes.EventTheory
{
    ///<summary>
    /// Класс реализующий правило чтения
    ///</summary>
    [Serializable]
    public class ReadRule
    {
        protected Place pPattern = null;
        protected ArrayList vault = new ArrayList();

        ///<summary>
        ///Метод реализует проверку на наличние места в правиле.
        ///</summary>
        ///<param name="ToRule">Проверяемое место</param>
        ///<returns>Возвраает true в случае наличния данного места в правиле, иначе false</returns>
        public bool Contains(Place ToRule)
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
        /// Свойство возвращающее кол-во мест с которыми соеденено данное
        ///</summary>
        public int Count
        {
            get { return vault.Count; }
        }

        ///<summary>
        /// Конструктор
        ///</summary>
        ///<param name="Place">Базовое место для которого используется данное правило</param>
        ///<exception cref="NullReferenceException">В случае если базовое место null вызывает исключение.</exception>
        public ReadRule(Place Place)
        {
            if (Place == null)
            {
                throw new NullReferenceException();
            }
            pPattern = Place;
        }

        ///<summary>
        /// метод добавляющий отношение "чтения" между базовым и передоваемым местом 
        ///</summary>
        ///<param name="Place">Передоваемое место</param>
        ///<exception cref="Exception">В случае если передоваемое место уже имеется в списке, не является соседним для базового или является null вызывается исключение</exception>
        public void Add(Place Place)
        {
            if (!pPattern.CompatibleTo(Place) || !pPattern.Neighbour(Place) || Contains(Place))
            {
                throw new Exception();
            }
            vault.Add(Place.Clone());
        }

        ///<summary>
        /// Свойство позволяющее получить элемент(места) с которым базовое место связанно отнощением "чтения"
        ///</summary>
        ///<param name="index">Номер элемента</param>
        public Place this[int index]
        {
            get { return (Place) ((Place) vault[index]).Clone(); }
            set
            {
                if (!pPattern.CompatibleTo(value) || Contains(value) || !pPattern.Neighbour(value))
                {
                    throw new Exception();
                }
                vault[index] = value.Clone();
            }
        }

        ///<summary>
        /// Метод удаляет место из правила
        ///</summary>
        ///<exception cref="NotImplementedException">В случае если номер места больше количества элементов или меньше 0 вызываается исключение</exception>
        public void Remove(int index)
        {
            vault.RemoveAt(index);
        }

        ///<summary>
        /// метод реализует отношение эквивальентность
        ///</summary>
        ///<param name="B">Правило с которым сравниваем</param>
        ///<returns>True если места совпадают иначе false</returns>
        public bool EqualAsRule(ReadRule B)
        {
            if (vault.Count != B.Count)
            {
                return false;
            }
            for (int i = 0; i < Count; i++)
            {
                if (!vault.Contains((B[i])))
                {
                    return false;
                }
            }
            return true;
        }

        ///<summary>
        /// Метод клонирования глубокого
        ///</summary>
        ///<returns>Вощвращаяет копию объекта</returns>
        public ReadRule Clone()
        {
            ReadRule temp = new ReadRule(pPattern);
            temp.vault = (ArrayList) vault.Clone();
            return temp;
        }

        ///<summary>
        /// Метод производящий склеивание двух правил
        /// Правила должну принадолжать одному месту.
        ///</summary>
        ///<param name="rr2">Второе правило</param>
        ///<returns>ссылку на самого себя</returns>
        ///<exception cref="NotImplementedException">выкидывате исключение если правила принадлежть разным точкам или второй аргумент null</exception>
        public ReadRule Add(ReadRule rr2)
        {
            if (rr2 == null)
            {
                throw new NullReferenceException();
            }
            if (!pPattern.EqualsAsPlace(rr2.pPattern))
            {
                throw new Exception();
            }

            for (int i = 0; i < rr2.Count; i++)
            {
                if (!Contains(rr2[i]))
                {
                    Add(rr2[i]);
                }
            }
            return this;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return EqualAsRule(obj as ReadRule);
        }
    }
}
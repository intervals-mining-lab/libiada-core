using System;
using System.Collections;
using System.Diagnostics;
using ChainAnalises.Classes.Root;

namespace ChainAnalises.Classes.EventTheory
{
    ///<summary>
    /// Класс Место
    ///</summary>
    [Serializable]
    public class Place : IBaseObject
    {
        private readonly ArrayList pDimensions = new ArrayList();
        private readonly ArrayList Values = new ArrayList();

        ///<summary>
        /// Конструктор
        ///</summary>
        ///<param name="dimensionality">Размерность пространтсва которому принаджелит ланное место</param>
        ///<exception cref="Exception">Экземпляр класса</exception>
        public Place(ArrayList dimensionality)
        {
            if (dimensionality == null) throw new ArgumentNullException("dimensionality");
            if (dimensionality.Count <= 0)
            {
                Debug.WriteLine("-------------------------------------------------------------------------");
                Debug.WriteLine("Warning: " + (GetType()) + " place would be empty (wrong space )");
                Debug.WriteLine("Предупреждение: " + (GetType()) + " вырожденое место (пространиство вырождненое) ");
                Debug.WriteLine("-------------------------------------------------------------------------");
                throw new Exception("Dimention is wrong <0");
            }
            else
            {
                for (int i = 0; i < dimensionality.Count; i++) //TODO
                {
                    if (pDimensions.Contains(dimensionality[i]))
                    {
                        throw  new Exception("Ошибка данных. Битое пространство");
                    }
                    Values.Add(((Dimension) dimensionality[i]).min);
                    pDimensions.Add(((Dimension) dimensionality[i]).Clone());
                }
            }
        }

        ///<summary>
        /// Устанваливает значение value по измерению под номером index 
        ///</summary>
        ///<param name="value">Значение</param>
        ///<param name="index">Номер измерения</param>
        ///<exception cref="Exception">При попытке установить значение не существующему измерению или значение выходит за область определения измерния вызыватся исключение</exception>
        public virtual void SetValue(Int64 value, Int64 index)
        {
//Данный код можно убрать без боязни... :) Оставил просто для понимания....:)
            if (index >= pDimensions.Count || index < 0)
            {
                throw  new Exception("Попытка установить не существующее измерение");
            }
//код который можно убрать кончлися :)

            if (value < ((Dimension) pDimensions[(int) index]).min || value > ((Dimension) pDimensions[(int) index]).max)
            {
                throw new Exception("Попытка установить значение " + value + " выходящие за область определения (" +
                                    ((Dimension) pDimensions[(int) index]).min + " , " +
                                    ((Dimension) pDimensions[(int) index]).max + ")  данного измерения ");
            }
            Values[(int) index] = value;
        }

/*
        ///<summary>
        /// Устанваливает значение value по измерению Dimension 
        ///</summary>
        ///<param name="value">Значение</param>
        ///<param name="inDimension">Измерние</param>
        ///<exception cref="Exception">При попытке установить значение не существующему измерению или значение выходит за область определения измерния вызыватся исключение</exception>
        public virtual void SetValue(Int64 value, Dimension inDimension)
        {
            SetValue(value,pDimensions.IndexOf(inDimension));
        }
*/

        ///<summary>
        ///Устанавливает значения по всем измерениям из массива.
        ///</summary>
        ///<param name="value">Массив значений</param>
        ///<exception cref="Exception">В случае если размерности массива и места не совпадают и в случае если одно из значений выходит за пределы области определения соответствующего измерния вызывается исключение</exception>
        public virtual Place SetValues(Int64[] value)
        {
            if (value.GetLength(0) != pDimensions.Count)
            {
                throw new Exception("Размерности не совпадают");
            }

            for (Int64 i = 0; i < pDimensions.Count; i++)
            {
                SetValue(value[i], i);
            }

            return this;
        }

        ///<summary>
        /// Возвращяет значение по измерению под номером index 
        ///</summary>
        ///<param name="index">Номер измерения</param>
        ///<exception cref="Exception">При попытке получить значение по несуществующему измерению вызыватся исключение</exception>
        public virtual Int64 GetValue(Int64 index)
        {
            if (index >= pDimensions.Count || index < 0)
            {
                throw new Exception("Попытка получить значение не существующего измерения");
            }
            return (long) Values[(int) index];
        }

/*
        ///<summary>
        /// Возвращяет значение по измерению Dimension
        ///</summary>
        ///<param name="inDimension">Измерение</param>
        ///<exception cref="Exception">При попытке получить значение по несуществующему измерению вызыватся исключение</exception>
        public virtual Int64 GetValue(Dimension inDimension)
        {
            return GetValue(pDimensions.IndexOf(inDimension));
        }
*/

        ///<summary>
        /// Возвращает массив значений по всем измерениям
        ///</summary>
        ///<returns>Массив значений по всем измерениям</returns>
        public virtual Int64[] GetValues()
        {
            return (long[]) new ArrayList(Values).ToArray(typeof (long));
        }

        ///<summary>
        ///Возвращает массив измерний пространства которому принадлежит место 
        ///</summary>
        public IList Dimension
        {
            get { return pDimensions; }
        }

        ///<summary>
        /// Возвращает размерность пространства которому принадлежит место.
        ///</summary>
        public Int64 Count
        {
            get
            {
                if (pDimensions.Count != Values.Count)
                {
                    throw new Exception("Ошибка челостности данных");
                }
                return pDimensions.Count;
            }
        }

        ///<summary>
        ///</summary>
        ///<param name="b"></param>
        ///<returns></returns>
        ///<exception cref="Exception"></exception>
        public Boolean CompatibleTo(Place b)
        {
            if (b == null)
            {
                throw new NullReferenceException("Место null");
            }
            if (ReferenceEquals(this, b))
            {
                return true;
            }

            if (b.Count != Count)
            {
                return false;
            }

            for (int i = 0; i < b.Count; i++)
            {
                if (!((Dimension) b.Dimension[i]).EqualsAsDimension((Dimension) pDimensions[i]))
                {
                    return false;
                }
            }
            return true;
        }

        ///<summary>
        ///</summary>
        ///<param name="b"></param>
        ///<returns></returns>
        ///<exception cref="Exception"></exception>
        public Boolean Neighbour(Place b)
        {
            if (b == null)
            {
                return false;
            }
            bool result;
            int Distance = 0;

            if (!CompatibleTo(b))
            {
                return false;
            }

            for (int i = 0; i < b.Count; i++)
            {
                if (b.GetValue(i) == GetValue(i))
                {
                    continue;
                }
                Distance = (int) (Distance + Math.Abs(b.GetValue(i) - GetValue(i)));
            }
            result = Distance == 1;
            return result;
        }

        ///<summary>
        /// Сравнивает два места как места
        ///</summary>
        ///<param name="after">место с которым сравниваем. Если null то возвращает false</param>
        ///<returns>True если места принадлежат одному пространству и имеют одинаковые значения иначе false</returns>
        public bool EqualsAsPlace(Place after)
        {
            if (after == null || !CompatibleTo(after))
            {
                return false;
            }

            for (int i = 0; i < Count; i++)
            {
                if (!((Dimension) pDimensions[i]).EqualsAsDimension((Dimension) after.Dimension[i]) ||
                    GetValue(i) != after.GetValue(i))
                {
                    return false;
                }
            }
            return true;
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public IBaseObject Clone()
        {
            Place Temp = new Place((ArrayList) pDimensions.Clone());
            Temp.SetValues((long[]) Values.ToArray(typeof (long)).Clone());
            return Temp;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            return EqualsAsPlace(obj as Place);
        }

        public IBin GetBin()
        {
            throw new NotImplementedException();
        }
    }
}
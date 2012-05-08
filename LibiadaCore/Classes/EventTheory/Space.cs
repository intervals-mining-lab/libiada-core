using System;
using System.Collections;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.TheoryOfSet;

namespace LibiadaCore.Classes.EventTheory
{
    ///<summary>
    /// Данный класс реализует простраство. 
    ///</summary>
    [Serializable]
    public class Space : IEnumerator, IBaseObject
    {
        ///<summary>
        /// Конструктор
        ///</summary>
        public Space()
        {
            pAlphabet.Add(PsevdoValue.Instance());
        }

        #region <Private Structure>

        protected Int64[] vault = null;
        protected Alphabet pAlphabet = new Alphabet();
        protected ArrayList pDimension = new ArrayList();

        #endregion

        #region <Iterator>

        private int EnumeratorState = -1;
        private bool WasChange = false;
        private int ElementsCount = 0;

        ///<summary>
        ///Advances the enumerator to the next element of the collection.
        ///</summary>
        ///<returns>
        ///true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.
        ///</returns>
        ///<exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception><filterpriority>2</filterpriority>
        public bool MoveNext()
        {
            if (EnumeratorState == -1)
            {
                WasChange = false;
            }

            if (WasChange)
            {
                throw new InvalidOperationException();
            }
            EnumeratorState = EnumeratorState + 1;
            return EnumeratorState < vault.Length;
        }

        ///<summary>
        ///Sets the enumerator to its initial position, which is before the first element in the collection.
        ///</summary>
        ///<exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception><filterpriority>2</filterpriority>
        public void Reset()
        {
            EnumeratorState = -1;
            WasChange = false;
        }

        ///<summary>
        ///Gets the current element in the collection.
        ///</summary>
        ///<returns>
        ///The current element in the collection.
        ///</returns>
        ///<exception cref="T:System.InvalidOperationException">The enumerator is positioned before the first element of the collection or after the last element. </exception><filterpriority>2</filterpriority>
        public object Current
        {
            get
            {
                if (WasChange || EnumeratorState == -1 || EnumeratorState >= vault.Length)
                {
                    throw new InvalidOperationException();
                }
                return pAlphabet[(int) vault[EnumeratorState]];
            }
        }

        #endregion

//--------------------------------------------------------------------

        #region <Other>

        ///<summary>
        /// Строй.
        ///</summary>
        public Int64[] Building
        {
            get
            {
                return (Int64[]) vault.Clone();
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
                Alphabet Temp = (Alphabet) pAlphabet.Clone();
                Temp.Remove(0);
                return Temp;
            }
        }

        #endregion

        #region <IBaseObject>

        #region <Help>

        ///<summary>
        /// Метод реализует отношение эквивалентности.
        /// Два пространста эквиваленты при условии эквивалентности их пространств, алфавитов
        /// и порядка следования элементов.
        ///</summary>
        ///<param name="discrete">Объект прострнства с которым сравниваем</param>
        ///<returns></returns>
        protected bool EqualsAsSpace(Space discrete)
        {
            if (discrete == null)
            {
                return false;
            }

            if (!GetPlacePattern().EqualsAsPlace(discrete.GetPlacePattern()))
            {
                return false;
            }

            if (!Alphabet.Equals(discrete.Alphabet))
            {
                return false;
            }

            Reset();
            discrete.Reset();

            for (int i = 0; MoveNext() && discrete.MoveNext(); i++)
            {
                if (!Current.Equals(discrete.Current))
                {
                    return false;
                }
            }
            return true;
        }

        protected virtual void FillClone(IBaseObject temp)
        {
            Space tempSpace = temp as Space;
            if (tempSpace != null)
            {
                tempSpace.pAlphabet = (Alphabet) pAlphabet.Clone();
                tempSpace.pDimension = (ArrayList) pDimension.Clone();
                tempSpace.vault = (long[]) vault.Clone();
            }
        }

        ///<summary>
        ///</summary>
        ///<param name="Temp"></param>
        public void FillBin(SpaceBin Temp)
        {
            Temp.Alphabet = (AlphabetBin) Alphabet.GetBin();
            Temp.Building = (long[])vault.Clone();
            foreach (Dimension dimension in pDimension)
            {
                Temp.Dimensions.Add(dimension.GetBin());
            }
        }

        ///<summary>
        ///</summary>
        ///<param name="bin"></param>
        public Space(SpaceBin bin)
        {
            vault = (long[]) bin.Building.Clone();

            foreach (DimensionBin dimension in bin.Dimensions)
            {
                pDimension.Add(dimension.GetInstance());
            }

            Alphabet Temp = (Alphabet) bin.Alphabet.GetInstance();
            pAlphabet.Add(PsevdoValue.Instance());
            foreach (IBaseObject baseObject in Temp)
            {
                pAlphabet.Add(baseObject);
            }
        }

        #endregion

        public virtual IBaseObject Clone()
        {
            Space Temp = new Space();
            FillClone(Temp);
            return Temp;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            return EqualsAsSpace(obj as Space);
        }

        public IBin GetBin()
        {
            SpaceBin Temp = new SpaceBin();
            FillBin(Temp);
            return Temp;
        }

        #endregion

        #region <Work with Dimenstion>

        ///<summary>
        /// Увеличивает размерность пространства.
        /// При передачи в качесвте параметра null вызыватся null исключение.
        /// Измерение копируестя, последующее изменение объекта класса измерние, передаваемого в качестве
        /// параметра, никак не скажется на состоянии пространства.
        /// При добавлении измерения в пространство (минимум одномерное) в случае если 
        /// предварительно в пространство были установденнны элементы они сохранят свои позиции. 
        ///</summary>
        /// <example>
        ///  BaseSpace = new SpaceDiscrete();
        /// 
        /// Dimension dm1 = new Dimension(0, 10);
        /// Dimension dm2 = new Dimension(-1, 10);
        /// 
        /// BaseSpace.AddDimension(dm1);
        /// 
        /// ValueInt int1 = new ValueInt(1);
        /// ValueInt int2 = new ValueInt(6);
        /// ValueInt int3 = new ValueInt(1);
        /// 
        /// Place Pl = BaseSpace.GetPlacePattern(); 
        /// 
        /// Pl.SetValues(new long[] { 1 });
        /// BaseSpace.AddItem(int1, Pl);
        /// 
        /// Pl.SetValues(new long[] { 2 });
        /// BaseSpace.AddItem(int2, Pl);
        /// 
        /// Pl.SetValues(new long[] { 3 });
        /// BaseSpace.AddItem(int3, Pl);
        /// 
        /// Pl.SetValues(new long[] { 4 });
        /// BaseSpace.AddItem(int3, Pl);
        /// 
        /// Pl.SetValues(new long[] { 5 });
        /// BaseSpace.AddItem(int1, Pl);
        /// 
        /// Pl.SetValues(new long[] { 6 });
        /// BaseSpace.AddItem(int2, Pl);
        /// 
        /// BaseSpace.AddDimension(dm2);
        /// 
        /// Pl = BaseSpace.GetPlacePattern();
        /// 
        /// Assert.AreEqual(int1, BaseSpace.GetItem(Pl.SetValues(new long[] { 1, 0 })));
        /// Assert.IsTrue(int2.Equals(BaseSpace.GetItem(Pl.SetValues(new long[] { 2, 0 }))));
        /// Assert.IsTrue(int3.Equals(BaseSpace.GetItem(Pl.SetValues(new long[] { 3, 0 }))));
        /// Assert.IsTrue(int3.Equals(BaseSpace.GetItem(Pl.SetValues(new long[] { 4, 0 }))));
        /// Assert.IsTrue(int1.Equals(BaseSpace.GetItem(Pl.SetValues(new long[] { 5, 0 }))));
        /// Assert.IsTrue(int2.Equals(BaseSpace.GetItem(Pl.SetValues(new long[] { 6, 0 }))));
        /// </example>
        ///<param name="Dimension">Объект измерение</param>
        protected void AddDimension(Dimension Dimension)
        {
            pDimension.Add(Dimension);
            WasChange = true;
            CreateSpace();
            if (1 == pDimension.Count)
            {
                ElementsCount = (int) (((Dimension) pDimension[0]).max - ((Dimension) pDimension[0]).min);
            }
            else
            {
                ElementsCount = ElementsCount*(int) (((Dimension) pDimension[0]).max - ((Dimension) pDimension[0]).min);
            }
        }

        ///<summary>
        /// Удаляет все измерения пространтсва
        /// И очищает весь алфавит.
        ///</summary>
        protected void DeleteDimesnions()
        {
            pDimension.Clear();
            pAlphabet = new Alphabet();
            pAlphabet.Add(PsevdoValue.Instance());
            WasChange = true;
        }

        ///<summary>
        /// Позволяет получить одно из измерений пространтсва.
        ///</summary>
        ///<param name="i">Номер измерния в пространстве</param>
        ///<returns>Объект измерение</returns>
        protected Dimension GetDimension(int i)
        {
            return (Dimension) pDimension[i];
        }

        ///<summary>
        /// Количество измерений пространства.
        /// Размерность пространства.
        ///</summary>
        ///<returns>Возвращает INT64. Результат всегда >=0</returns>
        protected Int64 DimensionCount()
        {
            return pDimension.Count;
        }

        #endregion

        #region <Work With Items in Space>

        ///<summary>
        /// Свойство возвращает кол-во элементов в пространстве.
        /// <example>
        /// Dimension D1 = new Dimension(0, 10);
        /// 
        /// BaseSpace.AddDimension(D1);
        /// Assert.AreEqual(D1.Length, BaseSpace.ItemCount);
        /// 
        /// Dimension D2 = new Dimension(-10, 10);
        /// 
        /// BaseSpace.AddDimension(D2);
        /// Assert.AreEqual(D1.Length * D2.Length, BaseSpace.ItemCount);
        /// </example>   
        ///</summary>
        public int PlaceCount
        {
            get { return vault.Length; }
        }

        ///<summary>
        /// Позволяет получить место принадлежащее данному пространству.
        /// Используйте данное место (заполнив значения для каждой размерности) в качстве параметра для методов требующий объект класса место.
        ///</summary>
        ///<returns>Объект Место, совместимый с данным пространством</returns>
        public Place GetPlacePattern()
        {
            return new Place(pDimension);
        }

        ///<summary>
        /// Удаляет величину из места place
        ///</summary>
        ///<param name="place">Объект место величину в котром нужно очистить, принадлежащее протранству</param>
        ///<exception cref="Exception">В случае если место выходит за пределы пространства вызывается исключение</exception>
        public virtual void RemoveAt(Place place)
        {
            Int64 pos = Point2Position(place);
            if ((pos < 0) || (pos >= vault.LongLength))
            {
                throw new Exception("Place does not belong to space");
            }
            Int64 temp = vault[Point2Position(place)];
            vault[Point2Position(place)] = 0;
            if (-1 == Array.IndexOf(vault, temp))
            {
                pAlphabet.Remove((int) temp);
                for (Int64 i = 0; i < vault.GetLength(0); i++)
                {
                    if (vault[i] > temp)
                    {
                        vault[i]--;
                    }
                }
            }
            WasChange = true;
        }

        ///<summary>
        /// Возвращает величину из места place
        ///</summary>
        ///<param name="place">Объект место из которого нужно выбрать величину, принадлежащее протранству</param>
        ///<returns>Возвращает объект типа I если место имеет ну пусто наполнение, в противном случае null</returns>
        ///<exception cref="Exception">В случае если место выходит за пределы пространства вызывается исключение</exception>
        public IBaseObject GetItem(Place place)
        {
            if (!place.CompatibleTo(GetPlacePattern()))
            {
                throw new Exception("Place does not belong to space");
            }

            Int64 pos = Point2Position(place);
            if ((pos < 0) || (pos >= vault.LongLength))
            {
                throw new Exception("Place does not belong to space");
            }
            return pAlphabet[(int) vault[pos]];
        }

        ///<summary>
        /// Помещает величину в место place
        ///</summary>
        ///<param name="value">Объект типа I который требуется поместить в меcто Place</param>
        ///<param name="place">Объект типа меcто Place в котрый требуется поместить величину value</param>
        ///<exception cref="Exception">В случае если место выходит за пределы пространства вызывается исключение</exception>
        public virtual void AddItem(IBaseObject value, Place place)
        {
            if (value == null)
            {
                throw new NullReferenceException();
            }

            if (!place.CompatibleTo(GetPlacePattern()))
            {
                throw new Exception("Place does not belong to space");
            }

            Int64 Index = Point2Position(place);
            if ((Index < 0) || (Index >= vault.LongLength))
            {
                throw new Exception("Place does not belong to space");
            }

            RemoveAt(place);
            Int64 pos = pAlphabet.IndexOf(value);
            if (-1 == pos)
            {
                pAlphabet.Add(value);
                pos = pAlphabet.power - 1;
            }

            vault[Point2Position(place)] = pos;
            WasChange = true;
        }

        #endregion

        //-----------------------------------------------------------------------------------

        #region <Private Special>

        protected void CreateSpace()
        {
            Int64[] temp;
            CreateTemp(out temp);
            AllocSpace();
            ReFillSpace(temp);
        }

        protected void CreateTemp(out Int64[] temp)
        {
            if (vault != null)
            {
                temp = vault;
            }
            else
            {
                temp = null;
            }
        }

        protected void AllocSpace()
        {
            Int64 length = 1;
            foreach (Dimension Dimension in pDimension)
            {
                length *= (Dimension.max - Dimension.min) + 1;
            }
            vault = new Int64[length];
        }

        protected void ReFillSpace(Int64[] temp)
        {
            if (temp != null)
            {
                Array.Copy(temp, vault, temp.GetLength(0));
            }
        }

        protected virtual Int64 Point2Position(Place p)
        {
            Int64 position = 0;
            for (int i = 0; i < pDimension.Count - 1; i++)
            {
                Int64 product = 1;
                for (int j = 0; j < i - 1; j++)
                {
                    product *= ((Dimension) pDimension[j]).Length;
                }
                position += product*((int) p.GetValue(i) - ((Dimension) pDimension[i]).min);
            }
            position += (int) p.GetValue(p.Count - 1);
            return position;
        }

        #endregion
    }

    ///<summary>
    ///</summary>
    public class SpaceBin:IBin
    {
        #region <Data>

        public Int64[] Building = null;
        public AlphabetBin Alphabet = null;
        public ArrayList Dimensions = new ArrayList();

        #endregion

        public IBaseObject GetInstance()
        {
            return new Space(this);
        }
    }
}
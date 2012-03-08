using System.Collections;
using PhantomChains.Classes.Statistics.MarkovChain.Builders;

namespace PhantomChains.Classes.Statistics.MarkovChain.Matrixes.Base
{
    ///<summary>
    /// Базовые класс для матриц
    ///</summary>
    public abstract class MatrixBase
    {
        protected int alphPower;
        protected ArrayList ValueList;
        protected int rang;
        protected double Value;


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="poweOfAlphabet">Мощность алфавита</param>
        /// <param name="razmernost">Размерность матрицы</param>
        /// <param name="Builder">Правило создания матриц</param>
        public MatrixBase(int poweOfAlphabet, int razmernost, IMatrixBuilder Builder)
        {
            alphPower = poweOfAlphabet;
            ValueList = new ArrayList();
            rang = razmernost;
            for (int i = 0; i < alphPower; i++)
            {
                ValueList.Add(Builder.Create(alphPower, razmernost - 1));
            }
        }

        ///<summary>
        /// Мощность алфавита
        ///</summary>
        public int AlpahbetPower
        {
            get
            {
                return alphPower;
            }
        }

        ///<summary>
        /// Размерность матрицы.
        /// Только чтение.
        ///</summary>
        public int Rang
        {
            get
            {
                return rang;
            }
        }

        /// <summary>
        /// Возвращает частоту появления объекта
        /// </summary>
        /// <returns></returns>
        public abstract double FrequencyFromObject(int[] indexes);

        /// <summary>
        /// Добавляем элемент в частотный словарь
        /// </summary>
        /// <returns></returns>
        public double GetValue()
        {
            return Value;
        }

        ///<summary>
        /// Возвращает вектор элементов матрицы
        ///</summary>
        public ArrayList GetValueList
        {
            get
            {
                return ValueList;
            }
        }
    }
}
using System.Collections;
using PhantomChains.Classes.Statistics.MarkovChain.Builders;

namespace PhantomChains.Classes.Statistics.MarkovChain.Matrixes.Base
{
    ///<summary>
    /// Базовые класс для матриц
    ///</summary>
    public abstract class MatrixBase
    {
        protected readonly int alphabetPower;
        protected readonly ArrayList ValueList;
        ///<summary>
        /// Размерность матрицы.
        /// Только чтение.
        ///</summary>
        public readonly int Rank;
        protected double Value;


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="powerOfAlphabet">Мощность алфавита</param>
        /// <param name="dimensionality">Размерность матрицы</param>
        /// <param name="builder">Правило создания матриц</param>
        public MatrixBase(int powerOfAlphabet, int dimensionality, IMatrixBuilder builder)
        {
            alphabetPower = powerOfAlphabet;
            ValueList = new ArrayList();
            Rank = dimensionality;
            for (int i = 0; i < alphabetPower; i++)
            {
                ValueList.Add(builder.Create(alphabetPower, dimensionality - 1));
            }
        }

        ///<summary>
        /// Мощность алфавита
        ///</summary>
        public int AlphabetPower
        {
            get
            {
                return alphabetPower;
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
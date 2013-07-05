using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;

namespace BuildingsIterator.Classes
{
    ///<summary>
    /// Пара, калькулятор характеристики и привязка
    ///</summary>
    public abstract class LinkedUpCharacteristic
    {
        private ICalculator calc;
        private LinkUp link;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="calc">Калюкулятор характеристики цепи</param>
        /// <param name="link">Привязка</param>
        public LinkedUpCharacteristic(ICalculator calc, LinkUp link)
        {
            this.calc = calc;
            this.link = link;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="calc">Калюкулятор характеристики цепи</param>
        public LinkedUpCharacteristic(ICalculator calc)
        {
            this.calc = calc;
            link = LinkUp.Start;
        }

        /// <summary>
        /// Калькулятор характеристики
        /// </summary>
        public ICalculator Calc
        {
            get
            {
                return calc;
            }
        }

        /// <summary>
        /// Привязка
        /// </summary>
        public LinkUp LinkUp
        {
            get
            {
                return link;
            }
        }
    }
}
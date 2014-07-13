namespace BuildingsIterator.Classes
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators;

    /// <summary>
    /// Пара, калькулятор характеристики и привязка
    /// </summary>
    public abstract class LinkedCharacteristic
    {
        /// <summary>
        /// The calc.
        /// </summary>
        private readonly ICalculator calc;

        /// <summary>
        /// The link.
        /// </summary>
        private readonly Link link;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="calc">Калюкулятор характеристики цепи</param>
        /// <param name="link">Привязка</param>
        public LinkedCharacteristic(ICalculator calc, Link link)
        {
            this.calc = calc;
            this.link = link;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="calc">Калюкулятор характеристики цепи</param>
        public LinkedCharacteristic(ICalculator calc)
        {
            this.calc = calc;
            link = Link.Start;
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
        public Link Link
        {
            get
            {
                return link;
            }
        }
    }
}
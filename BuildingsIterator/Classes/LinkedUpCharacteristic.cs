namespace BuildingsIterator.Classes
{
    ///<summary>
    /// Пара, калькулятор характеристики и привязка
    ///</summary>
    public class LinkedUpCharacteristic
    {
        private ICharacteristicCalculator calc;
        private LinkUp link;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="calc">Калюкулятор характеристики цепи</param>
        /// <param name="link">Привязка</param>
        public LinkedUpCharacteristic(ICharacteristicCalculator calc, LinkUp link)
        {
            this.calc = calc;
            this.link = link;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="calc">Калюкулятор характеристики цепи</param>
        public LinkedUpCharacteristic(ICharacteristicCalculator calc)
        {
            this.calc = calc;
            link = LinkUp.Start;
        }

        /// <summary>
        /// Калькулятор характеристики
        /// </summary>
        public ICharacteristicCalculator Calc
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
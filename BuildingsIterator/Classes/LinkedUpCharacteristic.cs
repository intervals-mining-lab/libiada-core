using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.Calculators;

namespace BuildingsIterator.Classes
{
    ///<summary>
    /// ����, ����������� �������������� � ��������
    ///</summary>
    public abstract class LinkedUpCharacteristic
    {
        private ICalculator calc;
        private LinkUp link;

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="calc">����������� �������������� ����</param>
        /// <param name="link">��������</param>
        public LinkedUpCharacteristic(ICalculator calc, LinkUp link)
        {
            this.calc = calc;
            this.link = link;
        }

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="calc">����������� �������������� ����</param>
        public LinkedUpCharacteristic(ICalculator calc)
        {
            this.calc = calc;
            link = LinkUp.Start;
        }

        /// <summary>
        /// ����������� ��������������
        /// </summary>
        public ICalculator Calc
        {
            get
            {
                return calc;
            }
        }

        /// <summary>
        /// ��������
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
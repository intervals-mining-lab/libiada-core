using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics.Calculators;

namespace ChainAnalises.Classes.Project_A
{
    ///<summary>
    /// ����, ����������� �������������� � ��������
    ///</summary>
    public class LinkedUpCharacteristic
    {
        private ICharacteristicCalculator calc;
        private LinkUp link;

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="calc">����������� �������������� ����</param>
        /// <param name="link">��������</param>
        public LinkedUpCharacteristic(ICharacteristicCalculator calc, LinkUp link)
        {
            this.calc = calc;
            this.link = link;
        }

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="calc">����������� �������������� ����</param>
        public LinkedUpCharacteristic(ICharacteristicCalculator calc)
        {
            this.calc = calc;
            link = LinkUp.Start;
        }

        /// <summary>
        /// ����������� ��������������
        /// </summary>
        public ICharacteristicCalculator Calc
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
using System.Collections.Generic;

namespace MarkovCompare
{
    ///<summary>
    /// �����-����������� ��� ���������� ��������������� �������� �������
    ///</summary>
    public class ExpectationCalculator : IOnePicksCalculator
    {
        ///<summary>
        /// ���������� ��������������� ��������
        ///</summary>
        ///<param name="values">�������������� �������</param>
        ///<returns>�������������� ��������</returns>
        public double Calculate(List<double> values)
        {
            return (new StartingPointCalculator(1)).Calculate(values);
        }
    }
}
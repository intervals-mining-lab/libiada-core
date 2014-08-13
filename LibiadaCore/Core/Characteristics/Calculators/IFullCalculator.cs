namespace LibiadaCore.Core.Characteristics.Calculators
{
    /// <summary>
    /// ��������� ������������ ������ �������
    /// </summary>
    public interface IFullCalculator
    {
        /// <summary>
        /// ��������� � ���������� �������� �������������� 
        /// ��� ������ ������������ ������.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// May be redundant for some characteristics.
        /// </param>
        /// <returns>
        /// Characteristic value as <see cref="double"/>.
        /// </returns>
        double Calculate(Chain chain, Link link);
    }
}
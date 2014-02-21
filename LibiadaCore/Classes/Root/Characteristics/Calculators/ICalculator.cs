namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    /// <summary>
    /// ��������� ������������
    /// </summary>
    public interface ICalculator
    {
        /// <summary>
        /// ��������� � ���������� �������� �������������� 
        /// ��� ���������� ������.
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
        double Calculate(CongenericChain chain, Link link);

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

        /// <summary>
        /// Returns enum of this characteristic.
        /// </summary>
        /// <returns>
        /// The <see cref="CharacteristicsEnum"/>.
        /// </returns>
        CharacteristicsEnum GetCharacteristicName();
    }
}
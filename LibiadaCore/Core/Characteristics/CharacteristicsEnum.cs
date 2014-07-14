namespace LibiadaCore.Core.Characteristics
{
    /// <summary>
    /// ������ ���� ������������ �������������
    /// </summary>
    public enum CharacteristicsEnum
    {
        /// <summary>
        /// ������ ����.
        /// </summary>
        Length,

        /// <summary>
        /// ����� ���� ����������.
        /// </summary>
        IntervalsSum,

        /// <summary>
        /// �������� ��������.
        /// </summary>
        AlphabetCardinality,

        /// <summary>
        /// ������� ����������.
        /// </summary>
        AverageRemoteness,

        /// <summary>
        /// ���������� ���������.
        /// ��� ���������� ���� ��� ���������� 
        /// �������� ���������.
        /// ��� ������������ ���� ��� � �����.
        /// </summary>
        Count,

        /// <summary>
        /// ����� ��������� �� ����������.
        /// </summary>
        CutLength,

        /// <summary>
        /// ���������� ���������� � ����������� �� ��������.
        /// </summary>
        IntervalsCount,

        /// <summary>
        /// ���������� ���������������� ���������� ������������ �� ���� �������� ���������.
        /// ��������, ���������� ����������.
        /// </summary>
        Entropy,

        /// <summary>
        /// ����� ����. ������������ ���� ���� � ����������.
        /// </summary>
        Volume,

        /// <summary>
        /// ����� ��������� ������� ������� ����� ������������� 
        /// �� ������ �������, ���������� ��������� ���������.
        /// </summary>
        PhantomMessageCount,

        /// <summary>
        /// �������� ������� �� ����������. 
        /// </summary>
        CutLengthVocabularyEntropy,

        /// <summary>
        /// ������������.
        /// </summary>
        Regularity,

        /// <summary>
        /// ����������� (�������).
        /// </summary>
        Probability,

        /// <summary>
        /// ����� ������������ ����������.
        /// </summary>
        DescriptiveInformation,

        /// <summary>
        /// �������.
        /// </summary>
        Depth,

        /// <summary>
        /// ������� �������������� �������� ���� ����������.
        /// </summary>
        ArithmeticMean,

        /// <summary>
        /// �������, ������������ �� ���� ���������.
        /// </summary>
        NormalizedDepth,

        /// <summary>
        /// �������������.
        /// </summary>
        Periodicity,

        /// <summary>
        /// ������� �������������� �������� ���� ����������.
        /// </summary>
        GeometricMean,

        /// <summary>
        /// ��������������� ����������.
        /// </summary>
        NormalizedAverageRemoteness,

        /// <summary>
        /// ������� ����� �����.
        /// </summary>
        AverageWordLength,

        /// <summary>
        /// ������� � �������� ��������.
        /// </summary>
        AlphabeticDepth,

        /// <summary>
        /// ���������� � �������� ��������.
        /// </summary>
        AlphabeticAverageRemoteness,

        /// <summary>
        /// ��������� ������� �����������.
        /// </summary>
        AverageRemotenessDispersion
    }
}
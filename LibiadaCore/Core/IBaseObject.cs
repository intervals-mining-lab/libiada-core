namespace LibiadaCore.Core
{
    /// <summary>
    /// ��������� ���������� ������� ��� ���� (����������� �����) �������� ����������
    /// �������� ��������� ���������� ������� � ������ �� �����.
    /// ����� ������� ������ ��������� ������ ���������.
    /// </summary>
    public interface IBaseObject
    {
        /// <summary>
        /// ����� ������������ �������
        /// </summary>
        /// <returns>
        /// ����� ������� �������
        /// </returns>
        IBaseObject Clone();

        /// <summary>
        /// ����� ����������� ��������� ���������������
        /// </summary>
        /// <param name="other">
        /// ������ c ������� ���������� �������� �� ���������������
        /// </param>
        /// <returns>
        /// True ���� ������� ������������, ����� false
        /// </returns>
        bool Equals(object other);
    }
}
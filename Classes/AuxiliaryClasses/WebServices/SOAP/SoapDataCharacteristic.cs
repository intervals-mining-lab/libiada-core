using System;
using System.Collections.Specialized;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.SOAP
{
    ///<summary>
    /// Soap �����, ��������������� �������� ������� <see cref="HybridDictionary"/>.
    ///</summary>
    [Serializable]
    public class SoapDataCharacteristic
    {
        ///<summary>
        /// ��������� ���� �� �������� � ������� ������ ��������.
        /// ��� ������������� ����� ������ ���� �������������,
        /// ������������ �� ��� �������������� � <see cref="Value"/>.
        ///</summary>
        public string Key;
        ///<summary>
        /// ������������ �������� �����-���� ��������� ��������������.
        ///</summary>
        public double Value;
    }
}
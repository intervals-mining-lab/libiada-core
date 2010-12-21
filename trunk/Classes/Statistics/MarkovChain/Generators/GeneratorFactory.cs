using System;
using ChainAnalises.Classes.Statistics.MarkovChain.Generators;

namespace ChainAnalises.Classes.Statistics.MarkovChain.Generators
{
    ///<summary>
    /// ����������� ����� - ������� ����������� ��������� �����
    ///</summary>
    public static class GeneratorFactory
    {
        ///<summary>
        /// ����� ��������� ��������� ��������� ������� ��������� ����
        ///</summary>
        ///<param name="generator">��� ����������</param>
        ///<returns>��������� ��������� �����</returns>
        ///<exception cref="Exception">����������� ��� ���������� �������� ����������</exception>
        public static IGenerator Create(GeneratorType generator)
        {
            switch (generator)
            {
                case GeneratorType.SimpleGenerator:
                    return new SimpleGenerator();
                default:
                    throw new Exception("This type of generator does not registated in system");
            }
        }
    }
}
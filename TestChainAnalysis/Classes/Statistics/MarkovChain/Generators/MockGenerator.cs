using ChainAnalises.Classes.Statistics.MarkovChain.Generators;

namespace TestChainAnalysis.Classes.Statistics.MarkovChain.Generators
{
    ///<summary>
    /// ��������� �������� ������������ � ������ ��� �������� ����������� ������������� �����.
    ///</summary>
    public class MockGenerator : IGenerator
    {
        private readonly double[] vault = new double[30];
        private int step = -1;


        ///<summary>
        ///</summary>
        public MockGenerator()
        {
            vault[0] = 0.77;
            vault[1] = 0.15;
            vault[2] = 0.96;
            vault[3] = 0.61;
            vault[4] = 0.15;
            vault[5] = 0.85;
            vault[6] = 0.67;
            vault[7] = 0.51;
            vault[8] = 0.71;
            vault[9] = 0.2;
            vault[10] = 0.77;
            vault[11] = 0.15;
            vault[12] = 0.96;
            vault[13] = 0.61;
            vault[14] = 0.15;
            vault[15] = 0.85;
            vault[16] = 0.67;
            vault[17] = 0.51;
            vault[18] = 0.71;
            vault[19] = 0.2;
            vault[20] = 0.77;
            vault[21] = 0.15;
            vault[22] = 0.96;
            vault[23] = 0.61;
            vault[24] = 0.15;
            vault[25] = 0.85;
            vault[26] = 0.67;
            vault[27] = 0.51;
            vault[28] = 0.71;
            vault[29] = 0.2;
        }

        ///<summary>
        /// �������������� ��������� �����.
        ///</summary>
        public void Resert()
        {
            step = -1;
        }

        ///<summary>
        /// �������� ��������� �������� �������������� ��������.
        ///</summary>
        ///<returns>[0..1] ��������</returns>
        public double Next()
        {
            step++;
            if(step < vault.Length)
            {
                return vault[step];
            }
            return 0;
        }

    }
}
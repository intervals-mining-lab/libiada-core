using System.Collections;
using System.Collections.Generic;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.Iterators;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics;
using ChainAnalises.Classes.Root;
using TestChainAnalysis.Classes.Statistics;

namespace TestChainAnalysis.Classes.Compress
{
    public class CoderHannon
    {
        private SortDictionary probability_table = new SortDictionary();
        private Hashtable code_table = new Hashtable();

        ///<summary>
        ///</summary>
        public Hashtable CodeTable
        {
            get
            {
                return code_table;
            }
        }

        ///<summary>
        ///</summary>
        ///<param name="source"></param>
        public void Teach(Chain source)
        {
            foreach (IBaseObject mes in source.Alpahbet)
            {
                double p = source.UniformChain(mes).GetCharacteristic(LinkUp.Both, CharacteristicsFactory.P);
                probability_table.Add(mes, p);
                code_table.Add(mes, "");
            }

            BuildCode(0, probability_table.Count() - 1, "");
        }

        private void BuildCode(int start, int end, string code)
        {
            if (code.Length == 1)
            {
                SetCodeAddition(start, end, code);
            }

            if (start == end)
            {
                return;
            }

            double sum = 0;
            double step = GetStep(start, end);

            int start1 = start;
            int end1 = GetBoundary(step, start);
            int start2 = end1 + 1;
            int end2 = end;

            BuildCode(start1, end1, "1");
            BuildCode(start2, end2, "0");
        }

        private void SetCodeAddition(int start1, int end1, string code_addition)
        {
            for (int i = start1; i <= end1; i++ )
            {
                IBaseObject obj = probability_table.GetKeyByIndex(i);
                code_table[obj] += code_addition;
            }
        }

        private int GetBoundary(double step, int start)
        {
            double sum = probability_table.GetValueByIndex(start);
            while(sum <= step) 
            {
                start++;
                sum = sum + probability_table.GetValueByIndex(start);
            }
            return start;
        }

        private double GetStep(int start, int end)
        {
            double sum = 0;
            for(int i = start; i < end; i++)
            {
                sum = sum + (double)probability_table.GetValueByIndex(i);
            }
            return sum/2;
        }

        public string Compress(Chain source)
        {
            string temp = "";
            IteratorSimpleStart<Chain> it =new IteratorSimpleStart<Chain>(source, 1);
            while(it.Next())
            {
                temp += code_table[it.Current()];
            }
            return temp;
        }
    }
}
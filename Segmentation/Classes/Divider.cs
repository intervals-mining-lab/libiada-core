using System;
using LibiadaCore.Classes.Root;
using Segmentation.Classes.Criteria;

namespace Segmentation.Classes
{
    public class Divider
    {
        private readonly Chain chain_for_divizion;
        private readonly double balance_factor;
        
        public double best_level;//наилучшее значение порога
        public double best_delta = Double.MaxValue;//наилучшие расхождение теоретического и практического словарей
        public double theory_volume;

        public AlphabetChain full_alphabet;
        public Chain divided_chain;

        private int start_length;
        private LinkUp interval_link;
        private Method calc_frecuncy_method;
        private double right_value;
        private double eps;

        public Divider(Chain chain, double balance_factor, int start_length, LinkUp interval_link, Method calc_frecuncy_method, double right_value, double eps)
        {
            chain_for_divizion = chain;
            this.balance_factor = balance_factor;
            this.start_length = start_length;
            this.interval_link = interval_link;
            this.calc_frecuncy_method = calc_frecuncy_method;
            this.right_value = right_value;
            this.eps = eps;
        }
        
        public void Divizion_with_inspection()
        {
            double left_value = 0;
            best_level = (right_value - left_value) / 2;//наилучшее значение порога
            double delta;
            

            int bad_iterations = 0;
            while (best_delta != 0 && ((right_value - left_value) > eps) && (bad_iterations < 3))
            {
                double level = (right_value + left_value) / 2;
                SimpleDivider simple_divider = new SimpleDivider(chain_for_divizion, balance_factor, 4, interval_link, calc_frecuncy_method);
                AlphabetChain practis_alphabet = simple_divider.DivideToAccords(level);
                divided_chain = simple_divider.convoluted_chain;
                double tv = Get_theory_volume(practis_alphabet, simple_divider.convoluted_chain);
                delta = (tv - practis_alphabet.Power);

                if(Math.Abs(delta)<Math.Abs(best_delta))
                {
                    best_level = level;
                    best_delta = delta;
                    full_alphabet = practis_alphabet;
                    divided_chain = simple_divider.convoluted_chain;
                    theory_volume = tv;
                    bad_iterations = 0;
                }
                else bad_iterations++;

                if (delta < 0) left_value = level;
                else right_value = level;
            }
        }
        
        
        private double Get_theory_volume(AlphabetChain alphabet, Chain chain)
        {
            double one = 0;
            //поиск частоты самого частого слова
            double f = 0;
            foreach (Chain element in alphabet)
            {
                one = one + Calculator.frequency(chain, element);
                if (Calculator.frequency(chain, element) > f) f = Calculator.frequency(chain, element);
            }
            double z = chain.Length;
            double k = 1/(Math.Log(f*z));//иногда улетаем в Infinity, но, похоже, это нормально
            
                        
            double b = k/f - 1;

            double v = k*z-b;
            return v;
        }

    }
}

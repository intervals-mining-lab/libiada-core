using System;
using System.Collections;
using System.Collections.Generic;
using LibiadaCore.Classes.Misc.Iterators;
using LibiadaCore.Classes.Root;
using Segmentation.Classes.AuxiliaryClasses;
using Segmentation.Classes.Criteria;
using Segmentation.Classes.DataCollectors;
using Segmentation.Classes.ProbabilityCountStrateges;

namespace Segmentation.Classes
{
    public class StdCalculator
    {
        private IDataCollector full;
        private IDataCollector mines_one;
        private IDataCollector midl;

        public SortedDictionary<double, DictionaryEntry> alphabet = new SortedDictionary<double, DictionaryEntry>();

        ///<summary>
        ///</summary>
        ///<param name="chain"></param>
        ///<param name="length"></param>
        ///<param name="calc_frecuncy_method"></param>
        ///<param name="interval_link"></param>
        ///<param name="balance_factor"></param>
        ///<param name="good_alphabet"></param>
        ///<param name="level"></param>
        ///<returns></returns>
        ///<exception cref="Exception"></exception>
        public DictionaryEntry? CalcStds(Chain chain, int length, Method calc_frecuncy_method, LinkUp interval_link,
                                         double balance_factor, AlphabetChain good_alphabet, double level)
        {
            double best_std = -1;
            if (length < 2)
            {
                throw  new Exception("Try to made segmentation less to length of accord");
            }

            full = DataCollectorFactory.Create(length);
            mines_one = DataCollectorFactory.Create(length - 1);
            midl = DataCollectorFactory.Create(length - 2);

            IteratorStart<Chain, Chain> it = new IteratorStart<Chain, Chain>(chain, length, 1);
            while (it.Next())
            {
                //проверка на существующие цепочки
                //if (!one_item_is_in_alphabet(it.Current(), good_alphabet))
                {
                    full.Add(it, 0);

                    Strategy Method = GetStrategyForLessOne.Get(it, length);
                    Method.Calculate(mines_one, it.Current(), it.ActualPosition());

                    Method = GetStrategyForLessTwo.Get(it, length);
                    Method.Calculate(midl, it.Current(), it.ActualPosition());
                }
            }

            CriteiaMethod CriteriaCalculator = CriteriaStrategy.Get(calc_frecuncy_method);
            Filter Filter = new SimpleFilter();
            foreach (DictionaryEntry accord in full)
            {
                Filter.MakeFilteration((IDataForStd) accord.Value, chain.Length, length);
                double FrequenceCriteria = CriteriaCalculator.Frequncy((IDataForStd) accord.Value, chain.Length, length);
                double DezignExpected =
                    CriteriaCalculator.DesignExpected((Chain) accord.Key, (IDataForStd) accord.Value, chain.Length,
                                                      length, mines_one, midl);
                double IntervalEstimate =
                    CriteriaCalculator.IntervalEstimate((Chain) accord.Key, (IDataForStd) accord.Value, chain.Length,
                                                        length, interval_link);
                double std =
                    (Math.Abs(balance_factor*IntervalEstimate + (1 - balance_factor)*FrequenceCriteria - DezignExpected))/
                    Math.Sqrt(DezignExpected);
                if (!alphabet.ContainsKey(std))
                    alphabet.Add(std, accord);
            }

            ArrayList tmp = new ArrayList(alphabet.Keys);
            ArrayList tmp2 = new ArrayList(alphabet.Values);

            for (int i = tmp2.Count-1; i >= 0; i--)
            {
                if (!one_item_is_in_alphabet((Chain) ((DictionaryEntry)tmp2[i]).Key, good_alphabet))
                {
                    best_std = (double) tmp[i];
                    if (best_std > level)
                    {
                        return alphabet[best_std];
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            return null;
        }


        private bool one_item_is_in_alphabet(Chain chain, AlphabetChain previos_alph)
        {
            for (int i = 0; i < chain.Length; i++)
            {
                if (previos_alph.Contains(chain[i])) return true;
            }
            return false;
        }

        /*
        //не работает вариант когда длина accord=2
        static public double Calculate(Chain chain, Chain accord, double balance_factor,
            LinkUp interval_link, bool calc_frecuncy_method)
        {
            IteratorStart<Chain, Chain> it = new IteratorStart<Chain, Chain>(accord, accord.Length-1, 1);
            it.Next();
            Chain ac_begin = it.Current();
            it.Next();
            Chain ac_end = it.Current();
            Chain ac_midl = null;
            if (accord.Length != 2)
            {
                it = new IteratorStart<Chain, Chain>(accord, accord.Length - 2, 1);
                it.Next();
                it.Next();
                ac_midl = it.Current();
            }

            int f_c_begin = ac_begin.Length;;
            int f_c_end = ac_end.Length;
            int f_c_midl = 0;
            if (ac_midl != null) f_c_midl = ac_midl.Length;
            int f_c_all = accord.Length;


            double f_begin = 0; 
            double f_end = 0;
            double f_midl = 0;
            double f_all =0 ;

            int l_begin=1;
            int l_end=1;
            int l_both=1;

            int just_interval = 0;
            int equals_counter = 0;

            bool cal_first_time=true;

            it = new IteratorStart<Chain, Chain>(chain, accord.Length, 1);
            while (it.Next())
            {
                //начало подсчёта переменных частот
                f_c_begin++;
                f_c_end++;
                f_c_midl++;
                f_c_all++;

                if (accord.Length != 2)
                {
                    IteratorStart<Chain, Chain> it_in =
                        new IteratorStart<Chain, Chain>(it.Current(), accord.Length - 2, 1);
                    it_in.Next();
                    it_in.Next();
                    if (it_in.Current().Equals(ac_midl) && (f_c_midl >= ac_midl.Length))
                    {
                        f_c_midl = 0;
                        f_midl++;
                        IteratorStart<Chain, Chain> it_temp =
                            new IteratorStart<Chain, Chain>(it.Current(), accord.Length - 1, 1);
                        it_temp.Next();
                        if (it_temp.Current().Equals(ac_begin) && (f_c_begin >= ac_begin.Length))
                        {
                            f_c_begin = 0;
                            f_begin++;
                        }
                        it_temp.Next();
                        if (it_temp.Current().Equals(ac_end) && (f_c_end >= ac_end.Length))
                        {
                            f_c_end = 0;
                            f_end++;
                        }
                    }
                }else
                {
                    IteratorStart<Chain, Chain> it_temp =
                            new IteratorStart<Chain, Chain>(it.Current(), accord.Length - 1, 1);
                    it_temp.Next();
                    if (it_temp.Current().Equals(ac_begin) && (f_c_begin >= ac_begin.Length))
                    {
                        f_c_begin = 0;
                        f_begin++;
                    }
                    it_temp.Next();
                    if (it_temp.Current().Equals(ac_end) && (f_c_end >= ac_end.Length))
                    {
                        f_c_end = 0;
                        f_end++;
                    }
                }
                //конец подсчёта переменных частот
                //начало расчётов переменных для подсчёта ср. геометрич интервала
                just_interval++;
                if(it.Current().Equals(accord))
                {
                    if(f_c_all>=accord.Length)
                    {
                        f_all++;
                        f_c_all = 0;
                    }
                    equals_counter++;
                    if (cal_first_time) l_begin = l_begin * just_interval;
                    else l_begin = l_begin * (just_interval+1)-accord.Length;
                    if (!cal_first_time) l_end = l_end * (just_interval+1) - accord.Length ;
                    cal_first_time = false;
                    just_interval = 0;
                }
                //конец расчётов переменных для подсчёта ср. геометрич интервала
            }
            l_end = l_end * (just_interval+1);
            l_both = l_begin * (just_interval+1);

            //расчёт интервальной оценки
            double interval_estimate=0;
            
            switch (interval_link)
            {
                case LinkUp.Start:
                    interval_estimate = 1/Math.Pow(l_begin, (double) 1/equals_counter);
                    break;
                case LinkUp.End:
                    interval_estimate = 1 / Math.Pow(l_end, (double)1 / equals_counter);
                    break;
                case LinkUp.Both:
                    interval_estimate = 1 / Math.Pow(l_both, (double)1 / (equals_counter+1));
                    break;
            }

            //расчёт расчётно-ожидаемой частоты
            if (calc_frecuncy_method) //с учётом длины созвучия (т.е. созвучие является элементом длиной в 1)
            {
                f_all = f_all/(chain.Length - f_all*accord.Length + f_all);
                f_begin = f_begin / (chain.Length - f_begin * ac_begin.Length + f_begin);
                f_end = f_end / (chain.Length - f_end * ac_end.Length + f_end);
                if (ac_midl != null) f_midl = f_midl / (chain.Length - f_midl * ac_midl.Length + f_midl);
            }else//без учёта длины созвучия 
            {
                f_all = f_all / (chain.Length);
                f_begin = f_begin / (chain.Length);
                f_end = f_end / (chain.Length);
                f_midl = f_midl / (chain.Length);
            }
            if (accord.Length == 2) f_midl = 1;
            double disign_expected_frecuncy = (f_begin*f_end)/f_midl;

            //расчёт оценки
            double std = (Math.Abs(balance_factor*interval_estimate + (1 - balance_factor)*f_all - disign_expected_frecuncy))/
                         Math.Sqrt(disign_expected_frecuncy);

            return std;
        }*/
    }
}
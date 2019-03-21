using System;
using System.Collections.Generic;
using System.Text;

namespace Segmenter.PoemsSegmenter
{
    class FrequencySegmenter
    {
        public string textEtalon = "tistiemthishaartshoodbeeanmuvd sintsutherzithathhseesdtuemuev yetthoeiekanaatbeebeelluvid stilletmeeluv miedaezaarinthuyeloeleef thuflaawerzandfruetsuvluvaargaun thuwermthukaenkerandthugreef aarmienulloen thufierthataanmieboozimprae izloenazsumvaalkkanikiel noetorchizkindooldatitsblaez ufyueneroolpiel thuhoepthufeerthujeliskair thuigzzaultidporshinuvthupaen andpaaweruvluviekanaatshair butwairthuchaen buttisnaatthusandtisnaatheer suchthhautsshoodshaekmiesoelnornou wairgloorideksthuherouzbeer orbiendzhizbrou thusordthubanerandthufeeld gloriandgriisurroundmeesee thuspaartinboornuppaanhizsheeld wuznaatmorfree uwwaeknaatgriissheeizuwwaek uwwaekmiespeeritthheenkthhruehuem thieliefbludtraksitspairintlaek andthenstriekhoem tredthoezrivvieveengpashinzdoun unwwertheemanhooduntuethee inddifrintshoodthusmielorfroun uvbyueteebee ifthourigretstthieyuethhwieliv thulanduvonarabledethh izheeruptuethufeeldandgiv uwwaethiebrethh";
        public string text = "tistiemthishaartshoodbeeanmuvd sintsutherzithathhseesdtuemuev yetthoeiekanaatbeebeelluvid stilletmeeluv miedaezaarinthuyeloeleef thuflaawerzandfruetsuvluvaargaun thuwermthukaenkerandthugreef aarmienulloen thufierthataanmieboozimprae izloenazsumvaalkkanikiel noetorchizkindooldatitsblaez ufyueneroolpiel thuhoepthufeerthujeliskair thuigzzaultidporshinuvthupaen andpaaweruvluviekanaatshair butwairthuchaen buttisnaatthusandtisnaatheer suchthhautsshoodshaekmiesoelnornou wairgloorideksthuherouzbeer orbiendzhizbrou thusordthubanerandthufeeld gloriandgriisurroundmeesee thuspaartinboornuppaanhizsheeld wuznaatmorfree uwwaeknaatgriissheeizuwwaek uwwaekmiespeeritthheenkthhruehuem thieliefbludtraksitspairintlaek andthenstriekhoem tredthoezrivvieveengpashinzdoun unwwertheemanhooduntuethee inddifrintshoodthusmielorfroun uvbyueteebee ifthourigretstthieyuethhwieliv thulanduvonarabledethh izheeruptuethufeeldandgiv uwwaethiebrethh";
        public double P = 0.1081554578238;//0.1088522178238;//0.1088091372238;//0.1095238095238;

        //public string text = "iewenttuethugaardinuvluv andsauwutieneverhadseen uchapoolwuzbiltinthumidst wairieyuezdtueplaeaanthugreen andthugaetsuvthischapoolwershut andthoushaltnaatritoeverthudor soeieternttuethugaardinuvluv thatsoemeneesweetflaawerzbor andiesauitwuzfildwithhgreivz andtuemstoenzwairflaawerzshoodbee andpreestsinblakgounzwerwaukeengthairroundz andbiendeengwithhbrieyerzmiejoizanddizzierz";
        //public static string text1 = "маросисолнцедьеньчудьесный йещотыдрьемльешдрукпрьельесный паракрасавьицапрасньись аткройсамкнутыньегайвзоры нафстрьечусьевьернайавроры звьездойусьевьерайавьись вьечортыпомньишвьйугазльилась намутнамньебьемгланасьилась лунакакбльеднайепьатно сквосьтучимрачныйежелтьела итыпьечальнайасьидьела анынчепагльадьифакно потгалубымьиньебьесамьи вьельикальепнымьикаврамьи бльестьанасолнцесньекльежыт празрачныйльесадьинчерньейет ийельсквосьиньейзьельеньейет ирьечкаподальдомбльестьит фсьакомнатайантарнымбльескам азарьенавьесьолымтрьескам трьещитзатопльеннайапьеч прьийатнадуматьульежанкьи нознайешньевьельетьльифсанкьи кабылкубуруйузапрьеч скальзьапоутрьеньньемусньегу друкмьилыйпрьедадьимсьабьегу ньетьерпьельиваваканьа инавьестьимпальапустыйе льесаньедавнастольгустыйе ибьерьекмьилыйдльамьеньа";

        List<String> consonanceList = new List<string>();
        public List<String> StartProgram()
        {
            while (true)
            {
                int n = 4; //максимальная длина последовательности символов

                while (n != 0)
                {
                    Segmentation(n);
                    n--;
                    //Console.ReadLine();
                }

                double newP = calculateP(consonanceList);
                Console.WriteLine("P = " + P);
                //Console.ReadLine();
                if (newP == P)
                {
                    break;
                }
                else
                {
                    //Console.WriteLine("P = " + P);
                    //consonanceList.Sort();
                    //foreach (string item in consonanceList)
                    //{
                    //    Console.WriteLine(item);
                    //}
                    //Console.ReadLine();
                    P = newP;
                    n = 4;
                    consonanceList.Clear();
                    text = textEtalon;
                }
            }

            //Console.ReadLine();
            //Console.WriteLine("P = " + P);
            return consonanceList;
        }

        public static double calculateStd(string textE, string candidateConsonance, int countEntires)
        {
            //textE = textE.Replace(" ", "").Replace(".", "");
            double fW = calculateFW(textE, candidateConsonance, countEntires); //фактическая частота слова в тексте
            double fC = calculateFC(textE, candidateConsonance, countEntires); //расчетно-ожидаемая частота слова в тексте
            double stdW = 0;
            stdW = Math.Abs(fW - fC) / Math.Sqrt(fC);
            //Console.WriteLine("Количество вхождений кандидата: " + fW);
            //Console.WriteLine("Расчетное количество вхождений кандидата: " + fC);
            //Console.WriteLine("Отклонение: " + stdW);
            return stdW;
        }

        public static double calculateFW(string textE, string candidateConsonance, int countEntires)
        {

            //Console.WriteLine(textE.Length);
            double fW = 0;
            fW = textE.Split(new string[] { candidateConsonance }, StringSplitOptions.None).Length - 1;
            fW = fW / countEntires; //количество вхождений кандидата
            return fW;
        }

        public static double calculateFC(string textE, string candidateConsonance, int countEntires)
        {
            double fC = 0;
            double f1 = calculateFW(textE, candidateConsonance.Substring(0, (candidateConsonance.Length - 1)), countEntires); // частота вхождений кандидата с первого по n-1 символ
            double f2 = calculateFW(textE, candidateConsonance.Substring(1, (candidateConsonance.Length - 1)), countEntires); // частота вхождений кандидата со второго по n символ
            if (candidateConsonance.Length > 2)
            {
                double f3 = calculateFW(textE, candidateConsonance.Substring(1, (candidateConsonance.Length - 2)), countEntires); // частота вхождений кандидата со второго по n-1 символ
                fC = (f1 * f2) / (f3);
                //Console.WriteLine(fC);
            }
            else
            {
                fC = (f1 * f2);
            }


            return fC;
        }

        public int calculateAllNEntries(string textE, int n)
        {
            int count = 0;

            //textE = textE.Replace(" ", "");
            string[] textEArray = textE.Split('.');
            for (int i = 0; i < textEArray.Length; i++)
            {
                textEArray[i] = textEArray[i].Replace(" ", "");
                count += textEArray[i].Length;
            }
            textE = textE.Replace(" ", "");
            count += textEArray.Length;
            return count;
        }

        public void Segmentation(int n)
        {
            double stdW; //отклонение
            //double P = 0.105;//0.1095238095238(max);//порог для i went to the garden: 0.166209418434262; // пороговое значение (если stdW >= P - то последовательность является созвучием)
            //string[] words = text.Split(" "); // массив слов
            string textCons = "";
            int i = 0;
            for (i = 0; i < text.Length; i++)
            {
                try
                {
                    for (int j = i; j < n + i; j++)
                    {
                        if (text[j].Equals(' ') || text[j].Equals('.'))
                        {
                            textCons = "";
                            break;
                        }
                        else
                        {
                            textCons += text[j];
                        }
                    }
                    if (textCons.Equals(""))
                    {
                        textCons = "";
                        continue;
                    }
                    else if (n == 1)
                    {
                        consonanceList.Add(textCons);
                        text = text.Replace(textCons, ".");
                        textCons = "";
                        continue;
                    }

                    int countEntries = calculateAllNEntries(text, n);

                    stdW = calculateStd(text, textCons, countEntries);
                    //Console.WriteLine(textCons + ": " + stdW);
                    //Console.ReadLine();
                    //if (textCons == "veen")
                    //{
                    //    Console.WriteLine(textCons + ": " + stdW);
                    //    //Console.ReadLine();
                    //    //P = 0.6;
                    //}
                    if (stdW >= P)
                    {
                        consonanceList.Add(textCons);
                        text = text.Replace(textCons, ".");
                        textCons = "";
                        //если отклонение > P, то записать в consonances и вычеркнуть это созвучие во всех элементах и дальше проверять это же слово, только с n-го элемента строки
                    }
                    else
                    {
                        textCons = "";
                        //проверять то же слово, только со следующего символа
                    }
                }
                catch
                {
                    textCons = "";
                    continue;
                }
            }
        }

        public double calculateP(List<string> factList)
        {
            double vT = calculateVT(factList); //теоретическая мощность словаря
            double v = factList.Count; //фактическая мощность словаря
            double newP = P;

            double difference = Math.Abs(vT - v);
            Console.WriteLine("Difference: " + difference);
            if (newP == 0)
            {
                newP = P;
            }
            else if (difference > 0)
            {
                newP -= 0.000000001;
            }

            return newP;
        }

        public double calculateVT(List<string> factList)
        {
            double F1 = calculateF1(factList);
            double textLength = text.Replace(" ", "").Length;
            double P1 = F1 / textLength; //частота самого частого слова
            double K = 1 / Math.Log(F1);
            double B = (K / P1) - 1;

            double vT = K * textLength - B;
            //double vT = K * (textEtalon.Length - 1) - B;
            return Math.Round(vT);

        }

        public int calculateF1(List<string> factList)
        {
            string text = textEtalon;
            int F1 = 0; //количество вхождений самого частого слова
            int countEntries = 0;
            string[] factArray = factList.ToArray();
            //считаем максимальное число вхождений
            for (int i = 0; i < factArray.Length; i++)
            {
                countEntries = text.Split(new string[] { factArray[i] }, StringSplitOptions.None).Length;
                if (countEntries >= F1)
                {
                    F1 = countEntries;
                }
                //Console.WriteLine(factArray[i] + ": " + F1);
                text = text.Replace(factArray[i], ".");
            }
            //Console.ReadLine();
            return F1;
        }
    
    }
}

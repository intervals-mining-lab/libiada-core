using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using MDA.OIP.MusicXml;
using System.IO;
using MDA.OIP.BorodaDivider;
using MDA.OIP.ScoreModel;
using MDA.Analisis;

namespace MDA.OIP.View
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Reset();
            folderBrowserDialog1.ShowDialog();

            Console.WriteLine("FOLDER : " + folderBrowserDialog1.SelectedPath);
            Console.WriteLine("");

            if (folderBrowserDialog1.SelectedPath != "")
            {
                // сводный файл для сохранения имени name
                FileStream fsname = new FileStream(folderBrowserDialog1.SelectedPath + "\\Total_name.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter stname = new StreamWriter(fsname);
                // сводный файл для len
                FileStream fslen = new FileStream(folderBrowserDialog1.SelectedPath + "\\Total_len.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter stlen = new StreamWriter(fslen);
                // сводный файл для diffv
                FileStream fsdiffv = new FileStream(folderBrowserDialog1.SelectedPath + "\\Total_diffv.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter stdiffv = new StreamWriter(fsdiffv);
                // сводный файл для g
                FileStream fsg = new FileStream(folderBrowserDialog1.SelectedPath + "\\Total_g.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter stg = new StreamWriter(fsg);
                // сводный файл для G
                FileStream fsGe = new FileStream(folderBrowserDialog1.SelectedPath + "\\Total_Ge.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter stGe = new StreamWriter(fsGe);
                // сводный файл для r
                FileStream fsr = new FileStream(folderBrowserDialog1.SelectedPath + "\\Total_r.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter str = new StreamWriter(fsr);
                // сводный файл для E
                FileStream fsE = new FileStream(folderBrowserDialog1.SelectedPath + "\\Total_E.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter stE = new StreamWriter(fsE);
                DirectoryInfo dir = new DirectoryInfo(folderBrowserDialog1.SelectedPath);
                //DirectoryInfo dir = new DirectoryInfo("D:\\Учеба\\НИРС\\_xml");

                foreach (var item in dir.GetFiles())
                {
                    if (item.Name.EndsWith(".xml"))
                    {
                        try
                        {
                            Console.WriteLine("_________________________________________________");
                            Console.WriteLine(item.FullName);
                            Console.WriteLine();

                            XmlDocument xmldocument = new XmlDocument();
                            MusicXmlReader xmlreader = new MusicXmlReader(item.FullName);
                            MusicXmlParser Parser = new MusicXmlParser();
                            Parser.Execute(xmlreader.MusicXmlDocument, xmlreader.FileName);

                            BorodaDivider.BorodaDivider bd = new BorodaDivider.BorodaDivider();

                            List<FmotivChain> Listfmotivchains = bd.Divide(Parser.ScoreModel);
                            #region анализ моно цепочек
                            foreach (FmotivChain fmchain in Listfmotivchains)
                            {
                                Console.WriteLine("Fmotiv Chain № " + fmchain.Id.ToString() + " Name = " + fmchain.Name);
                                Console.WriteLine();
                                Console.WriteLine("------------------------");

                                // записываем строй в файл с таким же именем только с припиской .txt
                                FileStream fs = new FileStream(item.FullName + ".txt", FileMode.OpenOrCreate, FileAccess.Write);
                                StreamWriter st = new StreamWriter(fs);

                                foreach (Fmotiv fmotiv in fmchain.FmotivList)
                                {
                                    st.WriteLine(fmotiv.Id.ToString());

                                    Console.WriteLine("Fmotiv № " + fmotiv.Id.ToString() + " | type " + fmotiv.Type);
                                    Console.WriteLine();
                                    foreach (Note note in fmotiv.NoteList)
                                    {
                                        // TODO : добавить вывод триоли и лиги
                                        if (note.Pitch != null)
                                        {
                                            // если есть лига, то определяем ее тип по номеру
                                            string tietype = "";
                                            switch (note.Tie)
                                            {
                                                case 0:
                                                    tietype = " TieStarts";
                                                    break;
                                                case 1:
                                                    tietype = " TieStops";
                                                    break;
                                                case 2:
                                                    tietype = " TieContinues";
                                                    break;
                                                default:
                                                    break;
                                            }
                                            Console.WriteLine("Note: duration = " + note.Duration.Numerator.ToString() + "/" + note.Duration.Denominator.ToString() +
                                            " step = " + note.Pitch.Step.ToString() + " priority = " + note.Priority.ToString() + tietype);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Pause: duration = " + note.Duration.Numerator.ToString() + "/" + note.Duration.Denominator.ToString() +
                                            " priority = " + note.Priority.ToString());
                                        }

                                    }
                                    Console.WriteLine("------------------------");
                                }
                                st.Close();
                                fs.Close();
                            }
#endregion

                            try
                            {
                                Composition com = new Composition();
                                int i = 0;
                                for (i = 0; i < Listfmotivchains[0].FmotivList.Count; i++)// previously was .Count , not .Lenght
                                {
                                    com.AddFM(Listfmotivchains[0].FmotivList[i].Id.ToString());
                                }
                                com.CreatePLex();
                                com.CreateTlex();
                                com.RangePlex();
                                com.RangeTlex();
                                com.IdentifyRange();
                                com.MakeNewChain();
                                com.CalcCharacteristics();
                                com.CalcDifference();
                                com.FillDisplayData();
                                
                                    stname.WriteLine(item.Name);
                                    stlen.WriteLine(Listfmotivchains[0].FmotivList.Count.ToString());
                                    stdiffv.WriteLine(Convert.ToString(com.VDiff.GetpdV()));
                                    stg.WriteLine(com.AvgRemoteness.ToString());
                                    stGe.WriteLine(com.AvgDepth.ToString());
                                    str.WriteLine(com.Regularity.ToString());
                                    stE.WriteLine(com.Entropy.ToString());
                            }
                            catch (Exception err)
                            {
                                MessageBox.Show(err.Message, "Analisis Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(item.FullName + " "+ ex);
                        }
                    }


                }
                stg.Close();
                fsg.Close();
                stGe.Close();
                fsGe.Close();
                str.Close();
                fsr.Close();
                stE.Close();
                fsE.Close();
                stname.Close();
                fsname.Close();
                stlen.Close();
                fslen.Close();
                stdiffv.Close();
                fsdiffv.Close();
            }
        }
    }
}

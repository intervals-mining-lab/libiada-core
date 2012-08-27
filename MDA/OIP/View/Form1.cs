using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using LibiadaCore.Classes.Root.Characteristics;
using MDA.OIP.MusicXml;
using System.IO;
using MDA.OIP.BorodaDivider;
using MDA.Analisis;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;

namespace MDA.OIP.View
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // для закрытия элементов среды Excel
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Reset();
            folderBrowserDialog1.ShowDialog();

            Console.WriteLine("FOLDER : " + folderBrowserDialog1.SelectedPath);
            Console.WriteLine("");

            if (folderBrowserDialog1.SelectedPath != "")
            {

                // ----------Создание Excel файла-----------------------------------------------------------
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;

                Excel.Worksheet xlWorkSheetFmSeqPauseIgnore;
                Excel.Worksheet xlWorkSheetFmSeqSilencePause;
                Excel.Worksheet xlWorkSheetFmSeqDuarPlus;

                Excel.Worksheet xlWorkSheetFmNoSeq;
                Excel.Worksheet xlWorkSheetNote;
                Excel.Worksheet xlWorkSheetTakt;

                object misValue = System.Reflection.Missing.Value;

                //System.Globalization.CultureInfo oldCI = System.Threading.Thread.CurrentThread.CurrentCulture;

                //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

                //Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(Type.Missing);

                xlWorkBook.Worksheets.Add();
                xlWorkBook.Worksheets.Add();
                xlWorkBook.Worksheets.Add();


                xlWorkSheetFmSeqPauseIgnore = (Excel.Worksheet) xlWorkBook.Worksheets.get_Item(1);
                xlWorkSheetFmSeqSilencePause = (Excel.Worksheet) xlWorkBook.Worksheets.get_Item(2);
                xlWorkSheetFmSeqDuarPlus = (Excel.Worksheet) xlWorkBook.Worksheets.get_Item(3);
                xlWorkSheetFmNoSeq = (Excel.Worksheet) xlWorkBook.Worksheets.get_Item(4);
                xlWorkSheetNote = (Excel.Worksheet) xlWorkBook.Worksheets.get_Item(5);
                xlWorkSheetTakt = (Excel.Worksheet) xlWorkBook.Worksheets.get_Item(6);

                xlWorkSheetFmSeqPauseIgnore.Name = "FmSeqPauseIgnore";
                xlWorkSheetFmSeqSilencePause.Name = "FmSeqSilencePause";
                xlWorkSheetFmSeqDuarPlus.Name = "FmSeqDuarPlus";
                xlWorkSheetFmNoSeq.Name = "FmNoSeqPauseDuar";
                xlWorkSheetNote.Name = "Note";
                xlWorkSheetTakt.Name = "Takt";

                #region Шапка

                //----------------заполнение шапки-----------------------
                xlWorkSheetFmSeqPauseIgnore.Cells.ColumnWidth = 10;
                xlWorkSheetFmSeqPauseIgnore.Cells[1, 1] = "Name";
                xlWorkSheetFmSeqPauseIgnore.Cells[1, 2] = "L";
                xlWorkSheetFmSeqPauseIgnore.Cells[1, 3] = "Max P";
                xlWorkSheetFmSeqPauseIgnore.Cells[1, 4] = "Vp";
                xlWorkSheetFmSeqPauseIgnore.Cells[1, 5] = "Vt";
                xlWorkSheetFmSeqPauseIgnore.Cells[1, 6] = "Vt-Vp/Vt %";

                xlWorkSheetFmSeqPauseIgnore.Cells[1, 7] = "g";
                xlWorkSheetFmSeqPauseIgnore.Cells[1, 8] = "H";
                xlWorkSheetFmSeqPauseIgnore.Cells[1, 9] = "G";
                xlWorkSheetFmSeqPauseIgnore.Cells[1, 10] = "L*H";
                xlWorkSheetFmSeqPauseIgnore.Cells[1, 11] = "r";

                //-------------------------------------------------------
                xlWorkSheetFmSeqSilencePause.Cells.ColumnWidth = 10;
                xlWorkSheetFmSeqSilencePause.Cells[1, 1] = "Name";
                xlWorkSheetFmSeqSilencePause.Cells[1, 2] = "L";
                xlWorkSheetFmSeqSilencePause.Cells[1, 3] = "Max P";
                xlWorkSheetFmSeqSilencePause.Cells[1, 4] = "Vp";
                xlWorkSheetFmSeqSilencePause.Cells[1, 5] = "Vt";
                xlWorkSheetFmSeqSilencePause.Cells[1, 6] = "Vt-Vp/Vt %";

                xlWorkSheetFmSeqSilencePause.Cells[1, 7] = "g";
                xlWorkSheetFmSeqSilencePause.Cells[1, 8] = "H";
                xlWorkSheetFmSeqSilencePause.Cells[1, 9] = "G";
                xlWorkSheetFmSeqSilencePause.Cells[1, 10] = "L*H";
                xlWorkSheetFmSeqSilencePause.Cells[1, 11] = "r";
                //--------------------------------------------------------
                xlWorkSheetFmSeqDuarPlus.Cells.ColumnWidth = 10;
                xlWorkSheetFmSeqDuarPlus.Cells[1, 1] = "Name";
                xlWorkSheetFmSeqDuarPlus.Cells[1, 2] = "L";
                xlWorkSheetFmSeqDuarPlus.Cells[1, 3] = "Max P";
                xlWorkSheetFmSeqDuarPlus.Cells[1, 4] = "Vp";
                xlWorkSheetFmSeqDuarPlus.Cells[1, 5] = "Vt";
                xlWorkSheetFmSeqDuarPlus.Cells[1, 6] = "Vt-Vp/Vt %";

                xlWorkSheetFmSeqDuarPlus.Cells[1, 7] = "g";
                xlWorkSheetFmSeqDuarPlus.Cells[1, 8] = "H";
                xlWorkSheetFmSeqDuarPlus.Cells[1, 9] = "G";
                xlWorkSheetFmSeqDuarPlus.Cells[1, 10] = "L*H";
                xlWorkSheetFmSeqDuarPlus.Cells[1, 11] = "r";
                //--------------------------------------------------------
                xlWorkSheetFmNoSeq.Cells.ColumnWidth = 10;
                xlWorkSheetFmNoSeq.Cells[1, 1] = "Name";
                xlWorkSheetFmNoSeq.Cells[1, 2] = "L";
                xlWorkSheetFmNoSeq.Cells[1, 3] = "Max P";
                xlWorkSheetFmNoSeq.Cells[1, 4] = "Vp";
                xlWorkSheetFmNoSeq.Cells[1, 5] = "Vt";
                xlWorkSheetFmNoSeq.Cells[1, 6] = "Vt-Vp/Vt %";

                xlWorkSheetFmNoSeq.Cells[1, 7] = "g";
                xlWorkSheetFmNoSeq.Cells[1, 8] = "H";
                xlWorkSheetFmNoSeq.Cells[1, 9] = "G";
                xlWorkSheetFmNoSeq.Cells[1, 10] = "L*H";
                xlWorkSheetFmNoSeq.Cells[1, 11] = "r";

                //--------------------------------------------------------
                xlWorkSheetNote.Cells.ColumnWidth = 10;
                xlWorkSheetNote.Cells[1, 1] = "Name";
                xlWorkSheetNote.Cells[1, 2] = "L";
                xlWorkSheetNote.Cells[1, 3] = "Max P";
                xlWorkSheetNote.Cells[1, 4] = "Vp";
                xlWorkSheetNote.Cells[1, 5] = "Vt";
                xlWorkSheetNote.Cells[1, 6] = "Vt-Vp/Vt %";

                xlWorkSheetNote.Cells[1, 7] = "g";
                xlWorkSheetNote.Cells[1, 8] = "H";
                xlWorkSheetNote.Cells[1, 9] = "G";
                xlWorkSheetNote.Cells[1, 10] = "L*H";
                xlWorkSheetNote.Cells[1, 11] = "r";

                //--------------------------------------------------------
                xlWorkSheetTakt.Cells.ColumnWidth = 10;
                xlWorkSheetTakt.Cells[1, 1] = "Name";
                xlWorkSheetTakt.Cells[1, 2] = "L";
                xlWorkSheetTakt.Cells[1, 3] = "Max P";
                xlWorkSheetTakt.Cells[1, 4] = "Vp";
                xlWorkSheetTakt.Cells[1, 5] = "Vt";
                xlWorkSheetTakt.Cells[1, 6] = "Vt-Vp/Vt %";

                xlWorkSheetTakt.Cells[1, 7] = "g";
                xlWorkSheetTakt.Cells[1, 8] = "H";
                xlWorkSheetTakt.Cells[1, 9] = "G";
                xlWorkSheetTakt.Cells[1, 10] = "L*H";
                xlWorkSheetTakt.Cells[1, 11] = "r";
                //--------------------------------------------------------

                #endregion

                DirectoryInfo dir = new DirectoryInfo(folderBrowserDialog1.SelectedPath);

                int n = 1; //счетчик для файлов

                foreach (var item in dir.GetFiles())
                {
                    // для каждого .xml файла
                    if (item.Name.EndsWith(".xml"))
                    {

                        try
                        {
                            n = n + 1; //  на один файл больще стало
                            XmlDocument xmldocument = new XmlDocument();
                            MusicXmlReader xmlreader = new MusicXmlReader(item.FullName);
                            MusicXmlParser Parser = new MusicXmlParser();
                            Parser.Execute(xmlreader.MusicXmlDocument, xmlreader.FileName);
                            BorodaDivider.BorodaDivider bd = new BorodaDivider.BorodaDivider();

                            //------Создание Exсel файла со строями нот для каждого
                            Excel.Workbook xlWorkBook1;
                            Excel.Worksheet xlWorkSheet1;
                            Excel.Worksheet xlWorkSheet2;
                            Excel.Worksheet xlWorkSheet3;
                            Excel.Worksheet xlWorkSheet4;

                            object misValue1 = System.Reflection.Missing.Value;

                            xlWorkBook1 = xlApp.Workbooks.Add(misValue1);

                            xlWorkBook1.Worksheets.Add();

                            xlWorkSheet1 = (Excel.Worksheet) xlWorkBook1.Worksheets.get_Item(1);
                            xlWorkSheet2 = (Excel.Worksheet) xlWorkBook1.Worksheets.get_Item(2);
                            xlWorkSheet3 = (Excel.Worksheet) xlWorkBook1.Worksheets.get_Item(3);
                            xlWorkSheet4 = (Excel.Worksheet) xlWorkBook1.Worksheets.get_Item(4);

                            xlWorkSheet1.Name = "Строй";
                            xlWorkSheet2.Name = "Зависимости K1";
                            xlWorkSheet3.Name = "Зависимости K2";
                            xlWorkSheet4.Name = "Зависимости K3";

                            //ширина зависимости
                            xlWorkSheet2.Cells.ColumnWidth = 6;
                            xlWorkSheet3.Cells.ColumnWidth = 6;
                            xlWorkSheet4.Cells.ColumnWidth = 6;

                            xlWorkSheet1.Cells.ColumnWidth = 10;
                            xlWorkSheet1.Cells[1, 1] = "FmSeqPauseIgnore";
                            xlWorkSheet1.Cells[1, 2] = "FmSeqSilencePause";
                            xlWorkSheet1.Cells[1, 3] = "FmSeqDuarPlus";
                            xlWorkSheet1.Cells[1, 4] = "FmNoSeqPauseDuar";
                            xlWorkSheet1.Cells[1, 5] = "Note";
                            xlWorkSheet1.Cells[1, 6] = "Takt";

                            xlWorkSheet1.Cells[1, 8] = "giRang";
                            xlWorkSheet1.Cells[1, 9] = "gi";
                            xlWorkSheet1.Cells[1, 10] = "nj";

                            xlWorkSheet1.Cells[1, 12] = "Log(Gi)";
                            xlWorkSheet1.Cells[1, 13] = "Log(Gi)/max";
                            xlWorkSheet1.Cells[1, 14] = "nj";
                            xlWorkSheet1.Cells[1, 15] = "nj/max";

                            xlWorkSheet1.Cells[1, 17] = "njF";
                            xlWorkSheet1.Cells[1, 18] = "njN";
                            xlWorkSheet1.Cells[1, 19] = "njT";



                            //--------------

                            /*
                            // записываем строй в файл с таким же именем только с припиской .txt
                            foreach (FmotivChain fmchain in Listfmotivchains)
                            {
                                FileStream fs = new FileStream(item.FullName + ".txt", FileMode.OpenOrCreate, FileAccess.Write);
                                StreamWriter st = new StreamWriter(fs);
                                foreach (Fmotiv fmotiv in fmchain.FmotivList)
                                {
                                    st.WriteLine(fmotiv.Id.ToString());
                                }
                                st.Close();
                                fs.Close();
                            }*/


                            //--------------------sequent-Pause-ignore--------------------------------------------------------------------------------
                            List<FmotivChain> Listfmotivchains = bd.Divide(Parser.ScoreModel, PauseTreatment.Ignore,
                                                                           FMSequentEquality.Sequent);
                            try
                            {

                                Composition com = new Composition();
                                int i = 0;

                                for (i = 0; i < Listfmotivchains[0].FmotivList.Count; i++)
                                    // previously was .Count , not .Lenght
                                {
                                    com.AddFM(Listfmotivchains[0].FmotivList[i].Id.ToString());
                                    xlWorkSheet1.Cells[(i + 2), 1] = Listfmotivchains[0].FmotivList[i].Id;
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

                                xlWorkSheetFmSeqPauseIgnore.Cells[n, 1] = item.Name;
                                xlWorkSheetFmSeqPauseIgnore.Cells[n, 2] = Listfmotivchains[0].FmotivList.Count;
                                xlWorkSheetFmSeqPauseIgnore.Cells[n, 3] = com.PLex.CalcGreatFrequency();
                                xlWorkSheetFmSeqPauseIgnore.Cells[n, 4] = com.PLex.Capacity;
                                xlWorkSheetFmSeqPauseIgnore.Cells[n, 5] = com.TLex.Capacity;
                                xlWorkSheetFmSeqPauseIgnore.Cells[n, 6] = com.VDiff.PdV;

                                xlWorkSheetFmSeqPauseIgnore.Cells[n, 7] = com.AvgRemoteness;
                                xlWorkSheetFmSeqPauseIgnore.Cells[n, 8] = com.Entropy;
                                xlWorkSheetFmSeqPauseIgnore.Cells[n, 9] = com.AvgDepth;
                                xlWorkSheetFmSeqPauseIgnore.Cells[n, 10] = com.Entropy*
                                                                           Listfmotivchains[0].FmotivList.Count;
                                xlWorkSheetFmSeqPauseIgnore.Cells[n, 11] = com.Regularity;



                            }
                            catch (Exception err)
                            {
                                MessageBox.Show(err.Message, "Analisis Ошибка", MessageBoxButtons.OK,
                                                MessageBoxIcon.Stop);
                            }

                            //--------------------sequent-Pause-Duar--------------------------------------------------------------------------------
                            List<FmotivChain> Listfmotivchains3 = bd.Divide(Parser.ScoreModel,
                                                                            PauseTreatment.NoteTrace,
                                                                            FMSequentEquality.Sequent);
                            try
                            {
                                Composition com = new Composition();

                                Chain mychain = new Chain(Listfmotivchains3[0].FmotivList.Count);
                                int i = 0;

                                for (i = 0; i < Listfmotivchains3[0].FmotivList.Count; i++)
                                    // previously was .Count , not .Lenght
                                {
                                    com.AddFM(Listfmotivchains3[0].FmotivList[i].Id.ToString());

                                    mychain.Add(new ValueInt(Listfmotivchains3[0].FmotivList[i].Id), i);

                                    xlWorkSheet1.Cells[(i + 2), 3] = Listfmotivchains3[0].FmotivList[i].Id;
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

                                //------------------------------Хар-ки слов по конкретному файлу----------- 

                                // удаленности i-ые
                                ArrayList Ri = new ArrayList();
                                Ri = com.PLex.RangeLexRi();
                                // глубины i-ые
                                ArrayList Di = new ArrayList();
                                Di = com.PLex.RangeLexDi();

                                for (i = 0; i < com.PLex.Capacity; i++) // previously was .Count , not .Lenght
                                {
                                    xlWorkSheet1.Cells[(i + 2), 8] = (double) Ri[i];
                                    xlWorkSheet1.Cells[(i + 2), 9] = ((FMotiv) com.PLex.RData[i]).Remoteness;
                                    xlWorkSheet1.Cells[(i + 2), 10] = ((FMotiv) com.PLex.RData[i]).Frequency;

                                    xlWorkSheet1.Cells[(i + 2), 12] = (double) Di[i];
                                    xlWorkSheet1.Cells[(i + 2), 13] = (double) Di[i]/(double) Di[0];
                                    xlWorkSheet1.Cells[(i + 2), 14] = ((FMotiv) com.PLex.RData[i]).Frequency;
                                    xlWorkSheet1.Cells[(i + 2), 15] = ((FMotiv) com.PLex.RData[i]).Frequency/
                                                                      ((FMotiv) com.PLex.RData[0]).Frequency;

                                    xlWorkSheet1.Cells[(i + 2), 17] = ((FMotiv) com.PLex.RData[i]).Frequency;
                                    ;

                                    //зависимости: заполнение алфавита
                                    xlWorkSheet2.Cells[i + 2, 1] = i;
                                    xlWorkSheet2.Cells[1, i + 2] = i;
                                    xlWorkSheet3.Cells[i + 2, 1] = i;
                                    xlWorkSheet3.Cells[1, i + 2] = i;
                                    xlWorkSheet4.Cells[i + 2, 1] = i;
                                    xlWorkSheet4.Cells[1, i + 2] = i;
                                }

                                //таблицы зависимости
                                List<List<double>> table1 = BinaryCharacteristicsFactory.K1.Calculate(mychain,
                                                                                                      LinkUp.End);
                                List<List<double>> table2 = BinaryCharacteristicsFactory.K2.Calculate(mychain,
                                                                                                      LinkUp.End);
                                List<List<double>> table3 = BinaryCharacteristicsFactory.K3.Calculate(mychain,
                                                                                                      LinkUp.End);

                                for (int k = 0; k < com.PLex.Capacity; k++) // previously was .Count , not .Lenght
                                {
                                    for (int m = 0; m < com.PLex.Capacity; m++)
                                        // previously was .Count , not .Lenght
                                    {


                                        xlWorkSheet2.Cells[k + 2, m + 2] = table1[k][m];
                                        if (table1[k][m] > 0.4)
                                        {
                                            xlWorkSheet2.Cells[k + 2, m + 2].Font.Color =
                                                System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                                        }
                                        if (table1[k][m] > 0.7)
                                        {
                                            xlWorkSheet2.Cells[k + 2, m + 2].Font.Color =
                                                System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                                        }

                                        xlWorkSheet3.Cells[k + 2, m + 2] = table2[k][m];
                                        if (table2[k][m] > 0.4)
                                        {
                                            xlWorkSheet3.Cells[k + 2, m + 2].Font.Color =
                                                System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                                        }
                                        if (table2[k][m] > 0.7)
                                        {
                                            xlWorkSheet3.Cells[k + 2, m + 2].Font.Color =
                                                System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                                        }


                                        xlWorkSheet4.Cells[k + 2, m + 2] = table3[k][m];
                                        if (table3[k][m] > 0.4)
                                        {
                                            xlWorkSheet4.Cells[k + 2, m + 2].Font.Color =
                                                System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                                        }
                                        if (table3[k][m] > 0.7)
                                        {
                                            xlWorkSheet4.Cells[k + 2, m + 2].Font.Color =
                                                System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                                        }

                                    }
                                }

                                //------------------------------------------------------------------------------

                                xlWorkSheetFmSeqDuarPlus.Cells[n, 1] = item.Name;
                                xlWorkSheetFmSeqDuarPlus.Cells[n, 2] = Listfmotivchains3[0].FmotivList.Count;
                                xlWorkSheetFmSeqDuarPlus.Cells[n, 3] = com.PLex.CalcGreatFrequency();
                                xlWorkSheetFmSeqDuarPlus.Cells[n, 4] = com.PLex.Capacity;
                                xlWorkSheetFmSeqDuarPlus.Cells[n, 5] = com.TLex.Capacity;
                                xlWorkSheetFmSeqDuarPlus.Cells[n, 6] = com.VDiff.PdV;

                                xlWorkSheetFmSeqDuarPlus.Cells[n, 7] = com.AvgRemoteness;
                                xlWorkSheetFmSeqDuarPlus.Cells[n, 8] = com.Entropy;
                                xlWorkSheetFmSeqDuarPlus.Cells[n, 9] = com.AvgDepth;
                                xlWorkSheetFmSeqDuarPlus.Cells[n, 10] = com.Entropy*
                                                                        Listfmotivchains3[0].FmotivList.Count;
                                xlWorkSheetFmSeqDuarPlus.Cells[n, 11] = com.Regularity;
                            }
                            catch (Exception err)
                            {
                                MessageBox.Show(err.Message, "Analisis Ошибка", MessageBoxButtons.OK,
                                                MessageBoxIcon.Stop);
                            }
                            //--------------------sequent Pause silence----------------------------------------------------------------------------------
                            List<FmotivChain> Listfmotivchains4 = bd.Divide(Parser.ScoreModel,
                                                                            PauseTreatment.SilenceNote,
                                                                            FMSequentEquality.Sequent);
                            try
                            {
                                Composition com = new Composition();
                                int i = 0;

                                for (i = 0; i < Listfmotivchains4[0].FmotivList.Count; i++)
                                    // previously was .Count , not .Lenght
                                {
                                    com.AddFM(Listfmotivchains4[0].FmotivList[i].Id.ToString());
                                    xlWorkSheet1.Cells[(i + 2), 2] = Listfmotivchains4[0].FmotivList[i].Id;
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

                                xlWorkSheetFmSeqSilencePause.Cells[n, 1] = item.Name;
                                xlWorkSheetFmSeqSilencePause.Cells[n, 2] = Listfmotivchains4[0].FmotivList.Count;
                                xlWorkSheetFmSeqSilencePause.Cells[n, 3] = com.PLex.CalcGreatFrequency();
                                xlWorkSheetFmSeqSilencePause.Cells[n, 4] = com.PLex.Capacity;
                                xlWorkSheetFmSeqSilencePause.Cells[n, 5] = com.TLex.Capacity;
                                xlWorkSheetFmSeqSilencePause.Cells[n, 6] = com.VDiff.PdV;

                                xlWorkSheetFmSeqSilencePause.Cells[n, 7] = com.AvgRemoteness;
                                xlWorkSheetFmSeqSilencePause.Cells[n, 8] = com.Entropy;
                                xlWorkSheetFmSeqSilencePause.Cells[n, 9] = com.AvgDepth;
                                xlWorkSheetFmSeqSilencePause.Cells[n, 10] = com.Entropy*
                                                                            Listfmotivchains4[0].FmotivList.Count;
                                xlWorkSheetFmSeqSilencePause.Cells[n, 11] = com.Regularity;
                            }
                            catch (Exception err)
                            {
                                MessageBox.Show(err.Message, "Analisis Ошибка", MessageBoxButtons.OK,
                                                MessageBoxIcon.Stop);
                            }
                            //------------------------------------------------------------------------------------------------------


                            //--------------------non sequent pause Duar----------------------------------------------------------------------------------
                            List<FmotivChain> Listfmotivchains2 = bd.Divide(Parser.ScoreModel,
                                                                            PauseTreatment.NoteTrace,
                                                                            FMSequentEquality.NonSequent);
                            try
                            {
                                Composition com = new Composition();
                                int i = 0;

                                for (i = 0; i < Listfmotivchains2[0].FmotivList.Count; i++)
                                    // previously was .Count , not .Lenght
                                {
                                    com.AddFM(Listfmotivchains2[0].FmotivList[i].Id.ToString());
                                    xlWorkSheet1.Cells[(i + 2), 4] = Listfmotivchains2[0].FmotivList[i].Id;
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

                                xlWorkSheetFmNoSeq.Cells[n, 1] = item.Name;
                                xlWorkSheetFmNoSeq.Cells[n, 2] = Listfmotivchains2[0].FmotivList.Count;
                                xlWorkSheetFmNoSeq.Cells[n, 3] = com.PLex.CalcGreatFrequency();
                                xlWorkSheetFmNoSeq.Cells[n, 4] = com.PLex.Capacity;
                                xlWorkSheetFmNoSeq.Cells[n, 5] = com.TLex.Capacity;
                                xlWorkSheetFmNoSeq.Cells[n, 6] = com.VDiff.PdV;

                                xlWorkSheetFmNoSeq.Cells[n, 7] = com.AvgRemoteness;
                                xlWorkSheetFmNoSeq.Cells[n, 8] = com.Entropy;
                                xlWorkSheetFmNoSeq.Cells[n, 9] = com.AvgDepth;
                                xlWorkSheetFmNoSeq.Cells[n, 10] = com.Entropy*Listfmotivchains2[0].FmotivList.Count;
                                xlWorkSheetFmNoSeq.Cells[n, 11] = com.Regularity;



                            }
                            catch (Exception err)
                            {
                                MessageBox.Show(err.Message, "Analisis Ошибка", MessageBoxButtons.OK,
                                                MessageBoxIcon.Stop);
                            }
                            //------------------------------------------------------------------------------------------------------



                            //--------------------Note----------------------------------------------------------------------------------

                            try
                            {
                                int[] notesOrder = Parser.ScoreModel.UniformScoreTracks[0].NoteIdOrder();
                                Composition com = new Composition();
                                int i = 0;

                                for (i = 0; i < notesOrder.Length; i++) // previously was .Count , not .Lenght
                                {
                                    com.AddFM(notesOrder[i].ToString());
                                    xlWorkSheet1.Cells[(i + 2), 5] = notesOrder[i];

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

                                // ззаносим в файл частоты вхождения нот
                                for (i = 0; i < com.PLex.Capacity; i++) // previously was .Count , not .Lenght
                                {
                                    xlWorkSheet1.Cells[(i + 2), 18] = ((FMotiv) com.PLex.RData[i]).Frequency;

                                }
                                xlWorkSheetNote.Cells[n, 1] = item.Name;
                                xlWorkSheetNote.Cells[n, 2] = notesOrder.Length;
                                xlWorkSheetNote.Cells[n, 3] = com.PLex.CalcGreatFrequency();
                                xlWorkSheetNote.Cells[n, 4] = com.PLex.Capacity;
                                xlWorkSheetNote.Cells[n, 5] = com.TLex.Capacity;
                                xlWorkSheetNote.Cells[n, 6] = com.VDiff.PdV;

                                xlWorkSheetNote.Cells[n, 7] = com.AvgRemoteness;
                                xlWorkSheetNote.Cells[n, 8] = com.Entropy;
                                xlWorkSheetNote.Cells[n, 9] = com.AvgDepth;
                                xlWorkSheetNote.Cells[n, 10] = com.Entropy*notesOrder.Length;
                                xlWorkSheetNote.Cells[n, 11] = com.Regularity;
                            }
                            catch (Exception err)
                            {
                                MessageBox.Show(err.Message, "Analisis Ошибка", MessageBoxButtons.OK,
                                                MessageBoxIcon.Stop);
                            }
                            //------------------------------------------------------------------------------------------------------
                            //--------------------Takt----------------------------------------------------------------------------------
                            try
                            {
                                int[] measureOrder = Parser.ScoreModel.UniformScoreTracks[0].MeasureIdOrder();
                                Composition com = new Composition();
                                int i = 0;

                                for (i = 0; i < measureOrder.Length; i++) // previously was .Count , not .Lenght
                                {
                                    com.AddFM(measureOrder[i].ToString());
                                    xlWorkSheet1.Cells[(i + 2), 6] = measureOrder[i];
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

                                // заносим в файл частоты вхождения тактов
                                for (i = 0; i < com.PLex.Capacity; i++) // previously was .Count , not .Lenght
                                {
                                    xlWorkSheet1.Cells[(i + 2), 19] = ((FMotiv) com.PLex.RData[i]).Frequency;

                                }

                                xlWorkSheetTakt.Cells[n, 1] = item.Name;
                                xlWorkSheetTakt.Cells[n, 2] = measureOrder.Length;
                                xlWorkSheetTakt.Cells[n, 3] = com.PLex.CalcGreatFrequency();
                                xlWorkSheetTakt.Cells[n, 4] = com.PLex.Capacity;
                                xlWorkSheetTakt.Cells[n, 5] = com.TLex.Capacity;
                                xlWorkSheetTakt.Cells[n, 6] = com.VDiff.PdV;

                                xlWorkSheetTakt.Cells[n, 7] = com.AvgRemoteness;
                                xlWorkSheetTakt.Cells[n, 8] = com.Entropy;
                                xlWorkSheetTakt.Cells[n, 9] = com.AvgDepth;
                                xlWorkSheetTakt.Cells[n, 10] = com.Entropy*measureOrder.Length;
                                xlWorkSheetTakt.Cells[n, 11] = com.Regularity;
                            }
                            catch (Exception err)
                            {
                                MessageBox.Show(err.Message, "Analisis Ошибка", MessageBoxButtons.OK,
                                                MessageBoxIcon.Stop);
                            }
                            //------------------------------------------------------------------------------------------------------

                            xlWorkBook1.SaveAs(folderBrowserDialog1.SelectedPath + "\\" + item.Name + ".order.xls",
                                               Excel.XlFileFormat.xlWorkbookDefault, misValue1, misValue1, misValue1,
                                               misValue1, Excel.XlSaveAsAccessMode.xlExclusive, misValue1, misValue1,
                                               misValue1, misValue1, misValue1);
                            xlWorkBook1.Close(true, misValue1, misValue1);
                            //xlApp1.Quit();

                            releaseObject(xlWorkSheet1);
                            releaseObject(xlWorkSheet2);
                            releaseObject(xlWorkSheet3);
                            releaseObject(xlWorkSheet4);
                            releaseObject(xlWorkBook1);
                            //releaseObject(xlApp1);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(item.FullName + " " + ex);
                        }
                    }
                }

                // ----------Сохранение Excel файла-----------------------------------------------------------
                xlWorkBook.SaveAs(folderBrowserDialog1.SelectedPath + "\\Total.xls", Excel.XlFileFormat.xlWorkbookNormal,
                                  misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue,
                                  misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();



                releaseObject(xlWorkSheetFmSeqPauseIgnore);
                releaseObject(xlWorkSheetFmSeqSilencePause);
                releaseObject(xlWorkSheetFmSeqDuarPlus);
                releaseObject(xlWorkSheetNote);
                releaseObject(xlWorkSheetFmNoSeq);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);

                //System.Threading.Thread.CurrentThread.CurrentCulture = oldCI;

                MessageBox.Show("Excel file created , you can find the file " + folderBrowserDialog1.SelectedPath +
                                "\\Total.xls");
                //---------------------------------------------------------------------------------------------
            }




            /*
                
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
            // ------------ 7 НОВЫХ --------------------------
            // сводный файл для Lcp
            FileStream fsLcp = new FileStream(folderBrowserDialog1.SelectedPath + "\\Total_Lcp.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter stLcp = new StreamWriter(fsLcp);                
            // сводный файл для gl
            FileStream fsgl = new FileStream(folderBrowserDialog1.SelectedPath + "\\Total_gl.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter stgl = new StreamWriter(fsgl);
            // сводный файл для Gl
            FileStream fsGl = new FileStream(folderBrowserDialog1.SelectedPath + "\\Total_GGl.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter stGl = new StreamWriter(fsGl);
            // сводный файл для gw
            FileStream fsgw = new FileStream(folderBrowserDialog1.SelectedPath + "\\Total_gw.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter stgw = new StreamWriter(fsgw);
            // сводный файл для Gw
            FileStream fsGw = new FileStream(folderBrowserDialog1.SelectedPath + "\\Total_GGw.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter stGw = new StreamWriter(fsGw);

            // сводный файл для Gw2
            FileStream fsGw2 = new FileStream(folderBrowserDialog1.SelectedPath + "\\Total_GGw2.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter stGw2 = new StreamWriter(fsGw2);

            // сводный файл для Gw3
            FileStream fsGw3 = new FileStream(folderBrowserDialog1.SelectedPath + "\\Total_GGw3.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter stGw3 = new StreamWriter(fsGw3);

            // сводный файл для Vlen
            FileStream fsVl = new FileStream(folderBrowserDialog1.SelectedPath + "\\Total_Vl.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter stVl = new StreamWriter(fsVl);


            // сводный файл для g2
            FileStream fsg2 = new FileStream(folderBrowserDialog1.SelectedPath + "\\Total_g2.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter stg2 = new StreamWriter(fsg2);
            // сводный файл для gaw
            FileStream fsgaw = new FileStream(folderBrowserDialog1.SelectedPath + "\\Total_gaw.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter stgaw = new StreamWriter(fsgaw);


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

                        List<FmotivChain> Listfmotivchains = bd.Divide(Parser.ScoreModel, ParamPauseTreatment.Ignore, ParamEqualFM.Sequent);
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
                                    
                            // 7 новых
                                stLcp.WriteLine(AverageLength.Calculate(Listfmotivchains[0]).ToString());
                                stgl.WriteLine(NoteCharacteristic.CalculateRemoteness(Listfmotivchains[0]).ToString());
                                stGl.WriteLine(NoteCharacteristic.CalculateGamut(Listfmotivchains[0]).ToString());
                                stgw.WriteLine(WordRemoteness.CalculateInLetters(Listfmotivchains[0]).ToString());
                                stGw.WriteLine(WordRemoteness.CalculateTextGamut(Listfmotivchains[0]).ToString());

                                stGw2.WriteLine(TextWordGamut.CalculateTextWordGamut(Listfmotivchains[0]).ToString());
                                stGw3.WriteLine(TextWordGamut.CalculateTextWordGamutW(Listfmotivchains[0]).ToString());

                                stVl.WriteLine(TextWordGamut.CalculateVlen(Listfmotivchains[0]).ToString());

                                stg2.WriteLine(WordRemoteness.CalculateInWords(Listfmotivchains[0]).ToString());
                                stgaw.WriteLine(WithinWordRemoteness.Calculate(Listfmotivchains[0]).ToString());
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

            // 7 новых
            stLcp.Close();
            stgl.Close();
            stGl.Close();
            stgw.Close();
            stGw.Close();

            stGw2.Close();
            stGw3.Close();
            stVl.Close();

            stg2.Close();
            stgaw.Close();
                
            */
        }
    }
}
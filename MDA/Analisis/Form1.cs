using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using MDA.OIP.MusicXml;
using MDA.OIP.BorodaDivider;
using System.IO;
using MDA.OIP.ScoreModel;
using Excel = Microsoft.Office.Interop.Excel;

namespace MDA.Analisis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public Composition composition = new Composition();

        //----------------------Load TXT button-----------------------------------		
        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                textBox1.Clear();
                openFileDialog1.FileName = "";
                openFileDialog1.Filter = "Txt|*.txt|All files|*.*";
                openFileDialog1.ShowDialog();

                Reader r = new Reader();

                r.SetData(openFileDialog1.FileName);
                textBox1.Clear();
                int i = 0;
                for (i = 0; i < r.Data.Length - 1; i++) // COUNT -> Length error
                {
                    textBox1.Text = textBox1.Text + r.Data[i] + '\r' + '\n';
                }
                textBox1.Text = textBox1.Text + r.Data[i];
                new Drawer().Clean(this);
                label24.Text = openFileDialog1.FileName;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        //-----------------------------------------------------------------------

        //----------------------Load XMl button-------------------------	
        private void button20_Click_1(object sender, EventArgs e)
        {


            try
            {
                textBox1.Clear();
                openFileDialog1.FileName = "";
                openFileDialog1.Filter = "Xml|*.xml|All files|*.*";
                openFileDialog1.ShowDialog();

                XmlDocument xmldocument = new XmlDocument();
                MusicXmlReader xmlreader = new MusicXmlReader(openFileDialog1.FileName);
                MusicXmlParser Parser = new MusicXmlParser();
                Parser.Execute(xmlreader.MusicXmlDocument, xmlreader.FileName);

                BorodaDivider bd = new BorodaDivider();

                List<FmotivChain> Listfmotivchains = bd.Divide(Parser.ScoreModel, PauseTreatment.NoteTrace,
                                                               FMSequentEquality.Sequent);

                #region запись разбитых фмотивов в файл

                // записываем строй в файл с таким же именем только с припиской _Consistence.txt состав по нотам в фмотивах
                FileStream fs = new FileStream(openFileDialog1.FileName + "_Consistence.txt", FileMode.OpenOrCreate,
                                               FileAccess.Write);
                StreamWriter st = new StreamWriter(fs);


                foreach (FmotivChain fmchain in Listfmotivchains)
                {
                    st.WriteLine("Fmotiv Chain № " + fmchain.Id.ToString() + " Name = " + fmchain.Name);
                    st.WriteLine();
                    st.WriteLine("------------------------");

                    foreach (Fmotiv fmotiv in fmchain.FmotivList)
                    {
                        st.WriteLine("Fmotiv № " + fmotiv.Id.ToString() + " | type " + fmotiv.Type);
                        st.WriteLine();
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
                                st.WriteLine("Note: duration = " + note.Duration.Numerator.ToString() + "/" +
                                             note.Duration.Denominator.ToString() +
                                             " step = " + note.Pitch.Step.ToString() + " priority = " +
                                             note.Priority.ToString() + tietype);
                            }
                            else
                            {
                                st.WriteLine("Pause: duration = " + note.Duration.Numerator.ToString() + "/" +
                                             note.Duration.Denominator.ToString() +
                                             " priority = " + note.Priority.ToString());
                            }

                        }
                        st.WriteLine("------------------------");
                    }
                }
                st.Close();
                fs.Close();

                #endregion

                textBox1.Clear();
                int i = 0;
                for (i = 0; i < Listfmotivchains[0].FmotivList.Count; i++) // COUNT -> (string []) LENGTH error
                {
                    textBox1.Text = textBox1.Text + Listfmotivchains[0].FmotivList[i].Id + '\r' + '\n';
                }
                //textBox1.Text = textBox1.Text + r.GetData()[i];
                new Drawer().Clean(this);
                label24.Text = openFileDialog1.FileName;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        //-----------------------------------------------------------------------
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

        //----------------------Analize button-----------------------------------		
        private void button1_Click(object sender, EventArgs e)
        {
            // ----------Создание Excel файла-----------------------------------------------------------

            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;

            Excel.Worksheet xlWorkSheet;

            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);

            xlWorkSheet = (Excel.Worksheet) xlWorkBook.Worksheets.get_Item(1);
            //---------------------------------------------------------------------------------
            try
            {
                //TODO: вынести composition (com) в глобальные переменные + после каждой очистки формы, удалять/чистить объект.
                Composition com = new Composition();
                int i = 0;
                for (i = 0; i < textBox1.Lines.Length; i++) // previously was .Count , not .Lenght
                {
                    com.AddFM((string) textBox1.Lines.GetValue(i));
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
                composition = com.Clone();


                Drawer draver = new Drawer();
                draver.Draw(this, com.GetDisplayData());

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            // ----------Сохранение Excel файла-----------------------------------------------------------
            xlWorkBook.SaveAs(folderBrowserDialog1.SelectedPath + "\\Total.xls", Excel.XlFileFormat.xlWorkbookNormal,
                              misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue,
                              misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();



            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            MessageBox.Show("Excel file created , you can find the file " + folderBrowserDialog1.SelectedPath +
                            "\\Total.xls");
            //---------------------------------------------------------------------------------------------


        }

        //-----------------------------------------------------------------------

        //--------------Print, Save as bmp, Refresh, Clean, Clean All-----------------	

        #region -----------Print, Save as bmp, Refresh, Clean, Clean All, ExitMenu-------

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            zedGraphControl1.DoPrint();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            zedGraphControl2.DoPrint();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            zedGraphControl3.DoPrint();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            zedGraphControl4.DoPrint();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            zedGraphControl5.DoPrint();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            zedGraphControl1.SaveAsBitmap();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            zedGraphControl2.SaveAsBitmap();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            zedGraphControl3.SaveAsBitmap();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            zedGraphControl4.SaveAsBitmap();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            zedGraphControl5.SaveAsBitmap();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Drawer drawer = new Drawer();
            drawer.DrawGraphs(this, composition.GetDisplayData(), 1);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Drawer drawer = new Drawer();
            drawer.DrawGraphs(this, composition.GetDisplayData(), 2);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Drawer drawer = new Drawer();
            drawer.DrawGraphs(this, composition.GetDisplayData(), 3);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Drawer drawer = new Drawer();
            drawer.DrawGraphs(this, composition.GetDisplayData(), 4);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Drawer drawer = new Drawer();
            drawer.DrawGraphs(this, composition.GetDisplayData(), 5);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            label24.Text = "Name";

        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            label24.Text = "Name";
            new Drawer().Clean(this);
        }

        #endregion

        //----------------------------------------------------------------------------

        /*-----------------------------------test------------------------------------
	
                private void button20_Click(object sender, EventArgs e)
                {
                    GraphPane pane = zedGraphControl5.GraphPane;     // Получим панель для рисования
                    pane.CurveList.Clear();                 // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
                    PointPairList list1 = new PointPairList();      // Создадим список точек
                    list1.Add(4.05887, 1);
                    list1.Add(4.34456, 1);
                    list1.Add(4.96888, 1);
                    list1.Add(4.97012, 1);
                    list1.Add(5.26461, 1);
                    list1.Add(5.44004, 1);
                    list1.Add(6.06081, 1);

                    LineItem myCurve1 = pane.AddCurve("Practical", list1, Color.Black, SymbolType.VDash);
                    myCurve1.Line.Width = 2.0F; // Толщина графиков

                    pane.XAxis.Scale.Min = (-0.02 * 6.06081);
                    pane.XAxis.Scale.Max = (6.06081 * 1.02);

                    PointF pc = new PointF((float)2.5, (float)2.5);
                    zedGraphControl5.ZoomPane(pane, 1, pc, false);
                    zedGraphControl5.Refresh();

                }
        */

    }
}
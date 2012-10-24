using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace MDA.Analisis
{
    public class Drawer
    {


        public void Clean(Form1 f)
        {
            f.textBox9.Clear();
            f.textBox8.Clear();
            f.textBox7.Clear();
            f.textBox6.Clear();
            f.textBox5.Clear();
            f.textBox4.Clear();
            f.textBox3.Clear();
            f.textBox2.Clear();
            f.textBox10.Clear();
            f.textBox11.Clear();
            f.textBox12.Clear();
            f.textBox13.Clear();
            f.textBox14.Clear();
            f.textBox15.Clear();
            f.textBox16.Clear();
            f.textBox17.Clear();
            f.textBox18.Clear();
            f.textBox19.Clear();

            f.dataGridView1.Rows.Clear();
            GraphPane pane1 = f.zedGraphControl1.GraphPane;
            pane1.CurveList.Clear();
            f.dataGridView2.Rows.Clear();
            GraphPane pane2 = f.zedGraphControl2.GraphPane;
            pane2.CurveList.Clear();
            f.dataGridView3.Rows.Clear();
            GraphPane pane3 = f.zedGraphControl3.GraphPane;
            pane3.CurveList.Clear();
            f.dataGridView4.Rows.Clear();
            GraphPane pane4 = f.zedGraphControl4.GraphPane;
            pane4.CurveList.Clear();
            f.dataGridView5.Rows.Clear();
            GraphPane pane5 = f.zedGraphControl5.GraphPane;
            pane5.CurveList.Clear();

        }

        public void DrawZGC(DataGridView d, ZedGraphControl z, ArrayList data1, ArrayList data2, double MaxX,
                            double MaxY, string G, string x, string y)
        {
            d.Rows.Clear();
            GraphPane pane = z.GraphPane; // Получим панель для рисования
            pane.CurveList.Clear(); // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.Title.Text = G; // Название панели и осей
            pane.XAxis.Title.Text = x;
            pane.YAxis.Title.Text = y;

            PointPairList list1 = new PointPairList(); // Создадим список точек
            for (int i = 0; i < data1.Count; i++)
            {
                d.Rows.Add(); //добавляем строку в таблицу
                d[0, i].Value = ((double[]) data1[i])[0];
                d[1, i].Value = ((double[]) data1[i])[1];
                list1.Add(((double[]) data1[i])[0], ((double[]) data1[i])[1]);
            }
            LineItem myCurve1 = pane.AddCurve("Practical", list1, Color.Red, SymbolType.None);
            myCurve1.Line.Width = 2.0F; // Толщина графиков
            if (data2 != null)
            {
                PointPairList list2 = new PointPairList(); // Создадим список точек
                for (int i = 0; i < data2.Count; i++)
                {
                    if (i >= data1.Count)
                    {
                        d.Rows.Add(); //добавляем строку в таблицу
                    }
                    d[0, i].Value = ((double[]) data2[i])[0];
                    d[2, i].Value = ((double[]) data2[i])[1];
                    list2.Add(((double[]) data2[i])[0], ((double[]) data2[i])[1]);
                }
                LineItem myCurve2 = pane.AddCurve("Theoretical", list2, Color.Blue, SymbolType.None);
                myCurve2.Line.Width = 2.0F; // Толщина графиков
            }


            pane.YAxis.Scale.Min = 0;
            pane.XAxis.Scale.Min = -0.02*MaxX;
            pane.YAxis.Scale.Max = (MaxY*1.05);
            pane.XAxis.Scale.Max = (MaxX*1.02);

            pane.XAxis.MajorGrid.IsVisible = true; // Включаем отображение сетки напротив крупных рисок по оси X
            // Задаем вид пунктирной линии для крупных рисок по оси X:
            // Длина штрихов равна 10 пикселям, ... 
            pane.XAxis.MajorGrid.DashOn = 10;
            // затем 5 пикселей - пропуск
            pane.XAxis.MajorGrid.DashOff = 5;
            // Включаем отображение сетки напротив крупных рисок по оси Y
            pane.YAxis.MajorGrid.IsVisible = true;
            // Аналогично задаем вид пунктирной линии для крупных рисок по оси Y
            pane.YAxis.MajorGrid.DashOn = 10;
            pane.YAxis.MajorGrid.DashOff = 5;



            PointF pc = new PointF((float) 2.5, (float) 2.5);
            z.ZoomPane(pane, 1, pc, false);
            z.Refresh();
        }

        public void DrawGraphs(Form1 f, DisplayData dd, int number)
        {
            switch (number)
            {
                case 1:
                    DrawZGC(f.dataGridView1, f.zedGraphControl1, dd.Id_N, null, dd.Id_N.Count, dd.GreatOccur,
                            "Graph nj(Id)", "Id", "nj");
                    break;
                case 2:
                    DrawZGC(f.dataGridView2, f.zedGraphControl2, dd.Rank_FreqP, dd.Rank_FreqT,
                            Math.Max(dd.Rank_FreqP.Count, dd.Rank_FreqT.Count), dd.GreatFrequency, "Graph Freq(Rank)",
                            "Rank", "Freq");
                    break;
                case 3:
                    DrawZGC(f.dataGridView3, f.zedGraphControl3, dd.LogRank_LogNP, dd.LogRank_LogNT,
                            Math.Log(Math.Max(dd.LogRank_LogNP.Count, dd.LogRank_LogNT.Count), 2),
                            Math.Log(dd.GreatOccur, 2), "Graph Log(nj)(Log(Rank))", "Log(Rank)", "Log(nj)");
                    break;
                case 4:
                    DrawZGC(f.dataGridView4, f.zedGraphControl4, dd.LogRank_LogGamut, null,
                            Math.Log(dd.LogRank_LogGamut.Count, 2), dd.GreatLogGamut, "Graph Log(Gr)(Log(Rank))",
                            "Log(Rank)", "Log(Gr)");
                    break;
                case 5:
                    DrawZGC(f.dataGridView5, f.zedGraphControl5, dd.Rank_Remoteness, null, dd.Rank_Remoteness.Count,
                            dd.GreatRemoteness, "Graph gr(Rank)", "Rank", "gr");
                    break;
            }


        }

        public void Draw(Form1 f, DisplayData dd)
        {
            this.Clean(f);

            f.textBox9.Text = Convert.ToString(dd.GreatFrequency);
            f.textBox8.Text = Convert.ToString(dd.len);
            f.textBox7.Text = Convert.ToString(dd.DiffRFreq.D);
            f.textBox6.Text = Convert.ToString(dd.DiffRFreq.SqHi);
            f.textBox5.Text = Convert.ToString(dd.DiffRFreq.OnonP);
            f.textBox4.Text = Convert.ToString(dd.DiffRFreq.NonP);
            f.textBox3.Text = Convert.ToString(dd.TLCapacity);
            f.textBox2.Text = Convert.ToString(dd.PLCapacity);
            f.textBox10.Text = Convert.ToString(dd.DiffV.PdV);
            f.textBox11.Text = Convert.ToString(dd.DiffV.DV);
            f.textBox12.Text = Convert.ToString(dd.IInfo);
            f.textBox13.Text = Convert.ToString(dd.Entropy);
            f.textBox14.Text = Convert.ToString(dd.AvgDepth);
            f.textBox15.Text = Convert.ToString(dd.AvgRemoteness);
            f.textBox16.Text = Convert.ToString(dd.Periodicity);
            f.textBox17.Text = Convert.ToString(dd.Regularity);
            f.textBox18.Text = Convert.ToString(dd.OIInfo);
            f.textBox19.Text = Convert.ToString(dd.LEntropy);

            DrawGraphs(f, dd, 1);
            DrawGraphs(f, dd, 2);
            DrawGraphs(f, dd, 3);
            DrawGraphs(f, dd, 4);
            DrawGraphs(f, dd, 5);

        }


    }
}

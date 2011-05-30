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

                DirectoryInfo dir = new DirectoryInfo(folderBrowserDialog1.SelectedPath);
                //DirectoryInfo dir = new DirectoryInfo("D:\\Учеба\\НИРС\\_xml");
                foreach (var item in dir.GetFiles())
                {
                    if (item.Name.EndsWith(".xml"))
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

                        foreach (FmotivChain fmchain in Listfmotivchains) 
                        {
                            Console.WriteLine("Fmotiv Chain № " + fmchain.Id.ToString() + " Name = " + fmchain.Name);
                            Console.WriteLine();
                            Console.WriteLine("------------------------");
                            foreach (Fmotiv fmotiv in fmchain.FmotivList) 
                            {
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
                        }
                    }
                }
            }
        }
    }
}

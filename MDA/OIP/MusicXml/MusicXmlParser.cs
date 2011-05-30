using System;
using System.Xml;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Text;
using MDA.OIP.ScoreModel;

namespace MDA.OIP.MusicXml
{
    public class MusicXmlParser
    {
        private ScoreTrack scoremodel; // модель в которую разбирается XML документ


        public MusicXmlParser()
        {

        }
        public ScoreTrack ScoreModel
        {
            get
            {
                return scoremodel;
            }
        }
        public void Execute(XmlDocument xmldocument, string filename)
        {
            // TODO: проверка схемы Xml на соотвествие схеме MusicXml
            if (ChordFound((XmlDocument)xmldocument.Clone())) // если в документе найден хоть один аккорд, то сообщение об ошибке
            {
                throw new Exception("MDA.PARSER: Chord Detected!");
            }
            // создаем объект модели музыкального текста из Xml документа
            scoremodel = new ScoreTrack(filename, parseUniformScoreTracks((XmlDocument)xmldocument.Clone()));
        }

        private bool ChordFound(XmlDocument xmldocument) 
        {
            //Проверка на наличие аккорда в Xml документе
            XmlNodeList chordlist = xmldocument.GetElementsByTagName("chord"); // Ищем две одновременно звучащие ноты (аккорд) на одной моно дорожке
            if (chordlist.Count > 0)
            {
                return true;   
            }
            return false;
        }

        private List<UniformScoreTrack> parseUniformScoreTracks(XmlDocument scoreNode)
        {
            List<UniformScoreTrack> Temp = new List<UniformScoreTrack>();

            XmlNodeList uniformlist = scoreNode.GetElementsByTagName("part"); // Создаем и заполняем лист по тегу "part"  
            for (int i = 0; i < uniformlist.Count; i++)
            {
                //TODO: вероятно нужна проверка на то есть ли такой атрибут - имя моно трека, если нет то задать счетчиком i
                Temp.Add(new UniformScoreTrack(uniformlist[i].Attributes["id"].Value, parseMeasures((XmlNode)uniformlist[i].Clone())));
            }
            return Temp;
        }

        private List<Measure> parseMeasures(XmlNode uniformScoreNode)
        {
            XmlNodeList mesaurelist = uniformScoreNode.ChildNodes;
            List<Measure> Temp = new List<Measure>();
            for (int i = 0; i < mesaurelist.Count; i++) 
            {
                Temp.Add(new Measure(parseNotes((XmlNode)mesaurelist[i].Clone()), parseAttributes((XmlNode)mesaurelist[i].Clone())));
            }
            return Temp;
        }

        private Attributes parseAttributes(XmlNode measureNode)
        {
            foreach (XmlNode measureChild in measureNode.ChildNodes)
            {
                if (measureChild.Name == "attributes")
                {
                    Attributes Temp = new Attributes(parseSize((XmlNode)measureChild.Clone()), parseKey((XmlNode)measureChild.Clone()));
                    return Temp;
                }
                break;
            }
            return null;
            #region old method
            /*foreach (XmlNode measureChild in MeasureNode.ChildNodes)
            {
                if (measureChild.Name == "attributes")
                {
                    Size size = null;
                    Key key = null;
                    int ticks = 0;
                    bool needticks = false;

                    foreach (XmlNode attributeChild in measureChild.ChildNodes)
                    {
                        //----TICKS---------
                        if (attributeChild.Name == "divisions") 
                        {
                            ticks = Convert.ToInt16(attributeChild.InnerText);
                            needticks = true;
                        }
                        //----KEY---------
                        if (attributeChild.Name == "key")
                        {
                            int fifths=0;
                            string mode="";
                            bool needmode = false;
                            
                            foreach (XmlNode keyChild in attributeChild) 
                            {
                                if (keyChild.Name == "fifths")
                                {
                                    fifths = Convert.ToInt16(keyChild.InnerText);
                                }
                                if (keyChild.Name == "mode")
                                {
                                    mode = keyChild.InnerText;
                                    needmode = true;
                                }
                            }
                            if (needmode)
                            {
                                key = new Key(fifths, mode);
                            }
                            else 
                            {
                                key = new Key(fifths);
                            }
                        }
                        //----SIZE---------
                        if (attributeChild.Name == "time")
                        {
                            int beats = 0;
                            int beatbase = 0;

                            foreach (XmlNode timeChild in attributeChild)
                            {
                                if (timeChild.Name == "beats")
                                {
                                    beats = Convert.ToInt16(timeChild.InnerText);
                                }
                                if (timeChild.Name == "beat-type")
                                {
                                    beatbase = Convert.ToInt16(timeChild.InnerText);
                                }
                            }
                            if (needticks)
                            {
                                size = new Size(beats, beatbase, ticks);
                            }
                            else
                            {
                                size = new Size(beats, beatbase);
                            }
                            
                        }
                    }
            
                    Attributes Temp = new Attributes((Size)size.Clone(),(Key)key.Clone());
                    return Temp;
                    //Order order = new Order(nodeOrder.Attributes["Адрес"].Value, DateTime.Parse(nodeOrder.Attributes["Дата"].Value));
                }
                break;
            }
            return null;*/
            #endregion
        }
        private Size parseSize(XmlNode attributeNode)
        {
            int ticks = 0;
            bool needticks = false;
            foreach (XmlNode attributeChild in attributeNode.ChildNodes) 
            {
                //-----TICKS----------------
                if (attributeChild.Name == "divisions")
                {
                    ticks = Convert.ToInt16(attributeChild.InnerText);
                    needticks = true;
                }
                //----SIZE---------
                if (attributeChild.Name == "time")
                {
                    int beats = 0;
                    int beatbase = 0;

                    foreach (XmlNode timeChild in attributeChild)
                    {
                        if (timeChild.Name == "beats")
                        {
                            beats = Convert.ToInt16(timeChild.InnerText);
                        }
                        if (timeChild.Name == "beat-type")
                        {
                            beatbase = Convert.ToInt16(timeChild.InnerText);
                        }
                    }
                    if (needticks)
                    {
                        return new Size(beats, beatbase, ticks);
                    }
                    else
                    {
                        return new Size(beats, beatbase);
                    }

                }
            }
            return null;
        }
        private Key parseKey(XmlNode attributeNode)
        {
            foreach (XmlNode attributeChild in attributeNode.ChildNodes)
            {
                //----KEY---------
                if (attributeChild.Name == "key")
                {
                    int fifths = 0;
                    string mode = "";
                    bool needmode = false;

                    foreach (XmlNode keyChild in attributeChild)
                    {
                        if (keyChild.Name == "fifths")
                        {
                            fifths = Convert.ToInt16(keyChild.InnerText);
                        }
                        if (keyChild.Name == "mode")
                        {
                            mode = keyChild.InnerText;
                            needmode = true;
                        }
                    }
                    if (needmode)
                    {
                        return new Key(fifths, mode);
                    }
                    else
                    {
                        return new Key(fifths);
                    }
                }
            }
                return null;
        }

        private List<Note> parseNotes(XmlNode measureNode)
        {       
            List<Note> Temp = new List<Note>();
            bool hasNotes = false;
            foreach (XmlNode measureChild in measureNode.ChildNodes)
            {
                if (measureChild.Name == "note")
                {
                    Temp.Add(new Note(parsePitch((XmlNode)measureChild.Clone()),parseDuration((XmlNode)measureChild.Clone()),parseTriplet((XmlNode)measureChild.Clone()),parseTie((XmlNode)measureChild.Clone())));   
                    hasNotes = true;
                }
            }
            if (hasNotes) return Temp;
            else return null;
        }

        private Pitch parsePitch(XmlNode noteNode)
        {
            foreach (XmlNode noteChild in noteNode.ChildNodes) 
            {
                if (noteChild.Name == "pitch") 
                {
                    char step = '0';
                    int alter = 0;
                    int octave = 0;
                    bool hasStep = false;
                    bool hasOctave = false;
                    foreach(XmlNode pitchChild in noteChild.ChildNodes)
                    {
                        if (pitchChild.Name == "step") 
                        {
                            step = Convert.ToChar(pitchChild.InnerText);
                            hasStep = true;
                        }
                        if (pitchChild.Name == "alter")
                        {
                            alter = Convert.ToInt16(pitchChild.InnerText);
                        }
                        if (pitchChild.Name == "octave")
                        {
                            octave = Convert.ToInt16(pitchChild.InnerText);
                            hasOctave = true;
                        }
                    }
                    if (hasOctave && hasStep) 
                    {
                        return new Pitch(octave, step, alter);
                    }

                    throw new Exception("MDA.XmlParser: error while Note parsing: pitch structure");
                }
                if (noteChild.Name == "rest") 
                {
                    return null;
                }
            }
            throw new Exception("MDA.XmlParser: error while Note parsing: no pitch or rest");
        }

        private int parseTie(XmlNode noteNode)
        {
            bool start = false; // флаг наличия начала лиги
            bool stop = false; // флаг наличия конца лиги
            foreach (XmlNode noteChild in noteNode.ChildNodes)
            {
                if (noteChild.Name == "tie")
                {
                    if (noteChild.Attributes["type"].Value == "start")
                    {
                        start = true;
                    }
                    else
                    {
                        if (noteChild.Attributes["type"].Value == "stop")
                        {
                            stop = true;
                        }
                        else 
                        {
                            throw new Exception("MDA.XmlParser: error while Note parsing: Tie type unknow");
                        }
                    }
                }
            }
                if (start && stop) 
                {
                    // случай когда лига приходит в эту ноту, и с этой же ноты начинается следущая лига
                    return Tie.StartStop;
                }
                if (start)
                {
                    // случай когда лига начинается с этой ноты
                    return Tie.Start;
                }
                if (stop)
                {
                    // случай когда лига заканчивается на этой ноте
                    return Tie.Stop;
                }

                // когда нету лиги
                return Tie.None;
        }

        private bool parseTriplet(XmlNode noteNode)
        {
            foreach (XmlNode noteChild in noteNode.ChildNodes)
            {
                if (noteChild.Name == "time-modification")
                {
                    return true;
                }
            }
            return false;
        }

        private Duration parseDuration(XmlNode noteNode)
        {
            string type = "";
            int duration = 0;
            bool dot = false;
            bool hasTimeModification = false;
            int actualNotes = 0;
            int normalNotes = 0;

            foreach (XmlNode noteChild in noteNode.ChildNodes)
            {
                if (noteChild.Name == "duration")
                {
                    duration = Convert.ToInt16(noteChild.InnerText);
                }
                if (noteChild.Name == "type")
                {
                    type = noteChild.InnerText;
                }
                if (noteChild.Name == "time-modification")
                {
                    hasTimeModification = true;
                    foreach (XmlNode timeModification in noteChild) 
                    {
                        if (timeModification.Name == "actual-notes") 
                        {
                            actualNotes = Convert.ToInt16(timeModification.InnerText);
                        }
                        if (timeModification.Name == "normal-notes")
                        {
                            normalNotes = Convert.ToInt16(timeModification.InnerText);
                        }
                    }
                }
                if (noteChild.Name == "dot")
                {
                    dot = true;
                }

            }

            if (hasTimeModification)
            {
                return new Duration(DurationType.ParseType(type)[0], DurationType.ParseType(type)[1],normalNotes,actualNotes,dot,duration);
            }
            else 
            {
                return new Duration(DurationType.ParseType(type)[0], DurationType.ParseType(type)[1], dot, duration);
            }
            
        }


    }
}

using System;
using System.Xml;
using System.Collections.Generic;
using LibiadaMusic.ScoreModel;

namespace LibiadaMusic.MusicXml
{
    public class MusicXmlParser
    {
        private Attributes CurrentAttributes;
        private ScoreTrack scoremodel; // модель в которую разбирается XML документ

        public ScoreTrack ScoreModel
        {
            get { return scoremodel; }
        }

        public void Execute(XmlDocument xmldocument, string filename)
        {
            // TODO: проверка схемы Xml на соотвествие схеме MusicXml
            /*
            if (ChordFound((XmlDocument)xmldocument.Clone())) // если в документе найден хоть один аккорд, то сообщение об ошибке
            {
                throw new Exception("LibiadaMusic.PARSER: Chord Detected!");
            } // это уже неактуально */
            // создаем объект модели музыкального текста из Xml документа
            scoremodel = new ScoreTrack(filename, parseUniformScoreTracks((XmlDocument) xmldocument.Clone()));




            // не в каждом такте проставленны аттрибуты, если не проставлены - значит они остаются такие же как и в предыдущем такте
            // заполнение отсутствующих объектов класса атрибут во всем треке

            /*
            #region заполнение аттрибутов

            foreach (UniformScoreTrack utrack in scoremodel.UniformScoreTracks) 
            {
                if (utrack.Measurelist[0].Attributes == null) 
                {
                    throw new Exception("LibiadaMusic PARSER: в модели для 1 такта нет аттрибутов");
                }
                for (int i = 1; i < utrack.Measurelist.Count; i++) 
                {
                    if (utrack.Measurelist[i].Attributes == null) 
                    {
                        // копируем аттрибуты предыдущего такта
                        utrack.Measurelist[i].Attributes = (Attributes)utrack.Measurelist[i - 1].Attributes.Clone();
                    }
                }
            }

#endregion
            */

        }

        private List<UniformScoreTrack> parseUniformScoreTracks(XmlDocument scoreNode)
        {
            List<UniformScoreTrack> Temp = new List<UniformScoreTrack>();

            XmlNodeList uniformlist = scoreNode.GetElementsByTagName("part");
                // Создаем и заполняем лист по тегу "part"  

            for (int i = 0; i < uniformlist.Count; i++)
            {
                //TODO: вероятно нужна проверка на то есть ли такой атрибут - имя моно трека, если нет то задать счетчиком i
                Temp.Add(new UniformScoreTrack(uniformlist[i].Attributes["id"].Value,
                    parseMeasures((XmlNode) uniformlist[i].Clone())));
            }

            return Temp;
        }

        private List<Measure> parseMeasures(XmlNode uniformScoreNode)
        {
            XmlNodeList mesaurelist = uniformScoreNode.ChildNodes;
            List<Measure> Temp = new List<Measure>();
            for (int i = 0; i < mesaurelist.Count; i++)
            {
                Temp.Add(new Measure(parseNotes((XmlNode) mesaurelist[i].Clone()),
                    parseAttributes((XmlNode) mesaurelist[i].Clone())));
            }
            return Temp;
        }

        private Attributes parseAttributes(XmlNode measureNode)
        {
            foreach (XmlNode measureChild in measureNode.ChildNodes)
            {
                if (measureChild.Name == "attributes")
                {
                    //Attributes Temp = new Attributes(parseSize((XmlNode)measureChild.Clone()), parseKey((XmlNode)measureChild.Clone()));

                    Size size = parseSize((XmlNode) measureChild.Clone());
                    ;
                    Key key = parseKey((XmlNode) measureChild.Clone());
                    ;

                    if (key == null)
                    {
                        key = (Key) CurrentAttributes.Key.Clone();
                    }
                    if (size == null)
                    {
                        size = (Size) CurrentAttributes.Size.Clone();
                    }

                    CurrentAttributes = new Attributes(size, key);
                    return CurrentAttributes;
                }
            }
            return CurrentAttributes;

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
                        return new Size(beats, beatbase, CurrentAttributes.Size.Ticksperbeat);
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
            Note TempNote;
            bool hasNotes = false;
            foreach (XmlNode measureChild in measureNode.ChildNodes)
            {
                if (measureChild.Name == "note")
                {
                    foreach (XmlNode chordchild in ((XmlNode) measureChild.Clone()).ChildNodes)
                    {
                        if (chordchild.Name == "chord")
                            //если найден "аккорд", то добавим текущую ноту к предыдущей уже мультиноте
                        {

                            Temp[Temp.Count - 1].AddPitch(parsePitch((XmlNode) measureChild.Clone()));
                            if (Temp[Temp.Count - 1].Tie != parseTie((XmlNode)measureChild.Clone()))
                                Temp[Temp.Count - 1].SetTie(Tie.None);

                            break;
                        }
                        else //если нота - не аккорд, то значит добавим её как обычную ноту
                        {
                            Temp.Add(new Note(parsePitch((XmlNode) measureChild.Clone()),
                                parseDuration((XmlNode) measureChild.Clone()),
                                parseTriplet((XmlNode) measureChild.Clone()), (Tie)parseTie((XmlNode) measureChild.Clone())));
                            hasNotes = true;
                            break;
                        }
                    }
                }
            }
            if (hasNotes) return Temp;
            else return null;
        }

        private Pitch parsePitch(XmlNode noteNode)
        {
            string childname = "";
            foreach (XmlNode noteChild in noteNode.ChildNodes)
            {
                childname = noteChild.Name;
                if (noteChild.Name == "pitch")
                {
                    char step = '0';
                    int alter = 0;
                    int octave = 0;
                    bool hasStep = false;
                    bool hasOctave = false;
                    foreach (XmlNode pitchChild in noteChild.ChildNodes)
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

                    throw new Exception("LibiadaMusic.XmlParser: error while Note parsing: pitch structure");
                }
                if (noteChild.Name == "rest")
                {
                    return null;
                }
                if (noteChild.Name == "notations")
                {
                    return null;
                }
            }
            throw new Exception("LibiadaMusic.XmlParser: error while Note parsing: no pitch or rest: " + childname);
        }

        private Tie parseTie(XmlNode noteNode)
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
                            throw new Exception("LibiadaMusic.XmlParser: error while Note parsing: Tie type unknow");
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
                return new Duration(DurationType.ParseType(type)[0], DurationType.ParseType(type)[1], normalNotes,
                    actualNotes, dot, duration);
            }
            else
            {
                return new Duration(DurationType.ParseType(type)[0], DurationType.ParseType(type)[1], dot, duration);
            }
        }
    }
}

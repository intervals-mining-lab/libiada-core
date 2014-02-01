using System;
using System.Xml;
using System.Collections.Generic;
using LibiadaMusic.ScoreModel;

namespace LibiadaMusic.MusicXml
{
    public class MusicXmlParser
    {
        private Attributes currentAttributes;
        private ScoreTrack scoreModel; // модель в которую разбирается XML документ

        public ScoreTrack ScoreModel
        {
            get { return scoreModel; }
        }

        public void Execute(XmlDocument xmlDocument, string filename)
        {
            // TODO: проверка схемы Xml на соотвествие схеме MusicXml
            // создаем объект модели музыкального текста из Xml документа
            scoreModel = new ScoreTrack(filename, ParseUniformScoreTracks((XmlDocument) xmlDocument.Clone()));
        }

        private List<UniformScoreTrack> ParseUniformScoreTracks(XmlDocument scoreNode)
        {
            var temp = new List<UniformScoreTrack>();

            XmlNodeList uniformList = scoreNode.GetElementsByTagName("part");
            // Создаем и заполняем лист по тегу "part"  

            for (int i = 0; i < uniformList.Count; i++)
            {
                //TODO: вероятно нужна проверка на то есть ли такой атрибут - имя моно трека, если нет то задать счетчиком i
                temp.Add(new UniformScoreTrack(uniformList[i].Attributes["id"].Value,
                    ParseMeasures(uniformList[i].Clone())));
            }

            return temp;
        }

        private List<Measure> ParseMeasures(XmlNode uniformScoreNode)
        {
            XmlNodeList measureList = uniformScoreNode.ChildNodes;
            var Temp = new List<Measure>();
            for (int i = 0; i < measureList.Count; i++)
            {
                Temp.Add(new Measure(ParseNotes(measureList[i].Clone()),
                    ParseAttributes(measureList[i].Clone())));
            }
            return Temp;
        }

        private Attributes ParseAttributes(XmlNode measureNode)
        {
            foreach (XmlNode measureChild in measureNode.ChildNodes)
            {
                if (measureChild.Name == "attributes")
                {
                    //Attributes Temp = new Attributes(parseSize((XmlNode)measureChild.Clone()), parseKey((XmlNode)measureChild.Clone()));

                    Size size = ParseSize(measureChild.Clone());
                    ;
                    Key key = parseKey(measureChild.Clone());
                    ;

                    if (key == null)
                    {
                        key = (Key) currentAttributes.Key.Clone();
                    }
                    if (size == null)
                    {
                        size = (Size) currentAttributes.Size.Clone();
                    }

                    currentAttributes = new Attributes(size, key);
                    return currentAttributes;
                }
            }
            return currentAttributes;
        }

        private Size ParseSize(XmlNode attributeNode)
        {
            int ticks = 0;
            bool needTicks = false;
            foreach (XmlNode attributeChild in attributeNode.ChildNodes)
            {
                //-----TICKS----------------
                if (attributeChild.Name == "divisions")
                {
                    ticks = Convert.ToInt16(attributeChild.InnerText);
                    needTicks = true;
                }
                //----SIZE---------
                if (attributeChild.Name == "time")
                {
                    int beats = 0;
                    int beatBase = 0;

                    foreach (XmlNode timeChild in attributeChild)
                    {
                        if (timeChild.Name == "beats")
                        {
                            beats = Convert.ToInt16(timeChild.InnerText);
                        }
                        if (timeChild.Name == "beat-type")
                        {
                            beatBase = Convert.ToInt16(timeChild.InnerText);
                        }
                    }
                    if (needTicks)
                    {
                        return new Size(beats, beatBase, ticks);
                    }
                    return new Size(beats, beatBase, currentAttributes.Size.TicksPerBeat);
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
                    bool needMode = false;

                    foreach (XmlNode keyChild in attributeChild)
                    {
                        if (keyChild.Name == "fifths")
                        {
                            fifths = Convert.ToInt16(keyChild.InnerText);
                        }
                        if (keyChild.Name == "mode")
                        {
                            mode = keyChild.InnerText;
                            needMode = true;
                        }
                    }
                    if (needMode)
                    {
                        return new Key(fifths, mode);
                    }
                    return new Key(fifths);
                }
            }
            return null;
        }

        private List<Note> ParseNotes(XmlNode measureNode)
        {
            var temp = new List<Note>();
            bool hasNotes = false;
            foreach (XmlNode measureChild in measureNode.ChildNodes)
            {
                if (measureChild.Name == "note")
                {
                    foreach (XmlNode chordChild in measureChild.Clone().ChildNodes)
                    {
                        if (chordChild.Name == "chord")
                            //если найден "аккорд", то добавим текущую ноту к предыдущей уже мультиноте
                        {
                            temp[temp.Count - 1].AddPitch(parsePitch(measureChild.Clone()));
                            if (temp[temp.Count - 1].Tie != parseTie(measureChild.Clone()))
                                temp[temp.Count - 1].Tie = Tie.None;

                            break;
                        }
                        temp.Add(new Note(parsePitch(measureChild.Clone()),
                            parseDuration(measureChild.Clone()),
                            parseTriplet(measureChild.Clone()), parseTie(measureChild.Clone())));
                        hasNotes = true;
                        break;
                    }
                }
            }
            if (hasNotes) return temp;
            return null;
        }

        private Pitch parsePitch(XmlNode noteNode)
        {
            string childName = String.Empty;
            foreach (XmlNode noteChild in noteNode.ChildNodes)
            {
                childName = noteChild.Name;
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
            throw new Exception("LibiadaMusic.XmlParser: error while Note parsing: no pitch or rest: " + childName);
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
            return new Duration(DurationType.ParseType(type)[0], DurationType.ParseType(type)[1], dot, duration);
        }
    }
}
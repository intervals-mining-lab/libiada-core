using System;
using System.Xml;
using System.Collections.Generic;
using LibiadaMusic.ScoreModel;

namespace LibiadaMusic.MusicXml
{
    public class MusicXmlParser
    {
        private Attributes currentAttributes;

        /// <summary>
        /// модель в которую разбирается XML документ
        /// </summary>
        public ScoreTrack ScoreModel { get; private set; }

        public void Execute(XmlDocument xmlDocument, string filename)
        {
            // TODO: проверка схемы Xml на соотвествие схеме MusicXml
            // создаем объект модели музыкального текста из Xml документа
            ScoreModel = new ScoreTrack(filename, ParseCongenericScoreTracks((XmlDocument) xmlDocument.Clone()));
        }

        private List<CongenericScoreTrack> ParseCongenericScoreTracks(XmlDocument scoreNode)
        {
            var temp = new List<CongenericScoreTrack>();

            XmlNodeList congenericList = scoreNode.GetElementsByTagName("part");
            // Создаем и заполняем лист по тегу "part"  

            for (int i = 0; i < congenericList.Count; i++)
            {
                //TODO: вероятно нужна проверка на то есть ли такой атрибут - имя моно трека, если нет то задать счетчиком i
                temp.Add(new CongenericScoreTrack(congenericList[i].Attributes["id"].Value,
                    ParseMeasures(congenericList[i].Clone())));
            }
            return temp;
        }

        private List<Measure> ParseMeasures(XmlNode congenericScoreNode)
        {
            XmlNodeList measureList = congenericScoreNode.ChildNodes;
            var measures = new List<Measure>();
            for (int i = 0; i < measureList.Count; i++)
            {
                measures.Add(new Measure(ParseNotes(measureList[i].Clone()), ParseAttributes(measureList[i].Clone())));
            }
            return measures;
        }

        private Attributes ParseAttributes(XmlNode measureNode)
        {
            foreach (XmlNode measureChild in measureNode.ChildNodes)
            {
                if (measureChild.Name == "attributes")
                {
                    Key key = parseKey(measureChild.Clone()) ?? (Key) currentAttributes.Key.Clone();

                    Size size = ParseSize(measureChild.Clone()) ?? (Size) currentAttributes.Size.Clone();

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
                switch (attributeChild.Name)
                {
                    case "divisions":
                        ticks = Convert.ToInt16(attributeChild.InnerText);
                        needTicks = true;
                        break;
                    case "time":
                    {
                        int beats = 0;
                        int beatBase = 0;

                        foreach (XmlNode timeChild in attributeChild)
                        {
                            switch (timeChild.Name)
                            {
                                case "beats":
                                    beats = Convert.ToInt16(timeChild.InnerText);
                                    break;
                                case "beat-type":
                                    beatBase = Convert.ToInt16(timeChild.InnerText);
                                    break;
                            }
                        }
                        if (needTicks)
                        {
                            return new Size(beats, beatBase, ticks);
                        }
                        return new Size(beats, beatBase, currentAttributes.Size.TicksPerBeat);
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
                    string mode = String.Empty;
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

        private List<ValueNote> ParseNotes(XmlNode measureNode)
        {
            var notes = new List<ValueNote>();
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
                            notes[notes.Count - 1].AddPitch(parsePitch(measureChild.Clone()));
                            if (notes[notes.Count - 1].Tie != parseTie(measureChild.Clone()))
                                notes[notes.Count - 1].Tie = Tie.None;

                            break;
                        }
                        notes.Add(new ValueNote(parsePitch(measureChild.Clone()),
                            parseDuration(measureChild.Clone()),
                            parseTriplet(measureChild.Clone()), parseTie(measureChild.Clone())));
                        hasNotes = true;
                        break;
                    }
                }
            }
            if (hasNotes)
            {
                return notes;
            }
            else
            {
                return null;
            }
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
                        switch (pitchChild.Name)
                        {
                            case "step":
                                step = Convert.ToChar(pitchChild.InnerText);
                                hasStep = true;
                                break;
                            case "alter":
                                alter = Convert.ToInt16(pitchChild.InnerText);
                                break;
                            case "octave":
                                octave = Convert.ToInt16(pitchChild.InnerText);
                                hasOctave = true;
                                break;
                        }
                    }
                    if (hasOctave && hasStep)
                    {
                        return new Pitch(octave, step, alter);
                    }

                    throw new Exception("LibiadaMusic.XmlParser: error while Note parsing: pitch structure");
                }
                if (noteChild.Name == "rest" || noteChild.Name == "notations")
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
                    switch (noteChild.Attributes["type"].Value)
                    {
                        case "start":
                            start = true;
                            break;
                        case "stop":
                            stop = true;
                            break;
                        default:
                            throw new Exception("LibiadaMusic.XmlParser: error while Note parsing: Tie type unknown");
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
            string type = String.Empty;
            int duration = 0;
            bool dot = false;
            bool hasTimeModification = false;
            int actualNotes = 0;
            int normalNotes = 0;

            foreach (XmlNode noteChild in noteNode.ChildNodes)
            {
                switch (noteChild.Name)
                {
                    case "duration":
                        duration = Convert.ToInt16(noteChild.InnerText);
                        break;
                    case "type":
                        type = noteChild.InnerText;
                        break;
                    case "time-modification":
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
                        break;
                    case "dot":
                        dot = true;
                        break;
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
﻿namespace LibiadaMusic.MusicXml
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    using LibiadaMusic.ScoreModel;

    /// <summary>
    /// The music xml parser.
    /// </summary>
    public class MusicXmlParser
    {
        /// <summary>
        /// The current attributes.
        /// </summary>
        private Attributes currentAttributes;

        /// <summary>
        /// Gets score model.
        /// модель в которую разбирается XML документ
        /// </summary>
        public ScoreTrack ScoreModel { get; private set; }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="xmlDocument">
        /// The xml document.
        /// </param>
        /// <param name="filename">
        /// The filename.
        /// </param>
        public void Execute(XmlDocument xmlDocument, string filename)
        {
            // TODO: проверка схемы Xml на соотвествие схеме MusicXml
            // создаем объект модели музыкального текста из Xml документа
            ScoreModel = new ScoreTrack(filename, ParseCongenericScoreTracks((XmlDocument)xmlDocument.Clone()));
        }

        /// <summary>
        /// The parse congeneric score tracks.
        /// </summary>
        /// <param name="scoreNode">
        /// The score node.
        /// </param>
        /// <returns>
        /// The <see cref="List{CongenericScoreTrack}"/>.
        /// </returns>
        private List<CongenericScoreTrack> ParseCongenericScoreTracks(XmlDocument scoreNode)
        {
            var temp = new List<CongenericScoreTrack>();

            XmlNodeList congenericList = scoreNode.GetElementsByTagName("part");

            // Создаем и заполняем лист по тегу "part"
            for (int i = 0; i < congenericList.Count; i++)
            {
                // TODO: вероятно нужна проверка на то есть ли такой атрибут - имя моно трека, если нет то задать счетчиком i
                temp.Add(new CongenericScoreTrack(congenericList[i].Attributes["id"].Value, ParseMeasures(congenericList[i].Clone())));
            }

            return temp;
        }

        /// <summary>
        /// The parse measures.
        /// </summary>
        /// <param name="congenericScoreNode">
        /// The congeneric score node.
        /// </param>
        /// <returns>
        /// The <see cref="List{Measure}"/>.
        /// </returns>
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

        /// <summary>
        /// The parse attributes.
        /// </summary>
        /// <param name="measureNode">
        /// The measure node.
        /// </param>
        /// <returns>
        /// The <see cref="Attributes"/>.
        /// </returns>
        private Attributes ParseAttributes(XmlNode measureNode)
        {
            foreach (XmlNode measureChild in measureNode.ChildNodes)
            {
                if (measureChild.Name == "attributes")
                {
                    Key key = ParseKey(measureChild.Clone()) ?? (Key)currentAttributes.Key.Clone();

                    Size size = ParseSize(measureChild.Clone()) ?? (Size)currentAttributes.Size.Clone();

                    currentAttributes = new Attributes(size, key);
                    return currentAttributes;
                }
            }

            return currentAttributes;
        }

        /// <summary>
        /// The parse size.
        /// </summary>
        /// <param name="attributeNode">
        /// The attribute node.
        /// </param>
        /// <returns>
        /// The <see cref="Size"/>.
        /// </returns>
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

        /// <summary>
        /// The parse key.
        /// </summary>
        /// <param name="attributeNode">
        /// The attribute node.
        /// </param>
        /// <returns>
        /// The <see cref="Key"/>.
        /// </returns>
        private Key ParseKey(XmlNode attributeNode)
        {
            foreach (XmlNode attributeChild in attributeNode.ChildNodes)
            {
                //----KEY---------
                if (attributeChild.Name == "key")
                {
                    int fifths = 0;
                    string mode = string.Empty;
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

        /// <summary>
        /// The parse notes.
        /// </summary>
        /// <param name="measureNode">
        /// The measure node.
        /// </param>
        /// <returns>
        /// The <see cref="List{ValueNote}"/>.
        /// </returns>
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
                        {
                            // если найден "аккорд", то добавим текущую ноту к предыдущей уже мультиноте
                            notes[notes.Count - 1].AddPitch(ParsePitch(measureChild.Clone()));
                            if (notes[notes.Count - 1].Tie != ParseTie(measureChild.Clone()))
                            {
                                notes[notes.Count - 1].Tie = Tie.None;
                            }

                            break;
                        }

                        notes.Add(new ValueNote(ParsePitch(measureChild.Clone()), ParseDuration(measureChild.Clone()), ParseTriplet(measureChild.Clone()), ParseTie(measureChild.Clone())));
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

        /// <summary>
        /// The parse pitch.
        /// </summary>
        /// <param name="noteNode">
        /// The note node.
        /// </param>
        /// <returns>
        /// The <see cref="Pitch"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if pitch doesn't have Octave or step.
        /// </exception>
        private Pitch ParsePitch(XmlNode noteNode)
        {
            string childName = string.Empty;
            foreach (XmlNode noteChild in noteNode.ChildNodes)
            {
                childName = noteChild.Name;
                if (noteChild.Name == "pitch")
                {
                    char step = '0';
                    short alter = 0;
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

        /// <summary>
        /// The parse tie.
        /// </summary>
        /// <param name="noteNode">
        /// The note node.
        /// </param>
        /// <returns>
        /// The <see cref="Tie"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if Tie type of note is unknown.
        /// </exception>
        private Tie ParseTie(XmlNode noteNode)
        {
            // флаг наличия начала лиги
            bool start = false;

            // флаг наличия конца лиги
            bool stop = false;
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
                return Tie.Continue;
            }

            if (start)
            {
                // случай когда лига начинается с этой ноты
                return Tie.Start;
            }

            if (stop)
            {
                // случай когда лига заканчивается на этой ноте
                return Tie.End;
            }

            // когда нету лиги
            return Tie.None;
        }

        /// <summary>
        /// The parse triplet.
        /// </summary>
        /// <param name="noteNode">
        /// The note node.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool ParseTriplet(XmlNode noteNode)
        {
            return noteNode.ChildNodes.Cast<XmlNode>().Any(noteChild => noteChild.Name == "time-modification");
        }

        /// <summary>
        /// The parse duration.
        /// </summary>
        /// <param name="noteNode">
        /// The note node.
        /// </param>
        /// <returns>
        /// The <see cref="Duration"/>.
        /// </returns>
        private Duration ParseDuration(XmlNode noteNode)
        {
            string type = string.Empty;
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
                var parsedType = DurationType.ParseType(type);
                return new Duration(parsedType[0], parsedType[1], normalNotes, actualNotes, dot, duration);
            }

            return new Duration(DurationType.ParseType(type)[0], DurationType.ParseType(type)[1], dot, duration);
        }
    }
}

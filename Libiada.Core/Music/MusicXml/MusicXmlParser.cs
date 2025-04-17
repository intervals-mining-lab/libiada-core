namespace Libiada.Core.Music.MusicXml;

using System.Globalization;
using System.Xml;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// The music xml parser.
/// </summary>
public class MusicXmlParser
{
    /// <summary>
    /// The current attributes.
    /// </summary>
    private MeasureAttributes currentAttributes;

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
    public void Execute(XmlDocument xmlDocument)
    {
        // TODO: проверка схемы Xml на соотвествие схеме MusicXml
        // создаем объект модели музыкального текста из Xml документа
        ScoreModel = new ScoreTrack(ParseCongenericScoreTracks((XmlDocument)xmlDocument.Clone()));
    }

    /// <summary>
    /// The parse congeneric score tracks.
    /// </summary>
    /// <param name="scoreNode">
    /// The score node.
    /// </param>
    /// <returns>
    /// The <see cref="List{Libiada.Core.Core.CongenericScoreTrack}"/>.
    /// </returns>
    private List<CongenericScoreTrack> ParseCongenericScoreTracks(XmlDocument scoreNode)
    {
        List<CongenericScoreTrack> temp = [];

        XmlNodeList congenericList = scoreNode.GetElementsByTagName("part");

        // Создаем и заполняем лист по тегу "part"
        for (int i = 0; i < congenericList.Count; i++)
        {
            // TODO: вероятно нужна проверка на то есть ли такой атрибут - имя моно трека, если нет то задать счетчиком i
            string name = congenericList[i].Attributes["id"].Value;
            List<Measure> measures = ParseMeasures(congenericList[i].Clone());
            temp.Add(new CongenericScoreTrack(measures));
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
    /// The <see cref="List{Libiada.Core.Core.SimpleTypes.Measure}"/>.
    /// </returns>
    private List<Measure> ParseMeasures(XmlNode congenericScoreNode)
    {
        XmlNodeList measureList = congenericScoreNode.ChildNodes;
        List<Measure> measures = [];
        bool isOnRepeat = false;
        List<Measure> repeatedMeasures = [];
        for (int i = 0; i < measureList.Count; i++)
        {
            List<ValueNote> notes = ParseNotes(measureList[i].Clone());
            MeasureAttributes attributes = ParseAttributes(measureList[i].Clone());
            XmlNodeList childNodes = measureList[i]?.ChildNodes;
            XmlNode lastNode = childNodes?[^1];
            if ((lastNode?.Name == "barline") /*&& (lastNode.ChildNodes[0].Attributes["direction"].Value == "forward")*/)
            {
                foreach(XmlNode childNode in lastNode.ChildNodes)
                {
                    if (childNode.Name == "repeat")
                    {
                        if (childNode.Attributes["direction"].Value == "forward")
                        {
                            repeatedMeasures = [new Measure(notes, attributes)];
                            isOnRepeat = true;
                        }
                    }
                    else if(childNode.Name == "bar-style")
                    {
                        if(childNode.InnerText == "light-light" || childNode.InnerText == "light-heavy")
                        {
                            measures.Add(new Measure(notes, attributes));
                        }
                    }
                }
                // repeatedMeasures = [new Measure(notes, attributes)];
                // isOnRepeat = true;
            }
            else if (isOnRepeat)
            {
                repeatedMeasures.Add(new Measure(notes, attributes));
                if ((lastNode?.Name == "barline") /*&& (lastNode.ChildNodes[0].Attributes["direction"].Value == "backward")*/)
                {
                    foreach(XmlNode childNode in lastNode.ChildNodes)
                    {
                        if (childNode.Name == "repeat")
                        {
                            if (childNode.Attributes["direction"].Value == "backward")
                            {
                                isOnRepeat = false;
                                ushort repeatCount = Convert.ToUInt16(childNode.Attributes["times"].Value);
                                for (int j = 0; j < repeatCount; j++)
                                {
                                    measures.AddRange(repeatedMeasures);
                                }
                            }
                        }
                    }
                    // isOnRepeat = false;
                    // ushort repeatCount = Convert.ToUInt16(lastNode.ChildNodes[0].Attributes["times"].Value);
                    // for (int j = 0; j < repeatCount; j++)
                    // {
                    //     measures.AddRange(repeatedMeasures);
                    // }
                }
            }
            else
            {
                measures.Add(new Measure(notes, attributes));
            }
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
    /// The <see cref="MeasureAttributes"/>.
    /// </returns>
    private MeasureAttributes ParseAttributes(XmlNode measureNode)
    {
        foreach (XmlNode measureChild in measureNode.ChildNodes)
        {
            if (measureChild.Name == "attributes")
            {
                Key key = ParseKey(measureChild.Clone()) ?? (Key)currentAttributes.Key.Clone();

                Size size = ParseSize(measureChild.Clone()) ?? (Size)currentAttributes.Size.Clone();

                currentAttributes = new MeasureAttributes(size, key);
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
        foreach (XmlNode attributeChild in attributeNode.ChildNodes)
        {
            switch (attributeChild.Name)
            {
                case "divisions":
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

                    return new Size(beats, beatBase);
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
    /// The <see cref="List{Libiada.Core.Core.SimpleTypes.ValueNote}"/>.
    /// </returns>
    private List<ValueNote> ParseNotes(XmlNode measureNode)
    {
        List<ValueNote> notes = [];
        bool hasNotes = false;
        foreach (XmlNode measureChild in measureNode.ChildNodes)
        {
            if (measureChild.Name == "note")
            {
                XmlNode measureChildClone = measureChild.Clone();
                foreach (XmlNode chordChild in measureChildClone.ChildNodes)
                {
                    if (chordChild.Name == "chord")
                    {
                        // если найден "аккорд", то добавим текущую ноту к предыдущей уже мультиноте
                        Pitch? chordPitch = ParsePitch(measureChildClone);
                        if(chordPitch != null) notes[^1].AddPitch(chordPitch);
                        if (notes[^1].Tie != ParseTie(measureChildClone))
                        {
                            notes[^1].Tie = Tie.None;
                        }

                        break;
                    }

                    Pitch? pitch = ParsePitch(measureChildClone);
                    ValueNote note = pitch == null
                        ? new ValueNote(ParseDuration(measureChildClone), ParseTriplet(measureChildClone), ParseTie(measureChildClone))
                        : new ValueNote(pitch, ParseDuration(measureChildClone), ParseTriplet(measureChildClone), ParseTie(measureChildClone));
                    note.Pitches.Sort();
                    notes.Add(note);
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
    private Pitch? ParsePitch(XmlNode noteNode)
    {
        string childName = string.Empty;
        foreach (XmlNode noteChild in noteNode.ChildNodes)
        {
            childName = noteChild.Name;
            if (noteChild.Name == "pitch")
            {
                NoteSymbol step = NoteSymbol.C;
                Accidental alter = Accidental.Bekar;
                byte octave = 0;
                bool hasStep = false;
                bool hasOctave = false;
                foreach (XmlNode pitchChild in noteChild.ChildNodes)
                {
                    switch (pitchChild.Name)
                    {
                        case "step":
                            Enum.TryParse(pitchChild.InnerText, true, out step);
                            hasStep = true;
                            break;
                        case "alter":
                            alter = (Accidental)Convert.ToInt16(pitchChild.InnerText);
                            break;
                        case "octave":
                            octave = Convert.ToByte(pitchChild.InnerText);
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

        throw new Exception($"LibiadaMusic.XmlParser: error while Note parsing: no pitch or rest: {childName}");
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
                string tieType = noteChild.Attributes?["type"].Value;
                switch (tieType)
                {
                    case "start":
                        start = true;
                        break;
                    case "stop":
                        stop = true;
                        break;
                    default:
                        throw new InvalidOperationException($"Unknown tie type {tieType}");
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
        bool dot = false;
        bool hasTimeModification = false;
        int actualNotes = 0;
        int normalNotes = 0;

        foreach (XmlNode noteChild in noteNode.ChildNodes)
        {
            switch (noteChild.Name)
            {
                case "duration":
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

        (int numerator, int denominator) = DurationType.ParseType(type);

        if (hasTimeModification)
        {
            return new Duration(numerator, denominator, normalNotes, actualNotes, dot);
        }

        return new Duration(numerator, denominator, dot);
    }
}

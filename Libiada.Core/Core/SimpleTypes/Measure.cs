﻿namespace Libiada.Core.Core.SimpleTypes;

/// <summary>
/// The measure.
/// </summary>
public class Measure : IBaseObject
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Measure"/> class.
    /// </summary>
    /// <param name="noteList">
    /// The note list.
    /// </param>
    /// <param name="attributes">
    /// The attributes.
    /// </param>
    public Measure(List<ValueNote> noteList, MeasureAttributes attributes)
    {
        if (attributes != null)
        {
            Attributes = (MeasureAttributes)attributes.Clone();
        }

        NoteList = new List<ValueNote>(noteList.Count);

        foreach (ValueNote note in noteList)
        {
            NoteList.Add((ValueNote)note.Clone());
        }
    }

    /// <summary>
    /// Gets notes list.
    /// </summary>
    public List<ValueNote> NoteList { get; }

    /// <summary>
    /// Gets the attributes.
    /// </summary>
    public MeasureAttributes Attributes { get; }

    /// <summary>
    /// Gets or sets the id of measure.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// The merge measures.
    /// </summary>
    /// <param name="measure">
    /// The measure.
    /// </param>
    public void MergeMeasures(Measure measure)
    {
        int k = 0;

        // проведём цикл до тех пор, пока номер текущей ноты не превышает количество нот в обоих тактах
        while ((k < NoteList.Count) && (k < measure.NoteList.Count))
        {
            if (NoteList[k].Duration.Equals(measure.NoteList[k].Duration))
            {
                // ноты одинаковые по длине, можно просто склеить
                NoteList[k].AddPitch(measure.NoteList[k].Pitches);
            }
            else
            {
                List<ValueNote> tempNoteList = [];
                if (NoteList[k].Duration.Value < measure.NoteList[k].Duration.Value)
                {
                    // нота из склеенного массива короче, значит нужно вторую разделить на две и склеить
                    tempNoteList.AddRange(measure.NoteList[k].SplitNote(NoteList[k].Duration));
                    measure.NoteList.RemoveAt(k);
                    measure.NoteList.InsertRange(k, tempNoteList);
                    NoteList[k].AddPitch(measure.NoteList[k].Pitches);
                }
                else
                {
                    // нота из склеенного массива длиннее, значит надо её делить и клеить со второй
                    tempNoteList.AddRange(NoteList[k].SplitNote(measure.NoteList[k].Duration));
                    NoteList.RemoveAt(k);
                    NoteList.InsertRange(k, tempNoteList);
                    NoteList[k].AddPitch(measure.NoteList[k].Pitches);
                }
            }

            k++;
        }

        // теоретически на этом моменте у нас все ноты должны быть обработаны
        // хотя могло получиться, что в каком-то из тактов остались несклеенные ноты
    }

    /// <summary>
    /// Creates copy of current measure.
    /// </summary>
    /// <returns>
    /// The measure as <see cref="IBaseObject"/>.
    /// </returns>
    public IBaseObject Clone() => new Measure(NoteList, Attributes);

    /// <summary>
    /// The equals.
    /// </summary>
    /// <param name="obj">
    /// The object.
    /// </param>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj is Measure other
         && NoteList.Count == other.NoteList.Count
         && Attributes.Equals(other.Attributes))
        {
            for (int i = 0; i < NoteList.Count; i++)
            {
                if (!NoteList[i].Equals(other.NoteList[i]))
                {
                    return false;
                }
            }

            return true;
        }

        return false;

        // TODO: сделать сравнение не по всей ноте/объекту, а еще только по месту например,
        // TODO: из сравнения исключить триплет, так можно различать одинаковые по длительности ноты, но записанные по разному(!)
    }

    /// <summary>
    /// Calculates hash code using
    /// <see cref="Attributes"/> and <see cref="NoteList"/>.
    /// </summary>
    /// <returns>
    /// The <see cref="int"/>.
    /// </returns>
    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = 68558965;
            hashCode = (hashCode * -1521134295) + Attributes.GetHashCode();
            foreach (ValueNote note in NoteList)
            {
                hashCode = (hashCode * -1521134295) + note.GetHashCode();
            }

            return hashCode;
        }
    }
}

namespace Libiada.Core.Music;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// The fmotif identifier.
/// </summary>
public class FmotifIdentifier
{
    /// <summary>
    /// The get identification.
    /// </summary>
    /// <param name="fmotifSequence">
    /// The fmotif sequence.
    /// </param>
    /// <param name="pauseTreatment">
    /// The param pause treatment.
    /// </param>
    /// <param name="sequentialTransfer">
    /// The sequential transfer parameter.
    /// </param>
    /// <returns>
    /// The <see cref="FmotifSequence"/>.
    /// </returns>
    public FmotifSequence GetIdentification(FmotifSequence fmotifSequence, bool sequentialTransfer)
    {
        FmotifSequence sequence = (FmotifSequence)fmotifSequence.Clone();

        if (sequentialTransfer)
        {
            Fmotif[] fmotifs = new Fmotif[fmotifSequence.FmotifsList.Count];
            for (int i = 0; i < sequence.FmotifsList.Count; i++)
            {
                fmotifs[i] = FmotifSequentialTransfer(sequence.FmotifsList[i]);
            }

            sequence = new FmotifSequence(fmotifs.ToList());
        }

        for (int i = 0; i < sequence.FmotifsList.Count; i++)
        {
            for (int j = i; j < sequence.FmotifsList.Count; j++)
            {
                if (sequence.FmotifsList[i].Equals(sequence.FmotifsList[j]))
                {
                    sequence.FmotifsList[j].Id = sequence.FmotifsList[i].Id;
                }
            }
        }

        for (int i = 0; i < sequence.FmotifsList.Max(fl => fl.Id); i++)
        {
            bool haveId = sequence.FmotifsList.Any(t => t.Id == i); // флаг того что есть такой id в цепочке
            if (!haveId)
            {
                foreach (Fmotif fmotif in sequence.FmotifsList)
                {
                    if (fmotif.Id > i)
                    {
                        // уменьшаем на 1 id тех фмотивов которые больше текущей  id - i, которой не нашлось в цепи
                        fmotif.Id--;
                    }
                }

                // уменьшаем i на 1 чтобы еще раз проверить есть ли это i среди цепи после уменьшения id-ек больших i
                i--;
            }
        }

        return sequence;
    }

    public Fmotif FmotifSequentialTransfer(Fmotif fmotif)
    {
        
        int minMidiNumber = fmotif.NoteList.Min(n => n.Pitches.Count > 0 ? n.Pitches.Min(p => p.MidiNumber) : int.MaxValue);

        for (int i = 0; i < fmotif.NoteList.Count; i++)
        {
            if (fmotif.NoteList[i].Pitches.Count > 0)
            {
                for (int j = 0; j < fmotif.NoteList[i].Pitches.Count; j++)
                {
                    // TODO: проверить, что минимальная высота будет правильной
                    fmotif.NoteList[i].Pitches[j] = new Pitch(fmotif.NoteList[i].Pitches[j].MidiNumber - minMidiNumber);
                }
            }
        }

        return fmotif;
    }
}

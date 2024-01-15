namespace Libiada.Core.Music;

using System;
using System.Collections.Generic;
using System.Linq;

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
    /// <param name="fmotifChain">
    /// The fmotif chain.
    /// </param>
    /// <param name="pauseTreatment">
    /// The param pause treatment.
    /// </param>
    /// <param name="sequentialTransfer">
    /// The sequential transfer parameter.
    /// </param>
    /// <returns>
    /// The <see cref="FmotifChain"/>.
    /// </returns>
    public FmotifChain GetIdentification(FmotifChain fmotifChain, bool sequentialTransfer)
    {
        var chain = (FmotifChain)fmotifChain.Clone();

        if (sequentialTransfer)
        {
            var fmotifs = new Fmotif[fmotifChain.FmotifsList.Count];
            for (int i = 0; i < chain.FmotifsList.Count; i++)
            {
                fmotifs[i] = FmotifSequentialTransfer(chain.FmotifsList[i]);
            }

            chain = new FmotifChain(fmotifs.ToList());
        }

        for (int i = 0; i < chain.FmotifsList.Count; i++)
        {
            for (int j = i; j < chain.FmotifsList.Count; j++)
            {
                if (chain.FmotifsList[i].Equals(chain.FmotifsList[j]))
                {
                    chain.FmotifsList[j].Id = chain.FmotifsList[i].Id;
                }
            }
        }

        for (int i = 0; i < chain.FmotifsList.Max(fl => fl.Id); i++)
        {
            bool haveId = chain.FmotifsList.Any(t => t.Id == i); // флаг того что есть такой id в цепочке
            if (!haveId)
            {
                foreach (Fmotif fmotif in chain.FmotifsList)
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

        return chain;
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

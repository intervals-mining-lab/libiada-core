﻿using System;
using System.Collections.Generic;
using System.Text;
using MDA.OIP.BorodaDivider;
using ChainAnalises.Classes.IntervalAnalysis;
using MDA.OIP.ScoreModel;
using ChainAnalises.Classes.Root.SimpleTypes;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics.Calculators;

namespace MDA.ICL
{
    public static class NoteCharacteristic
    {
        static private double valR = 0; // удаленность между буквами в буквах
        static private double valG = 0; // глубина в буквах
        
        static public double CalculateRemoteness(FmotivChain FmChain)
        {
            if (Calculate(FmChain)) return valR;
            throw new Exception("Word Remoteness in words not calculated, ask specialist!");
        }

        static public double CalculateGamut(FmotivChain FmChain)
        {
            if (Calculate(FmChain)) return valG;
            throw new Exception("TextGamut in words not calculated, ask specialist!");
        }

        static private bool Calculate(FmotivChain FmChain)
        {
            if (FmChain.FmotivList.Count < 1) throw new Exception("Unaible to count note remoteness with no elements in chain!");

            List<Note> notelist = new List<Note>(); // список нот, класса Note, всей цепи фмотивов

            foreach (Fmotiv fmotiv in FmChain.FmotivList)
            {
                foreach(Note note in fmotiv.TieGathered().PauseTreatment(ParamPauseTreatment.Ignore).NoteList)
                {
                    notelist.Add((Note)note.Clone());
                }
            }

            Chain notechain = new Chain(notelist.Count);
            for (int i = 0; i < notelist.Count; i++) 
            {
                double ostatok =0 ;
                double midi = notelist[i].Pitch.Midinumber;

                ostatok = midi - 12* Math.Truncate(midi/12);

                //TODO: переделать нормально чтоб цепочка складывалась из ValueNote, а не как попало

                notechain[i] = new ValueString(Convert.ToString(notelist[i].Pitch.Midinumber) + " " +
                    Convert.ToString(notelist[i].Duration.Value * 10000000));


                /*
                Вариант когда ноты различимы только по ступени, не важно в какой октаве 
                                
                notechain[i] = new ValueString(Convert.ToString(Math.Round(ostatok)) + " " + 
                    Convert.ToString(notelist[i].Duration.Value*10000000));
                */
            }

            Characteristic R = new Characteristic(new AverageRemoteness());           
            valR = R.Value(notechain, LinkUp.End);

            Characteristic G = new Characteristic(new Gamut());
            valG = G.Value(notechain, LinkUp.End);

            return true;
        }
    }
}

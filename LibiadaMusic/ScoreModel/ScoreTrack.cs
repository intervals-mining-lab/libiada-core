using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root;

namespace LibiadaMusic.ScoreModel
{
    public class ScoreTrack : IBaseObject // полный музыкальный текст/трек
    {
        private string name; // имя музыкального текста ( муз. произведения)
        private List<UniformScoreTrack> uniformscoretracks; // список моно треков
        //TODO: сделать поля жанра/автора/типа произведения, для дальнейшего анализа, 
        //PS:либо сделать на уровень структуры выше, где будет разбиение на Ф-мотивы
        public ScoreTrack(string name, List<UniformScoreTrack> uniformscoretracks)
        {
            this.name = name; // присваиваем имя музыкального трека
            this.uniformscoretracks = new List<UniformScoreTrack>();
            for (int i = 0; i < uniformscoretracks.Count; i++)
                // создаем список монотреков, по средствам клонирования каждого монотрека.
            {
                this.uniformscoretracks.Add((UniformScoreTrack) uniformscoretracks[i].Clone());
                /*foreach (Measure measure in this.uniformscoretracks[this.uniformscoretracks.Count - 1].Measurelist)
                foreach (Note note in measure.NoteList)
                    note.SetInstrument(i);*/
            }

            //////////////////////////////////////////////
            /// ПОЛИФОНИЧЕСКАЯ ВСТАВКА
            //////////////////////////////////////////////
            UniformScoreTrack temp = (UniformScoreTrack) MergedTracks(this.uniformscoretracks).Clone();
            this.uniformscoretracks.Clear();
            this.uniformscoretracks.Add(temp);
        }

        public UniformScoreTrack MergedTracks(List<UniformScoreTrack> tracks)
        {
            int j = 0;
            UniformScoreTrack temp = (UniformScoreTrack) tracks[0].Clone(); // список склеенных дорожек
            List<Measure> templist = new List<Measure>(temp.Measurelist); //список склеенных тактов
            Measure tempm; // текущий склеиваемый такт
            for (int i = 1; i < tracks.Count; i++)
            {
                if (templist.Count != tracks[i].Measurelist.Count)
                    throw new Exception("ScoreTrack: invalid measure count");
                for (j = 0; j < temp.Measurelist.Count; j++)
                {
                    // склеивание j-тых тактов
                    tempm = (Measure) tracks[i].Measurelist[j].Clone();
                    tempm.MergeMeasures(templist[j]);
                    templist.RemoveAt(j);
                    templist.Insert(j, tempm);
                }
            }

            temp = new UniformScoreTrack(temp.Name, templist);
            return temp;
        }

        public string Name
        {
            get { return name; }
        }

        public List<UniformScoreTrack> UniformScoreTracks
        {
            get { return uniformscoretracks; }
        }

        #region IBaseMethods

        public IBaseObject Clone()
        {
            ScoreTrack Temp = new ScoreTrack(name, uniformscoretracks);
            return Temp;
        }

        public override bool Equals(object obj)
        {
            bool equalUniformscoretracks = true;

            if (UniformScoreTracks.Count != ((ScoreTrack) obj).UniformScoreTracks.Count)
            {
                equalUniformscoretracks = false;
            }
            for (int i = 0; i < UniformScoreTracks.Count; i++)
            {
                if (!UniformScoreTracks[i].Equals(((ScoreTrack) obj).UniformScoreTracks[i]))
                {
                    equalUniformscoretracks = false;
                }
            }
            if (equalUniformscoretracks)
            {
                return true;
            }
            return false;
        }

        #endregion

    }
}

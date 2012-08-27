using System.Collections.Generic;
using LibiadaCore.Classes.Root;


namespace MDA.OIP.ScoreModel
{
    /// <summary>
    /// полный музыкальный текст/трек
    /// </summary>
    public class ScoreTrack : IBaseObject
    {
        /// <summary>
        /// имя музыкального текста ( муз. произведения)
        /// </summary>
        private string name;

        /// <summary>
        /// список моно треков
        /// </summary>
        private List<UniformScoreTrack> uniformscoretracks;

        //TODO: сделать поля жанра/автора/типа произведения, для дальнейшего анализа, 
        //PS:либо сделать на уровень структуры выше, где будет разбиение на Ф-мотивы

        public ScoreTrack(string name, List<UniformScoreTrack> uniformscoretracks)
        {
            this.name = name; // присваиваем имя музыкального трека
            for (int i = 0; i < uniformscoretracks.Count; i++)
                // создаем список монотреков, посредством клонирования каждого монотрека.
            {
                this.uniformscoretracks = new List<UniformScoreTrack>(); // зачем каждый раз создавать массив???(о_О)
                this.uniformscoretracks.Add((UniformScoreTrack) uniformscoretracks[i].Clone());
            }
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

        private ScoreTrack()
        {
            ///<summary>
            /// Stub for GetBin
            ///</summary>  
        }

        public IBaseObject Clone()
        {
            ScoreTrack Temp = new ScoreTrack(this.name, this.uniformscoretracks);
            return Temp;
        }

        public bool Equals(object obj)
        {
            bool equalUniformscoretracks = UniformScoreTracks.Count == ((ScoreTrack) obj).UniformScoreTracks.Count;

            for (int i = 0; i < this.UniformScoreTracks.Count; i++)
            {
                if (!this.UniformScoreTracks[i].Equals(((ScoreTrack) obj).UniformScoreTracks[i]))
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

        public IBin GetBin()
        {
            ScoreTrackBin Temp = new ScoreTrackBin();
            ///<summary>
            /// Stub
            ///</summary>
            return Temp;
        }

        public class ScoreTrackBin : IBin
        {
            public IBaseObject GetInstance()
            {
                ///<summary>
                /// Stub
                ///</summary>
                return new ScoreTrack();
            }
        }
        #endregion
    }
}

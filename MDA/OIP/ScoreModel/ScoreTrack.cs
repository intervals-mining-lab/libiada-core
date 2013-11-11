using System;
using System.Collections.Generic;
using System.Text;
using ChainAnalises.Classes.Root;


namespace MDA.OIP.ScoreModel
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
        for (int i = 0; i < uniformscoretracks.Count; i++) // создаем список монотреков, по средствам клонирования каждого монотрека.
        {
            this.uniformscoretracks = new List<UniformScoreTrack>();
            this.uniformscoretracks.Add((UniformScoreTrack)uniformscoretracks[i].Clone());
        }
    }
    public string Name
    {
        get
        {
            return name;
        }
    }
    public List<UniformScoreTrack> UniformScoreTracks
    {
        get
        {
            return uniformscoretracks;
        }
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

    public override bool Equals(object obj)
    {
        bool equalUniformscoretracks = true;

        if (this.UniformScoreTracks.Count != ((ScoreTrack)obj).UniformScoreTracks.Count) { equalUniformscoretracks = false; }
        for (int i = 0; i < this.UniformScoreTracks.Count; i++)
        {
            if (!this.UniformScoreTracks[i].Equals(((ScoreTrack)obj).UniformScoreTracks[i])) { equalUniformscoretracks = false; }
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

    public class ScoreTrackBin:IBin
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

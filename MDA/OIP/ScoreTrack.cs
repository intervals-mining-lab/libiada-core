using System;
using System.Collections.Generic;
using System.Text;
using ChainAnalises.Classes.Root;


namespace MDA.OIP
{
    public class ScoreTrack : IBaseObject
    {
        
    private List<UniformScoreTrack> scoretracks;
    private int count = 0;
    private string name;

    private ScoreTrack() 
    {
        ///<summary>
        /// Stub для GetBin
        ///</summary>  
    }
    public ScoreTrack(string tname) 
    {
        this.name = tname;
    }
    public string GetName() 
    {
        return name;
    }
    public void AddUniformTrack(UniformScoreTrack utrack) 
    {
        //scoretracks.Add(((UniformScoreTrack) utrack).Clone());
        scoretracks.Add( (UniformScoreTrack) utrack.Clone());
        count = count + 1;
    }
    public List<UniformScoreTrack> GetScoreTrackes() 
    {
        return scoretracks;
    }

    protected void FillClone(IBaseObject temp)
    {
        ScoreTrack tempSpace = temp as ScoreTrack;
        if (tempSpace != null)
        {
            for (int i = 0; i < count; i++ )
            {
            tempSpace.AddUniformTrack((UniformScoreTrack) scoretracks[i].Clone());
            }
        }
    }  

    public IBaseObject Clone()
    {
        ScoreTrack Temp = new ScoreTrack(this.name);
        FillClone(Temp);
        return Temp;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(this, obj))
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
    }
}

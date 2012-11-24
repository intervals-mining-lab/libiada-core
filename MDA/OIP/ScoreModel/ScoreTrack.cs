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
        
        /*public int MergeTracks()
	    {
	    	//@@@@ TODO: бла бла бла
	    	int k = 0;
            List<ValueNote> TempNoteList = new List<ValueNote>(0);
	    	for (int i = 1; i < this.uniformscoretracks.Count-1; i++)
	    	{//Далее - мерджим все дорожки в нулевую, i - номер текущей дорожки начиная с 1
	    		for (int j = 0; j < this.uniformscoretracks[i].Measurelist.Count; j++)
	        	{//Нужно по очереди смерджить каждый такт текущей дорожки с тактом нулевой, который имеет тот же порядковый номер
	                        
	            	while (k < this.uniformscoretracks[0].Measurelist[j].NoteList.Count)
	             	{//Как это делается: берём ноту текущего такта текущей дорожки
	                	//Если количество нот текущего трека не меньше, чем положение курсора в нулевом, то
	                	if (this.uniformscoretracks[i].Measurelist[j].NoteList.Count >= k)
	                	{
	                		//Смотрим на её длительность - есть соответствующая по началу нота нулевой дорожки равна по длительности, то просто вставим одну в другую
	                    	//for (int l = 0; l < Temp[i].Measurelist[j].NoteList.Count)
	             	    	//if (Temp[i].Measurelist[j].NoteList[k].Duration.Equals(Temp[0].Measurelist[j].NoteList[k].Duration))
	                 		//Нужна процедур SplitNote, которая в качестве параметра имеет количество тиков,
	             			//а на выходе - список из двух нот, количество тиков первой равно заданному

                            if (this.uniformscoretracks[0].Measurelist[j].NoteList[k].Duration.Value < this.uniformscoretracks[i].Measurelist[j].NoteList[k].Duration.Value)
	                        { 
	                        	//Нулевая нота короче, значит делить надо ненулевую
	                        	TempNoteList = this.uniformscoretracks[i].Measurelist[j].NoteList[k].SplitNote(this.uniformscoretracks[0].Measurelist[j].NoteList[k].Duration);
	                        	this.uniformscoretracks[i].Measurelist[j].NoteList.Remove(this.uniformscoretracks[i].Measurelist[j].NoteList[k]);
	                        	this.uniformscoretracks[i].Measurelist[j].NoteList.InsertRange(k, TempNoteList);
	                        }
	                        else if (this.uniformscoretracks[0].Measurelist[j].NoteList[k].Duration.Value > this.uniformscoretracks[i].Measurelist[j].NoteList[k].Duration.Value)
	                        {
	                        	//Нулевая нота длиннее, значит делить надо её
	                        	TempNoteList = this.uniformscoretracks[0].Measurelist[j].NoteList[k].SplitNote(this.uniformscoretracks[i].Measurelist[j].NoteList[k].Duration);
	                        	this.uniformscoretracks[0].Measurelist[j].NoteList.Remove(this.uniformscoretracks[i].Measurelist[j].NoteList[k]);
	                        	this.uniformscoretracks[0].Measurelist[j].NoteList.InsertRange(k, TempNoteList);
	                        }
	                        else this.uniformscoretracks[0].Measurelist[j].NoteList[k].AddPitch(this.uniformscoretracks[i].Measurelist[j].NoteList[k].Pitch);
	                    }
	                    k++;
	             	}
	        	}
	    	}
            return 0;
	    }*/

        public string Name
        {
            get { return name; }
        }

        public List<UniformScoreTrack> UniformScoreTracks
        {
            get { return uniformscoretracks; }
        }

        #region IBaseMethods

        ///<summary>
        /// Stub for GetBin
        ///</summary> 
        private ScoreTrack()
        {
             
        }

        public IBaseObject Clone()
        {
            ScoreTrack Temp = new ScoreTrack(this.name, this.uniformscoretracks);
            return Temp;
        }

        public override bool Equals(object obj)
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

        #endregion
    }
}

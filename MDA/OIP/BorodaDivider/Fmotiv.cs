using System;
using System.Collections.Generic;
using System.Text;
using MDA.OIP.ScoreModel;

namespace MDA.OIP.BorodaDivider
{
    public class Fmotiv
    {
        // класс для хранения ф-мотива
        private int id; // порядковый номер - идентификатор (возможно введения доп id - глобального для словаря ф-мотивов)
        private string type = ""; // тип ф-мотива (ПМТ, МТ, ВП, ПМТВП, МТВП)
        private List<Note> notelist; // список нот, входящих в  ф-мотив

        public Fmotiv(int id, string type) 
        {
            this.id = id;
            this.type = type;
            this.notelist = new List<Note>();
        }

        public List<Note> NoteList
        {
            get
            {
                return notelist;
            }
        }
        public string Type
        {
            get
            {
                return type;
            }
            set 
            {
                this.type = value;
            }
        }
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                this.id = value;
            }
        }

        //TODO: реализовать методы IBASEOBJECT!

    }
}

﻿using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace MDA.Analisis
{
    public class FMName
    {
        private int id = 0;
        private string name;
        
        public FMName(string st) 
        {
            this.name = st;
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetId(int ident)
        {
            this.id = ident;
        }

        public int GetId()
        {
            return this.id;
        }
    }
}

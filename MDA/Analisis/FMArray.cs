using System;
using System.Collections;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace MDA.Analisis
{
    public class FMArray
    {
        private ArrayList Ar=new ArrayList();
        private int length;
        public ArrayList GetData()
        {
            return Ar;
        }
        public void SetData(ArrayList inpAr)
        {
            Ar=(ArrayList) inpAr.Clone();
        }
        public void NewRecord(String str)
        {   this.Ar.Add(new FMName(str));
            length += 1;
        }
        public int Getlength()
        {
            return length;
        }
    }
}

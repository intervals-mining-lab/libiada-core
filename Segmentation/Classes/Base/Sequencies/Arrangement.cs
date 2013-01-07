using System;
using System.Collections.Generic;
using System.Text;
using Segmentation.Classes.Interfaces;

namespace Segmentation.Classes.Base.Sequencies
{
    /// <summary>
    /// The class is designed for storing and processing numeric sequences.
    /// Not tied to any notion of order a chain.
    /// </summary>
    public class Arrangement:INumberSequence
    {
        protected List<int> values;
    protected String delimiter = "-";

    public Arrangement(List<int> values){
        build(values);
    }

    public Arrangement() {
        this.values = new List<int>();
    }

     public Arrangement(int[] values) {
        this.values = new List<int>();
         for (int index = 0; index < values.Length; index++){
             this.values.Add(values[index]);
         }
    }

    /// <summary>
    /// Maps taken to the value of the object
    /// </summary>
    /// <param name="values">input numeric sequence</param>
    private void build(List<int> values) {
        this.values = new List<int>();
        if (values.Count == 0){
            List<int> list = new List<int>();
            this.values.AddRange(list);
            return;
        }
        this.values.AddRange(values);
    }

    public bool isEmpty() {

        return values.Count == 0;
    }

    public int length() {
        return values.Count;
    }

    public int elementAt(int index) {
        try {
            return values[index];
        }
        catch (Exception e) {
           
        }
        return -1;
    }

    public INumberSequence concat(INumberSequence value) {
        try {
            if (!value.isEmpty()) {
                for (int index = 0; index < value.length(); index++) {
                    values.Add(value.elementAt(index));
                }
            }
        }
        catch (Exception e) {
        }

        return this;
    }

    public INumberSequence add(int value) {
        values.Add(value);
        return this;
    }

    public INumberSequence substring(int beginIndex, int endIndex) {
        Arrangement arrangement = null;
            arrangement = new Arrangement(sublist(beginIndex, endIndex));
        return arrangement;  
    }

    public INumberSequence clearAt(int index) {
        try {
            values.Remove(index);
        }
        catch (Exception e) {
        }
        return this;
    }

    /// <summary>
    /// Returns a new sequence that is a sublist of the current sequence. 
    /// The substring begins at the specified beginIndex and extends to the figures at index endIndex - 1. 
    /// Thus the length of the substring is endIndex-beginIndex.
    /// </summary>
    /// <param name="beginIndex">the beginning index, inclusive.</param>
    /// <param name="endIndex">the ending index, exclusive.</param>
    /// <returns>the specified numerical substring.</returns>
    protected List<int> sublist(int beginIndex, int endIndex) {
        List<int> sublist = null;

        try {
            sublist =  values.GetRange(beginIndex, endIndex - beginIndex);
        }
        catch (Exception e) {
        }

        return new List<int>(sublist);
    }

    public override bool Equals(Object obj) {
        if (!(obj is Arrangement))
        {
            return false;
        }
        Arrangement sequence = (Arrangement) obj;
        if (sequence.length() != values.Count) return false;
        for(int index = 0; index < sequence.length(); index++){
            if ( values[index] != sequence.elementAt(index))
                return false;
        }
        return true;
    }


    public override String ToString(){
      StringBuilder str = new StringBuilder();

            for(List<int>.Enumerator iter = this.values.GetEnumerator(); iter.MoveNext();){
                str.Append(iter.Current + delimiter);
            }
        str.Remove(str.Length - 1, 1);
        return str.ToString();
    }
    
    public void push(int value){
        values.Add(value);
    }

    public void clear(){
        values.Clear();
    } 
    }
}
using System;
using System.Collections;
using ChainAnalises.Classes.DataMining;
using ChainAnalises.Classes.MatrixCalculus;
using ChainAnalises.Classes.Root.SimpleTypes;
using ChainAnalises.Classes.TheoryOfSet;

namespace ChainAnalises.Classes.TheoryOfGraphs
{
    ///<summary>
    ///</summary>
    public class Graph : ICloneable
    {
        private ArrayList pPoints = new ArrayList();
        private Dictionary vault = new Dictionary();

        ///<summary>
        ///</summary>
        ///<exception cref="NotImplementedException"></exception>
        public ArrayList Branches
        {
            get { return new ArrayList(vault.Keys); }
        }

        ///<summary>
        ///</summary>
        public int Count
        {
            get { return vault.Count; }
        }

        ///<summary>
        ///</summary>
        public ArrayList Points
        {
            get { return (ArrayList) pPoints.Clone(); }
        }

        ///<summary>
        ///</summary>
        ///<param name="branch"></param>
        ///<exception cref="NotImplementedException"></exception>
        public double this[Branch branch]
        {
            get { return vault[branch]; }
            set
            {
                if (vault.Keys.Contains(branch))
                {
                    vault[branch] = value;
                }
                else
                {
                    Add(branch, value);
                }
            }
        }

        #region ICloneable Members

        public object Clone()
        {
            Graph Temp = new Graph();
            Temp.vault = (Dictionary) vault.Clone();
            Temp.pPoints = (ArrayList) pPoints.Clone();
            return Temp;
        }

        #endregion

        ///<summary>
        ///</summary>
        ///<param name="branch"></param>
        ///<param name="value"></param>
        ///<exception cref="NotImplementedException"></exception>
        public void Add(Branch branch, double value)
        {
            vault.Add(branch, value);
            AddPoint(branch.From);
            AddPoint(branch.To);
        }

        ///<summary>
        ///</summary>
        ///<param name="point"></param>
        public void AddPoint(int point)
        {
            if (!pPoints.Contains(point))
            {
                pPoints.Add(point);
            }
        }

        public override bool Equals(object obj)
        {
            return (obj != null) && (Equals(obj as Graph));
        }

        ///<summary>
        ///</summary>
        ///<param name="obj"></param>
        ///<returns></returns>
        public bool Equals(Graph obj)
        {
            foreach (int i in pPoints)
            {
                if (!obj.pPoints.Contains(i))
                {
                    return false;
                }
            }

            foreach (DictionaryEntry entry in vault)
            {
                if (((Double) entry.Value) != (obj[(Branch) entry.Key]))
                {
                    return false;
                }
            }

            return true;
        }

        ///<summary>
        ///</summary>
        ///<param name="i"></param>
        ///<returns></returns>
        ///<exception cref="NotImplementedException"></exception>
        public ArrayList BranchesContains(int i)
        {
            ArrayList Temp = new ArrayList();
            foreach (DictionaryEntry entry in vault)
            {
                if (((Branch) entry.Key).Equals(i))
                {
                    Temp.Add(entry.Key);
                }
            }
            return Temp;
        }

        ///<summary>
        ///</summary>
        ///<param name="i"></param>
        ///<returns></returns>
        public ArrayList PointsConnectedWith(int i)
        {
            ArrayList Temp = new ArrayList();
            foreach (Branch entry in BranchesContains(i))
            {
                Temp.Add(entry.GetOtherPoint(i));
            }
            return Temp;
        }

        ///<summary>
        ///</summary>
        ///<param name="branch"></param>
        ///<exception cref="NotImplementedException"></exception>
        public void Remove(Branch branch)
        {
            vault.Remove(branch);
        }

        ///<summary>
        ///</summary>
        ///<param name="branch"></param>
        ///<returns></returns>
        public bool Contains(Branch branch)
        {
            return (new ArrayList(vault.Keys)).Contains(branch);
        }

        ///<summary>
        ///</summary>
        ///<param name="point"></param>
        public void Remove(int point)
        {
            ArrayList Temp = PointsConnectedWith(point);
            foreach (int i in Temp)
            {
                Remove(new Branch(point, i));
            }
            pPoints.Remove(point);
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public Matrix AsMatrix()
        {
            Alphabet Alp = new Alphabet();
            foreach (int point in pPoints)
            {
                Alp.Add((ValueInt) point);
            }
            Matrix temp = new Matrix(Alp);

            foreach (DictionaryEntry entry in vault)
            {
                int i = ((Branch) entry.Key).To;
                int j = ((Branch)entry.Key).From;
                temp.Set(i, j, (double) entry.Value);
                temp.Set(j, i, (double)entry.Value);
            }
            return temp;
        }
    }
}
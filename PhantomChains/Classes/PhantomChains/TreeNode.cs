using System;
using PhantomChains.Classes.Statistics.MarkovChain.Generators;

namespace PhantomChains.Classes.PhantomChains
{
    ///<summary>
    /// �����-���� ������ ��������
    ///</summary>
    public class TreeNode:ITreeNode
    {
        private IBaseObject id = null;
        private ITreeNode Parent = null;


        ///<summary>
        /// �����������
        ///</summary>
        ///<param name="parent">������������ ����</param>
        ///<param name="content">������� ����������� ��������������� ������� ����</param>
        ///<param name="table">������� � �����������</param>
        ///<exception cref="Exception">���� ������������ ������� �� �����, ��������� ����������</exception>
        public TreeNode(ITreeNode parent, IBaseObject content, PhantomTable table)
        {
            if (parent != null)
            {
                Parent = parent;
            }
            else
            {
                throw new Exception("����������� ������������ ������� � ������ ���������");
            }
            level = Parent.Level + 1;
            volume = table[level + 1].Volume;
            id = content;
            StartPosition = table.StartPositions[level];
        }

        ///<summary>
        /// ���������� ����� ���������� ���������� ��������� � ������ �����
        /// � �������� ������ ������.
        /// ����� ��������� ���������� ��������� ������� ���� �� 1.
        ///</summary>
        ///<returns>���� ��������� ��� ����� ���������� ������ ������ �����</returns>
        public override bool Decrement()
        {
            volume--;
            bool flag = Parent.Decrement();
            if (flag)
            {
                for (int i = 0; i < Children.Count; i++)
                {
                    if (Children[i].Volume == 0)
                    {
                        Children.RemoveAt(i);
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        ///<summary>
        /// ����� ����������� � ����������� ������� ��� ���� �������
        /// � ���������� ����������� ����� � ������ �� �������� 
        /// ���� ������� ��������� �� �� �����.
        ///</summary>
        ///<param name="Result">������������ �������</param>
        ///<param name="generator">��������� ��������� �����</param>
        public void FillChain(BaseChain Result, IGenerator generator,PhantomTable table)
        {
            if ((table.Length != (level + 2))&&(Children.Count==0))
            {
                MessagePhantom temp = table[level + 2].Content;
                for (int i = 0; i < temp.power; i++)
                {
                    Children.Add(new TreeNode(this, temp[i], table));
                }
            }
            if((id is BaseChain)||(id is ValueString))
            {
                String amin = id.ToString();
                for (int k = 0; k < amin.Length;k++)
                {
                    Result[StartPosition+k] = new ValueChar(amin[k]);
                }
            }
            else
            {
                Result[StartPosition] = id;
            }
            this.Find(Result,generator,table);
        }
    }
}
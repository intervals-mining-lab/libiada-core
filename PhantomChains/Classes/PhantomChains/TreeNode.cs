using System;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using PhantomChains.Classes.Statistics.MarkovChain.Generators;

namespace PhantomChains.Classes.PhantomChains
{
    ///<summary>
    /// �����-���� ������ ��������
    ///</summary>
    public class TreeNode:AbstractNode
    {
        private IBaseObject id;
        private AbstractNode Parent;


        ///<summary>
        /// �����������
        ///</summary>
        ///<param name="parent">������������ ����</param>
        ///<param name="content">������� ����������� ��������������� ������� ����</param>
        ///<param name="table">������� � �����������</param>
        ///<exception cref="Exception">���� ������������ ������� �� �����, ��������� ����������</exception>
        public TreeNode(AbstractNode parent, IBaseObject content, PhantomTable table)
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
            return false;
        }

        /// <summary>
        ///  ����� ����������� � ����������� ������� ��� ���� �������
        ///  � ���������� ����������� ����� � ������ �� �������� 
        ///  ���� ������� ��������� �� �� �����.
        /// </summary>
        /// <param name="result">������������ �������</param>
        /// <param name="generator">��������� ��������� �����</param>
        /// <param name="table"></param>
        public void FillChain(BaseChain result, IGenerator generator, PhantomTable table)
        {
            if ((table.Length != (level + 2))&&(Children.Count==0))
            {
                ValuePhantom temp = table[level + 2].Content;
                for (int i = 0; i < temp.Power; i++)
                {
                    Children.Add(new TreeNode(this, temp[i], table));
                }
            }
            if((id is BaseChain)||(id is ValueString))
            {
                String amin = id.ToString();
                for (int k = 0; k < amin.Length;k++)
                {
                    result[StartPosition+k] = new ValueChar(amin[k]);
                }
            }
            else
            {
                result[StartPosition] = id;
            }
            Find(result,generator,table);
        }
    }
}
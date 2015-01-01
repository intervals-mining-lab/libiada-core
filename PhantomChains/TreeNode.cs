namespace PhantomChains
{
    using System;

    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;

    using MarkovChains.MarkovChain.Generators;

    /// <summary>
    /// �����-���� ������ ��������
    /// </summary>
    public class TreeNode : AbstractNode
    {
        /// <summary>
        /// The id.
        /// </summary>
        private readonly IBaseObject id;

        /// <summary>
        /// The parent.
        /// </summary>
        private readonly AbstractNode parent;

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeNode"/> class.
        /// </summary>
        /// <param name="parent">
        /// ������������ ����
        /// </param>
        /// <param name="content">
        /// ������� ����������� ��������������� ������� ����
        /// </param>
        /// <param name="table">
        /// ������� � �����������
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// ���� ������������ ������� �� �����, ��������� ����������
        /// </exception>
        public TreeNode(AbstractNode parent, IBaseObject content, PhantomTable table)
        {
            if (parent == null)
            {
                throw new ArgumentNullException("parent", "����������� ������������ ������� � ������ ���������");
            }

            this.parent = parent;
            Level = this.parent.Level + 1;
            Volume = table[Level + 1].Volume;
            id = content;
            StartPosition = table.StartPositions[Level];
        }

        /// <summary>
        /// ���������� ����� ���������� ���������� ��������� � ������ �����
        /// � �������� ������ ������.
        /// ����� ��������� ���������� ��������� ������� ���� �� 1.
        /// </summary>
        /// <returns>���� ��������� ��� ����� ���������� ������ ������ �����</returns>
        public override bool Decrement()
        {
            Volume--;
            bool flag = parent.Decrement();
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
        /// <param name="result">
        /// ������������ �������
        /// </param>
        /// <param name="generator">
        /// ��������� ��������� �����
        /// </param>
        /// <param name="table">
        /// ������� � �����������
        /// </param>
        public void FillChain(BaseChain result, IGenerator generator, PhantomTable table)
        {
            if ((table.Length != (Level + 2)) && (Children.Count == 0))
            {
                ValuePhantom temp = table[Level + 2].Content;
                for (int i = 0; i < temp.Cardinality; i++)
                {
                    Children.Add(new TreeNode(this, temp[i], table));
                }
            }

            if ((id is BaseChain) || (id is ValueString))
            {
                string amino = id.ToString();
                for (int k = 0; k < amino.Length; k++)
                {
                    result[StartPosition + k] = new ValueString(amino[k]);
                }
            }
            else
            {
                result[StartPosition] = id;
            }

            Find(result, generator, table);
        }
    }
}

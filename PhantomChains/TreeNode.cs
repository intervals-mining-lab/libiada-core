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
            this.Level = this.parent.Level + 1;
            this.Volume = table[this.Level + 1].Volume;
            this.id = content;
            this.StartPosition = table.StartPositions[this.Level];
        }

        /// <summary>
        /// ���������� ����� ���������� ���������� ��������� � ������ �����
        /// � �������� ������ ������.
        /// ����� ��������� ���������� ��������� ������� ���� �� 1.
        /// </summary>
        /// <returns>���� ��������� ��� ����� ���������� ������ ������ �����</returns>
        public override bool Decrement()
        {
            this.Volume--;
            bool flag = this.parent.Decrement();
            if (flag)
            {
                for (int i = 0; i < this.Children.Count; i++)
                {
                    if (this.Children[i].Volume == 0)
                    {
                        this.Children.RemoveAt(i);
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
            if ((table.Length != (this.Level + 2)) && (this.Children.Count == 0))
            {
                ValuePhantom temp = table[this.Level + 2].Content;
                for (int i = 0; i < temp.Cardinality; i++)
                {
                    this.Children.Add(new TreeNode(this, temp[i], table));
                }
            }

            if ((this.id is BaseChain) || (this.id is ValueString))
            {
                string amino = this.id.ToString();
                for (int k = 0; k < amino.Length; k++)
                {
                    result[this.StartPosition + k] = new ValueChar(amino[k]);
                }
            }
            else
            {
                result[this.StartPosition] = this.id;
            }

            this.Find(result, generator, table);
        }
    }
}
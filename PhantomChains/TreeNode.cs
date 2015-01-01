namespace PhantomChains
{
    using System;

    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;

    using MarkovChains.MarkovChain.Generators;

    /// <summary>
    /// Класс-узел дерева ваиантов
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
        /// Родительский узел
        /// </param>
        /// <param name="content">
        /// Вариант содержимого соответствующий данному узлу
        /// </param>
        /// <param name="table">
        /// Таблица с параметрами
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Если родительский элемент не задан, возникает исключение
        /// </exception>
        public TreeNode(AbstractNode parent, IBaseObject content, PhantomTable table)
        {
            if (parent == null)
            {
                throw new ArgumentNullException("parent", "Отсутствует родительский элемент в дереве вариантов");
            }

            this.parent = parent;
            Level = this.parent.Level + 1;
            Volume = table[Level + 1].Volume;
            id = content;
            StartPosition = table.StartPositions[Level];
        }

        /// <summary>
        /// Рекурсивый метод уменьшения количества вариантов в данной ветви
        /// и удаления пустых ветвей.
        /// Также уменьшает количество вариантов данного узла на 1.
        /// </summary>
        /// <returns>Флаг говорящий что нужно продолжать поиски пустой ветви</returns>
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
        ///  Метод добавляющий в заполняемую цепочку ещё один элемент
        ///  и вызывающий аналогичный метод у одного из потомков 
        ///  если цепочка заполнена не до конца.
        /// </summary>
        /// <param name="result">
        /// Генерируемая цепочка
        /// </param>
        /// <param name="generator">
        /// Генератор случайных чисел
        /// </param>
        /// <param name="table">
        /// Таблица с параметрами
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

namespace PhantomChains.PhantomChains
{
    using System.Collections.Generic;

    using LibiadaCore.Classes.Root;

    using global::PhantomChains.Statistics.MarkovChain.Generators;

    /// <summary>
    /// Интерфейс элемента дерева
    /// </summary>
    public abstract class AbstractNode
    {
        /// <summary>
        /// The children.
        /// </summary>
        protected readonly List<TreeNode> Children = new List<TreeNode>();

        /// <summary>
        /// Поле хранящее количество дочерних элементов
        /// </summary>
        public ulong Volume { get; protected set; }

        /// <summary>
        /// Уровень элемента в дереве
        /// </summary>
        public int Level { get; protected set; }

        /// <summary>
        /// The start position.
        /// </summary>
        protected int StartPosition { get; set; }

        /// <summary>
        /// Интерфейс рекурсивного метода осуществляющего декременту вариантов построения в данной ветви.
        /// Также уменьшает количество вариантов данного узла на 1. Вызывается после генерации очередного занчения.
        /// </summary>
        /// <returns>
        /// Булевый флаг, показывающий нужно ли производить проверку детей
        /// на отсутствие дальнейших вариантов. Если флаг имеет значение false,
        /// то действие не требуется. Если же true, то требуется проверить дочерние элементы 
        /// на наличие возможных вариантов, и удалить детей в которых больше нет вариантов. 
        /// </returns>
        public abstract bool Decrement();

        /// <summary>
        /// Метод, возвращающий дочерний для данного элемент дерева по его индексу.
        /// </summary>
        /// <param name="index">Индекс дочернего элемента</param>
        /// <returns>Дочерний элемент</returns>
        public TreeNode GetChild(int index)
        {
            return this.Children[index];
        }

        /// <summary>
        /// Метод, выбирающий какой из потомков будет генерировать очередной элемент цепи.
        /// </summary>
        /// <param name="result">Генерируемая цепь</param>
        /// <param name="generator">Генератор случайных чисел</param>
        /// <param name="table">Таблица с параметрами фантомной цепи</param>
        protected void Find(BaseChain result, IGenerator generator, PhantomTable table)
        {
            // если элемент не листовой
            if (this.Children.Count != 0)
            {
                double val = generator.Next();
                ulong curVal = 0;
                for (int i = 0; i < this.Children.Count; i++)
                {
                    curVal += this.Children[i].Volume;
                    if (val <= ((double)curVal / this.Volume))
                    {
                        this.Children[i].FillChain(result, generator, table);
                        return;
                    }
                }
            }
            else
            {
                // если дочерних элементов нет, то генерация закончена
                // и запускаем процедуру декременты варинтов в данной ветви
                this.Decrement();
            }
        }
    }
}

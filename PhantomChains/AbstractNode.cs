﻿namespace PhantomChains
{
    using System.Collections.Generic;

    using LibiadaCore.Core;

    using MarkovChains.MarkovChain.Generators;

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
        /// Gets or sets count of children elements.
        /// </summary>
        public ulong Volume { get; protected set; }

        /// <summary>
        /// Gets or sets the level of element in tree.
        /// </summary>
        public int Level { get; protected set; }

        /// <summary>
        /// Gets or sets the start position.
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
            return Children[index];
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
            if (Children.Count != 0)
            {
                double val = generator.Next();
                ulong curVal = 0;
                for (int i = 0; i < Children.Count; i++)
                {
                    curVal += Children[i].Volume;
                    if (val <= ((double)curVal / Volume))
                    {
                        Children[i].FillChain(result, generator, table);
                        return;
                    }
                }
            }
            else
            {
                // если дочерних элементов нет, то генерация закончена
                // и запускаем процедуру декременты варинтов в данной ветви
                Decrement();
            }
        }
    }
}

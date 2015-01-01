namespace PhantomChains
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;

    using MarkovChains.MarkovChain.Generators;

    /// <summary>
    /// Корневой узел дерева враинтов.
    /// </summary>
    public class TreeTop : AbstractNode
    {
        /// <summary>
        /// The table.
        /// </summary>
        private readonly PhantomTable table;

        /// <summary>
        /// The generator.
        /// </summary>
        private readonly IGenerator generator;

        /// <summary>
        /// The is string.
        /// </summary>
        private readonly bool isString;

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeTop"/> class,
        /// representing root element of the tree.
        /// </summary>
        /// <param name="source">
        /// The input chain.
        /// </param>
        /// <param name="generator">
        /// The gen.
        /// </param>
        public TreeTop(BaseChain source, IGenerator generator)
        {
            table = new PhantomTable(source);
            this.generator = generator;
            StartPosition = 0;
            Volume = table[0].Volume;
            Level = -1;
            if ((table[1].Content[0] is ValueString) || (table[1].Content[0] is BaseChain))
            {
                isString = true;
            }

            if ((source != null) && (source.GetLength() != 0))
            {
                var temp = (ValuePhantom)source[0];
                for (int i = 0; i < temp.Cardinality; i++)
                {
                    Children.Add(new TreeNode(this, temp[i], table));
                }
            }
        }

        /// <summary>
        /// Рекурсивный метод, осуществляющий декременту вариантов построения в данной ветви.
        /// Также уменьшает количество вариантов данного узла на 1. 
        /// Вызывается после генерации очередного занчения.
        /// </summary>
        /// <returns>
        /// Булевый флаг, показывающий нужно ли производить проверку детей
        /// на отсутствие дальнейших вариантов. Если флаг имеет значение false,
        /// то действие не требуется. Если же true, то требуется проверить дочерние элементы 
        /// на наличие возможных вариантов, и удалить детей в которых больше нет вариантов. 
        /// </returns>
        public override bool Decrement()
        {
            Volume--;
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

        /// <summary>
        /// Метод, в котором задаётся длина генерируемой цепочки
        /// и запускается её генерация
        /// </summary>
        /// <returns>
        /// Сгенерированная цепочка
        /// </returns>
        public BaseChain Generate()
        {
            int len = table.Length - 1;
            len *= isString ? 3 : 1;
            var result = new BaseChain(len);

            Find(result, generator, table);
            return result;
        }
    }
}

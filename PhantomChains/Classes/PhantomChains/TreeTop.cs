using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using PhantomChains.Classes.Statistics.MarkovChain.Generators;

namespace PhantomChains.Classes.PhantomChains
{
    ///<summary>
    /// Корневой узел дерева враинтов.
    ///</summary>
    public class TreeTop:AbstractNode
    {
        private PhantomTable Table;
        private IGenerator Generator;
        private bool IsString;

        ///<summary>
        /// Конструктор корневого элемента
        ///</summary>
        ///<param name="inputChain">Исходная цепь дя построения дерева варинтов</param>
        ///<param name="gen">Генератор </param>
        public TreeTop(BaseChain inputChain, IGenerator gen)
        {
            Table = new PhantomTable(inputChain);
            Generator = gen;
            StartPosition = 0;
            volume = Table[0].Volume;
            level = -1;
            if ((Table[1].Content[0] is ValueString) || (Table[1].Content[0] is BaseChain))
            {
                IsString = true;
            }
            if ((inputChain != null) && (inputChain.Length != 0))
            {
                ValuePhantom temp = (ValuePhantom)inputChain[0];
                for (int i = 0; i < temp.Power; i++)
                {
                    Children.Add(new TreeNode(this, temp[i], Table));
                }
            }
        }

        ///<summary>
        /// Рекурсивный метод, осуществляющий декременту вариантов построения в данной ветви.
        /// Также уменьшает количество вариантов данного узла на 1. 
        /// Вызывается после генерации очередного занчения.
        ///</summary>
        ///<returns>Булевый флаг, показывающий нужно ли производить проверку детей
        /// на отсутствие дальнейших вариантов. Если флаг имеет значение false,
        /// то действие не требуется. Если же true, то требуется проверить дочерние элементы 
        /// на наличие возможных вариантов, и удалить детей в которых больше нет вариантов. </returns>
        public override bool Decrement()
        {
            volume--;
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

        ///<summary>
        /// Метод, в котором задаётся длина генерируемой цепочки
        /// и запускается её генерация
        ///</summary>
        ///<returns>Сгенерированная цепочка</returns>
        public BaseChain Generate()
        {
            BaseChain result;
            int len = Table.Length - 1;
            len *= IsString ? 3 : 1;
            result =  new BaseChain(len);
            
            Find(result,Generator,Table);
            return result;
        }
    }
}

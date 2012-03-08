using PhantomChains.Classes.Statistics.MarkovChain.Generators;

namespace PhantomChains.Classes.PhantomChains
{
    ///<summary>
    /// Корневой узел дерева враинтов.
    ///</summary>
    public class TreeTop:ITreeNode
    {
        private PhantomTable Table = null;
        private IGenerator Generator = null;
        private bool IsString = false;

        ///<summary>
        /// Конструктор корневого элемента
        ///</summary>
        ///<param name="InputChain">Исходная цепь дя построения дерева варинтов</param>
        ///<param name="Gen">Генератор </param>
        public TreeTop(BaseChain InputChain, IGenerator Gen)
        {
            Table = new PhantomTable(InputChain);
            Generator = Gen;
            StartPosition = 0;
            volume = Table[0].Volume;
            level = -1;
            if ((Table[1].Content[0] is ValueString) || (Table[1].Content[0] is BaseChain))
            {
                IsString = true;
            }
            if ((InputChain != null) && (InputChain.Length != 0))
            {
                MessagePhantom temp = (MessagePhantom)InputChain[0];
                for (int i = 0; i < temp.power; i++)
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
            BaseChain Result = null;
            if(IsString)
            {
                Result = new BaseChain(3 * (Table.Length - 1));
            }
            else
            {
                Result = new BaseChain(Table.Length - 1);
            }
            
            this.Find(Result,Generator,Table);
            return Result;
        }
    }
}

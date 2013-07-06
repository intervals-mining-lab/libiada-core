using System;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using PhantomChains.Classes.Statistics.MarkovChain.Generators;

namespace PhantomChains.Classes.PhantomChains
{
    ///<summary>
    /// Класс-узел дерева ваиантов
    ///</summary>
    public class TreeNode:AbstractNode
    {
        private IBaseObject id;
        private AbstractNode Parent;


        ///<summary>
        /// Конструктор
        ///</summary>
        ///<param name="parent">Родительский узел</param>
        ///<param name="content">Вариант содержимого соответствующий данному узлу</param>
        ///<param name="table">Таблица с параметрами</param>
        ///<exception cref="Exception">Если родительский элемент не задан, возникает исключение</exception>
        public TreeNode(AbstractNode parent, IBaseObject content, PhantomTable table)
        {
            if (parent != null)
            {
                Parent = parent;
            }
            else
            {
                throw new Exception("Отсутствует родительский элемент в дереве вариантов");
            }
            level = Parent.Level + 1;
            volume = table[level + 1].Volume;
            id = content;
            StartPosition = table.StartPositions[level];
        }

        ///<summary>
        /// Рекурсивый метод уменьшения количества вариантов в данной ветви
        /// и удаления пустых ветвей.
        /// Также уменьшает количество вариантов данного узла на 1.
        ///</summary>
        ///<returns>Флаг говорящий что нужно продолжать поиски пустой ветви</returns>
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
        ///  Метод добавляющий в заполняемую цепочку ещё один элемент
        ///  и вызывающий аналогичный метод у одного из потомков 
        ///  если цепочка заполнена не до конца.
        /// </summary>
        /// <param name="result">Генерируемая цепочка</param>
        /// <param name="generator">Генератор случайных чисел</param>
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
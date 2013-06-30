using System;
using LibiadaCore.Classes.Root.SimpleTypes;

namespace PhantomChains.Classes.PhantomChains
{
    ///<summary>
    /// Запись соответствующая одному уровню дерева варинтов.
    ///</summary>
    public class Record
    {
        ///<summary>
        /// Фантомное сообщение, находящееся в определенной позиции фантомной цепи 
        /// и представляющее варианты содержимого узлов этого же уровня в дереве вариантов.
        ///</summary>
        public ValuePhantom Content = null;
        ///<summary>
        /// Количество варинтов, накопившееся к данному уровню дерева.
        ///</summary>
        public UInt64 Volume;

        ///<summary>
        /// Конструктор.
        ///</summary>
        ///<param name="message">Фантомное сообщение в данной позиции фантомной цепи</param>
        ///<param name="volume">Суммарное количество варинтов построения до данной позиции</param>
        ///<exception cref="Exception">Исключение возникает в слчае отирицательного количества вариантов</exception>
        public Record(ValuePhantom message,UInt64 volume)
        {
            if(message==null)
            {
                throw new Exception();
            }
            Content = message;
            Volume = volume;
        }
    }
}

using System.Collections.Generic;

namespace LibiadaCore.Classes.Root
{
    ///<summary>
    /// Класс отличается от цепи тем что ChainMessagBin содержит только массив объектов. 
    ///</summary>
    public class ChainMessage : Chain, IBaseObject
    {
        ///<summary>
        /// Констуртор
        ///</summary>
        ///<param name="length">Длинна цепи</param>
        public ChainMessage(int length): base(length)
        {
            
        }

        ///<summary>
        /// Не параметризированный конструктор.
        /// Требует вызова после него метода ClearAndSetLength
        /// для инициализации длинны цепи и выделения под него места.
        ///</summary>
        public ChainMessage()
        {
            
        }

        public IBaseObject Clone()
        {
            ChainMessage temp = new ChainMessage(Length);
            FillClone(temp);
            return temp;
        }
    }
}
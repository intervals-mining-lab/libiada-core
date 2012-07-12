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

        ///<summary>
        /// Конструктор загрузки из бина
        ///</summary>
        ///<param name="Bin">Бин ChainMessage</param>
        public ChainMessage(ChainMessageBin Bin):base(Bin.values.Count)
        {
            int pos = 0;
            foreach (IBin item in Bin.values)
            {
                Add(item.GetInstance(), pos);
                pos++;
            }
        }

        public IBaseObject Clone()
        {
            ChainMessage temp = new ChainMessage(Length);
            FillClone(temp);
            return temp;
        }

        
        ///<summary>
        /// Получить бин объекта
        ///</summary>
        ///<returns>Бин</returns>
        public new IBin GetBin()
        {
            ChainMessageBin Temp = new ChainMessageBin();
            FillBin(Temp);
            return Temp;
        }

        ///<summary>
        ///</summary>
        ///<param name="Bin"></param>
        public void FillBin(ChainMessageBin Bin)
        {
            foreach (int position_num in building)
            {
                Bin.values.Add(alphabet[position_num].GetBin());
            }
        }

    }

    ///<summary>
    /// Класс бина ChainMessage
    ///</summary>
    public class ChainMessageBin: IBin
    {
        public List<IBin> values = new List<IBin>();
        ///<summary>
        /// Получение объекта из бина
        ///</summary>
        ///<returns>Объект ChainMessage со стуктурой данных объекта</returns>
        public IBaseObject GetInstance()
        {
            return new ChainMessage(this);
        }
    }
}
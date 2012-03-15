using System;
using System.Collections;
using LibiadaCore.Classes.EventTheory;
using LibiadaCore.Classes.TheoryOfSet;

namespace LibiadaCore.Classes.Root.SimpleTypes
{
    ///<summary>
    /// Фантомное сообщение, хранящее в себе несколько вариантов значений одной позиции.
    ///</summary>
    [Serializable]
    public class ValuePhantom : Alphabet, IBaseObject
    {

        ///<summary>
        /// Конструктор без параметров
        ///</summary>
        public ValuePhantom()
        {
            
        }
        ///<summary>
        ///</summary>
        public ValuePhantom(AlphabetBin Bin) : base(Bin)
        {
        }

        public new IBin GetBin()
        {
            ValuePhantomBin Temp = new ValuePhantomBin();
            FillBin(Temp);
            return Temp;
        }

        /// <summary>
        /// Сравнение фантомного сообщения исходного и заданного в параметре
        /// </summary>
        /// <param name="obj"> фантомное сообщение сравниваемое с исходным</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return
                EqualsAsPhantom(obj as ValuePhantom) || EqualsAsPsevdo(obj as PsevdoValue) ||
                EqualsAsElement(obj as IBaseObject);
        }

        private bool EqualsAsPsevdo(PsevdoValue psevdoValue)
        {
            if (psevdoValue == null)
            {
                return false;
            }
            return power == 0;
        }

        private bool EqualsAsElement(IBaseObject baseObject)
        {
            for (int i = 0; i < power; i++)
            {
                if (IndexOf(baseObject) != -1)
                {
                    return true;
                }
            }
            return false;
        }

        private bool EqualsAsPhantom(ValuePhantom messagePhantom)
        {
            return base.Equals(messagePhantom);
        }

        ///<summary>
        /// Метод добавляет фантомное сообщение к данному, путем объединения.
        /// Все элементы второго объединяемого сообщения, не содержащиеся в первом фантомном сообщении,
        /// добавляются к первому. То есть, происходит пересечение фантомных сообщений, как 
        /// классических множеств результат записывается в первое сообщение.
        ///</summary>
        ///<param name="messagePhantom">Второе сообщение</param>
        public void Add(ValuePhantom messagePhantom)
        {
            if (messagePhantom != null)
            {
                for (int i = 0; i < messagePhantom.power; i++)
                {
                    if (!Contains(messagePhantom[i]))
                    {
                        Add(messagePhantom[i]);
                    }
                }
            }
        }

        /// <summary>
        /// Добавляет объект в фантомное сообщение.
        /// </summary>
        /// <param name="BaseObject">Новый объект</param>
        /// <returns>Индекс нового объекта или -1 если его не удалось добавить</returns>
        public override int Add(IBaseObject BaseObject)
        {
            if (BaseObject != null && !BaseObject.Equals(PsevdoValue.Instance()))
            {
                return base.Add(BaseObject);
            }
            return -1;
        }

        public override string ToString()
        {
            return vault[0].ToString();
        }


        /// <summary>
        /// Метод копирования фантомного сообщения
        /// </summary>
        /// <returns>Копия объекта</returns>
        public new IBaseObject Clone()
        {
            ValuePhantom temp = new ValuePhantom();
            temp.vault = (ArrayList) vault.Clone();
            return temp;
        }
    }

    ///<summary>
    ///</summary>
    public class ValuePhantomBin:AlphabetBin, IBin
    {
        public new IBaseObject GetInstance()
        {
            return new ValuePhantom(this);
        }
    }
}
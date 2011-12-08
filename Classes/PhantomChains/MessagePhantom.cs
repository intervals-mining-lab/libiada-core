using System;
using System.Collections;
using ChainAnalises.Classes.EventTheory;
using ChainAnalises.Classes.Root;
using ChainAnalises.Classes.TheoryOfSet;

namespace ChainAnalises.Classes.PhantomChains
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class MessagePhantom : Alphabet, IBaseObject
    {

        ///<summary>
        ///</summary>
        public MessagePhantom()
        {
            
        }
        ///<summary>
        ///</summary>
        ///<exception cref="NotImplementedException"></exception>
        public MessagePhantom(AlphabetBin Bin) : base(Bin)
        {
        }

        public new IBin GetBin()
        {
            MessagePhantomBin Temp = new MessagePhantomBin();
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
                EqualsAsPhantom(obj as MessagePhantom) || EqualsAsPsevdo(obj as PsevdoValue) ||
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

        private bool EqualsAsPhantom(MessagePhantom messagePhantom)
        {
            /*if (messagePhantom == null)
            {
                return false;
            }
            bool result = false;
            MessagePhantom In;
            MessagePhantom what;

            if (power > messagePhantom.power)
            {
                In = messagePhantom;
                what = this;
            }
            else
            {
                In = this;
                what = messagePhantom;
            }
            for (int i = 0; i < what.power; i++)
            {
                if (In.IndexOf(what[i]) != -1)
                {
                    return true;
                }
            }
            return result;*/
            return base.Equals(messagePhantom);
        }

        ///<summary>
        /// Метод добавляет фантомное сообщение к данному, путем объединения.
        /// Все элементы второго объединяемого сообщения, не содержащиеся в первом фантомном сообщении,
        /// добавляются к первому. То есть, происходит пересечение фантомных сообщений, как 
        /// классических множеств результат записывается в первое сообщение.
        ///</summary>
        ///<param name="messagePhantom">Второе сообщение</param>
        public void Add(MessagePhantom messagePhantom)
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

        public override int Add(IBaseObject BaseObject)
        {
            if (BaseObject != null && !BaseObject.Equals(PsevdoValue.Instance()))
            {
                return base.Add(BaseObject);
            }
            return -1;
        }

        public new IBaseObject Clone()
        {
            MessagePhantom temp = new MessagePhantom();
            temp.vault = (ArrayList) vault.Clone();
            return temp;
        }
    }

    ///<summary>
    ///</summary>
    public class MessagePhantomBin:AlphabetBin, IBin
    {
        public new IBaseObject GetInstance()
        {
            return new MessagePhantom(this);
        }
    }
}
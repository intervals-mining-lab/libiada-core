namespace LibiadaCore.Classes.Root.SimpleTypes
{
    using System.Collections.Generic;

    using LibiadaCore.Classes.TheoryOfSet;

    /// <summary>
    /// Фантомное сообщение, хранящее в себе несколько вариантов значений одной позиции.
    /// </summary>
    public class ValuePhantom : Alphabet, IBaseObject
    {
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

            return EqualsAsPhantom(obj as ValuePhantom) || Equals(obj as NullValue) ||
                   EqualsAsElement(obj as IBaseObject);
        }

        private bool Equals(NullValue nullValue)
        {
            if (nullValue == null)
            {
                return false;
            }
            return Power == 0;
        }

        private bool EqualsAsElement(IBaseObject baseObject)
        {
            for (int i = 0; i < Power; i++)
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

        /// <summary>
        /// Метод добавляет фантомное сообщение к данному, путем объединения.
        /// Все элементы второго объединяемого сообщения, не содержащиеся в первом фантомном сообщении,
        /// добавляются к первому. То есть, происходит пересечение фантомных сообщений, как 
        /// классических множеств результат записывается в первое сообщение.
        /// </summary>
        ///<param name="messagePhantom">Второе сообщение</param>
        public void Add(ValuePhantom messagePhantom)
        {
            if (messagePhantom != null)
            {
                for (int i = 0; i < messagePhantom.Power; i++)
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
        /// <param name="baseObject">Новый объект</param>
        /// <returns>Индекс нового объекта или -1 если его не удалось добавить</returns>
        public override int Add(IBaseObject baseObject)
        {
            if (baseObject != null && !baseObject.Equals(NullValue.Instance()))
            {
                return base.Add(baseObject);
            }
            return -1;
        }

        public override string ToString()
        {
            return Vault[0].ToString();
        }


        /// <summary>
        /// Метод копирования фантомного сообщения
        /// </summary>
        /// <returns>Копия объекта</returns>
        public new IBaseObject Clone()
        {
            var clone = new ValuePhantom {Vault = new List<IBaseObject>(Vault)};
            return clone;
        }
    }
}
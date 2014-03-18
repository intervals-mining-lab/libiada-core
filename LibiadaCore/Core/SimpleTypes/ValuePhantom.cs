namespace LibiadaCore.Core.SimpleTypes
{
    /// <summary>
    /// Фантомное сообщение, хранящее в себе несколько вариантов значений одной позиции.
    /// </summary>
    public class ValuePhantom : Alphabet, IBaseObject
    {
        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="other">
        /// The other element.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool Equals(object other)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.EqualsAsPhantom(other as ValuePhantom) || this.Equals(other as NullValue) ||
                   this.EqualsAsElement(other as IBaseObject);
        }

        /// <summary>
        /// Метод добавляет фантомное сообщение к данному, путем объединения.
        /// Все элементы второго объединяемого сообщения, не содержащиеся в первом фантомном сообщении,
        /// добавляются к первому. То есть, происходит пересечение фантомных сообщений, как 
        /// классических множеств результат записывается в первое сообщение.
        /// </summary>
        /// <param name="messagePhantom">Второе сообщение</param>
        public void Add(ValuePhantom messagePhantom)
        {
            if (messagePhantom != null)
            {
                for (int i = 0; i < messagePhantom.Cardinality; i++)
                {
                    if (!this.Contains(messagePhantom[i]))
                    {
                        this.Add(messagePhantom[i]);
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

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            return this.Elements[0].ToString();
        }

        /// <summary>
        /// Метод копирования фантомного сообщения
        /// </summary>
        /// <returns>Копия объекта</returns>
        public new IBaseObject Clone()
        {
            var clone = new ValuePhantom();
            for (int i = 0; i < this.Elements.Count; i++)
            {
                clone.Add(this.Elements[i]);
            }
            return clone;
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="nullValue">
        /// The null value.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool Equals(NullValue nullValue)
        {
            if (nullValue == null)
            {
                return false;
            }

            return this.Cardinality == 0;
        }

        /// <summary>
        /// The equals as element.
        /// </summary>
        /// <param name="baseObject">
        /// The base object.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool EqualsAsElement(IBaseObject baseObject)
        {
            for (int i = 0; i < this.Cardinality; i++)
            {
                if (this.IndexOf(baseObject) != -1)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// The equals as phantom.
        /// </summary>
        /// <param name="messagePhantom">
        /// The message phantom.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool EqualsAsPhantom(ValuePhantom messagePhantom)
        {
            return base.Equals(messagePhantom);
        }
    }
}
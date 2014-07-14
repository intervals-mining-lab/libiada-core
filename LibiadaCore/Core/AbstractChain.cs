namespace LibiadaCore.Core
{
    using System.Text;

    using LibiadaCore.Core.SimpleTypes;

    /// <summary>
    /// The abstract chain.
    /// </summary>
    public abstract class AbstractChain : IBaseObject
    {
        /// <summary>
        /// Свойстово позволяет получить доступ к элементу цепи по индексу.
        /// В случае выхода за границы цепи вызывается исключение.
        /// </summary>
        /// <param name="index">
        /// Номер элементаю.
        /// </param>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public IBaseObject this[int index]
        {
            get
            {
                return Get(index);
            }

            set
            {
                Add(value, index);
            }
        }

        /// <summary>
        /// The length of chain.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public abstract int GetLength();

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <param name="index">
        /// The index.
        /// </param>
        public abstract void Add(IBaseObject item, int index);

        /// <summary>
        /// Метод позволяющий получить элемент по индексу.
        /// В случае выхода за границы цепи вызывается исключение.
        /// </summary>
        /// <param name="index">
        /// Индекс элемента
        /// </param>
        /// <returns>
        /// Возвращает элемент
        /// </returns>
        public abstract IBaseObject Get(int index);

        /// <summary>
        /// Метод удаляющий элемент с позиции цепи.
        /// В случае выхода за границы цепи вызывается исключение.
        /// </summary>
        /// <param name="index">
        /// Номер позиции.
        /// </param>
        public abstract void RemoveAt(int index);

        /// <summary>
        /// По сути пересоздаёт цепочки, очищая строй и алфавит,
        /// устанавливая новую длину.
        /// </summary>
        /// <param name="length">
        /// Новая длина цепочки.
        /// </param>
        public abstract void ClearAndSetNewLength(int length);

        /// <summary>
        /// The clone.
        /// </summary>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public abstract IBaseObject Clone();

        /// <summary>
        /// Converts chain to string.
        /// Empty positions are filled with <see cref="NullValue"/> ('-' symbol).
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public new string ToString()
        {
            var builder = new StringBuilder();

            for (int i = 0; i < this.GetLength(); i++)
            {
                builder.Append(this[i]);
            }

            return builder.ToString();
        }
    }
}
namespace PhantomChains.PhantomChains
{
    using System;

    using LibiadaCore.Core.SimpleTypes;

    /// <summary>
    /// Запись соответствующая одному уровню дерева варинтов.
    /// </summary>
    public class Record
    {
        /// <summary>
        /// Фантомное сообщение, находящееся в определенной позиции фантомной цепи 
        /// и представляющее варианты содержимого узлов этого же уровня в дереве вариантов.
        /// </summary>
        public readonly ValuePhantom Content;

        /// <summary>
        /// Количество варинтов, накопившееся к данному уровню дерева.
        /// </summary>
        public readonly ulong Volume;

        /// <summary>
        /// Initializes a new instance of the <see cref="Record"/> class.
        /// </summary>
        /// <param name="message">
        /// Фантомное сообщение в данной позиции фантомной цепи
        /// </param>
        /// <param name="volume">
        /// Суммарное количество варинтов построения до данной позиции
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Исключение возникает в слчае отирицательного количества вариантов
        /// </exception>
        public Record(ValuePhantom message, ulong volume)
        {
            if (message == null)
            {
                throw new ArgumentNullException();
            }

            this.Content = message;
            this.Volume = volume;
        }
    }
}
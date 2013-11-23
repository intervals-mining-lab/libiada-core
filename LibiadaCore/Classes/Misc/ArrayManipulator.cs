using System;

namespace LibiadaCore.Classes.Misc
{
    public static class ArrayManipulator
    {
        /// <summary>
        /// Метод для удаления элемента массива вместе с его ячейкой.
        /// </summary>
        /// <typeparam name="T">Тип массива</typeparam>
        /// <param name="source">Исходный массив</param>
        /// <param name="index">Удаляемая ячейка</param>
        /// <returns>Массив на 1 меньшей длины</returns>
        public static T[] DeleteAt<T>(T[] source, int index)
        {
            T[] dest = new T[source.Length - 1];
            if (index > 0)
                Array.Copy(source, 0, dest, 0, index);

            if (index < source.Length - 1)
                Array.Copy(source, index + 1, dest, index, source.Length - index - 1);

            return dest;
        }
    }
}
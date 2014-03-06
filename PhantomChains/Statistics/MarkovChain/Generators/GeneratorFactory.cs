namespace PhantomChains.Statistics.MarkovChain.Generators
{
    using System;

    /// <summary>
    /// Статический класс - фабрика генераторов случайных чисел
    /// </summary>
    public static class GeneratorFactory
    {
        /// <summary>
        /// Метод создающий генератор случайных величин заданного типа
        /// </summary>
        /// <param name="generator">Тип генератора</param>
        /// <returns>
        /// Генератор случайных чисел
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Неизвестный тип генератора вызывает исключение
        /// </exception>
        public static IGenerator Create(GeneratorType generator)
        {
            switch (generator)
            {
                case GeneratorType.SimpleGenerator:
                    return new SimpleGenerator();
                default:
                    throw new ArgumentException("This type of generator does not registered in system", "generator");
            }
        }
    }
}
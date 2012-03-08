using System;

namespace PhantomChains.Classes.Statistics.MarkovChain.Generators
{
    ///<summary>
    /// Статический класс - фабрика генераторов случайных чисел
    ///</summary>
    public static class GeneratorFactory
    {
        ///<summary>
        /// Метод создающий генератор случайных величин заданного типа
        ///</summary>
        ///<param name="generator">Тип генератора</param>
        ///<returns>Генератор случайных чисел</returns>
        ///<exception cref="Exception">Неизвестный тип генератора вызывает исключение</exception>
        public static IGenerator Create(GeneratorType generator)
        {
            switch (generator)
            {
                case GeneratorType.SimpleGenerator:
                    return new SimpleGenerator();
                default:
                    throw new Exception("This type of generator does not registated in system");
            }
        }
    }
}
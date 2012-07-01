namespace LibiadaCore.Classes.Root.Characteristics
{
    public enum BinaryCharacteristicsEnum
    {
        /// <summary>
        /// Среднегеометрическая удалённость между парой элементов
        /// </summary>
        BinaryGeometricMean,

        /// <summary>
        /// Избыточность кодировки второго элемента относительно себя
        /// по сравнению с кодированием относительно первого элемента
        /// </summary>
        Redundancy,

        /// <summary>
        /// K1
        /// Коэффициент частичной зависимости
        /// </summary>
        PartialDependenceCoefficient,
        
        /// <summary>
        /// K2
        /// Степень зависимости одной цепи от другой, 
        /// с учетом «полноты её участия» в составе обеих однородных цепей
        /// </summary>
        InvolvedPartialDependenceCoefficient,
        
        /// <summary>
        /// K3
        /// Коэффициент взаимной зависимости
        /// </summary>
        MutualDependenceCoefficient
    }
}
﻿namespace LibiadaCore.Core.Characteristics
{
    /// <summary>
    /// The binary characteristics enum.
    /// </summary>
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
        /// Нормализованный коэффициент K1
        /// Нормализованный коэффициент частичной зависимости
        /// </summary>
        NormalizedPartialDependenceCoefficient,
        
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
﻿namespace LibiadaCore.Classes.Root.Characteristics.BinaryCalculators
{
    using System.Collections.Generic;

    public interface IBinaryCalculator
    {
        double Calculate(Chain chain, IBaseObject firstElement, IBaseObject secondElement, Link link);

        List<List<double>> Calculate(Chain chain, Link link);

        /// <summary>
        /// Возвращает имя характеристики вычисляемой калькулятором
        /// </summary>
        ///<returns>Имя в виде строки, например Entropy</returns>
        BinaryCharacteristicsEnum GetCharacteristicName();
    }
}
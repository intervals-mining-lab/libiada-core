using System.Collections.Generic;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators.BinaryCalculators
{
    public interface IBinaryCharacteristicCalculator
    {
        double Calculate(Chain chain, IBaseObject firstElement, IBaseObject secondElement, LinkUp linkUp);

        List<List<double>> Calculate(Chain chain, LinkUp linkUp);

        ///<summary>
        /// Возвращает имя характеристики вычисляемой калькулятором
        ///</summary>
        ///<returns>Имя в виде строки, например Entropy</returns>
        BinaryCharacteristicsEnum GetCharacteristicName();
    }
}
namespace ChainAnalises.Classes.IntervalAnalysis.Characteristics.Calculators
{
    ///<summary>
    /// Интерфейс калькулатора
    ///</summary>
    public interface ICharacteristicCalculator
    {
        ///<summary>
        ///</summary>
        ///<param name="pChain"></param>
        ///<param name="Link"></param>
        ///<returns></returns>
        double Calculate(UniformChain pChain, LinkUp Link);

        ///<summary>
        ///</summary>
        ///<param name="pChain"></param>
        ///<param name="Link"></param>
        ///<returns></returns>
        double Calculate(Chain pChain, LinkUp Link);

        ///<summary>
        /// Возвращает имя характеристики вычисляемой калькулятором
        ///</summary>
        ///<returns>Имя в виде строки, например Entropy</returns>
        CharacteristicsEnum GetCharacteristicName();
    }
}
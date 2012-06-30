namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Интерфейс калькулятора
    ///</summary>
    public interface ICharacteristicCalculator
    {
        ///<summary>
        ///</summary>
        ///<param name="chain"></param>
        ///<param name="linkUp"></param>
        ///<returns></returns>
        double Calculate(UniformChain chain, LinkUp linkUp);

        ///<summary>
        ///</summary>
        ///<param name="chain"></param>
        ///<param name="linkUp"></param>
        ///<returns></returns>
        double Calculate(Chain chain, LinkUp linkUp);

        ///<summary>
        /// Возвращает имя характеристики вычисляемой калькулятором
        ///</summary>
        ///<returns>Имя в виде строки, например Entropy</returns>
        CharacteristicsEnum GetCharacteristicName();
    }
}
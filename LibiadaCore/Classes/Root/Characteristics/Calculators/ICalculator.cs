namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// »нтерфейс калькул€тора
    ///</summary>
    public interface ICalculator
    {
        ///<summary>
        /// ¬ычисл€ет и возвращает значение характеристики 
        /// дл€ однородной цеочки.
        ///</summary>
        ///<param name="chain"></param>
        ///<param name="linkUp"></param>
        ///<returns></returns>
        double Calculate(CongenericChain chain, LinkUp linkUp);

        ///<summary>
        /// ¬ычисл€ет и возвращает значение характеристики 
        /// дл€ полной неоднородной цеочки.
        ///</summary>
        ///<param name="chain"></param>
        ///<param name="linkUp"></param>
        ///<returns></returns>
        double Calculate(Chain chain, LinkUp linkUp);

        ///<summary>
        /// ¬озвращает им€ характеристики вычисл€емой калькул€тором
        ///</summary>
        ///<returns>»м€ в виде строки, например Entropy</returns>
        CharacteristicsEnum GetCharacteristicName();
    }
}
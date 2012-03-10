namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// –егул€рность.
    ///</summary>
    public class Regularity : ICharacteristicCalculator
    {
        public double Calculate(UniformChain pChain, LinkUp Link)
        {
            return CommonCalculate(pChain, Link);
        }

        private double CommonCalculate(ChainWithCharacteristic pChain, LinkUp Link)
        {
            double dg = pChain.GetCharacteristic(Link, CharacteristicsFactory.deltaG);
            double D = pChain.GetCharacteristic(Link, CharacteristicsFactory.D);
            return dg/D;
        }

        ///<summary>
        ///</summary>
        ///<param name="pChain"></param>
        ///<param name="Link"></param>
        ///<returns></returns>
        public double Calculate(Chain pChain, LinkUp Link)
        {
            return CommonCalculate(pChain, Link);
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.Regularity;
        }
    }
}
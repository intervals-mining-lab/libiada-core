namespace LibiadaCore.Classes.Root.Characteristics.AuxiliaryInterfaces
{
    ///<summary>
    ///</summary>
    public interface IChainDataForCalculaton:IDataForCalculator
    {
        ///<summary>
        ///</summary>
        ///<param name="i"></param>
        ///<returns></returns>
        UniformChain IUniformChain(int i);
    }
}
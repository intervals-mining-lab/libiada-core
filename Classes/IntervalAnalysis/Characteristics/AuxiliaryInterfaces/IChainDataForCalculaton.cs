using ChainAnalises.Classes.IntervalAnalysis.Characteristics.AuxiliaryInterfaces;

namespace ChainAnalises.Classes.IntervalAnalysis.Characteristics.AuxiliaryInterfaces
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
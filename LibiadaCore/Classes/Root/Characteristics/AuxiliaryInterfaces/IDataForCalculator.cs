using LibiadaCore.Classes.Statistics;

namespace LibiadaCore.Classes.Root.Characteristics.AuxiliaryInterfaces
{
    ///<summary>
    ///</summary>
    public interface IDataForCalculator
    {
        ///<summary>
        ///</summary>
        FrequencyList CommonIntervals { get; }

        ///<summary>
        ///</summary>
        FrequencyList StartInterval { get; }

        ///<summary>
        ///</summary>
        FrequencyList EndInterval { get; }
    }
}
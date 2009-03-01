using ChainAnalises.Classes.DivizionToAccords.AuxiliaryClasses;

namespace ChainAnalises.Classes.DivizionToAccords
{
    public interface Filter
    {
        IDataForStd MakeFilteration(IDataForStd std, int length, int i);
    }
}
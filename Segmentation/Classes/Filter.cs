using Segmentation.Classes.AuxiliaryClasses;

namespace Segmentation.Classes
{
    public interface Filter
    {
        IDataForStd MakeFilteration(IDataForStd std, int length, int i);
    }
}
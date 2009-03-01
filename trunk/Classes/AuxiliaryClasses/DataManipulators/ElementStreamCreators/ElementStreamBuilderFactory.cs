using System;

namespace ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.ElementStreamCreators
{
    ///<summary>
    ///</summary>
    public static class ElementStreamBuilderFactory
    {
        private static ElementStreamCreator TxtStreamCrtr = null;

        ///<summary>
        ///</summary>
        ///<param name="Type"></param>
        ///<returns></returns>
        public static ElementStreamCreator Create(FileType Type)
        {
            switch (Type.GetHashCode())
            {
                case 1054010489:
                    return new TextStreamCreator(); 
                case 1863149665: 
                    return new FonemStreamCreator();
                default:
                    throw new Exception("Wrong StreamCreater");
            }
        }
    }
}
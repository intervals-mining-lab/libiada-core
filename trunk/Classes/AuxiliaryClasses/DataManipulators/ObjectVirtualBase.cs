using System;
using System.Collections;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.SpaceRebuilders;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics.Calculators;
using ChainAnalises.Classes.TheoryOfSet;

namespace ChainAnalises.Classes.AuxiliaryClasses.DataManipulators
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class ObjectVirtualBase<ChainBase> where ChainBase : ChainWithCharacteristic, new()
    {
        protected ChainBase pBuilding;
        public MessageType pMessagesType;

        ///<summary>
        ///</summary>
        ///<param name="Method"></param>
        public virtual void RebuildSpace(SpaceRebuilder<ChainBase, ChainBase> Method)
        {
            pBuilding = Method.Rebuild(pBuilding);
        }

        ///<summary>
        ///</summary>
        ///<param name="ElementStream"></param>
        public virtual void LoadElements(ElementStream ElementStream)
        {
            pBuilding = new ChainBase();
            pBuilding.ClearAndSetNewLength(ElementStream.Count);
            for (int i = 0; i < ElementStream.Count; i++)
            {
                pBuilding[i] = ElementStream[i];
            }
        }



        ///<summary>
        ///</summary>
        public Alphabet Alphabet
        {
            get { return pBuilding.Alpahbet; }
        }

        ///<summary>
        ///</summary>
        public ChainBase Chain
        {
            get
            {
                return (ChainBase) pBuilding.Clone();
            }
        }

        ///<summary>
        ///</summary>
        ///<exception cref="NotImplementedException"></exception>
        public virtual void Calculate()
        {
            pBuilding.CalculateCharacteristicList(CharacteristicsFactory.List);

        }

        ///<summary>
        ///</summary>
        ///<param name="chain"></param>
        public void Load(ChainBase chain)
        {
            pBuilding = (ChainBase) chain.Clone();
        }
    }
}
using System;
using System.Collections;
using ChainAnalises.Classes.DataMining.Clusterization;
using ChainAnalises.Classes.EventTheory;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics;
using ChainAnalises.Classes.PhantomChains;
using ChainAnalises.Classes.Root.SimpleTypes;
using ChainAnalises.Classes.Statistics;
using ChainAnalises.Classes.TheoryOfSet;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.SOAP
{
    ///<summary>
    ///</summary>
    public class Converter
    {
        ///<summary>
        ///</summary>
        ///<param name="temp"></param>
        ///<returns></returns>
        public virtual SoapAlphabetOfChains ToAlphabetChains(AlphabetBin temp)
        {
            SoapAlphabetOfChains Temp = new SoapAlphabetOfChains();
            for (int i = 0; i < temp.Items.Count; i++)
            {
                Temp.Elements.Add(ToMessagePhantomOfChains((MessagePhantomBin)temp.Items[i]));
            }
            return Temp;
        }

        ///<summary>
        ///</summary>
        ///<param name="phantom"></param>
        ///<returns></returns>
        public virtual SoapPhantomMessageOfChains ToMessagePhantomOfChains(MessagePhantomBin phantom)
        {
            SoapPhantomMessageOfChains Temp = new SoapPhantomMessageOfChains();
            for (int i = 0; i < phantom.Items.Count; i++)
            {
                Temp.Messages.Add(ToChainOfValueString((ChainBin)phantom.Items[i]));
            }
            return Temp;
        }


        ///<summary>
        ///</summary>
        ///<param name="bin"></param>
        ///<returns></returns>
        public virtual SoapChainOfValueString ToChainOfValueString(ChainBin bin)
        {
            SoapChainOfValueString Temp = new SoapChainOfValueString();
            FillChainOfValueString(Temp, bin);
            return Temp;
        }

        protected void FillChainOfValueString(SoapChainOfValueString Temp, ChainBin bin)
        {
            FillSoapChainWithCharacteristicOfValueString(Temp, bin);

            for (int i = 0; i < bin.UniformChains.Count; i++)
            {
                Temp.UniformChains.Add(ToUniformChainsOfValueString((UniformChainBin) bin.UniformChains[i]));
            };
        }


        protected void FillSoapChainWithCharacteristicOfValueString(SoapChainWithCharacteristicOfValueString Temp, ChainWithCharacteristicBin bin)
        {
            FillBaseChainOfValueString(Temp, bin);
            for (int i = 0; i < bin.Characteristics.Count; i++)
            {
                Temp.Characteristics.Add(ToCharacteristic((CharacteristicBin)bin.Characteristics[i]));
            }

            Temp.CommonIntervals = ToFrequencyList(bin.CommonIntervals);
            Temp.EndInterval = ToFrequencyList(bin.EndInterval);
            Temp.StartIntervals = ToFrequencyList(bin.StartIntervals);
        }


        protected void FillBaseChainOfValueString(SoapBaseChainOfValueString Temp, BaseChainBin Parent)
        {
            FillSpaceOfValueString(Temp, Parent);
        }


        protected void FillSpaceOfValueString(SoapSpaceOfValueString Temp, SpaceBin bin)
        {
            Temp.Building = (long[])bin.Building.Clone();
            Temp.Alphabet = ToAlphabetValueString(bin.Alphabet);

            for (int i = 0; i < bin.Dimensions.Count; i++)
            {
                Temp.Dimensions.Add(ToDimension((DimensionBin)bin.Dimensions[i]));
            }
        }


        protected SoapChainWithCharacteristicOfValueString ToChainWithCharacteristicOfValueString(ChainWithCharacteristicBin bin)
        {
            SoapChainWithCharacteristicOfValueString Temp = new SoapChainWithCharacteristicOfValueString();
            FillBaseChainOfValueString(Temp, bin);
            return Temp;
        }

        protected SoapBaseChainOfValueString ToBaseChainOfValueString(BaseChainBin bin)
        {
            SoapBaseChainOfValueString Temp = new SoapBaseChainOfValueString();
            FillBaseChainOfValueString(Temp,bin);
            return Temp;
        }


        protected SoapSpaceOfValueString ToSpaceOfValueString(BaseChainBin bin)
        {
            SoapSpaceOfValueString Temp = new SoapSpaceOfValueString();
            FillSpaceOfValueString(Temp,bin);
            return Temp;
            
        }

        protected SoapUniformChainOfValueString ToUniformChainsOfValueString(UniformChainBin bin)
        {
           SoapUniformChainOfValueString Temp = new SoapUniformChainOfValueString();
           FillSoapChainWithCharacteristicOfValueString(Temp,bin);
           Temp.Message = ToValueString((ValueStringBin) bin.Message);
           return Temp;
        }

        protected SoapFrequencyList ToFrequencyList(FrequencyListBin bin)
        {
            SoapFrequencyList Temp = new SoapFrequencyList();
            for (int i = 0; i < bin.Elements.Count; i++)
            {
                Temp.Elements.Add(ToFrequencyListItem((FrequencyListItemBin) bin.Elements[i]));
            }
            return Temp;
        }

        protected SoapFrequencyListItem ToFrequencyListItem(FrequencyListItemBin bin)
        {
            SoapFrequencyListItem Temp = new SoapFrequencyListItem();
            Temp.Key = ((ValueIntBin)bin.Key).Value.ToString();
            Temp.Value = ((ValueIntBin) bin.Value).Value.ToString();
            return Temp;
        }
        
        protected SoapCharacteristic ToCharacteristic(CharacteristicBin bin)
        {
            SoapCharacteristic Temp = new SoapCharacteristic();
            Temp.Start = bin.StartValue;
            Temp.End = bin.EndValue;
            Temp.Both = bin.BothValue;
            Temp.Type = bin.Type.GetType().ToString();
            return Temp;
        }

        protected SoapDimension ToDimension(DimensionBin bin)
        {
            SoapDimension Temp  = new SoapDimension();
            Temp.Max = bin.Max;
            Temp.Min = bin.Min;
            return Temp;
        }

        protected SoapAlphabetOfValueString ToAlphabetValueString(AlphabetBin alphabet)
        {
            SoapAlphabetOfValueString Temp = new SoapAlphabetOfValueString();
            for (int i = 0; i < alphabet.Items.Count; i++)
            {
                Temp.Elements.Add(ToValueString((ValueStringBin)alphabet.Items[i]));
            }
            return Temp;
        }

        protected SoapPhantomMessageOfValueString ToMessagePhantomOfValueString(MessagePhantomBin bin)
        {
            SoapPhantomMessageOfValueString Temp = new SoapPhantomMessageOfValueString();
            for (int i = 0; i < bin.Items.Count; i++)
            {
                Temp.Messages.Add(ToValueString((ValueStringBin)bin.Items[i]));
            }
            return Temp;
        }

        ///<summary>
        ///</summary>
        ///<param name="bin"></param>
        ///<returns></returns>
        public virtual SoapValueString ToValueString(ValueStringBin bin)
        {
            SoapValueString temp = new SoapValueString();
            temp.Value = bin.value.ToString();
            return temp;
        }

        ///<summary>
        ///</summary>
        ///<param name="bin"></param>
        ///<returns></returns>
        public SoapChainOfChains ToChainOfChains(ChainBin bin)
        {
            SoapChainOfChains Temp = new SoapChainOfChains();
            FillChainOfChains(Temp, bin);
            return Temp;
        }

        private void FillChainOfChains(SoapChainOfChains Temp, ChainBin bin)
        {
            FillSoapChainWithCharacteristicOfChains(Temp, bin);

            for (int i = 0; i < bin.UniformChains.Count; i++)
            {
                Temp.UniformChains.Add(ToUniformChainsOfChains((UniformChainBin)bin.UniformChains[i]));
            };
        }

        private void FillSoapChainWithCharacteristicOfChains(SoapChainWithCharacteristicOfChains Temp, ChainWithCharacteristicBin bin)
        {
            FillBaseChainOfChains(Temp, bin);
            for (int i = 0; i < bin.Characteristics.Count; i++)
            {
                Temp.Characteristics.Add(ToCharacteristic((CharacteristicBin)bin.Characteristics[i]));
            }

            Temp.CommonIntervals = ToFrequencyList(bin.CommonIntervals);
            Temp.EndInterval = ToFrequencyList(bin.EndInterval);
            Temp.StartIntervals = ToFrequencyList(bin.StartIntervals);
        }

        private void FillBaseChainOfChains(SoapBaseChainOfChains Temp, BaseChainBin bin)
        {
            FillSpaceOfChains(Temp, bin);
        }

        private void FillSpaceOfChains(SoapSpaceOfChains Temp, SpaceBin bin)
        {
            Temp.Building = (long[])bin.Building.Clone();
            Temp.Alphabet = ToAlphabetChains(bin.Alphabet);

            for (int i = 0; i < bin.Dimensions.Count; i++)
            {
                Temp.Dimensions.Add(ToDimension((DimensionBin)bin.Dimensions[i]));
            }
        }

        private SoapUniformChainOfChains ToUniformChainsOfChains(UniformChainBin bin)
        {
            SoapUniformChainOfChains Temp = new SoapUniformChainOfChains();
            FillSoapChainWithCharacteristicOfChains(Temp, bin);
            Temp.Message = ToMessagePhantomOfChains((MessagePhantomBin) bin.Message);
            return Temp;
        }

        ///<summary>
        ///</summary>
        ///<param name="chain"></param>
        ///<returns></returns>
        ///<exception cref="NotImplementedException"></exception>
        public ChainBin ToChainBin(SoapChainOfChains chain)
        {
            ChainBin Temp = new ChainBin();
            ToChainBin(chain, Temp);
            return Temp;
        }

        private void ToChainBin(SoapChainOfChains chain, ChainBin Temp)
        {
            ToChainWithCharacteristicBin(chain, Temp);
            for (int i = 0; i < chain.UniformChains.Count; i++)
            {
               Temp.UniformChains.Add(ToUniformChainBin((SoapUniformChainOfChains)chain.UniformChains[i]));
            }
        }

        private void ToChainWithCharacteristicBin(SoapChainWithCharacteristicOfChains chain, ChainWithCharacteristicBin temp)
        {
            ToBaseChainBin(chain, temp);
            temp.StartIntervals = ToFrequencyListBin(chain.StartIntervals);
            temp.CommonIntervals = ToFrequencyListBin(chain.CommonIntervals);
            temp.EndInterval = ToFrequencyListBin(chain.EndInterval);

            for (int i = 0; i < chain.Characteristics.Count; i++)
            {
                temp.Characteristics.Add(ToCharacteristicBin((SoapCharacteristic)chain.Characteristics[i]));
            }
        }

        private void ToBaseChainBin(SoapBaseChainOfChains chain, BaseChainBin temp)
        {
            ToSpaceBin(chain, temp);
        }

        private void ToSpaceBin(SoapSpaceOfChains chain, SpaceBin temp)
        {
            temp.Alphabet = ToAlphabetBin(chain.Alphabet);
            temp.Building = ToBuildingBin(chain.Building);
            for (int i = 0; i < chain.Dimensions.Count; i++)
            {
                temp.Dimensions.Add(ToDimensionBin((SoapDimension)chain.Dimensions[i]));
            }
        }

        private DimensionBin ToDimensionBin(SoapDimension dimension)
        {
            DimensionBin Temp = new DimensionBin();
            Temp.Max = dimension.Max;
            Temp.Min = dimension.Min;
            return Temp;
        }

        private long[] ToBuildingBin(long[] building)
        {
            return (long[]) building.Clone();
        }

        private AlphabetBin ToAlphabetBin(SoapAlphabetOfChains alphabet)
        {
            AlphabetBin Temp = new AlphabetBin();
            for (int i = 0; i < alphabet.Elements.Count; i++)
            {
                Temp.Items.Add(ToPhantomMessageBin((SoapPhantomMessageOfChains)alphabet.Elements[i]));
            }
            return Temp;
        }

        private MessagePhantomBin ToPhantomMessageBin(SoapPhantomMessageOfChains chains)
        {
            MessagePhantomBin Temp = new MessagePhantomBin();
            for (int i = 0; i < chains.Messages.Count; i++)
            {
                Temp.Items.Add(ToChainBin((SoapChainOfValueString)chains.Messages[i]));
            }
            return Temp;
        }

        private ChainBin ToChainBin(SoapChainOfValueString chain)
        {
            ChainBin Temp = new ChainBin();
            ToChainBin(chain, Temp);
            return Temp;
        }

        private void ToChainBin(SoapChainOfValueString chain, ChainBin Temp)
        {
            ToChainWithCharacteristicBin(chain, Temp);
            for (int i = 0; i < chain.UniformChains.Count; i++)
            {
                Temp.UniformChains.Add(ToUniformChainBin((SoapUniformChainOfValueString)chain.UniformChains[i]));
            }
        }

        private void ToChainWithCharacteristicBin(SoapChainWithCharacteristicOfValueString chain, ChainWithCharacteristicBin temp)
        {
            ToBaseChainBin(chain, temp);
            temp.StartIntervals = ToFrequencyListBin(chain.StartIntervals);
            temp.CommonIntervals = ToFrequencyListBin(chain.CommonIntervals);
            temp.EndInterval = ToFrequencyListBin(chain.EndInterval);

            for (int i = 0; i < chain.Characteristics.Count; i++)
            {
                temp.Characteristics.Add(ToCharacteristicBin((SoapCharacteristic)chain.Characteristics[i]));
            }
        }

        private void ToBaseChainBin(SoapBaseChainOfValueString chain, BaseChainBin temp)
        {
            ToSpaceBin(chain, temp);
        }

        private void ToSpaceBin(SoapSpaceOfValueString chain, SpaceBin temp)
        {
            temp.Alphabet = ToAlphabetBin(chain.Alphabet);
            temp.Building = ToBuildingBin(chain.Building);
            for (int i = 0; i < chain.Dimensions.Count; i++)
            {
                temp.Dimensions.Add(ToDimensionBin((SoapDimension)chain.Dimensions[i]));
            }
        }

        private AlphabetBin ToAlphabetBin(SoapAlphabetOfValueString alphabet)
        {
            AlphabetBin Temp = new AlphabetBin();
            for (int i = 0; i < alphabet.Elements.Count; i++)
            {
                Temp.Items.Add(ToValueStringBin((SoapValueString)alphabet.Elements[i]));
            }
            return Temp;
        }

        private ValueStringBin ToValueStringBin(SoapValueString ValueString)
        {
            ValueStringBin Temp = new ValueStringBin();
            Temp.value = ValueString.Value;
            return Temp;
        }


        private CharacteristicBin ToCharacteristicBin(SoapCharacteristic characteristic)
        {
            
            CharacteristicBin Temp = new CharacteristicBin();
            Temp.Type = CharacteristicsFactory.Create(characteristic.Type);
            Temp.StartValue = characteristic.Start;
            Temp.EndValue = characteristic.End;
            Temp.BothValue = characteristic.Both;
            return Temp;
        }

        private FrequencyListBin ToFrequencyListBin(SoapFrequencyList intervals)
        {
            FrequencyListBin Temp  = new FrequencyListBin();
            for (int i = 0; i < intervals.Elements.Count; i++)
            {
                Temp.Elements.Add(ToFrequencyListItemBin((SoapFrequencyListItem)intervals.Elements[i]));
            }
            return Temp;
        }

        private FrequencyListItemBin ToFrequencyListItemBin(SoapFrequencyListItem item)
        {
            FrequencyListItemBin Temp = new FrequencyListItemBin();
            Temp.Key = new ValueIntBin(Convert.ToInt32(item.Key));
            Temp.Value = new ValueIntBin(Convert.ToInt32(item.Value));
            return Temp;
        }

        private UniformChainBin ToUniformChainBin(SoapUniformChainOfValueString ValueString)
        {
            UniformChainBin Temp = new UniformChainBin();
            ToChainWithCharacteristicBin(ValueString, Temp);
            return Temp;
        }

        private UniformChainBin ToUniformChainBin(SoapUniformChainOfChains chains)
        {
            UniformChainBin Temp = new UniformChainBin();
            ToChainWithCharacteristicBin(chains, Temp);
            return Temp;
        }

        ///<summary>
        ///</summary>
        ///<param name="Data"></param>
        ///<returns></returns>
        public DataTableBin ToDataTableBin(SoapDataTable Data)
        {
            DataTableBin Temp = new DataTableBin();
            foreach (SoapDataObject obj in Data.Objects)
            {
                DataObjectBin ob = ToDataObjectBin(obj);
                Temp.Objects.Add(new DictionaryEntry(ob.id, ob));
            }
            return Temp;
        }

        private DataObjectBin ToDataObjectBin(SoapDataObject obj)
        {
            DataObjectBin Temp = new DataObjectBin();
            Temp.id = obj.id;
            foreach (SoapDataCharacteristic bin in obj.vault)
            {
                Temp.vault.Add(new DictionaryEntry(bin.Key, bin.Value));
            }
            return Temp;
        }

        ///<summary>
        ///</summary>
        ///<param name="bin"></param>
        ///<returns></returns>
        public SoapClusterizationVaraints ToSoapClusteriztionVariants(ClustarizationVariantsBin bin)
        {
            SoapClusterizationVaraints Temp = new SoapClusterizationVaraints();
            foreach (ClustarizationResultBin variant in bin.Variants)
            {
                Temp.Variants.Add(ToSoapClusteriztionResults(variant));
            }
            return Temp;
        }

        private SoapClusterizationResult ToSoapClusteriztionResults(ClustarizationResultBin bin)
        {
            SoapClusterizationResult Temp = new SoapClusterizationResult();
            Temp.Quality = bin.Quality;
            foreach (ClusterBin cluster in bin.Clusters)
            {
                Temp.Clusters.Add(ToSoapCluster(cluster));
            }
            return Temp;
        }

        private SoapCluster ToSoapCluster(ClusterBin bin)
        {
            SoapCluster Temp  = new SoapCluster();
            Temp.Items = (ArrayList) bin.Items.Clone();
            return Temp;
        }
    }
}
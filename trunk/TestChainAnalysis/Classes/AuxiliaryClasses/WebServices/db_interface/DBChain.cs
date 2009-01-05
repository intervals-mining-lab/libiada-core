using System.Collections;
using ChainAnalises.Classes.AuxiliaryClasses.DBInterface;

namespace TestChainAnalysis.Classes.AuxiliaryClasses.WebServices.db_interface
{
    public class DBChain : Node
    {
        private DBAlphabet private_alphabet;
        private DBBuilding private_building;
        private ArrayList private_characteristics;
        private DBFrequencyList private_common_intervals;
        private DBFrequencyList private_end_intervals;
        private long private_length;
        private DBFrequencyList private_start_intervals;
        private ArrayList private_uniformchains;

        public virtual DBAlphabet alphabet
        {
            get { return private_alphabet; }
            set { private_alphabet = value; }
        }

        public virtual DBBuilding building
        {
            get { return private_building; }
            set { private_building = value; }
        }

        public virtual ArrayList characteristics
        {
            get { return private_characteristics; }
            set { private_characteristics = value; }
        }

        public virtual DBFrequencyList common_intervals
        {
            get { return private_common_intervals; }
            set { private_common_intervals = value; }
        }

        public virtual DBFrequencyList start_intervals
        {
            get { return private_start_intervals; }
            set { private_start_intervals = value; }
        }

        public virtual DBFrequencyList end_intervals
        {
            get { return private_end_intervals; }
            set { private_end_intervals = value; }
        }

        public virtual ArrayList uniformchains
        {
            get { return private_uniformchains; }
            set { private_uniformchains = value; }
        }

        public virtual long length
        {
            get { return private_length; }
            set { private_length = value; }
        }
    }
}
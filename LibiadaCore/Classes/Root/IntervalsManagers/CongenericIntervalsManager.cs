namespace LibiadaCore.Classes.Root.IntervalsManagers
{
    using System.Linq;

    using LibiadaCore.Classes.Misc;

    public class CongenericIntervalsManager : IntervalsManager
    {
        private readonly int[] building;
        public CongenericIntervalsManager(CongenericChain chain)
        {
            building = chain.Building;
            int count = building.Count(b => b.Equals(1));
            Intervals = new int[count - 1];
            FillIntervals();
        }

        private void FillIntervals()
        {
            //Geting all occurrences of element in building.
            int[] indexes = ArrayManipulator.AllIndexesOf(building, 1);

            Start = indexes[0] - 0;

            for (int i = 0; i < Intervals.Length; i++)
            {
                Intervals[i] = indexes[i + 1] - indexes[i];
            }

            End = building.Length - indexes[indexes.Length - 1];
        }
    }
}

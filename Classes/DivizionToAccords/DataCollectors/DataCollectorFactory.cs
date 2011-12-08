namespace ChainAnalises.Classes.DivizionToAccords
{
    public static class DataCollectorFactory
    {
        public static IDataCollector Create(int length)
        {
            if (length == 0)
            {
                return new NullDataCollector();
            }

            return new DataCollector();
        }
    }
}
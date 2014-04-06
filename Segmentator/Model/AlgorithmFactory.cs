namespace Segmentator.Model
{
    public static class AlgorithmFactory
    {
        public static Algorithm Make(int index, Input input)
        {
            switch (index)
            {
                case 0: return new AlgorithmBase(input);
                case 1: return null;
            }

            return null;
        } 
    }
}
namespace Segmentation.Classes.Model
{
    public class AlgorithmFactory
    {
        public static Algorithm make(int index, Input input)
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
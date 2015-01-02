namespace LibiadaMusic.ScoreModel
{
    using System;

    /// <summary>
    /// The duration type.
    /// </summary>
    public static class DurationType
    {
        /// <summary>
        /// The parse type.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="int[]"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public static int[] ParseType(string type)
        {
            // формируем массив из 2 элементов Numerator и Denominator по типу длительности
            var numDenom = new int[2]; 
            switch (type)
            {
                case "whole":
                    numDenom[0] = 1;
                    numDenom[1] = 1;
                    break;
                case "half":
                    numDenom[0] = 1;
                    numDenom[1] = 2;
                    break;
                case "quarter":
                    numDenom[0] = 1;
                    numDenom[1] = 4;
                    break;
                case "eighth":
                    numDenom[0] = 1;
                    numDenom[1] = 8;
                    break;
                case "16th":
                    numDenom[0] = 1;
                    numDenom[1] = 16;
                    break;
                case "32nd": // в Guiter Pro обозначается 32th - как 1/32.. мде..
                case "32th":
                    numDenom[0] = 1;
                    numDenom[1] = 32;
                    break;
                case "64th":
                    numDenom[0] = 1;
                    numDenom[1] = 64;
                    break;
                case "128th":
                    numDenom[0] = 1;
                    numDenom[1] = 128;
                    break;
                case "256th":
                    numDenom[0] = 1;
                    numDenom[1] = 256;
                    break;
                default:
                    throw new Exception("LibiadaMusic.ScoreModel: Error unknown duration type!");
            }

            return numDenom;
        }
    }
}

//====================================================
//| Downloaded From                                  |
//| Visual C# Kicks - http://www.vcskicks.com/       |
//| License - http://www.vcskicks.com/license.html   |
//====================================================

using System;
using System.Collections;
using System.Collections.Generic;

namespace BuildingsIterator.Classes
{
    class ConvertArray
    {
        public static string ArrayToString(IList array)
        {
            return ArrayToString(array, Environment.NewLine);
        }

        public static string ArrayToString(IList array, string delimeter)
        {
            string outputString = "";

            for (int i = 0; i < array.Count; i++)
            {
                if (array[i] is IList)
                {
                    outputString += ArrayToString((IList)array[i], delimeter);
                }
                else
                {
                    outputString += array[i];
                }
            }

            return outputString;
        }



        public static string ArrayToStringGeneric<T>(IList<T> array)
        {
            return ArrayToStringGeneric(array, Environment.NewLine);
        }

        public static string ArrayToStringGeneric<T>(IList<T> array, string delimeter)
        {
            string outputString = "";

            for (int i = 0; i < array.Count; i++)
            {
                if (array[i] is IList)
                {
                    outputString += ArrayToString((IList)array[i], delimeter);
                }
                else
                {
                    outputString += array[i];
                }

                if (i != array.Count - 1)
                    outputString += delimeter;
            }

            return outputString;
        }
    }
}

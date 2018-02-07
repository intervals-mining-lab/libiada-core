﻿namespace LibiadaCore.Core.SimpleTypes
{
    using System;
    using System.IO.Compression;

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
        /// The <see cref="T:int[]"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if type is unknown.
        /// </exception>
        public static (int, int) ParseType(string type)
        {
            // формируем массив из 2 элементов Numerator и Denominator по типу длительности
            int numerator;
            int denominator;
            switch (type)
            {
                case "whole":
                    numerator = 1;
                    denominator = 1;
                    break;
                case "half":
                    numerator = 1;
                    denominator = 2;
                    break;
                case "quarter":
                    numerator = 1;
                    denominator = 4;
                    break;
                case "eighth":
                    numerator = 1;
                    denominator = 8;
                    break;
                case "16th":
                    numerator = 1;
                    denominator = 16;
                    break;
                case "32nd": // в Guitar Pro обозначается 32th - как 1/32.. мде..
                case "32th":
                    numerator = 1;
                    denominator = 32;
                    break;
                case "64th":
                    numerator = 1;
                    denominator = 64;
                    break;
                case "128th":
                    numerator = 1;
                    denominator = 128;
                    break;
                case "256th":
                    numerator = 1;
                    denominator = 256;
                    break;
                default:
                    throw new InvalidOperationException($"Unknown duration type {type}");
            }

            return (numerator, denominator);
        }
    }
}

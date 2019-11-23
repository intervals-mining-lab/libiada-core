namespace LibiadaCore.Tests.DataTransformers
{
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.DataTransformers;

    using NUnit.Framework;

    
    [TestFixture]
    public class OrderGeneratorTests
    {
        private static readonly int[][] Expected1 =
        {
            new int[] { 0, 1 },
            new int[] { 1, 0 },
        };

        private static readonly int[][] Expected2 =
        {
            new int[] { 0, 1, 2 },
            new int[] { 0, 2, 1 },
            new int[] { 1, 2, 0 },
            new int[] { 1, 0, 2 },
            new int[] { 2, 0, 1 },
            new int[] { 2, 1, 0 },
        };

        [Test]
        public void LengthTest1()
        {
            var result = OrderGenerator.GetOrders(2);
            Assert.AreEqual(Expected1.Length, result.Length);
        }
        [Test]
        public void LengthTest2()
        {
            var result = OrderGenerator.GetOrders(3);
            Assert.AreEqual(Expected2.Length, result.Length);
        }
        [Test]
        public void GetOrdersTest1()
        {
            string expected = "";
            string result = "";
            var resultArray = OrderGenerator.GetOrders(2);

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    result += resultArray[i][j].ToString();
                    expected += Expected1[i][j].ToString();
                }
            }
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void GetOrdersTest2()
        {
            string expected = "";
            string result = "";
            var resultArray = OrderGenerator.GetOrders(3);

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    result += resultArray[i][j].ToString();
                    expected += Expected2[i][j].ToString();
                }
            }
            Assert.AreEqual(expected, result);
        }

    }
}

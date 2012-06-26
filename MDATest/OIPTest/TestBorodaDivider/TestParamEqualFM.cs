using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MDA.OIP.BorodaDivider;

namespace MDATest.OIPTest.TestBorodaDivider
{
    [TestClass]
    public class TestParamEqualFM
    {
        [TestMethod]
        public void TestParamEqual1()
        {
            Assert.AreEqual(ParamEqualFM.Sequent, 0);
            Assert.AreEqual(ParamEqualFM.NonSequent, 1);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Arita.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arita.Helpers.Tests
{
    [TestClass()]
    public class AritaConvertHelperTests
    {
        [TestMethod()]
        public void GetLocalTimeFromUtcTimeSpanTest()
        {
            Assert.AreEqual("20060822", 1156219870.GetLocalTimeFromUtcTimeSpan().ToString("yyyyMMdd"));
        }
    }
}
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
    public class AritaPinYinHelperTests
    {
        [TestMethod()]
        public void GetPinYinListTest()
        {
            CollectionAssert.AreEqual(new List<string> { "JI$GUAI", "QI$GUAI" }, AritaPinYinHelper.GetPinYinList("奇怪"));
            CollectionAssert.AreEqual(new List<string> { "*$S$T$ER$CHONG", "*$S$T$ER$ZHONG" }, AritaPinYinHelper.GetPinYinList("*st二重"));
        }

        [TestMethod()]
        public void GetPinYinFullListTest()
        {
            CollectionAssert.AreEqual(new List<string> { "JIGUAI", "QIGUAI" }, AritaPinYinHelper.GetPinYinFullList("奇怪"));
            CollectionAssert.AreEqual(new List<string> { "*STERCHONG", "*STERZHONG" }, AritaPinYinHelper.GetPinYinFullList("*st二重"));
        }

        [TestMethod()]
        public void GetPinYinInitialListTest()
        {
            CollectionAssert.AreEqual(new List<string> { "JG", "QG" }, AritaPinYinHelper.GetPinYinInitialList("奇怪"));
            CollectionAssert.AreEqual(new List<string> { "*STEC", "*STEZ" }, AritaPinYinHelper.GetPinYinInitialList("*st二重"));
        }
    }
}
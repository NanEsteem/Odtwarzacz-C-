using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OdtwarzaczTest
{
    [TestClass]
    public class OdtwarzaczTest
    {
        private string filename;

        [TestMethod]
        public void TestMethod1()
        {

            BtLadFile_Click getter = new BtLadFile_Click();
            getter.filename = "C:\renaimp.mp3";

            BtLadFile_Click bad = new BtLadFile_Click();
            bad.filename = "C:\ress.bat";

            Assert.IsFalse(getter.MessageBox.Show);
            Assert.IsTrue(bad.MessageBox.Show);

        }
    }
}
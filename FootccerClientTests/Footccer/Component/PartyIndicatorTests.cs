using Microsoft.VisualStudio.TestTools.UnitTesting;
using FootccerClient.Footccer.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootccerClient.Footccer.Component.Tests
{
    [TestClass()]
    public class PartyIndicatorTests
    {
        [TestMethod()]
        public void PartyIndicatorTest()
        {
            Panel testPanel = new Panel();

            int pWidth, pHeight, iHeight;
            GetRandomizedWidthHeight(out pWidth, out pHeight, out iHeight);

            testPanel.Size = new System.Drawing.Size(pWidth, pHeight);

            var CategoryIndicator = new PartyIndicator(iHeight, testPanel);

            Assert.AreEqual(CategoryIndicator.Height, iHeight);
            Assert.AreEqual(CategoryIndicator.Width, pWidth);
        }

        private void GetRandomizedWidthHeight(out int pWidth, out int pHeight, out int iHeight)
        {
            Random random = new Random();
            (pWidth, pHeight, iHeight) = (random.Next(100) + 1, random.Next(100) + 1, random.Next(50) + 1);
            Console.WriteLine(
                $"pWidth : {pWidth}\r\n" +
                $"pHeight : {pHeight}\r\n" +
                $"iHeight : {iHeight}");
        }
    }
}
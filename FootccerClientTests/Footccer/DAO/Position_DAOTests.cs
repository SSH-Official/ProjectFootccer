using Microsoft.VisualStudio.TestTools.UnitTesting;
using FootccerClient.Footccer.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootccerClientTests.Footccer;
using FootccerClient.Footccer.DAO.Base;

namespace FootccerClient.Footccer.DAO.Tests
{
    [TestClass()]
    public class Position_DAOTests : TestClass<Position_DAO, DAO_Base>
    {
        [TestMethod()]
        public void getPositionListTest()
        {
            var list = TheClass.getPositionList();

            Assert.IsTrue(list.Count > 0);
        }
    }
}
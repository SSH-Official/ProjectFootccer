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
    public class Position_DAOTests : TestClass_Custom<Position_DAO>
    {
        [TestMethod()]
        public void getPositionListTest()
        {
            Console.WriteLine("DB에서 Position 값들을 읽어오는지 테스트합니다.");

            var list = TheClass.getPositionList();

            Assert.IsTrue(list.Count > 0);
        }
    }
}
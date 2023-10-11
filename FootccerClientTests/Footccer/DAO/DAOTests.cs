using FootccerClient.Footccer.DAO.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.DAO.Tests
{
    [TestClass()]
    public class DAOTests : DAO_Base
    {
        [TestMethod()]
        public void TestDBConnection()
        {
            Console.WriteLine($"DB 질의문이 제대로 실행되는지 체크합니다.");
            int testResult = Read_Number1();
            
            Assert.AreEqual(1, testResult);
        }

        private int Read_Number1() => ExecuteTransaction((cmd) =>
        {
            cmd.CommandText = "SELECT 1;";
            return Convert.ToInt32(cmd.ExecuteScalar());
        });

        [TestMethod()]
        public void TestMultipleConnection()
        {
            int repeats = 10;
            Console.WriteLine($"DB 연결을 연속해서 {repeats}회 실행합니다.");
            
            for (int i = 0; i < repeats; i++)
            {
                Assert.AreEqual(1, Read_Number1());
            }

            Assert.IsTrue(true);
        }

    }
}

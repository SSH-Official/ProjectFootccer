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
    public class DBLogin_DAOTests : TestClass_Custom<DBLogin_DAO>
    {
        [TestMethod()]
        public void CheckLoginSuccessTest()
        {
            string testID = "ssh";
            string testPassword = "1234";
            var user = new UserCredentialDTO(testID, testPassword);

            Console.WriteLine($"테스트 계정 {{{user.ID} / {user.Password}}} 으로 로그인이 되는 지 테스트합니다.");

            Assert.AreEqual(true, TheClass.CheckLoginSuccess(user));
        }
    }
}
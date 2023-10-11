using Microsoft.VisualStudio.TestTools.UnitTesting;
using FootccerClient.Footccer.DTO.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootccerClientTests.Footccer;
using FootccerClient.Footccer.Util;

namespace FootccerClient.Footccer.DTO.Builder.Tests
{
    [TestClass()]
    public class UserInfoDTOBuilderTests 
    {
        [TestMethod()]
        public void BuildTest_NoArguments()
        {
            var Builder = new UserInfoDTOBuilder();
            var UserInfo = Builder.Build();

            Console.WriteLine(UserInfo);
            Assert.AreEqual(UserInfo.User, null);
            Assert.AreEqual(UserInfo.Name, null);
            Assert.AreEqual(UserInfo.Gender, null);
            Assert.AreEqual(UserInfo.Contact, null);
            Assert.AreEqual(UserInfo.Email, null);
            Assert.AreEqual(UserInfo.Birth, null);
            Assert.AreEqual(UserInfo.Prefer, null);            
            Assert.AreEqual(UserInfo.Image, null);
        }

        [TestMethod()]
        public void BuildTest_WithArguments()
        {
            var Image = new ImageMaker();
            var Builder = new UserInfoDTOBuilder();
            var UserInfo = Builder
                .SetUser(new UserDTO(77, "ID"))
                .SetName("Name")
                .SetGender("Male")
                .SetContact("010-0000-0000")
                .SetEmail("sample@email.com")
                .SetPrefer(new PreferenceDTO(
                    new CityDTO(66, "대구"),
                    new ActivityDTO(55, "축구!!")
                    ))
                .SetImage(Image.GetImageFromURL("https://t1.daumcdn.net/friends/prod/editor/dc8b3d02-a15a-4afa-a88b-989cf2a50476.jpg"))
                .Build();

            Console.WriteLine(UserInfo);
            Assert.AreEqual(UserInfo.User.Index, 77);
            Assert.AreEqual(UserInfo.User.ID, "ID");
            Assert.AreEqual(UserInfo.Name, "Name");
            Assert.AreEqual(UserInfo.Gender, "Male");
            Assert.AreEqual(UserInfo.Contact, "010-0000-0000");
            Assert.AreEqual(UserInfo.Email, "sample@email.com");
            Assert.AreEqual(UserInfo.Birth, null);
            Assert.AreEqual(UserInfo.Prefer.City.Index, 66);
            Assert.AreEqual(UserInfo.Prefer.City.Name, "대구");
            Assert.AreEqual(UserInfo.Prefer.Activity.Index, 55);
            Assert.AreEqual(UserInfo.Prefer.Activity.Name, "축구!!");
            Assert.AreEqual(UserInfo.Image, Image.GetImageFromURL("https://t1.daumcdn.net/friends/prod/editor/dc8b3d02-a15a-4afa-a88b-989cf2a50476.jpg"));
        }
    }
}
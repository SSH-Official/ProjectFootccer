using Microsoft.VisualStudio.TestTools.UnitTesting;
using FootccerClient.Footccer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Remoting.Messaging;

namespace FootccerClient.Footccer.Util.Tests
{
    [TestClass()]
    public class ImageMakerTests
    {
        [TestMethod()]
        public void GetImageFromURLTest()
        {
            ImageMaker im = new ImageMaker();
            List<string> urls = new List<string>
            {
                "https://static.wikia.nocookie.net/pokemon/images/5/57/%EC%9D%B4%EC%83%81%ED%95%B4%EC%94%A8_%EA%B3%B5%EC%8B%9D_%EC%9D%BC%EB%9F%AC%EC%8A%A4%ED%8A%B8.png/revision/latest/scale-to-width-down/1000?cb=20170404232618&path-prefix=ko",
                "https://static.wikia.nocookie.net/pokemon/images/5/5e/%ED%8C%8C%EC%9D%B4%EB%A6%AC_%EA%B3%B5%EC%8B%9D_%EC%9D%BC%EB%9F%AC%EC%8A%A4%ED%8A%B8.png/revision/latest/scale-to-width-down/1000?cb=20170404233005&path-prefix=ko",
                "https://static.wikia.nocookie.net/pokemon/images/a/aa/%EA%BC%AC%EB%B6%80%EA%B8%B0_%EA%B3%B5%EC%8B%9D_%EC%9D%BC%EB%9F%AC%EC%8A%A4%ED%8A%B8.png/revision/latest/scale-to-width-down/1000?cb=20170404233452&path-prefix=ko",
                "https://static.wikia.nocookie.net/pokemon/images/3/34/%EC%BA%90%ED%84%B0%ED%94%BC_%EA%B3%B5%EC%8B%9D_%EC%9D%BC%EB%9F%AC%EC%8A%A4%ED%8A%B8.png/revision/latest?cb=20161125130704&path-prefix=ko",
                "https://static.wikia.nocookie.net/pokemon/images/5/51/%EB%B2%84%ED%84%B0%ED%94%8C_%EA%B3%B5%EC%8B%9D_%EC%9D%BC%EB%9F%AC%EC%8A%A4%ED%8A%B8.png/revision/latest/scale-to-width-down/1000?cb=20170404233745&path-prefix=ko",
                "https://static.wikia.nocookie.net/pokemon/images/e/eb/%EB%8F%85%EC%B9%A8%EB%B6%95_%EA%B3%B5%EC%8B%9D_%EC%9D%BC%EB%9F%AC%EC%8A%A4%ED%8A%B8.png/revision/latest/scale-to-width-down/1000?cb=20170404233959&path-prefix=ko"
            };

            foreach(var url in urls)
            {
                Image img = im.GetImageFromURL(url);
            }

            Assert.AreEqual(im.ImageCache.Count, Math.Min(im.Threshold, urls.Count));
        }

        [TestMethod()]
        public void GetImageFromURLTest_InvalidLink()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                FootccerClient.Footccer.Util.ImageMaker im = new ImageMaker();
                List<string> urls = new List<string>
            {
                "https://naver.com",
            };

                foreach (var url in urls)
                {
                    Image img = im.GetImageFromURL(url);
                }
            });
        }
    }
}
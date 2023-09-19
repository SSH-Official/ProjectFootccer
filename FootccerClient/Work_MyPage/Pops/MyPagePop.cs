using FootccerClient.Footccer;
using FootccerClient.Work_MyPage.DTO;
using Lib.Frame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootccerClient.Windows.MyPage
{
    public partial class MyPagePop : MasterPop
    {
        UserInfoDTO userInfo;
        public MyPagePop()
        {
            InitializeComponent();
            userInfo = App.Instance.DB.MyPage.GetUserInfoAsSession();
        }

        

        private string GetTestImageURL()
        {
            return "https://static.wikia.nocookie.net" +
            "/pokemon/images/2/20" +
            "/%EC%9E%A0%EB%A7%8C%EB%B3%B4_%EA%B3%B5%EC%8B%9D_%EC%9D%BC%EB%9F%AC%EC%8A%A4%ED%8A%B8.png" +
            "/revision/latest?cb=20170405085804&path-prefix=ko";
        }
        private Image GetImageFromURL(string url)
        {
            using (WebClient client = new WebClient())
            {
                byte[] imgArray;
                imgArray = client.DownloadData(url);

                using (MemoryStream memstr = new MemoryStream(imgArray))
                {
                    Image img = Image.FromStream(memstr);
                    return img;
                }
            }
        }
    }
}

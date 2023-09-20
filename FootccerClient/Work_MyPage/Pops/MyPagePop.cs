using FootccerClient.Footccer;
using FootccerClient.Work_MyPage.DTO;
using FootccerClient.Work_MyPage.Pops;
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

        /// <summary>
        /// App.Instance.Session 정보로 유저 정보를 가져와 마이페이지 팝업을 생성합니다.
        /// 실패하면 오류를 발생시킵니다.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public MyPagePop()
        {
            userInfo = App.Instance.DB.MyPage.GetUserInfoAsSession();
            if (userInfo == null) 
            { 
                throw new Exception(
                    "UserInfo를 읽어오는 데에 실패했습니다.\r\n" +
                    "자세한 내용은 콘솔 로그를 확인해주세요."); 
            }
            InitializeComponent();
            InitailizeMyPagePop_AsUserInfo();
        }

        private void InitailizeMyPagePop_AsUserInfo()
        {
            tbox_Name.Text = userInfo.User.Name;
            tbox_Gender.Text = userInfo.Gender;
            tbox_Contact.Text = userInfo.Contact;
            tbox_Email.Text = userInfo.Email;
            tbox_PrefAct.Text = userInfo.Prefer.Activity.Name;
            tbox_PrefCity.Text = userInfo.Prefer.City.Name;
            panel_Image.BackgroundImage = userInfo.Image;
            panel_Image.BackgroundImageLayout = ImageLayout.Stretch;
            panel_Image.Tag = userInfo.Image.Tag;
        }

        private void btn_Apply_Click(object sender, EventArgs e)
        {

        }

        private void btn_DeleteFile_Click(object sender, EventArgs e)
        {
            panel_Image.BackgroundImage = null;
            panel_Image.Tag = null;
        }

        private void button_TestFeature_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{panel_Image.Tag}");
        }

        private void btn_FindFile_Click(object sender, EventArgs e)
        {
            UrlRecieverPop pop = new UrlRecieverPop();
            if (pop.ShowDialog() == DialogResult.OK )
            {
                string url = pop.Value;
                panel_Image.BackgroundImage = App.Instance.Image.GetImageFromURL(url);
                panel_Image.Tag = url;
            }
        }
    }
}

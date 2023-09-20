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
            try
            {
                userInfo = App.Instance.DB.MyPage.GetUserInfoAsSession();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.DialogResult = DialogResult.Abort; return;
            }            
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
        }

    }
}

using FootccerClient.Footccer;
using FootccerClient.Windows.MyPage;
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

namespace FootccerClient.Windows.Views
{
    public partial class MyPageView : MasterView
    {
        public MyPageView()
        {
            InitializeComponent();
        }

        private void btn_Testssh_Click(object sender, EventArgs e)
        {
            UserCredentialDTO User = new UserCredentialDTO(1, "ssh", "성승현");
            App.Instance.Session.TestSetup(User);
            App.Instance.MainForm.ShowPop<MyPagePop>();            
        }
        
    }
}

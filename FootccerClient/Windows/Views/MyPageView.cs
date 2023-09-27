using FootccerClient.Footccer;
using FootccerClient.Windows.MyPage;
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
using FootccerClient.Footccer.DTO;

namespace FootccerClient.Windows.Views
{
    public partial class MyPageView : MasterView
    {
        public MyPageView()
        {
            InitializeComponent();
        }

        private void btn_MyPage_Click(object sender, EventArgs e)
        {
            App.Instance.MainForm.ShowPop<MyPagePop>();
        }
    }
}

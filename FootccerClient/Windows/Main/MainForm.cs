using FootccerClient.Footccer;
using FootccerClient.Windows.Views;
using Lib.Frame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FootccerClient.Work_ELO.View;

namespace FootccerClient
{
    public partial class MainForm : Form
    {
        private List<MasterView> Views { get; set; }
        
        public MainForm()
        {
            InitializeComponent();
            InitializeViews();
            RegisterToApp();

            //////////////////////////////////////
            void InitializeViews()
            {
                Views = new List<MasterView>()
                {
                    new LoginView(),
                    new MyPageView(),
                    new PartyJoinView(),
                    new PartyCreateView(),
                    new PartySearchView(),
                    new RecordView()
                };

                foreach (MasterView view in this.Views)
                {
                    view.Parent = panel_ViewSpace;
                    view.Dock = DockStyle.Fill;
                    view.Visible = false;
                }
            }
            void RegisterToApp()
            {
                App.Instance.MainForm = this;
            }
        }

        

        private void btn_Login_Click(object sender, EventArgs e)
        {
            ShowView<LoginView>();
        }

        private void btn_MyPage_Click(object sender, EventArgs e)
        {
            ShowView<MyPageView>();
        }

        private void btn_PartySearch_Click(object sender, EventArgs e)
        {
            ShowView<PartySearchView>();
        }

        private void btn_PartyCreate_Click(object sender, EventArgs e)
        {
            ShowView<PartyCreateView>();
        }

        private void btn_PartyJoin_Click(object sender, EventArgs e)
        {
            ShowView<PartyJoinView>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowView<RecordView>();
        }
    }
}

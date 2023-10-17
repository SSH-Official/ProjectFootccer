using FootccerClient.Footccer;
using FootccerClient.Windows.Views;
using FootccerClient.Windows.Views.FootccerView;
using FootccerClient.Windows.Views.SubMenu;
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

namespace FootccerClient
{
    public partial class MainForm : Form
    {
        

        private List<MasterView> Views { get; set; }
        private List<Label> MenuControls { get; set; }

        private MasterView _CurrentView { get; set; }
        private MasterView CurrentView 
        {
            get => _CurrentView;
            set
            {
                value.Visible = true;
                value.Refresh_View();
                _CurrentView = value;
            }
        }
        
        
        public MainForm()
        {
            InitializeComponent();
            InitializeViews();
            this.WindowState = FormWindowState.Maximized;
        }


        private void btn_Logout_Click(object sender, EventArgs e)
        {
            App.Instance.Session.LogOut();
        }

        private void label_MyParty_Click(object sender, EventArgs e)
        {
            SelectMenu(sender as Label);
            ShowView<MyPartyMenuView>();
        }

        private void label_FindParty_Click(object sender, EventArgs e)
        {
            SelectMenu(sender as Label);
            ShowView<PartySearchView>();
        }

        private void label_Club_Click(object sender, EventArgs e)
        {
            SelectMenu(sender as Label);
            ShowView<ClubView>();
        }

        private void label_MyPage_Click(object sender, EventArgs e)
        {
            SelectMenu(sender as Label);
            ShowView<MyPageView>();
        }

        private void label_Config_Click(object sender, EventArgs e)
        {
            SelectMenu(sender as Label);
            ShowView<ConfigView>();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (CurrentView is MainScreenView)
                {
                    AskLogout();
                }
                else
                {
                    ShowView<MainScreenView>();
                }
                
            }
        }

    }
}

using FootccerClient.Footccer;
using FootccerClient.Windows.Views;
using FootccerClient.Windows.Views.FootccerView;
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
        public MainScreenView MainScreen { get; set; }
        public MenuView MenuView { get; set; }

        public MainForm()
        {
            InitializeComponent();
            InitializeViews();
            this.WindowState = FormWindowState.Maximized;
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

        internal void SetUserProfile()
        {
            MenuView.SetUserProfile();
        }
    }
}

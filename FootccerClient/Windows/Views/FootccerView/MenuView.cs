using FootccerClient.Footccer;
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

namespace FootccerClient.Windows.Views.FootccerView
{
    public partial class MenuView : MasterView
    {
        public MenuView()
        {
            InitializeComponent();
        }

        public override void Refresh_View() => CurrentView?.Refresh_View();
        public override void SetTitle(string aTitle)
        {
            label_Title.Text = aTitle;
        }

        public void ShowView<T>(string aTitle = "") where T : MasterView, new()
        {
            this.SetTitle(aTitle);
            var view = GetView<T>();
            CurrentView = view;
        }

        private void button_BackToMainMenu_Click(object sender, EventArgs e)
        {
            GoBackToMainMenu();
        }

        private void MenuView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                GoBackToMainMenu();
            }
        }

        public void GoBackToMainMenu()
        {
            App.Instance.MainForm.ShowView<MainScreenView>();
        }

        internal void SetUserProfile()
        {
            button_MyPage.BackgroundImage = App.Instance.DB.Session.ReadSessionUserImage();
            button_MyPage.BackColor = Color.White;
            button_MyPage.Text = App.Instance.DB.Session.ReadUserName();
        }
    }
}

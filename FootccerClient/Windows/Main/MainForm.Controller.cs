using FootccerClient.Footccer;
using FootccerClient.Windows.Views;
using FootccerClient.Windows.Views.FootccerView;
using Lib.Frame;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootccerClient
{
    partial class MainForm
    {
        private MasterView _CurrentView { get; set; }
        private MasterView CurrentView
        {
            get => _CurrentView;
            set
            {
                if (_CurrentView != null) _CurrentView.Visible = false;
                value.Visible = true;
                value.Refresh_View();

                _CurrentView = value;
            }
        }

        public void Refresh_View()
        {
            CurrentView?.Refresh_View();
        }

        private void InitializeViews()
        {
            MainScreen = new MainScreenView();
            MenuView = new MenuView();

            MainScreen.Parent = panel_ViewSpace;
            MenuView.Parent = panel_ViewSpace;
        }

        public void ShowView<T>(string aTitle = "") where T : MasterView, new()
        {
            var type = typeof(T);
            if (type == typeof(MainScreenView))
            {
                CurrentView = MainScreen;
            }
            else
            {
                CurrentView = MenuView;
                MenuView.ShowView<T>(aTitle);
            }
        }

        public DialogResult ShowPop<T>(ePopMode aPopMode = ePopMode.None, object aParam = null) where T : MasterPop, new()
        {
            var CurrentPop = new T();
            return CurrentPop.ShowPop(aPopMode, aParam);
        }

        private void AskLogout()
        {
            var result = MessageBox.Show("로그아웃 하시겠습니까?", "", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                App.Instance.Session.LogOut();
            }
        }
    }
}

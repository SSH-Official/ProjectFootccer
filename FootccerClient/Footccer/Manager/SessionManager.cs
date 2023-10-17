
using FootccerClient.Footccer.DTO;
using FootccerClient.Windows.Views;
using FootccerClient.Windows.Views.FootccerView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FootccerClient.Footccer.Manager
{
    public class SessionManager
    {
        public string ID { get => User?.ID; }
        public UserDTO User { get; private set; }
        public bool Offline { get => ID == null || User == null; }
        public bool Online { get => !Offline; }



        internal void TestSetup(UserDTO user)
        {
            this.User = user;
        }

        public void Login(UserDTO user)
        {
            this.User = user;
            App.Instance.LoginForm.Visible = false;
            App.Instance.MainForm.ShowView<MainScreenView>();
            App.Instance.MainForm.Visible = true;
            App.Instance.MainForm.SetUserProfile();
        }

        public void LogOut()
        {
            this.User = null;
            App.Instance.MainForm.Visible = false;
            App.Instance.LoginForm.Visible = true;
        }
    }
}

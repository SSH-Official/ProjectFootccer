
using FootccerClient.Footccer.DTO;
using FootccerClient.Windows.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FootccerClient.Footccer.Manager
{
    public class SessionManager
    {
        public string ID { get { return User?.ID; } }
        public UserDTO User { get; private set; }

        public bool Offline
        {
            get 
            { 
                return ID == null
                    || User == null; 
            }
        }
        public bool Online
        {
            get
            {
                return !Offline;
            }
        }



        internal void TestSetup(UserDTO user)
        {
            this.User = user;
        }

        public void Login(UserDTO user)
        {
            this.User = user;
            App.Instance.LoginForm.Visible = false;
            App.Instance.MainForm.ShowView<MyPartyView>();
            App.Instance.MainForm.Visible = true;            
        }

        public void LogOut()
        {
            this.User = null;
            App.Instance.MainForm.Visible = false;
            App.Instance.LoginForm.Visible = true;
        }
    }
}


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
        public UserDTO User;


        internal void TestSetup(UserDTO user)
        {
            this.User = user;
        }

        public void Login(UserDTO user)
        {
            this.User = user;
            App.Instance.MainForm.ShowView<PartyCreateView>();
        }
        public void LogOut()
        {
            User = new UserDTO(-1, null);
            App.Instance.MainForm.ShowView<LoginView>();
        }
    }
}

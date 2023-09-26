
using FootccerClient.Footccer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FootccerClient.Footccer.Manager
{
    public class SessionManager
    {
        public string ID { get; private set; }

        internal void TestSetup(string UID)
        {
            this.ID = UID;
        }

        public void Login(string UID)
        {
            this.ID = UID;
            App.Instance.LoginForm.Visible = false;
            App.Instance.MainForm.Visible = true;            
        }

        public void LogOut()
        {
            this.ID = null;
            App.Instance.MainForm.Visible = false;
            App.Instance.LoginForm.Visible = true;
        }
    }
}

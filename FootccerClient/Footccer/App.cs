using FootccerClient.Footccer.Manager;
using FootccerClient.Footccer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer
{
    public class App
    { 
        static private App instance;
        static public App Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new App();

                }
                return instance;
            }
        }

        private MainForm _MainForm;
        public MainForm MainForm
        {
            get
            {
                if(_MainForm == null)
                {
                    _MainForm = new MainForm();
                    _MainForm.FormClosed += (sender, e) =>
                    {
                        _MainForm = null;
                        App.instance.Session.LogOut();
                    };
                }
                return _MainForm;
            }
        }

        private LoginForm _LoginForm;
        public LoginForm LoginForm { get
            {
                if (_LoginForm == null)
                {
                    _LoginForm = new LoginForm();
                }
                return _LoginForm;
            }
        }
        
        
        public DBManager  DB { get; }        
        public SessionManager Session { get; }
        public ImageMaker Image { get; }
        

        public App()
        {
            DB = new DBManager();
            Session = new SessionManager();
            Image = new ImageMaker();
        }


    }
}

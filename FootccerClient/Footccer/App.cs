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
                return _MainForm;
            }
            set
            {
                _MainForm = value;
                _MainForm.FormClosed += (sender, e) =>
                {
                    App.instance.MainForm = new MainForm();
                    App.instance.Session.LogOut();
                };
            }
        }
        public LoginForm LoginForm { get; set; }
        
        
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

using FootccerClient.Footccer.Manager;
using FootccerClient.Work_MyPage.Manager;
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

        public DBManager DB { get; }
        public MainForm MainForm { get; set; }
        public SessionManager_MyPage Session { get; }
        public ImageMaker Image { get; }

        public App()
        {
            DB = new DBManager();
            Session = new SessionManager_MyPage();
            Image = new ImageMaker();
        }


    }
}

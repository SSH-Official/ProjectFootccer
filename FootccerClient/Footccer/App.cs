using FootccerClient.Footccer.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer
{
    public class App
    {
        public DBManager DB { get; }

        public App Instance
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

        private App instance;


        public App()
        {
            DB = new DBManager();
        }


    }
}

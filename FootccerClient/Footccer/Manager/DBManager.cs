using FootccerClient.Footccer.LoginFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.Manager
{
    public class DBManager
    {
        public DBLogin Login { get; set; } 

        public DBManager() { 
            Login = new DBLogin();
        }
    }
}
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.DBExecuter
{
    public abstract class DBExecture_Base
    {
        protected MySqlCommand cmd { get; }
        public DBExecture_Base(MySqlCommand cmd) 
        { 
            this.cmd = cmd;
        }

        public int ExecuteNonQuery()
        {
            return cmd.ExecuteNonQuery();
        }

    }
}

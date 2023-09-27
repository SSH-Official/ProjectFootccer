using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.Manager
{
    public class DBSettings
    {
        public static DBSettings KB_Default 
        { get { return new DBSettings("192.168.0.18", "Footccer", "Footccer", "1234", 3306); } }

        private string ServerIP;
        private string Database;
        private string UID;
        private string Password;
        private int Port;

        public string ConnectionString
        {
            get
            {
                return
                    $"Server={ServerIP};" +
                    $"Database={Database};" +
                    $"Uid={UID};" +
                    $"Pwd={Password};" +
                    $"Port={Port}";
            }
        }

        

        public DBSettings(string serverIP, string database, string uID, string password, int port)
        {
            ServerIP = serverIP;
            Database = database;
            UID = uID;
            Password = password;
            Port = port;
        }
    }
}

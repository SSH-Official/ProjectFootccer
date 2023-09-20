
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootccerClient.Footccer.LoginFeature
{
    public class DBLogin
    {
        public void funci()
        {
            MySqlConnection conn = null;
        }

        internal bool CheckLoginSuccess(UserCredential info)
        {
            try
            {
                string connectionstr = "Server = 192.168.0.18;" +
                    "Database=Footccer;" +
                    "Uid=root;" +
                    "Pwd=1234;";

                MySqlConnection connection = new MySqlConnection(connectionstr);

                connection.Open();

                int login_status = 0;

                string loginid = info.ID;
                string loginpwd = info.Password;

                string selectQuery = "SELECT * FROM `Credential` WHERE id = \'" + loginid + "\' ";

                MySqlCommand Selectcommand = new MySqlCommand(selectQuery, connection);
                MySqlDataReader userAccount = Selectcommand.ExecuteReader();

                while (userAccount.Read())
                {
                    if (loginid == (string)userAccount["id"] && loginpwd == (string)userAccount["password"])
                    {
                        login_status = 1;
                    }
                }
                connection.Close();

                if (login_status == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }

}

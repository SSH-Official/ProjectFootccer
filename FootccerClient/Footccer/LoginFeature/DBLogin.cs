
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace FootccerClient.Footccer.LoginFeature
{   
    
   
    public class DBLogin
    {
        public string connectionstr = "Server = 192.168.0.18;" +
                        "Database=Footccer;" +
                        "Uid=root;" +
                        "Pwd=1234;";

        public void funci()
        {
            MySqlConnection conn = null;
        }

        internal bool Checkjoinmember(JoinmemberInfo info)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionstr);

                connection.Open();

                string name = info.Name;
                string gender = info.Gender;
                string email = info.Email;
                string id = info.Id;
                string password = info.Password;
                string nickname = info.Nickname;
                string birthday = info.Birthday;
                if (DateTime.TryParseExact(birthday, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
                {
                   birthday = parsedDate.ToString("yyyy-MM-dd ");
                }
                string phone = info.Phone;                
                string SQL_InsertToUser = 
                    "INSERT INTO User (id, password) VALUES " 
                    + $"('{id}','{password}'); ";
                string SQL_GetUserIndex = $"SELECT idx FROM `User` WHERE id = '{id}'; ";
                string SQL_InsertToUserInfo = 
                    "INSERT INTO UserInfo (User_idx, nickname, name, gender, contact, email, birth) VALUES " +
                    "({0} ,'" + nickname + "','" + name + "', '" + gender + "', '" + phone + "', '" + email + "','" + birthday + "'); ";
                MySqlTransaction transaction =  connection.BeginTransaction();
                try
                {
                    MySqlCommand cmd = connection.CreateCommand();
                    cmd.Transaction = transaction;

                    cmd.CommandText = SQL_InsertToUser;
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = SQL_GetUserIndex;
                    MySqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    int User_idx = reader.GetInt32(0);
                    reader.Close();

                    string FormattedSQL = string.Format(SQL_InsertToUserInfo, User_idx);
                    cmd.CommandText = FormattedSQL;
                    cmd.ExecuteNonQuery();

                    throw new Exception("Testing");
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
                return true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        internal bool CheckLoginSuccess(UserCredential info)
        {
            try
            {              
                MySqlConnection connection = new MySqlConnection(connectionstr);

                connection.Open();

                int login_status = 0;

                string loginid = info.ID;
                string loginpwd = info.Password;

                string selectQuery = "SELECT * FROM `User` WHERE id = \'" + loginid + "\' ";

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
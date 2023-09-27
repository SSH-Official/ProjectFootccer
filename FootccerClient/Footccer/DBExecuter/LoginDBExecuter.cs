using FootccerClient.Footccer.DTO;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.DBExecuter
{
    public class LoginDBExecuter : DBExecture_Base
    {
        public LoginDBExecuter(MySqlCommand cmd) : base(cmd)
        {
        }

        public LoginDBExecuter SetSQL_InsertTOUser(JoinmemberInfoDTO info)
        {
            string Query = "INSERT INTO User (id, password) VALUES " + 
                $"('{info.Id}','{info.Password}'); ";
            cmd.CommandText = Query;
            return this;
        }

        public LoginDBExecuter SetSQL_ReadUserIndex(JoinmemberInfoDTO info)
        {
            string Query = $"SELECT idx FROM `User` WHERE id = '{info.Id}'; ";
            cmd.CommandText = Query;
            return this;
        }

        public int ReadUserIndex()
        {
            int User_idx;
            using (MySqlDataReader rdr = cmd.ExecuteReader())
            {
                rdr.Read();
                User_idx = rdr.GetInt32(0);
            }
            return User_idx;
        }

        public LoginDBExecuter SetSQL_InsertToUserInfo(JoinmemberInfoDTO info, int user_idx)
        {
            string SQL_InsertToUserInfo = 
                "INSERT INTO UserInfo (User_idx, nickname, name, gender, contact, email, birth) " +
                "VALUES " +
                "({0} ,'" + info.Nickname + "','" + info.Name + "', '" + info.Gender + "', '" + info.Phone + "', '" + info.Email + "','" + GetBirthday(info) + "'); ";
            string FormattedSQL = string.Format(SQL_InsertToUserInfo, user_idx);

            cmd.CommandText = FormattedSQL;
            return this;
        }
        private string GetBirthday(JoinmemberInfoDTO info)
        {
            string birthday = info.Birthday;
            if (DateTime.TryParseExact(birthday, "yyyyMMdd", null,
                System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
            {
                birthday = parsedDate.ToString("yyyy-MM-dd ");
            }

            return birthday;
        }

        internal LoginDBExecuter SetSQL_CheckLoginSuccess(UserCredentialDTO_RegisterUser info)
        {
            string loginid = info.ID;

            string selectQuery = "SELECT * FROM `User` WHERE id = \'" + loginid + "\' ";
            cmd.CommandText = selectQuery;
            return this;
        }

        internal int CheckLoginSuccess(UserCredentialDTO_RegisterUser info)
        {
            int login_status = 0;

            using (MySqlDataReader userAccount = cmd.ExecuteReader())
            {
                string loginid = info.ID;
                string loginpwd = info.Password;
                while (userAccount.Read())
                {
                    if (loginid == (string)userAccount["id"] && loginpwd == (string)userAccount["password"])
                    {
                        login_status = 1;
                    }
                }
            }

            return login_status;
        }

        internal LoginDBExecuter SetSQL_ReadUser(UserCredentialDTO_RegisterUser info)
        {
            cmd.CommandText = 
                "SELECT idx, id " +
                "FROM `User` AS U " +
                "WHERE U.id = @id; ";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@id", MySqlDbType.VarChar, 50).Value = info.ID;
            return this;
        }

        internal UserDTO ReadUser()
        {
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                reader.Read();
                return new UserDTO(reader.GetInt32("idx"), reader.GetString("id"));
            }
        }
    }
}

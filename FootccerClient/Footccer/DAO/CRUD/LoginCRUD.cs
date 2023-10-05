using FootccerClient.Footccer.DTO;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.DAO.CRUD
{
    /// <summary>
    /// 로그인 CRUD 인터페이스 제공 객체입니다. <br/>
    /// MySqlCommand 자원을 사용하므로 필요시에만 생성해서 사용해주세요.
    /// </summary>
    public class LoginCRUD : CRUD_Base
    {
        /// <summary>
        /// 로그인 CRUD 인터페이스 제공 객체입니다. <br/>
        /// MySqlCommand 자원을 사용하므로 필요시에만 생성해서 사용해주세요.
        /// </summary>
        public LoginCRUD(MySqlCommand cmd) : base(cmd)
        {
        }


        public int CreateUser(JoinmemberInfoDTO info)
        {
            string Query = "INSERT INTO User (id, password) VALUES " + 
                $"('{info.Id}','{info.Password}'); ";
            cmd.CommandText = Query;
            return cmd.ExecuteNonQuery();

            
        }


        public int ReadUserIndex(JoinmemberInfoDTO info)
        {
            int User_idx;

            string Query = $"SELECT idx FROM `User` WHERE id = '{info.Id}'; ";
            cmd.CommandText = Query;
            using (MySqlDataReader rdr = cmd.ExecuteReader())
            {
                rdr.Read();
                User_idx = rdr.GetInt32(0);
            }
            return User_idx;
        }


        public int CreateUserInfo(JoinmemberInfoDTO info) => CreateUserInfo(info, ReadUserIndex(info));
        public int CreateUserInfo(JoinmemberInfoDTO info, int user_idx)
        {
            string SQL_InsertToUserInfo = 
                "INSERT INTO UserInfo (User_idx, nickname, name, gender, contact, email, birth) " +
                "VALUES " +
                "({0} ,'" + info.Nickname + "','" + info.Name + "', '" + info.Gender + "', '" + info.Phone + "', '" + info.Email + "','" + GetBirthday(info) + "'); ";
            string FormattedSQL = string.Format(SQL_InsertToUserInfo, user_idx);
            cmd.CommandText = FormattedSQL;

            return cmd.ExecuteNonQuery();
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


        public int CheckLoginSuccess(UserCredentialDTO_RegisterUser info)
        {
            string loginid = info.ID;
            string loginpwd = info.Password;

            string selectQuery = "SELECT * FROM `User` WHERE id = \'" + loginid + "\' ";
            cmd.CommandText = selectQuery;
            int login_status = 0;

            using (MySqlDataReader userAccount = cmd.ExecuteReader())
            {
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


        public UserDTO ReadUser(UserCredentialDTO_RegisterUser info)
        {
            cmd.CommandText = 
                "SELECT idx, id " +
                "FROM `User` AS U " +
                "WHERE U.id = @id; ";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@id", MySqlDbType.VarChar, 50).Value = info.ID;

            return ReadData((reader) =>
            {
                return new UserDTO(reader.GetInt32("idx"), reader.GetString("id"));
            });
        }

    }
}

using FootccerClient.Footccer.DAO.Base;
using FootccerClient.Footccer.DTO;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.DAO
{
	partial class DBLogin_DAO
	{
		class CRUD : CRUD_Base
		{
			public int CreateUser(JoinmemberInfoDTO info)
			{
				string Query = "INSERT INTO User (id, password) VALUES " +
					$"('{info.Id}','{info.Password}'); ";
				cmd.CommandText = Query;

				return cmd.ExecuteNonQuery();
			}


			public int ReadUserIndex(JoinmemberInfoDTO info)
			{
				string Query = $"SELECT idx FROM `User` WHERE id = '{info.Id}'; ";
				cmd.CommandText = Query;

				return ReadData((rdr) => rdr.GetInt32(0));				
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


			public bool CheckLoginSuccess(UserCredentialDTO info)
			{
				string loginid = info.ID;
				string loginpwd = info.Password;

				string selectQuery = "SELECT * FROM `User` WHERE id = \'" + loginid + "\' ";
				cmd.CommandText = selectQuery;
				

				return ReadData((userAccount) =>
				{
					int login_status;
					if (loginid == (string)userAccount["id"] && loginpwd == (string)userAccount["password"])
					{
						login_status = 1;
					}
					else
					{
						login_status = 0;
					}

					return login_status == 1;  // 1이어야 성공임..
				});
			}


			public UserDTO ReadUser(UserCredentialDTO info)
			{
				cmd.CommandText =
					"SELECT idx, id " +
					"FROM `User` AS U " +
					"WHERE U.id = @id; ";
				cmd.Parameters.Clear();
				cmd.Parameters.Add("@id", MySqlDbType.VarChar, 50).Value = info.ID;

				return ReadData((reader) => new UserDTO(reader.GetInt32("idx"), reader.GetString("id")));
			}

		}
	}
}

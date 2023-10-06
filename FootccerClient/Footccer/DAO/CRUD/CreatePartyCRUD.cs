using FootccerClient.Footccer.DAO;
using FootccerClient.Footccer.DAO.CRUD;
using FootccerClient.Footccer.DTO;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootccerClient.Footccer.DAO.CRUD
{
    public class CreatePartyCRUD : CRUD_Base
    {
        public CreatePartyCRUD(MySqlCommand cmd) : base(cmd)
        {
        }

        public (string Address, int Idx) selectPlaceAddress(int cityIndex, string name)
        {
            string sql = $"select address, idx from Place where City_idx = @cityIndex and name = @name";
            cmd.CommandText = sql;
            cmd.Parameters.Add("@cityIndex", MySqlDbType.Int32, 10).Value = cityIndex;
            cmd.Parameters.Add("@name", MySqlDbType.VarChar, 50).Value = name;

            return ReadData(reader =>
            {
                string _Address = reader.GetString("address");
                int _Idx = reader.GetInt32("idx");
                return (_Address, _Idx);
            });
        }

        public List<string> selectPlaceName(int cityIndex)
        {
            string sql = $"select name from Place p where p.City_idx = @cityIndex";
            cmd.CommandText = sql;
            cmd.Parameters.Add("@cityIndex", MySqlDbType.Int32, 10).Value = cityIndex;

            return ReadDataList(reader =>
            {
                return reader.GetString("name");
            });
        }

        public List<string> selectCity()
        {
            string sql = "select name from City";
            cmd.CommandText = sql;

            return ReadDataList(reader =>
            {
                return reader.GetString("name");
            });
        }

        public List<string> selectActivity()
        {
            string sql = "select name from Activity ";
            cmd.CommandText = sql;

            return ReadDataList(reader =>
            {
                return reader.GetString("name");
            });
        }

        public int insertParty(CreatePartyDTO dto)
        {
            string date = dto.date.ToString("yyyy-MM-dd HH:mm:ss");
            string sql = $"insert into `Party` (`Activity_idx`, `Leader_idx`, `name`, `Place_idx`, `date`, `max`, `count`) " +
                         $"values(@Activity_idx, @Leader_idx, @name, @Place_idx, @date, @max, @count); " +
                         $"SELECT LAST_INSERT_ID();";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@Activity_idx", MySqlDbType.Int32, 10).Value = dto.Activity_idx;
            cmd.Parameters.Add("@Leader_idx", MySqlDbType.Int32, 10).Value = dto.Leader_idx;
            cmd.Parameters.Add("@name", MySqlDbType.VarChar, 50).Value = dto.name;
            cmd.Parameters.Add("@Place_idx", MySqlDbType.Int32, 10).Value = dto.Place_idx;
            cmd.Parameters.Add("@date", MySqlDbType.DateTime).Value = date;
            cmd.Parameters.Add("@max", MySqlDbType.Int32, 10).Value = dto.max;
            cmd.Parameters.Add("@count", MySqlDbType.Int32, 10).Value = dto.count;

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public int insertList(ListDTO dto)
        {
            string sql = $"insert into `List` (`User_idx`, `Party_idx`, `side`, `position`) " +
                             $"values(@User_idx, @Party_idx, @side, @position)";
            cmd.CommandText = sql;
            cmd.Parameters.Add("@User_idx", MySqlDbType.Int32, 10).Value = dto.User_idx;
            cmd.Parameters.Add("@Party_idx", MySqlDbType.Int32, 10).Value = dto.Party_idx;
            cmd.Parameters.Add("@side", MySqlDbType.VarChar, 1).Value = dto.side;
            cmd.Parameters.Add("@position", MySqlDbType.Int32, 10).Value = dto.position;

            return cmd.ExecuteNonQuery();

        }

        public int insertRecord(RecordDTO dto)
        {
            string sql = "insert into Record (Party_idx) values (@Party_idx) ";
            cmd.CommandText = sql;
            cmd.Parameters.Add("@Party_idx", MySqlDbType.Int32, 10).Value = dto.Party_idx;

            return cmd.ExecuteNonQuery();
        }
    }
}
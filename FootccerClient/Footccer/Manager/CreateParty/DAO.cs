using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootccerClient.Footccer.Manager;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace FootccerClient.Footccer.Manager.CreateParty
{
    public class DAO
    {
        private MySqlConnection conn;
        private MySqlCommand cmd;
        private MySqlDataReader reader;
        private MySqlDataAdapter dataAdapter;
        string strConnection = "Server=192.168.0.18;Database=Footccer;Uid=root;Pwd=1234;Port=3306";

        public int nonSQL(string sql)
        {
            using (conn = new MySqlConnection(strConnection))
            {
                cmd = new MySqlCommand(sql, conn);
                return cmd.ExecuteNonQuery();
            }
        }
        public MySqlDataReader selectUsingReader(string sql)
        {
            using (conn = new MySqlConnection(strConnection))
            {
                conn.Open();
                cmd = new MySqlCommand(sql, conn);
                reader = cmd.ExecuteReader();
                return reader;
            }
        }
        public MySqlDataAdapter selectUsingAdapter(string sql)
        {
            using (conn = new MySqlConnection(strConnection))
            {
                dataAdapter = new MySqlDataAdapter(sql, conn);
                return dataAdapter;
            }
        }



        public int insertParty(CreatePartyDTO dto)
        {
            using (conn = new MySqlConnection(strConnection))
            {
                conn.Open();
                string date = dto.date.ToString("yyyy-MM-dd HH:mm:ss");
                string sql = $"INSERT INTO `Party` (`Activity_idx`, `Leader_idx`, `name`, `Place_idx`, `date`, `max`, `count`) " +
                             $"VALUES({dto.Activity_idx}, {dto.Leader_idx}, \"{dto.name}\", {dto.Place_idx}, \"{date}\", {dto.max}, {dto.count})";
                cmd = new MySqlCommand(sql, conn);
                return cmd.ExecuteNonQuery();
            }           
        }
        public List<string> selectCity()
        {
            using(conn = new MySqlConnection(strConnection))
            {
                conn.Open();
                string sql = "select name from City";
                List<string> list = new List<string>();
                cmd = new MySqlCommand(sql, conn);
                reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    list.Add(reader.GetString("name"));
                }
                return list;
            }
        }
        public List<string> selectPlaceName(int city)
        {
            using(conn = new MySqlConnection(strConnection))
            {
                conn.Open();
                string sql = $"select name from Place p where p.City_idx = {city}";
                List<string> list = new List<string>();
                cmd = new MySqlCommand(sql , conn);
                reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    list.Add(reader.GetString("name"));
                }
                return list;
            }
        }
        public (string Address, int Idx) selectPlaceAddress(int city, string name)
        {
            using(conn = new MySqlConnection(strConnection))
            {
                conn.Open();
                string sql = $"select address, idx from Place where City_idx = {city} and name = \"{name}\"";
                (string Address, int Idx) result = default;
                cmd = new MySqlCommand(sql , conn);
                reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    result.Address = reader.GetString("address");
                    result.Idx = reader.GetInt32("idx");
                }
                return result;
            }
        }
    }
}

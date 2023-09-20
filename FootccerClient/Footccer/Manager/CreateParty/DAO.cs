﻿using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootccerClient.Footccer.Manager;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using System.Data;

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
                conn.Open();
                using(cmd = new MySqlCommand(sql, conn))
                {
                    return cmd.ExecuteNonQuery();
                }                
            }
        }
        public MySqlDataReader selectUsingReader(string sql)
        {
            using (conn = new MySqlConnection(strConnection))
            {
                conn.Open();
                using (cmd = new MySqlCommand(sql, conn))
                {
                    reader = cmd.ExecuteReader();
                    return reader;
                }                
            }
        }
        public DataSet selectUsingAdapter(string sql)
        {
            DataSet ds = new DataSet();
            using (conn = new MySqlConnection(strConnection))
            {
                conn.Open();
                dataAdapter = new MySqlDataAdapter(sql, conn);
                dataAdapter.Fill(ds);
                return ds;
            }
        }

        public int insertParty(CreatePartyDTO dto)
        {
            using (conn = new MySqlConnection(strConnection))
            {
                conn.Open();
                string date = dto.date.ToString("yyyy-MM-dd HH:mm:ss");
                string sql = $"insert into `Party` (`Activity_idx`, `Leader_idx`, `name`, `Place_idx`, `date`, `max`, `count`) " +
                             $"values(@Activity_idx, @Leader_idx, @name, @Place_idx, @date, @max, @count)";
                using (cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@Activity_idx", MySqlDbType.Int32, 10)).Value = dto.Activity_idx;
                    cmd.Parameters.Add(new MySqlParameter("@Leader_idx", MySqlDbType.Int32, 10)).Value = dto.Leader_idx;
                    cmd.Parameters.Add(new MySqlParameter("@name", MySqlDbType.VarChar, 50)).Value = dto.name;
                    cmd.Parameters.Add(new MySqlParameter("@Place_idx", MySqlDbType.Int32, 10)).Value = dto.Place_idx;
                    cmd.Parameters.Add(new MySqlParameter("@date", MySqlDbType.DateTime)).Value = date;
                    cmd.Parameters.Add(new MySqlParameter("@max", MySqlDbType.Int32, 10)).Value = dto.max;
                    cmd.Parameters.Add(new MySqlParameter("@count", MySqlDbType.Int32, 10)).Value = dto.count;
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public List<string> selectCity()
        {
            using(conn = new MySqlConnection(strConnection))
            {
                conn.Open();
                string sql = "select name from City";
                List<string> list = new List<string>();
                using (cmd = new MySqlCommand(sql, conn))
                {
                    using (reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(reader.GetString("name"));
                        }
                        return list;
                    }                        
                }                
            }
        }
        public List<string> selectPlaceName(int cityIndex)
        {
            using(conn = new MySqlConnection(strConnection))
            {
                conn.Open();
                string sql = $"select name from Place p where p.City_idx = @cityIndex";
                List<string> list = new List<string>();
                using (cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@cityIndex", MySqlDbType.Int32, 10)).Value = cityIndex;
                    using (reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(reader.GetString("name"));
                        }
                        return list;
                    }                        
                }                    
            }
        }
        public (string Address, int Idx) selectPlaceAddress(int cityIndex, string name)
        {
            using(conn = new MySqlConnection(strConnection))
            {
                conn.Open();
                string sql = $"select address, idx from Place where City_idx = @cityIndex and name = @name";
                (string Address, int Idx) result = default;
                using(cmd = new MySqlCommand(sql , conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@cityIndex", MySqlDbType.Int32, 10)).Value = cityIndex;
                    cmd.Parameters.Add(new MySqlParameter("@name", MySqlDbType.VarChar, 50)).Value = name;
                    using (reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            result.Address = reader.GetString("address");
                            result.Idx = reader.GetInt32("idx");
                        }
                        return result;
                    }
                }
            }
        }
    }
}
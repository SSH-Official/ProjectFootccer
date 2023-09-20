using FootccerClient.Work_PartySearch;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;


namespace FootccerClient.Footccer.Manager
{
    public class PartySearchDBExecuter
    {
        string strConn = 
            "Server = 192.168.0.18;" +
            "Database = Footccer;" +
            "Uid = root;" +
            "Pwd = 1234;";
        MySqlConnection conn = null;

        
        public List<CityDTO> ReadAllCity()
        {
            conn = new MySqlConnection(strConn);
            string sql = "SELECT * FROM `City`;";
            List<CityDTO> result = new List<CityDTO>();
            MySqlDataReader rdr = null;
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();
                
                while (rdr.Read())
                {
                    int idx = Convert.ToInt32(rdr["idx"]);
                    string name = Convert.ToString(rdr["name"]);
                    CityDTO theCity = new CityDTO(idx, name);
                    
                    result.Add(theCity);
                }
                rdr.Close();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }finally { conn.Close(); }
            
            return result;
        }
        public List<ActivityDTO> ReadAllActivities()
        {
            conn = new MySqlConnection(strConn);
            string sql = "SELECT * FROM `Activity`;";
            List<ActivityDTO> result = new List<ActivityDTO>();
            MySqlDataReader rdr = null;
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    int idx = Convert.ToInt32(rdr["idx"]);
                    string name = Convert.ToString(rdr["name"]);
                    ActivityDTO Activity = new ActivityDTO(idx, name);

                    result.Add(Activity);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { conn.Close(); }

            return result;
        }
    }
}
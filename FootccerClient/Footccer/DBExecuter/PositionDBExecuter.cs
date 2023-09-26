using FootccerClient.Footccer.DTO;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootccerClient.Footccer.DBExecuter
{
    public class PositionDBExecuter
    {
        string strConn =
            "Server = 192.168.0.18;" +
            "Database = Footccer;" +
            "Uid = root;" +
            "Pwd = 1234;";
        MySqlConnection conn = null;
        public List<PositionDTO> PSget(){
            conn = new MySqlConnection(strConn);
            string sql = "SELECT * FROM `Position`;";
            List<PositionDTO> result = new List<PositionDTO>();
            MySqlDataReader rdr = null;
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    int idx = Convert.ToInt32(rdr["idx"]);
                    string position = Convert.ToString(rdr["position"]);
                    PositionDTO ps = new PositionDTO(idx, position);

                    result.Add(ps);
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

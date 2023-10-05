using FootccerClient.Footccer.DTO;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FootccerClient.Footccer.DAO
{
    public class teamDAO
    {
        string strConn =
            "Server = 192.168.0.18;" +
            "Database = Footccer;" +
            "Uid = root;" +
            "Pwd = 1234;";
        MySqlConnection conn = null;


        public List<TeamDTO> Readmember(string Team)
        {
            conn = new MySqlConnection(strConn);
            string sql = "SELECT L.idx AS idx, COUNT(*) AS count, Ui.name AS username, side, Ui.elo as elo FROM `List` AS L " +
                         "LEFT JOIN `UserInfo` AS Ui ON L.User_idx = Ui.User_idx " +
                         "WHERE Party_idx = 14 AND side = " + Team +
                         " GROUP BY L.idx, Ui.name, side, Ui.elo ";
            List<TeamDTO> result = new List<TeamDTO>();
            MySqlDataReader rdr = null;
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    int idx = Convert.ToInt32(rdr["idx"]);
                    string username = Convert.ToString(rdr["username"]);
                    string side = Convert.ToString(rdr["side"]);
                    int elo = Convert.ToInt32(rdr["elo"]);
                    TeamDTO theCity = new TeamDTO(idx, username,side, elo);

                    result.Add(theCity);
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

        public PartyDTO readPartyInfo()
        {
            conn = new MySqlConnection(strConn);
            string sql = "SELECT Par.`name` as name, Ui.`name` as Uiname," +
                " Ui.`contact` as Uicontact, Act.`name` as Actname, Ci.`name` as Ciname," +
                " Pl.`name` as Plname, Pl.`address` as Pladdress, Par.`date` as Pardate "+
                "FROM `Party` AS Par " +
                "LEFT JOIN `UserInfo` AS Ui ON Par.Leader_idx = Ui.User_idx " +
                "LEFT JOIN `Activity` AS Act ON Par.Activity_idx = Act.idx " +
                "LEFT JOIN `Place` AS Pl ON Par.Place_idx = Pl.idx " +
                "LEFT JOIN `City` AS Ci ON Pl.City_idx = Ci.idx "+
                "WHERE Par.idx = 4";
            PartyDTO result = new PartyDTO();
            MySqlDataReader dr = null;
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                dr = cmd.ExecuteReader();
                dr.Read();
                string name = Convert.ToString(dr["name"]);
                string Uiname = Convert.ToString(dr["Uiname"]);
                string Uicontact = Convert.ToString(dr["Uicontact"]);
                string Actname = Convert.ToString(dr["Actname"]);
                string Ciname = Convert.ToString(dr["Ciname"]);
                string Plname = Convert.ToString(dr["Plname"]);
                string Plddress = Convert.ToString(dr["Pladdress"]);
                string Pardate = Convert.ToString(dr["Pardate"]); 
                result = new PartyDTO(name, Uiname, Uicontact, Actname, Ciname, Plname, Plddress, Pardate);
                dr.Close();
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
    }
}

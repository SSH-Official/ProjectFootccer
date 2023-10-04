using FootccerClient.Footccer.DAO;
using FootccerClient.Footccer.DTO;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootccerClient.Footccer.DBExecuter
{
    public class CreatePartyDBExecuter
    {
        private CreatePartyDAO dao { get; }

        public CreatePartyDBExecuter()
        {
            dao = new CreatePartyDAO();
        }

        public (string Address, int Idx) getPlaceAddress(int cityIndex, string name)
        {
            return dao.selectPlaceAddress(cityIndex, name);
        }

        public List<string> getPlaceName(int cityIndex)
        {
            return dao.selectPlaceName(cityIndex);
        }

        public List<string> getCityName()
        {
            return dao.selectCity();
        }

        public int setPartyDTO(CreatePartyDTO dto)
        {
            return dao.insertParty(dto);
        }

        public int setListDTO(ListDTO listDTO)
        {
            return dao.insertList(listDTO);
        }
        public int setRecordDTO(RecordDTO recordDTO)
        {
            return dao.insertRecord(recordDTO);
        }




        public MySqlCommand aa12aaa3123()
        {
            MySqlCommand cmd = new MySqlCommand();
            string sql = $"insert into `Party` (`Activity_idx`, `Leader_idx`, `name`, `Place_idx`, `date`, `max`, `count`) valuse (????)";
            cmd.CommandText = sql;
            cmd.Parameters.Add(new MySqlParameter("123", MySqlDbType.VarString, 20));
            cmd.Parameters.Add(new MySqlParameter());
            return cmd;
        }



        public int setPartyDTO1(CreatePartyDTO dto)
        {
            string date = dto.date.ToString("yyyy-MM-dd HH:mm:ss");
            string sql = $"insert into `Party` (`Activity_idx`, `Leader_idx`, `name`, `Place_idx`, `date`, `max`, `count`) " +
                         $"values({dto.Activity_idx}, {dto.Leader_idx}, \"{dto.name}\", {dto.Place_idx}, \"{date}\", {dto.max}, {dto.count})";
            return dao.nonSQL(sql);
        }

        public (string Address, int Idx) getPlaceAddress1(int cityIndex, string name)
        {
            string sql = $"select address, idx from Place where City_idx = {cityIndex} and name = \"{name}\"";
            /*using (MySqlDataReader reader = dao.selectUsingReader(sql))
            {
                (string Address, int Idx) result = default;
                if (reader.Read())
                {
                    result.Address = reader.GetString("address");
                    result.Idx = reader.GetInt32("idx");
                }
                return result;
            }*/
            DataSet ds = dao.selectUsingAdapter(sql);
            (string Address, int Idx) result = default;
            if (ds.Tables[0].Rows.Count > 0)
            {
                result.Address = ds.Tables[0].Rows[0]["address"].ToString();
                result.Idx = Int32.Parse(ds.Tables[0].Rows[0]["idx"].ToString());
            }
            return result;
        }
    }
}
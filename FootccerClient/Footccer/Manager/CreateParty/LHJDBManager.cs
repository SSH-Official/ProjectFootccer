using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.Manager.CreateParty
{
    public class LHJDBManager
    {
        private DAO dao { get;}

        public LHJDBManager()
        {
            dao = new DAO();
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


        public (string Address, int Idx) getPlaceAddress1(int cityIndex, string name)
        {
            string sql = $"select address, idx from Place where City_idx = {cityIndex} and name = \"{name}\"";
            MySqlDataReader reader = dao.selectUsingReader(sql);
            (string Address, int Idx) result = default;
            if (reader.Read())
            {
                result.Address = reader.GetString("address");
                result.Idx = reader.GetInt32("idx");
            }
            reader.Close();
            return result;
        }
    }
}

using FootccerClient.Footccer.DTO;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootccerClient.Footccer.DAO.CRUD
{
    public class Position_CRUD : CRUD_Base
    {
        public Position_CRUD(MySqlCommand cmd) : base(cmd)
        {
        }

        public List<PositionDTO> getPositionList()
        {
            string sql = "SELECT * FROM `Position`;";            
            cmd.CommandText = sql;

            return ReadDataList((rdr) =>
            {
                int idx = Convert.ToInt32(rdr["idx"]);
                string position = Convert.ToString(rdr["position"]);
                PositionDTO ps = new PositionDTO(idx, position);

                return ps;
            });
        }
    }
}

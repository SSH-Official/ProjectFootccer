using FootccerClient.Footccer.DAO.CRUD;
using FootccerClient.Footccer.DTO;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootccerClient.Footccer.DAO
{
    public class Position_DAO : DAO_Base
    {
        public List<PositionDTO> getPositionList() => ExecuteTransaction((cmd) =>
        {
            var CRUD = new Position_CRUD(cmd);

            return CRUD.getPositionList();
        });
        
    }
}

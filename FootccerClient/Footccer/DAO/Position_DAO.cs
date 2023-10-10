using FootccerClient.Footccer.DAO.Base;
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
    public partial class Position_DAO : DAO_Base
    {
        public List<PositionDTO> getPositionList() => ExecuteTransaction(new CRUD(), (CRUD) => CRUD.getPositionList());
        
    }
}

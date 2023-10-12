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
    public partial class PartySearch_DAO : DAO_Base
    {
        public List<CityDTO> ReadAllCity() => ExecuteTransaction(new CRUD(), (CRUD) => CRUD.ReadAllCity());
        public List<ActivityDTO> ReadAllActivities() => ExecuteTransaction(new CRUD(), (CRUD) => CRUD.ReadAllActivities());
        public List<PartyDTO> ReadParty(string kind, string seed) => ExecuteTransaction(new CRUD(), (CRUD) => CRUD.ReadParty(kind, seed));

    }
}

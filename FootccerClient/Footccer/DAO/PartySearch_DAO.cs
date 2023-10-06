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
    public class PartySearch_DAO : DAO_Base
    {
        public List<CityDTO> ReadAllCity() => ExecuteTransaction((cmd) =>
        {
            var CRUD = new PartySearchCRUD(cmd);

            return CRUD.ReadAllCity();
        });
        

        public List<ActivityDTO> ReadAllActivities() => ExecuteTransaction((cmd) =>
        {
            var CRUD = new PartySearchCRUD(cmd);
            
            return CRUD.ReadAllActivities();
        });


        public List<PartyDTO> ReadParty(string kind, string seed) => ExecuteTransaction((cmd) =>
        {
            var CRUD = new PartySearchCRUD(cmd);
        
            return CRUD.ReadParty(kind, seed);
        });
        
        
    }
}

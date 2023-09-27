using FootccerClient.Footccer.DBExecuter;
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
        string strConn { get { return App.Instance.DB.Settings.ConnectionString; } }
        MySqlConnection conn = null;


        public List<CityDTO> ReadAllCity()
        {
            List<CityDTO> result = ExecuteTransaction((cmd) =>{
                
                PartySearchDBExecuter DBE = new PartySearchDBExecuter(cmd);
                
                return DBE.SetSQL_ReadAllCity().ReadAllCity();

            }) as List<CityDTO>;

            return result;
        }


        public List<ActivityDTO> ReadAllActivities()
        {
            return ExecuteTransaction((cmd) => {

                PartySearchDBExecuter DBE = new PartySearchDBExecuter(cmd);

                return DBE.SetSQL_ReadAllActivities().ReadAllActivities();

            }) as List<ActivityDTO>;
        }
        
        
        public List<PartyDTO> ReadParty(string kind, string seed)
        {
            return ExecuteTransaction((cmd) =>
            {
                PartySearchDBExecuter DBE = new PartySearchDBExecuter (cmd);

                return DBE.SetSQL_ReadParty(kind, seed).ReadParty();

            }) as List<PartyDTO>;
        }
        
    }
}

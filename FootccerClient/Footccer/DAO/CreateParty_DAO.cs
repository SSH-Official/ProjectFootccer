using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using System.Data;
using FootccerClient.Footccer.DTO;
using FootccerClient.Windows.Pops;
using System.Windows.Forms;
using FootccerClient.Footccer.DAO.Base;

namespace FootccerClient.Footccer.DAO
{
    public partial class CreateParty_DAO : DAO_Base
    {
        public (string Address, int Idx) getPlaceAddress(int cityIndex, string name) => ExecuteTransaction(new CRUD(), (CRUD) => CRUD.selectPlaceAddress(cityIndex, name));
        public List<string> getPlaceName(int cityIndex) => ExecuteTransaction(new CRUD(), (CRUD) => CRUD.selectPlaceName(cityIndex));
        public List<string> getCityName() => ExecuteTransaction(new CRUD(), (CRUD) => CRUD.selectCity());
        public List<string> getActivityName() => ExecuteTransaction(new CRUD(), (CRUD) => CRUD.selectActivity());
        public int setPartyDTO(CreatePartyDTO dto) => ExecuteTransaction(new CRUD(), (CRUD) => CRUD.insertParty(dto));
        public int setListDTO(ListDTO listDTO) => ExecuteTransaction(new CRUD(), (CRUD) => CRUD.insertList(listDTO));
        public int setRecordDTO(RecordDTO recordDTO) => ExecuteTransaction(new CRUD(), (CRUD) => CRUD.insertRecord(recordDTO));

    }

    
}
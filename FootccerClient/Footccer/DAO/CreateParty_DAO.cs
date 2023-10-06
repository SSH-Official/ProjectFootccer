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
using FootccerClient.Footccer.DBExecuter;
using FootccerClient.Footccer.DAO.CRUD;

namespace FootccerClient.Footccer.DAO
{
    public class CreateParty_DAO : DAO_Base
    {        
        public (string Address, int Idx) getPlaceAddress(int cityIndex, string name) => ExecuteTransaction((cmd) =>
        {
            var CRUD = new CreatePartyCRUD(cmd);

            return CRUD.selectPlaceAddress(cityIndex, name);
        });
        

        public List<string> getPlaceName(int cityIndex) => ExecuteTransaction((cmd) =>
        {
            var CRUD = new CreatePartyCRUD(cmd);

            return CRUD.selectPlaceName(cityIndex);
        });
        

        public List<string> getCityName() => ExecuteTransaction((cmd) =>
        {
            var CRUD = new CreatePartyCRUD(cmd);

            return CRUD.selectCity();
        });

        public List<string> getActivityName() => ExecuteTransaction((cmd) =>
        {
            var CRUD = new CreatePartyCRUD(cmd);

            return CRUD.selectActivity();
        });

        public int setPartyDTO(CreatePartyDTO dto) => ExecuteTransaction((cmd) =>
        {
            var CRUD = new CreatePartyCRUD(cmd);

            return CRUD.insertParty(dto);
        });

        public int setListDTO(ListDTO listDTO) => ExecuteTransaction((cmd) =>
        {
            var CRUD = new CreatePartyCRUD(cmd);

            return CRUD.insertList(listDTO);
        });


        public int setRecordDTO(RecordDTO recordDTO) => ExecuteTransaction((cmd) =>
        {
            var CRUD = new CreatePartyCRUD(cmd);

            return CRUD.insertRecord(recordDTO);
        });

    }
}
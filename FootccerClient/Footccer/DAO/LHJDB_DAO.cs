using FootccerClient.Footccer.DAO.CRUD;
using FootccerClient.Footccer.DTO;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootccerClient.Footccer.DAO
{
    public class LHJDB_DAO : DAO_Base
    {
        public DataTable getRecordTable() => ExecuteTransaction((cmd) =>
        {
            var CRUD = new LHJDB_CRUD(cmd);

            return CRUD.getRecordTable();
        });

            
        public CalculateEloDTO getPartyAverageELO(int idx) => ExecuteTransaction((cmd) =>
        {
            var CRUD = new LHJDB_CRUD(cmd);

            return CRUD.getPartyAverageELO(idx);
        });
        
        public int updateRecord(RecordDTO dto) => ExecuteTransaction((cmd) =>
        {
            var CRUD = new LHJDB_CRUD(cmd);

            return CRUD.updateRecord(dto);
        });

        public int updateElo(int Party_idx, int alter_elo, char side) => ExecuteTransaction((cmd) =>
        {
            var CRUD = new LHJDB_CRUD(cmd);

            return CRUD.updateElo(Party_idx,alter_elo,side);
        });

        

        public int insertStat(StatDTO dto) => ExecuteTransaction((cmd) =>
        {
            var CRUD = new LHJDB_CRUD(cmd);

            return CRUD.insertStat(dto);
        });

        public StatDTO getStat(int List_idx) => ExecuteTransaction((cmd) =>
        {
            var CRUD = new LHJDB_CRUD(cmd);

            return CRUD.getStat(List_idx);
        });

        public int updateStat(StatDTO dto) => ExecuteTransaction((cmd) =>
        {
            var CRUD = new LHJDB_CRUD(cmd);

            return CRUD.updateStat(dto);
        });       

    }
}

using FootccerClient.Footccer.DAO.Base;
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
    public partial class LHJDB_DAO : DAO_Base
    {
        public DataTable getRecordTable() => ExecuteTransaction(new CRUD(), (CRUD) => CRUD.getRecordTable());            
        public CalculateEloDTO getPartyAverageELO(int idx) => ExecuteTransaction(new CRUD(), (CRUD) => CRUD.getPartyAverageELO(idx));        
        public int updateRecord(RecordDTO dto) => ExecuteTransaction(new CRUD(), (CRUD) => CRUD.updateRecord(dto));
        public int updateElo(int Party_idx, int alter_elo, char side) => ExecuteTransaction(new CRUD(), (CRUD) => CRUD.updateElo(Party_idx, alter_elo, side));
        public int insertStat(StatDTO dto) => ExecuteTransaction(new CRUD(), (CRUD) => CRUD.insertStat(dto));
        public StatDTO getStat(int List_idx) => ExecuteTransaction(new CRUD(), (CRUD) => CRUD.getStat(List_idx));
        public int updateStat(StatDTO dto) => ExecuteTransaction(new CRUD(), (CRUD) => CRUD.updateStat(dto));

        public DataTable getELORecordTable() => ExecuteTransaction(new CRUD(), (CRUD) => CRUD.getELORecordTable());

    }
}

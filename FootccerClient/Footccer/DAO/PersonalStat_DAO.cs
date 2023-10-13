using FootccerClient.Footccer.DAO.Base;
using FootccerClient.Footccer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.DAO
{
    public partial class PersonalStat_DAO : DAO_Base
    {
        public PersonalStatDTO Getactstat(int idx) => ExecuteTransaction(new CRUD(), (CRUD) => CRUD.Getactstat(idx));
    }
}

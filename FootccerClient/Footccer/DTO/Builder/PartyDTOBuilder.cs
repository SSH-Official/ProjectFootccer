using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FootccerClient.Footccer.DTO.Builder
{
    public class PartyDTOBuilder : DTOBuilder<PartyDTO>
    {
        int idx;
        string Actname;
        string Uname;
        string Parname;
        string CTname;
        string PLname;
        string PLaddress;
        DateTime date;
        int max;
        int count;
        int Uidx;


        public PartyDTOBuilder SetIndex(int idx) => SetParameter(ref this.idx, idx);
        public PartyDTOBuilder SetActname(string actname) => SetParameter(ref this.Actname, actname);
        public PartyDTOBuilder SetUname(string uname) => SetParameter(ref this.Uname, uname);
        public PartyDTOBuilder SetParname(string parname) => SetParameter(ref this.Parname, parname);
        public PartyDTOBuilder SetCTname(string ctname) => SetParameter(ref this.CTname, ctname);
        public PartyDTOBuilder SetPLname(string plname) => SetParameter(ref this.PLname, plname);
        public PartyDTOBuilder SetPLaddress(string pladdress) => SetParameter(ref this.PLaddress, pladdress);
        public PartyDTOBuilder SetDate(DateTime date) => SetParameter(ref this.date, date);
        public PartyDTOBuilder SetMax(int max) => SetParameter(ref this.max, max);
        public PartyDTOBuilder SetCount(int count) => SetParameter(ref this.count, count);
        public PartyDTOBuilder SetUidx(int uidx) => SetParameter(ref this.Uidx, uidx);
        public PartyDTOBuilder SetParameter<T>(ref T param, T value)
        {
            param = value;
            return this;
        }
        public PartyDTO Build()
        {
            return new PartyDTO(idx, Actname, Uname, Parname, CTname, PLname, PLaddress, date.ToString(), max, count, Uidx);
        }

    }
}

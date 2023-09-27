using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.DTO
{
    public class PartyDTO
    {
        public int idx { get; set; }
        public string Actname { get; set; }
        private string Uname { get; set; }
        private int Uidx { get; }
        public string UserWithTag { get { return $"{this.Uname}#{this.Uidx}"; } }
        public string Parname { get; set; }
        public string CTname { get; set; }
        public string PLname { get; set; }
        public string PLaddress { get; set; }
        public string date { get; set; }
        public int max { get; set; }
        public int count { get; set; }
        private string phone { get; }
        public PartyDTO() { }
        public PartyDTO(int idx, string Actname, string Uname, string Parname, string CTname, string PLname, string PLaddress, string date, int max, int count, int Uidx)
        {
            this.idx = idx; 
            this.Actname = Actname; 
            this.Uname=Uname; 
            this.Parname=Parname; 
            this.CTname=CTname;
            this.PLname=PLname; 
            this.PLaddress=PLaddress; 
            this.date=date;
            this.max=max;
            this.count=count;
            this.Uidx=Uidx;
        }
        public PartyDTO(string Parname,string Uname,string phone, string Actname,   string CTname, string PLname, string PLaddress, string date)
        {
            this.Actname = Actname;
            this.phone = phone;
            this.Uname = Uname;
            this.Parname = Parname;
            this.CTname = CTname;
            this.PLname = PLname;
            this.PLaddress = PLaddress;
            this.date = date;
        }
        public string toString()
        {
            string info = 
                $"제목:{Parname}\n" +
                $"작성자:{Uname}\n" +
                $"종류:{Actname}\n" +
                $"장소:{CTname}-{PLname}\n" +
                $"주소{PLaddress}\n" +
                $"날짜:{date}\n" +
                $"인원{count}/{max}";
            return info ;
        }
    }
}

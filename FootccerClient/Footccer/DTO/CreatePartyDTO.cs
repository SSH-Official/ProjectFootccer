using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.DTO
{
    public class CreatePartyDTO
    {
        public int Activity_idx { get; set; }
        public int Leader_idx { get; set; }
        public string name { get; set; }
        public int Place_idx { get; set; }
        public DateTime date { get; set; }
        public int max { get; set; }
        public int count { get; set; }


        public CreatePartyDTO()
        {

        }

        //인원수가 정해지지 않은 파티의 경우 intFree에 입력 받은 값을 넣으시면 됩니다.
        //이미 정해져 있는 5:5나 11:11의 경우 입력을 안하시면 됩니다.
        public CreatePartyDTO(int Acitvity_idx, int Leader_idx, string name, int Place_idx, DateTime date, int intFree = -99)
        {
            this.Activity_idx = Acitvity_idx;
            this.Leader_idx = Leader_idx;
            this.name = name;
            this.Place_idx = Place_idx;
            this.date = date;
            switch (Acitvity_idx)
            {
                case 1:
                case 2:
                    this.max = 22;
                    break;
                case 3:
                    if (intFree > 0)
                    {
                        this.max = intFree;
                    }
                    break;
                case 4:
                case 5:
                    this.max = 10;
                    break;
            }
            this.count = 1;
        }       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.DTO
{
    public class ListDTO
    {
        public int idx { get; set; }
        public int User_idx { get; set; }
        public int Party_idx { get; set; }
        public char side { get; set; }
        public int position{ get; set; }
        
        public ListDTO() 
        {

        }

        //포지션이 정해 지지 않은 자유 포지션 이면 값을 position값에 넣지 않으시면 됩니다.
        public ListDTO(int user_idx, int party_idx, char side, int position = -1)
        {           
            this.User_idx = user_idx;
            this.Party_idx = party_idx;
            this.side = side;
            if(position > 0)
            {
                this.position = position;
            }
        }
    }
}

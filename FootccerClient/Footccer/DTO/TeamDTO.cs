using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.DTO
{
    public class TeamDTO
    {
        private int idx { get; }
        public string 유저 { get; }
        public string side { get; }

        public int elo { get; }

        public TeamDTO(int idx,string username,string side, int elo)
        {
            this.idx = idx;
            this.유저 = username;
            this.side = side;
            this.elo = elo;
        }
    }
}

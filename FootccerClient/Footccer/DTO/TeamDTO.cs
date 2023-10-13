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
        private string 유저 { get; }
        public string UserWithTag { get { return $"{this.유저}#{this.idx}"; } }
        public string side { get; }

        public int elo { get; }

        public int formation { get; }


        public int getidx()
        {
            return idx;
        }

        public TeamDTO(int idx,string username,string side, int elo, int formation)
        {
            this.idx = idx;
            this.유저 = username;
            this.side = side;
            this.elo = elo;
            this.formation = formation;
        }
    }
}

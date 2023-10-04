using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.DTO
{
    public class RecordDTO
    {
        public int Party_idx { get; }
        public char result { get; }
        public string score { get; }
        public int alter_elo { get; }

        public RecordDTO() { }

        public RecordDTO(int Party_idx)
        {
            this.Party_idx = Party_idx;
        }
        public RecordDTO(int Party_idx, char result, string score, int alter_elo)
        {
            this.Party_idx = Party_idx;
            this.result = result;
            this.score = score;
            this.alter_elo = alter_elo;
        }
    }
}

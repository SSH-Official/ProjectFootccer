using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.DTO
{
    public class FormationDTO
    {
        public int Party_idx{ get; }
        public char side { get; }
        public int maxFW { get; }
        public int maxMF { get; }
        public int maxDF { get; }
        public int maxGK { get; }

        public FormationDTO() { }

        public FormationDTO(int Party_idx, char side, int maxFW, int maxMF, int maxDF, int maxGK)
        {
            this.Party_idx = Party_idx;
            this.side = side;
            this.maxFW = maxFW;
            this.maxMF = maxMF;
            this.maxDF = maxDF;
            this.maxGK = maxGK;
        }
    }
}

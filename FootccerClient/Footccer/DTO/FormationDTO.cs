using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.DTO
{
    public class FormationDTO
    {
        public int Party_idx{ get; set; }
        public char side { get; set; }
        public int maxFW { get; set; }
        public int maxMF { get; set; }
        public int maxDF { get; set; }
        public int maxGK { get; set; }

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

        public FormationDTO(char side, int maxFW, int maxMF, int maxDF, int maxGK)
        {
            this.side = side;
            this.maxFW = maxFW;
            this.maxMF = maxMF;
            this.maxDF = maxDF;
            this.maxGK = maxGK;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.DTO
{
    public class CalculateEloDTO
    {
        private int AteamAverageELO;
        private int BteamAverageELO;
        private const int Kconstant = 20;

        public CalculateEloDTO() 
        {

        }
        public CalculateEloDTO(int ateamAverageELO, int bteamAverageELO)
        {
            AteamAverageELO = ateamAverageELO;
            BteamAverageELO = bteamAverageELO;
        }

        public int calculator()
        {
            double eloGap = (BteamAverageELO - AteamAverageELO) / 400.0;
            double expectWinRate = 1.0 / (Math.Pow(10, eloGap) + 1.0);
            double alterElo = Kconstant * (1.0 - expectWinRate);
            return (int)alterElo;
        }
    }
}

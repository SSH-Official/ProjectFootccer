using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootccerClient.Footccer.DTO
{
    public class PersonalStatDTO
    {
        public int Game { get; set; }
        public int Victory { get; set; }
        public double Avggoal { get; set; }
        public double Avgassi { get; set; }
        public double Avgdis { get; set; }
        public int Maxgoal { get; set; }
        public int Maxassi { get; set; }
        public double Maxdis { get; set; }

        public int Getmaxpoint()
        {
            return Maxgoal + Maxassi;
        }

        public double Getavgpoint()
        {
            return Avggoal + Avgassi;
        }

        public double Getvictory()
        {
            return (Victory / (double)Game)*100;
        }


        public PersonalStatDTO(int game,int count, double avggoal, double avgassi, double avgdis, int maxgoal, int maxassi, int maxdis)
        {
            this.Game = game;
            this.Victory = count;
            this.Avggoal=avggoal;
            this.Avgassi = avgassi;
            this.Avgdis = avgdis;
            this.Maxgoal = maxgoal;
            this.Maxassi = maxassi;
            this.Maxdis = maxdis;
        }
    }

}

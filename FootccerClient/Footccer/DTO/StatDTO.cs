using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.DTO
{
    public class StatDTO
    {
        public int List_idx { get; }
        public int score { get; }
        public int assist { get; }
        public int distance { get; }
        public int heartRate { get; }

        public StatDTO() { }

        public StatDTO(int list_idx, int score, int assist, int distance, int heartRate)
        {
            List_idx = list_idx;
            this.score = score;
            this.assist = assist;
            this.distance = distance;
            this.heartRate = heartRate;
        }

        public StatDTO(int score, int assist, int distance, int heartRate)
        {
            this.score = score;
            this.assist = assist;
            this.distance = distance;
            this.heartRate = heartRate;
        }
    }
}

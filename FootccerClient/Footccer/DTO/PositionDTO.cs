using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.DTO{
    public class PositionDTO
    {
        public int idx { get; set; }
        public string position { get; set; }
        public PositionDTO(int idx,string position) {
            this.idx = idx;
            this.position = position;
        }
    }
}

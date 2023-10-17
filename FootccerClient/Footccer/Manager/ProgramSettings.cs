using FootccerClient.Footccer.FootccerComponent;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.Manager
{
    public class ProgramSettings
    {
        public PartyIndicatorSettings PartyIndicator { get; set; } = new PartyIndicatorSettings();

        public ProgramSettings()
        {
            PartyIndicator.Count = new Point(5, 2);
        }


        public class PartyIndicatorSettings
        {
            public Point Count { get; set; }
        }
    }
}

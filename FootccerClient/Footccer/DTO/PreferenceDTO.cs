using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.DTO
{
    public class PreferenceDTO
    {
        public CityDTO City { get; }
        public ActivityDTO Activity { get; }

        public PreferenceDTO(int cityidx, string cityname, int actidx, string actname)
        {
            City = new CityDTO(cityidx, cityname);
            Activity = new ActivityDTO(actidx, actname);
        }
        public override string ToString()
        {
            return $"PreferenceDTO : {{ City : {{{City}}}, Activity : {{{Activity}}} }}";
        }

        
        
    }
}

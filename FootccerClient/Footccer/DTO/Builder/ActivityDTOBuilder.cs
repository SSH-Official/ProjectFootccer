using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.DTO.Builder
{
    public class ActivityDTOBuilder
    {
        private int? index = null;
        private string name = null;


        public ActivityDTO Build()
        {
            if (this.index != null && this.name != null)
            {
                return new ActivityDTO((int)this.index, this.name);
            }
            else
            {
                throw new Exception("빌드 조건을 충족하지 않습니다.");
            }
        }

        public ActivityDTOBuilder Index(int index)
        {
            this.index = index;
            return this;
        }

        public ActivityDTOBuilder Name(string name)
        {
            this.name = name;
            return this;
        }
    }
}

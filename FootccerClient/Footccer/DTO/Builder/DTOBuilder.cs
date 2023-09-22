using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.DTO.Builder
{
    public interface DTOBuilder<T>
    {
        T Build();
    }
}

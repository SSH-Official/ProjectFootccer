using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.Util
{
    public static class Class1
    {
        public static int ExtendedCount<T>(this List<T> list)
        {
            return list.Count;
        }
    }
}

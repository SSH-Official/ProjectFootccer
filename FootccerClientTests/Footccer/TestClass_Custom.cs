using FootccerClient.Footccer.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClientTests.Footccer
{
    public class TestClass_Custom<T> where T : new()
    {
        protected T TheClass 
        {
            get
            {
                return new T(); 
            }
        }
    }
}

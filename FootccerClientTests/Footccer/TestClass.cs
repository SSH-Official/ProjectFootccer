using FootccerClient.Footccer.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClientTests.Footccer
{
    public class TestClass<T> : TestClass<T, object> where T : new()
    {
    }

    public class TestClass<T, Base> where T : Base, new()
    {
        protected T TheClass { get; }

        public TestClass()
        {
            TheClass = new T();
        }

    }
}

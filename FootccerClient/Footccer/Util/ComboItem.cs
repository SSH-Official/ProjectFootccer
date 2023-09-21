using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.Util
{
    class ComboItem
    {
        public string Key { get; set; }
        public object Value { get; set; }
        public ComboItem() { }
        public ComboItem(string aKey, object aValue)
        {
            Key = aKey;
            Value = aValue;
        }

        public override string ToString()
        {
            return Key;// +"["+Value.ToString()+"]";
        }
    }
}

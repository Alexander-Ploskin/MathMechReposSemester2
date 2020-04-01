using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListFunctions
{
    class MyList: List<int>
    {
        public List<int> Map(List<int> list, Func<int, int> func)
        {
            list.ForEach()
            return list;
        }

        public List<int> Filter(List<int> list, Func<int, bool> func)
        {
            
        }
    }
}

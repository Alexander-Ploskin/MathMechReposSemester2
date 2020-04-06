using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueList
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List();
            list.Add(0, 0);
            list.Add(1, 1);
            list.Add(2, 1);
            list.GetValueOfElementByPosition(0);
            list.GetValueOfElementByPosition(1);
            list.GetValueOfElementByPosition(2);
        }
    }
}

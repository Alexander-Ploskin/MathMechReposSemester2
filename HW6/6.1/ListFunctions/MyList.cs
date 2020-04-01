using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListFunctions
{
    public static class ListFunctions
    {
        public static List<int> Map(List<int> list,Func<int, int> func)
        {
            var output = new List<int>();

            foreach (int item in list)
            {
                output.Add(func(item));
            }

            return output;
        }

        public static List<int> Filter(List<int> list, Func<int, bool> func)
        {
            foreach (int item in list)
            {
                if (func(item))
                {
                    list.Remove(item);
                }
            }

            return list;
        }

        public static int Fold(List<int> list, int counter, Func<int, int, int> func)
        {
            foreach (int item in list)
            {
                counter = func(counter, item);
            }

            return counter;
        }

    }
}

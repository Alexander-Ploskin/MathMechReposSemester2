using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class BasicHashFunction: IHashFunction
    {
        public int HashFunction(string inputString, int size)
        {
            int result = 0;

            for (int i = 0; i < inputString.Length; ++i)
            {
                result = ((result + inputString[i]) + size) % size;
            }

            return result;
        }

    }
}

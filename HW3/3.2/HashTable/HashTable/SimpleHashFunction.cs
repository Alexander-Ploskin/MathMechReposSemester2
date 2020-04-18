using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    /// <summary>
    /// Simple and not effective hash function only for test of changebility of hash function
    /// </summary>
    public class SimpleHashFunction: IHashFunction
    {
        public int HashFunction(string inputString)
        {
            int result = 0;
            for (int i = 0; i < inputString.Length; ++i)
            {
                result += Convert.ToInt32(inputString[i]) - 10;
            }
            return result;
        }
    }
}
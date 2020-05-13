using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    /// <summary>
    /// Classes that implements that interface has hash function 
    /// </summary>
    public interface IHashFunction
    {
        /// <summary>
        /// Creates non-random int by string
        /// </summary>
        /// <param name="inputString">String you wanna to hash</param>
        /// <param name="size">Size of hash table</param>
        /// <returns>Non-random int</returns>
        int HashFunction(string inputString);
    }
}

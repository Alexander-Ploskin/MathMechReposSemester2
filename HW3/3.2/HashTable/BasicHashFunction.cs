﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    /// <summary>
    /// Basic hash function to hash table
    /// </summary>
    class BasicHashFunction: IHashFunction
    {
        /// <summary>
        /// Creates int that corresponds to number of cell in hash array
        /// </summary>
        /// <param name="inputString">String you wanna to hash</param>
        /// <param name="size">Size of hash table</param>
        /// <returns>Int by your string</returns>
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

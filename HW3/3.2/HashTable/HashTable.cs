﻿using System;

namespace HashTable
{
    ///<summary>
    ///The hash table class
    ///Contains all methods to work with hash table 
    ///</summary>
    ///<remarks>
    ///This hash table can change hash function optionally
    ///</remarks>
    public class HashTable
    {
        private IHashFunction hashFunction;

        private int size = 20;

        private double loadFactor = 0.0;

        private List[] hashArray = new List[20];

        /// <summary>
        /// Basic constructor, uses basic hash function
        /// </summary>
        public HashTable()
        {
            this.hashFunction = new BasicHashFunction();

            for (int i = 0; i < size; ++i)
            {
                hashArray[i] = new List();
            }
        }

        /// <summary>
        /// Hash table uses users hash function
        /// </summary>
        /// <param name="hashFunction">Hash function, that you wanna to use in hash table</param>
        public HashTable(IHashFunction hashFunction)
        {
            this.hashFunction = hashFunction;

            for (int i = 0; i < size; ++i)
            {
                hashArray[i] = new List();
            }
        }

        /// <summary>
        /// Changes hash function of hash table
        /// </summary>
        /// <param name="newHashFunction">
        /// Instance of class that inplements interface IHashTable
        /// </param>
        public void ChangeHashFunction(IHashFunction newHashFunction)
        {
            hashFunction = newHashFunction;

            for (int i = 0; i < hashArray.Length; ++i)
            {
                while (!hashArray[i].Empty())
                {
                    string buffer = hashArray[i].Pop();
                    hashArray[hashFunction.HashFunction(buffer, size)].Add(buffer);
                }
            }
        }

        /// <summary>
        /// Adds new element to hash table 
        /// </summary>
        /// <param name="inputString">String that you wanna to keep in hash table</param>
        public void Add(string inputString)
        {
            if (Contains(inputString))
            {
                return;
            }

            loadFactor += 1.0 / size;
            hashArray[hashFunction.HashFunction(inputString, size)].Add(inputString);
            if (loadFactor >= 1.2)
            {
                Resize();
            }
        }

        /// <summary>
        /// Calls when load factor too much
        /// Doubles hash size, but keeps all elements
        /// </summary>
        /// <remarks>load factor = amount of elements in table / hash size </remarks>
        private void Resize()
        {
            var newHashArray = new List[size * 2];

            for (int i = 0; i < hashArray.Length; ++i)
            {
                while (!hashArray[i].Empty())
                {
                    string buffer = hashArray[i].Pop();
                    newHashArray[hashFunction.HashFunction(buffer, size * 2)].Add(buffer);
                }
            }

            hashArray = newHashArray;
            loadFactor /= 2;
            size *= 2;
        }

        /// <summary>
        /// Removes string from the table 
        /// </summary>
        /// <param name="value">String that you wanna to remove</param>
        /// <remarks>If string doesn't contain in table, function do nothing</remarks>
        public void Remove(string value)
        {
            hashArray[hashFunction.HashFunction(value, size)].RemoveByValue(value);
            loadFactor -= 1 / size;
        }

        /// <summary>
        /// Checks availability of string in the table 
        /// </summary>
        /// <param name="value">String that you wanna to check</param>
        /// <returns>True if string contains in hash table, else false</returns>
        public bool Contains(string value) => hashArray[hashFunction.HashFunction(value, size)].Contains(value);

    }
}
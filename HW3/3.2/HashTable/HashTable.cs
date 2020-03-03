using System;

namespace HashTable
{
    public class HashTable
    {
        private IHashFunction hashFunction;

        private int size = 20;

        private double loadFactor = 0.0;

        private List[] hashArray = new List[20];

        public HashTable()
        {
            this.hashFunction = new BasicHashFunction();

            for (int i = 0; i < size; ++i)
            {
                hashArray[i] = new List();
            }
        }

        public HashTable(IHashFunction hashFunction)
        {
            this.hashFunction = hashFunction;

            for (int i = 0; i < size; ++i)
            {
                hashArray[i] = new List();
            }
        }

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

        public void Remove(string value)
        {
            hashArray[hashFunction.HashFunction(value, size)].RemoveByValue(value);
            loadFactor -= 1 / size;
        }

        public bool Contains(string value) => hashArray[hashFunction.HashFunction(value, size)].Contains(value);

    }
}
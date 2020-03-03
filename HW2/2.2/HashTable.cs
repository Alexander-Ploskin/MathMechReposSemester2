using System;

namespace Task2_2
{
    class HashTable
    { 
        private int size = 20;

        private double loadFactor = 0.0;

        private List[] hashArray = new List[20];

        public HashTable()
        {
            for (int i = 0; i < size; ++i)
            {
                hashArray[i] = new List();
            }
        }

        private int HashFunction(string inputString)
        {
            int result = 0;

            for (int i = 0; i < inputString.Length; ++i)
            {
                result = ((result + inputString[i]) + size) % size;
            }

            return result;
        }

        public void Add(string inputString)
        {
            loadFactor += 1.0 / size;
            hashArray[HashFunction(inputString)].Add(inputString);
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
                    newHashArray[HashFunction(buffer)].Add(buffer);
                }
            }

            hashArray = newHashArray;
            loadFactor /= 2;
            size *= 2;
        }

        public void Remove(string value)
        {
            hashArray[HashFunction(value)].RemoveByValue(value);
            loadFactor -= 1 / size;
        }

        public bool Contains(string value) => hashArray[HashFunction(value)].Contains(value);

    }
}
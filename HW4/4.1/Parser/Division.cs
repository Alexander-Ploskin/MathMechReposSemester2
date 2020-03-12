using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class Division: Operator
    {
        public Division(Operator parent)
        {
            this.parent = parent;
        }

        public override int Calculate()
        {
            if (Empty())
            {
                throw new Exception();
            }

            int valueOfRightChild = rightChild.Calculate();
            if (valueOfRightChild == 0)
            {
                throw new Exception();
            }

            return leftChild.Calculate() / rightChild.Calculate();
        }

        public override void Print()
        {
            Console.WriteLine("/ ");
        }
    }
}

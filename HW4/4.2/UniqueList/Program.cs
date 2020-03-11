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
            var list = new UniqueList();

            try
            {
                list.RemoveByPosition(5);
            }
            catch (RemoveFromEmptyListException)
            {
                Console.WriteLine("List is empty!");
            }
            catch (RemoveOfNotContainedElementException)
            {
                Console.WriteLine("List can't remove not contained element!");
            }

            try
            {
                list.Add("Dog");
                list.Add("Dog");
            }
            catch (AdditionOfContainedElementException)
            {
                Console.WriteLine("List can't contain two same elements!");
            }

        }
    }
}

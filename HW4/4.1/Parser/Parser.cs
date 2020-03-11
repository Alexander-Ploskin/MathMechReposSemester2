using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Parser
{
    public class Parser
    {
        private INodeOfParserTree root = null;

        private string readDataFromTheFile(string fileName)
        { 
            try
            {
                using (var sr = new StreamReader(fileName))
                {
                    return sr.ReadToEnd(); 
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                throw new Exception();
            }
        }

        public void createTreeByExpressionInTheFile(string fileName)
        {
            var expression = readDataFromTheFile(fileName);

            foreach (int index in expression)
            {
                S
            }
        }
    }
}

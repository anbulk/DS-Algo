using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random
{
    class Program
    {
        static void RemoveDupOnFly()
        {
            Dictionary<string,string> uniqueStream = new Dictionary<string,string>();
            List<string> output= new List<string>();
            while (true)
            {

               var word = Console.ReadLine();
                if (uniqueStream.Keys.Contains(word))
                    output.Remove(word);
                else
                {
                    //Console.WriteLine(word);
                    uniqueStream.Add(word, word);
                    output.Add(word);
                }

            }




        }



        static void Main(string[] args)
        {
            RemoveDupOnFly();
        }
    }
}

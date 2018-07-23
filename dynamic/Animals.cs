using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dynamic
{
    public class Animal{}
    public class Dog:Animal
    {
        public void Speak()
        {
            Console.WriteLine("Hav Hav");
        }
    }
    public class Cat:Animal
    {
        public static void Speak()
        {
            Console.WriteLine("Miyav Miyav");
        }
    }
}

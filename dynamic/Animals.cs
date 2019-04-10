using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dynamic
{
    public abstract class Animal
    {

        public abstract void Speak();
    }
    public class Legs
    {
        public bool isHave { get; set; }
        public int? count { get; set; }

        public virtual void test()
        {
            Console.WriteLine("In Legs");
        }
    }
    public class Dog : Animal
    {
        public override void Speak()
        {
            Console.WriteLine("Hav Hav");
        }
        public void test()
        {
            Console.WriteLine("In Dog");
        }
    }
    public class Cat : Animal
    {
        public override void Speak()
        {
            Console.WriteLine("Miyav Miyav");
        }
        public void test()
        {
            Console.WriteLine("In Cat");
        }
    }
}

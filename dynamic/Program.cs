using System;
using System.Collections.Generic;
using System.Reflection;

namespace dynamic
{
    public class MyClass<T, U> where T : U, new()//bu kısım kısıtlama için kullanılıyor eklenecek şey(T) Udan türeyecek gibi new() ile constructer boş olacak gibi
    {
        public void Add()
        {

        }
        public void Delete()
        {

        }
    }
    public class B :A{ }
    public class A { }
    public struct Insan
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int Yas { get; set; }
        public bool Askerlik { get; set; }

        public override string ToString()
        {
            Console.WriteLine($"{Ad} {Soyad}");
            return Ad + " " + Soyad;
        }
    }
    class Program
    {
        static List<Insan> insanlar = new List<Insan>
        {
            new Insan { Ad="Test1",Askerlik=true,Soyad="Test1",Yas=20},
            new Insan { Ad="Test2",Askerlik=false,Soyad="Test2",Yas=21},
            new Insan { Ad="Test3",Askerlik=true,Soyad="Test3",Yas=22},
            new Insan { Ad="Test4",Askerlik=false,Soyad="Test4",Yas=23},
            new Insan { Ad="Test5",Askerlik=true,Soyad="Test5",Yas=24},
            new Insan { Ad="Test6",Askerlik=false,Soyad="Test6",Yas=25},
            new Insan { Ad="Test7",Askerlik=true,Soyad="Test7",Yas=26},
            new Insan { Ad="Test8",Askerlik=false,Soyad="Test8",Yas=27}
        };
        static void Main(string[] args)
        {
            #region OBJECT
            MyClass<B, A> s;
            //MyClass<A, B> d; hata veriyor çünkü şarta uymuyor
            Console.WriteLine("You are in Object decleration");
            object o = GetFirstRealInsan();//o objectsi yani Insan sınıfından türetilmiş obje
            var x = (Insan)o;
            var type = o.GetType();//o objesiniin sınıfı yani İnsan sınıfının özelliklerini barındırır
            var getmethod = type.GetMethod("ToString");//insan sınıfının ToString metodunun özelliklerini barındırır
            o.GetType().GetMethod("ToString").Invoke(o,null);//metodu invoke ile doldurup çağrırır
            //YUKARIDA direk metodu nokta atışı bulduk bir kaç tane metod çağıracak isek
            var methods = type.GetMethods();
            foreach(MethodInfo method in methods)
            {
                if (method.Name.Contains("ToString"))
                {
                    method.Invoke(o, null);
                }
                if (method.Name.Contains("WhatDoYouExpect"))
                {
                    throw new NotImplementedException();
                }
            }
            #endregion
            #region DYNAMİC
            Console.WriteLine("You are in Dynamic decleration");
            dynamic d = GetFirstRealInsan();
            d.ToString();
            #endregion 
            #region test
            Type dogType = Assembly.Load("dynamic").GetType("dynamic.Dog");
            Type catType = Assembly.Load("dynamic").GetType("dynamic.Cat");
            Type legsType = Assembly.Load("dynamic").GetType("dynamic.Legs");
            /*All of Class
             *  foreach(var item in Assembly.Load("dynamic").GetTypes())
              {

              }*/
            dynamic dog = Activator.CreateInstance(dogType);
            dog.Speak();
            dogType.GetMethod("test").Invoke(dog, null);
            dynamic cat = Activator.CreateInstance(catType);
            cat.Speak();
            catType.GetMethod("test").Invoke(cat, null);
            dynamic leg = Activator.CreateInstance(legsType);
            legsType.GetMethod("test").Invoke(leg, null);
            #endregion

            MyClass<Dog, Animal> test = new MyClass<Dog, Animal>();
            MyClass<Cat, Animal> test2 = new MyClass<Cat, Animal>();

            Console.ReadKey();
        }
        private static object GetFirstRealInsan() { return new Insan { Ad = "Real", Askerlik = false, Soyad = "Soyad", Yas = 43 }; }
    }
}

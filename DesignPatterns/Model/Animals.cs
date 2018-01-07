using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Model
{
    public abstract class Animal
    {
        public void walk()
        {
            Console.WriteLine("Animal is walking");
        }

        public virtual void Speak()
        {
            Console.WriteLine("Animal Noise");
        }
    }


    public class Cat : Animal
    {
        public override void Speak()
        {
            Console.WriteLine("Meow!");
        }
    }

    public class Dog : Animal
    {
        public new void Speak()
        {
            Console.WriteLine("Woof Woof!");
        }
    }


    public struct TestStruct
    {
        public int x;
    }

    public class TestClass
    {
        public int x;
    }

    public class StructTest
    {
        public static void TakeStruct(TestStruct s)
        {
            s.x = 5;
        }

        public static void TakeClass(TestClass c)
        {
            c.x = 5;
        }
    }

    public class MyArray//:IEnumerable<>
    {
        private string[] arrayValue;

        public MyArray()
        {
            arrayValue = new string[10];

            for (int i = 0; i < 10; i++)
            {                
                arrayValue[i] = "Number " + i;
            }
        }

        public string this[long index]
        {
            get { return arrayValue[index]; }

            set { arrayValue[index] = value; }
        }

        //public IEnumerator<string> GetEnumerator()
        //{
        //    return arrayValue.GetEnumerator();
        //}

        public int Length()
        {
            return arrayValue.Length;
        }

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return arrayValue.GetEnumerator();
        //}
    }
}
using System;

namespace ActionAndFunc
{
    class Program
    {
        static int counter = 1;
        static void Method()
        {
            Console.WriteLine("{0}: I'm simply C# static method :)", counter++);
        }

        static void Method(int x)
        {
            Console.WriteLine("Method(int x) {");
            for (int i = 0; i < x; i++)
            {
                Console.WriteLine("\tI'm simply C# static method with param {0} :)", x);
            }
            Console.WriteLine("}");
        }

        delegate void MyDelegate();

        static void Main(string[] args)
        {
            Console.WriteLine("Action<T> and Lambda");

            Method(); //1 Method()

            MyDelegate myDelegate = Method;
            myDelegate(); //2 Method()

            myDelegate += Method;
            myDelegate += Method;
            myDelegate += Method;

            myDelegate(); //3,4,5,6 Method()

            Action action1 = new Action(Method);
            action1(); //7 Method()

            Action action1_1 = Method;
            action1_1(); //8 Method()

            Action action2 = () =>
            {
                Console.WriteLine("I'm simply C# LAMBDA :)");
            };
            action2(); //Lambda

            Action<int> action3 = new Action<int>(Method);
            action3(3); //Method(int x)

            Console.ReadLine();
        }
    }
}

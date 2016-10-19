using System;

namespace Func
{
    class Program
    {
        static int MethodWithoutParams()
        {
            int x = new Random().Next(1000);
            Console.WriteLine("Method(): I will return random number... {0}", x);
            return x;
        }

        static int counter = 1;
        static int Method(int x)
        {
            Console.WriteLine("{0}: I will return... {1}", counter++, x * 2);
            return x * 2;
        }

        delegate int MyDelegateInt(int x);

        static void Main(string[] args)
        {
            Console.WriteLine("Func<T>");

            Method(1);

            MyDelegateInt myDelegate = Method;
            myDelegate(2);

            myDelegate += Method;
            myDelegate += Method;
            myDelegate += Method;

            int result = myDelegate(4); //result == 4*8?
            #region result
            //result == 8 :)
            #endregion

            Func<int> func1 = MethodWithoutParams;
            Func<int, int> func2 = Method;
            #region Func<T>
            //Func<T>               - no params, returns T
            //Func<X, T>            - X as param, returns T
            //Func<X,Y, T>          - X, Y as params, returns T
            //.....
            //Func<X,Y,Z,A,B, T>    - X,Y,Z,A,B as params, returns T
            #endregion

            Console.ReadLine();
        }
    }
}

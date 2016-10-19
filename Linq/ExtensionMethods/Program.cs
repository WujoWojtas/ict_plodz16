using System;

namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Test testObject = new Test();
            testObject.TestMethod(); //method from Test
            testObject.TestMethod2(); //method from Test

            testObject.EstensionMethodForTestClass(); //extension method from Extensions
            #region supprise
            //Extensions.EstensionMethodForTestClass(testObject);
            #endregion
            testObject.EstensionMethodForTestClassWithParameter(10); //extension method from Extensions
            int result = testObject.EstensionMethodForTestClassWithParameter("COMARCH JARACZA 74/76"); //extension method from Extensions
        }
    }

    class Test
    {
        private int secretNumber = 123;
        public int publicNumber = 456;
        public DateTime Date { get; set; }

        public Test()
        {
            Date = DateTime.Now;
        }

        public void TestMethod()
        {
            Console.WriteLine("TestMethod()");
        }

        public int TestMethod2()
        {
            Console.WriteLine("TestMethod2()");
            return 2;
        }

        private void PrivateMethod()
        {
            Console.WriteLine("PrivateMethod()");
        }
    }
}

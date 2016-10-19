using System;

namespace ExtensionMethods
{
    static class Extensions
    {
        public static void EstensionMethodForTestClass(this Test testClassInstance)
        {
            Console.WriteLine("EstensionMethodForTestClass(this Test testClassInstance)");
            testClassInstance.TestMethod();
            Console.WriteLine(testClassInstance.Date);
        }

        public static void EstensionMethodForTestClassWithParameter(this Test testClassInstance, int x)
        {
            Console.WriteLine("EstensionMethodForTestClassWithParameter(this Test testClassInstance, int x)");
            for (int i = 0; i < x; i++)
            {
                Console.Write("{0}: ", i);
                testClassInstance.TestMethod();
            }
        }

        public static int EstensionMethodForTestClassWithParameter(this Test testClassInstance, string a)
        {
            Console.WriteLine("EstensionMethodForTestClassWithParameter(this Test testClassInstance, string a)");
            return a.Length;
        }
    }
}

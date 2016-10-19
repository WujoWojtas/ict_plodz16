using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var even = list.Where((listItem) => listItem % 2 == 0);

            var odd = from listItem in list
                      where listItem % 2 != 0
                      select listItem;

            DisplayList(even);
            DisplayList(odd);

            var orderedByDesc = list.OrderByDescending((item) => item);

            DisplayList(orderedByDesc);

            NotIEnumerable notIEnumerable = new NotIEnumerable();
            foreach (int x in notIEnumerable)
            {
                Console.WriteLine(x);
            }

            YieldReturn yieldReturn = new YieldReturn();
            foreach (var item in yieldReturn.GetValues(10))
            {
                Console.WriteLine("YieldReturn: {0}", item);
            }

            var yieldCollection = yieldReturn.GetValues(100000000);
            var bigList = Enumerable.Range(0, 100000001).ToList();

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            int yieldCount = yieldCollection.Count();
            stopWatch.Stop();
            Console.WriteLine("Count(): {0}", stopWatch.ElapsedMilliseconds);

            stopWatch.Restart();
            int listCount = list.Count;
            stopWatch.Stop();
            Console.WriteLine("Count: {0}", stopWatch.ElapsedMilliseconds);

            bool yieldBiggerThan100 = yieldCollection.Any((item) => item > 100);
            bool biggerThan100 = list.Any((item) => item > 100);
        }

        static void DisplayList(IEnumerable<int> list)
        {
            Console.WriteLine("##############");

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }

    class NotIEnumerable
    {
        IEnumerable<int> privateList = Enumerable.Range(0, 100);

        public IEnumerator<int> GetEnumerator()
        {
            return privateList.GetEnumerator();
        }
    }

    class YieldReturn
    {
        public IEnumerable<int> GetValues(int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (i == 15)
                {
                    yield return 100;
                }
                yield return i;
            }
        }
    }
}

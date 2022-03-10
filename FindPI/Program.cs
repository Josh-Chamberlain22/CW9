using System;
using System.Collections.Generic;
using System.Threading;

namespace FindPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the number of throws: ");
            int throws = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the number of threads: ");
            int threads = Convert.ToInt32(Console.ReadLine());
            List<FindPiThread> pie = new List<FindPiThread>();
            List<Thread> thread = new List<Thread>();
            for (int i = 0; i < threads; i++) {
                FindPiThread number1 = new FindPiThread(throws);
                pie.Add(number1);
                Thread number2 = new Thread(new ThreadStart(number1.throwDarts));
                thread.Add(number2);
                number2.Start();
                Thread.Sleep(16);
            }
            for(int i = 0; i < threads; i++)
            {
                thread[i].Join();
            }
            int inside = 0;
            for(int i = 0; i < threads; i++)
            {
                inside += pie[i].getCount();
            }
            Console.WriteLine(4 * (Convert.ToDouble((inside)) / (throws * threads)));
        }
    }
    class FindPiThread
    {
        int totalDarts;
        int count;
        Random rnd1;
        public FindPiThread(int darts)
        {
            rnd1 = new Random();
            count = 0;
            totalDarts = darts;
        }
        public int getCount()
        {
            return count;
        }
        public void throwDarts()
        {
            for(int i = 0; i < totalDarts; i++)
            {
                double x = rnd1.NextDouble();
                double y = rnd1.NextDouble();
                double length = Math.Pow(x, 2) + Math.Pow(y, 2);
                if(length <= 1)
                {
                    count++;
                }
            }
        }
    }
}

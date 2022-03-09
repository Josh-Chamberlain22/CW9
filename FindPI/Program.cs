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
            for (int i = 0; i < throws; i++) {
                FindPiThread number1 = new FindPiThread(1);
                pie.Add(number1);
                Thread number2 = new Thread(new ThreadStart(number1.throwDarts));
                thread.Add(number2);
                number2.Start();
                Thread.Sleep(16);
            }
            for(int i = 0; i < throws; i++)
            {
                thread[i].Join();
            }
            for(int i = 0; i < throws; i++)
            {
                int inside = pie[i].getCount();
                Console.WriteLine(4 * Convert.ToDouble((inside) / (throws)));
            }
            
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
            int totalDarts = darts;
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

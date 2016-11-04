using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            int max = 1000000;
            bool isCircular;
            //finding all the primes under maximal value
            List<int> primes = new List<int>();
            List<int> toClear=new List<int>();
            for (int i = 2; i < max; i++)
            {
                double root = Math.Sqrt(i);
                bool isSimple = true;
                foreach (var prime in primes)
                {
                    if (prime > root) break;
                    if (i % prime == 0)
                    {
                        isSimple = false;
                        break;
                    }
                }
                if (isSimple)
                    primes.Add(i);
            }

            while (primes.Count > 0)
            {
                isCircular = true;
                int tcount = 0;
                string temp = primes.First().ToString();
                int num = Int32.Parse(temp);
                toClear.Add(num);
                tcount++;
                for (int i = 0; i < temp.Length - 1; i++)
                {
                    temp = temp.Substring(1) + temp.Substring(0, 1);
                    num = Int32.Parse(temp);
                    if (!toClear.Contains(num))
                    {
                        if (!primes.Contains(num)) isCircular = false;
                        else
                        {
                            toClear.Add(num);
                            tcount++;
                        }
                    }
                }
                if (isCircular) count += tcount;
                foreach (var t in toClear)
                    primes.Remove(t);
                toClear.Clear();
            }
            Console.WriteLine(count);
            Console.Read();
        }
    }
}

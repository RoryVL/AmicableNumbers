using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace NumberFriends
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> Numbers = new List<int>();
            for(int i=0; i<20000;i++)
                Numbers.Add(i);

            Stopwatch timer = new Stopwatch();
            timer.Start();
            Console.WriteLine("Calculating..\n...");

            List<FriendPair> Friends = GetFriends(Numbers.Distinct().ToList());

            timer.Stop();
            Console.WriteLine("Time elapsed: " + timer.Elapsed + "\n...");

            Console.WriteLine("Number of friends found:" + Friends.Count);
            foreach (FriendPair fp in Friends)
                Console.WriteLine("Following numbers are friends: " + fp);
            
            Console.ReadLine();
        }

        static List<FriendPair> GetFriends(List<int> numbers)
        {
            List<FriendPair> Friends = new List<FriendPair>();

            for (int x=0; x<numbers.Count; x++)
            {
                for (int y=(x+1); y<numbers.Count; y++)
                {
                    if ( GetDelers(x).Sum() == y && GetDelers(y).Sum() == x )
                        Friends.Add(new FriendPair(numbers[x], numbers[y]));
                }
            }

            return Friends;
        }

        static List<int> GetDelers(int i)
        {
            List<int> delers = new List<int>();
            int max = (int)Math.Sqrt(i);
            for (int factor = 1; factor <= max; ++factor)
            { //test from 1 to the square root, or the int below it, inclusive.
                if (i % factor == 0)
                {
                    delers.Add(factor);
                    if (factor != i / factor && i / factor != i)// Don't add the square root twice, dont add the same number
                        delers.Add(i / factor);
                }
            }
            delers.Sort();
            return delers;
        }

        public struct FriendPair
        {
            public int x;
            public int y;
            public FriendPair(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public override String ToString()
            {
                return x + " and " + y;
            }
        }
    }
}

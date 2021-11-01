using System;
using System.Collections.Generic;
using System.Linq;

namespace TSPCrossover
{
    class Program
    {

        public static void printList(List<int> list) 
        {
            foreach (int item in list)
            {
                Console.Write("{0}  ", item);
            }
            Console.WriteLine("\n");
        }

        public static void crossover(List<int> parent1, List<int> parent2)
        {
            List<int> child = new List<int>();

            for (int i = 0; i < parent1.Count; i++)
                child.Add(0);

            int m = parent1.Count / 2;

            for (int i = m - 2; i <= m; i++)
            {
                child[i] = parent1[i];
            }

            for (int i = 0; i < parent2.Count; i++)
            {
                if (child[i] != 0)
                {
                    parent2.Remove(child[i]);
                }
            }


            child.InsertRange(m + 1, parent2.GetRange(0, m - 1).ToList());
            child.InsertRange(0, parent2.GetRange(m - 1, parent2.Count - m + 1).ToList());

            for (int i = 0; i < child.Count; i++)
            {
                child.Remove(0);
            }

            printList(child);

        }
        static void Main(string[] args)
        {
            List<int> parent1 = new List<int> { 7, 3, 1, 8, 2, 4, 6, 5 };
            List<int> parent2 = new List<int> { 4, 3, 2, 8, 6, 7, 1, 5 };

            Console.WriteLine("First parent: ");
            printList(parent1);
            Console.WriteLine("Second parent: ");
            printList(parent2);

            Console.WriteLine("\nChildrens: ");
            crossover(new List<int> (parent1), new List<int> (parent2));
            crossover(new List<int> (parent2), new List<int> (parent1));           
        }
    }
}

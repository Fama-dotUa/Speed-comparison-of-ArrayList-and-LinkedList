using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList_and_LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = 100000;       // Розмір списку для заповнення
            int insertions = 1000; // Кількість елементів для вставки

            // Ініціалізація списків
            ArrayList arrayList = new ArrayList();
            LinkedList<int> linkedList = new LinkedList<int>();

            // Порівняння операцій
            Console.WriteLine("Операції заповнення списку:");
            FillList(arrayList, N);
            FillList(linkedList, N);

            Console.WriteLine("\nОперації доступу до елементів (Random Access і Sequential Access):");
            AccessElements(arrayList);
            AccessElements(linkedList);

            Console.WriteLine("\nОперації вставки елементів на початок списку:");
            InsertAtBeginning(arrayList, insertions);
            InsertAtBeginning(linkedList, insertions);

            Console.WriteLine("\nОперації вставки елементів в кінець списку:");
            InsertAtEnd(arrayList, insertions);
            InsertAtEnd(linkedList, insertions);

            Console.WriteLine("\nОперації вставки елементів у середину списку:");
            InsertInMiddle(arrayList, insertions);
            InsertInMiddle(linkedList, insertions);
        }

        static void FillList(IList list, int size)
        {
            Random rand = new Random();
            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < size; i++)
            {
                list.Add(rand.Next(0, size));
            }

            stopwatch.Stop();
            Console.WriteLine($"{list.GetType().Name}: Заповнення списку зайняло {stopwatch.Elapsed} мс");
        }

        static void FillList(LinkedList<int> list, int size)
        {
            Random rand = new Random();
            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < size; i++)
            {
                list.AddLast(rand.Next(0, size));
            }

            stopwatch.Stop();
            Console.WriteLine($"{list.GetType().Name}: Заповнення списку зайняло {stopwatch.Elapsed} мс");
        }

        static void AccessElements(IList list)
        {
            Stopwatch stopwatch = new Stopwatch();

            // Random Access
            stopwatch.Start();
            for (int i = 0; i < list.Count; i += 1000)
            {
                var item = list[i];
            }
            stopwatch.Stop();
            Console.WriteLine($"{list.GetType().Name}: Random Access зайняв {stopwatch.Elapsed} мс");

            // Sequential Access
            stopwatch.Restart();
            foreach (var item in list) { }
            stopwatch.Stop();
            Console.WriteLine($"{list.GetType().Name}: Sequential Access зайняв {stopwatch.Elapsed} мс");
        }

        static void AccessElements(LinkedList<int> list)
        {
            Stopwatch stopwatch = new Stopwatch();

            // Random Access
            stopwatch.Start();
            int count = 0;
            foreach (var item in list)
            {
                if (count % 1000 == 0) { var temp = item; }
                count++;
            }
            stopwatch.Stop();
            Console.WriteLine($"{list.GetType().Name}: Random Access зайняв {stopwatch.Elapsed} мс");

            // Sequential Access
            stopwatch.Restart();
            foreach (var item in list) { }
            stopwatch.Stop();
            Console.WriteLine($"{list.GetType().Name}: Sequential Access зайняв {stopwatch.Elapsed} мс");
        }

        static void InsertAtBeginning(IList list, int count)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
            {
                list.Insert(0, i);
            }
            stopwatch.Stop();
            Console.WriteLine($"{list.GetType().Name}: Вставка на початок зайняла {stopwatch.Elapsed} мс");
        }

        static void InsertAtBeginning(LinkedList<int> list, int count)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
            {
                list.AddFirst(i);
            }
            stopwatch.Stop();
            Console.WriteLine($"{list.GetType().Name}: Вставка на початок зайняла {stopwatch.Elapsed} мс");
        }

        static void InsertAtEnd(IList list, int count)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
            {
                list.Add(i);
            }
            stopwatch.Stop();
            Console.WriteLine($"{list.GetType().Name}: Вставка в кінець зайняла {stopwatch.Elapsed} мс");
        }

        static void InsertAtEnd(LinkedList<int> list, int count)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
            {
                list.AddLast(i);
            }
            stopwatch.Stop();
            Console.WriteLine($"{list.GetType().Name}: Вставка в кінець зайняла {stopwatch.Elapsed} мс");
        }

        static void InsertInMiddle(IList list, int count)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int middle = list.Count / 2;
            for (int i = 0; i < count; i++)
            {
                list.Insert(middle, i);
            }
            stopwatch.Stop();
            Console.WriteLine($"{list.GetType().Name}: Вставка в середину зайняла {stopwatch.Elapsed} мс");
        }

        static void InsertInMiddle(LinkedList<int> list, int count)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            LinkedListNode<int> middleNode = GetMiddleNode(list);
            for (int i = 0; i < count; i++)
            {
                list.AddBefore(middleNode, i);
            }
            stopwatch.Stop();
            Console.WriteLine($"{list.GetType().Name}: Вставка в середину зайняла {stopwatch.Elapsed} мс");
        }

        static LinkedListNode<int> GetMiddleNode(LinkedList<int> list)
        {
            var slow = list.First;
            var fast = list.First;
            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            return slow;
        }
    }
}

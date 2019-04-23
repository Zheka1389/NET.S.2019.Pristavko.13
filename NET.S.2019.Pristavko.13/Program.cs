namespace NET.S._2019.Pristavko._13
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> q = new Queue<string>();
            q.Enqueue("1");
            q.Enqueue("24");
            q.Enqueue("3");
            q.Enqueue("43");
            foreach (string c in q)
            {
                Console.WriteLine("Queue: " + c);
            }
            Console.WriteLine("Dequeue: " + q.Dequeue());
            Console.WriteLine("Dequeue: " + q.Dequeue());
            foreach (string c in q)
            {
                Console.WriteLine("Queue after Dequeue: " + c);
            }
            Console.Read();
        }
    }
}

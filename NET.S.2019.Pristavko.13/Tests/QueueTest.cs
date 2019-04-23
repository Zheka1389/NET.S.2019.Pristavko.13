namespace NET.S._2019.Pristavko._13.Tests
{
    using NUnit.Framework;
    using System.Linq;

    [TestFixture]
    internal class QueueTest
    {
        [Test]
        public void Queue_Enqueue()
        {
            var queueInt = new Queue<int>();
            queueInt.Enqueue(34);
            queueInt.Enqueue(54);
            queueInt.Enqueue(2);
            queueInt.Enqueue(544);
            queueInt.Enqueue(23);
            queueInt.Enqueue(5224);

            var queueDouble = new Queue<double>();
            queueDouble.Enqueue(34.9);
            queueDouble.Enqueue(54);
            queueDouble.Enqueue(2);
            queueDouble.Enqueue(544);
            queueDouble.Enqueue(23);
            queueDouble.Enqueue(5224);

            Assert.AreEqual(queueInt.ToArray(), new[] { 34, 54, 2, 544, 23, 5224 });
            Assert.AreEqual(queueDouble.ToArray(), new[] { 34.9, 54, 2, 544, 23, 5224 });
        }

        [Test]
        public void Queue_Dequeue()
        {
            var queue = new Queue<int>(new[] { 34, 54, 2, 544, 23, 5224 });
            queue.Dequeue();
            queue.Dequeue();

            Assert.AreEqual(queue.ToArray(), new[] { 2, 544, 23, 5224 });
        }

        [Test]
        public void Queue_Peek()
        {
            var queue = new Queue<int>(new[] { 2, 544, 23, 5224 });
            
            Assert.AreEqual(queue.Peek(), 2);
        }

        [Test]
        public void Queue_Clear()
        {
            var queue = new Queue<int>(new[] { 23, 43, 34, 43, 454, 342 });
            queue.Clear();

            Assert.AreEqual(queue.ToArray(), new int[] { });
        }
    }
}

using System;

namespace Assignment4
{
    //Question 1
    public class Storage<T>
    {
        //private T item;

        public T item
        {
            get { return item; }
            set { item = value; }
        }

    }
    //Question2
    public class Pair<T1, T2>
    {
        // Properties to store the pair of values  
        public T1 First { get; set; }
        public T2 Second { get; set; }

        // Constructor to initialize the pair  
        public Pair(T1 first, T2 second)
        {
            First = first;
            Second = second;
        }

        // Method to display both values  
        public void PrintPair()
        {
            Console.WriteLine($"First: {First}, Second: {Second}");
        }
    }
    //Question 4
    public class Stack<T>
    {
        private T[] _items;
        private int _topIndex;

        public Stack(int initialCapacity = 10)
        {
            _items = new T[initialCapacity];
            _topIndex = -1;
        }

        public void Push(T item)
        {
            if (_topIndex == _items.Length - 1)
            {
                // Increase capacity if necessary
                Array.Resize(ref _items, _items.Length * 2);
            }

            _items[++_topIndex] = item;
        }

        public T Pop()
        {
            if (_topIndex == -1)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            return _items[_topIndex--];
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index > _topIndex)
                {
                    throw new IndexOutOfRangeException("Invalid index.");
                }

                return _items[index];
            }
        }
    }
    //Question 5
    public class Queue<T>
    {
        private T[] _items;
        private int _headIndex; // Index of the first element
        private int _tailIndex; // Index after the last element

        public Queue(int initialCapacity = 10)
        {
            _items = new T[initialCapacity];
            _headIndex = 0;
            _tailIndex = 0;
        }

        public void Enqueue(T item)
        {
            if (IsFull())
            {
                // Increase capacity if necessary
                Array.Resize(ref _items, _items.Length * 2);
            }

            _items[_tailIndex++] = item;
            _tailIndex %= _items.Length; // Wrap around tail index
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            T item = _items[_headIndex];
            _headIndex++;
            _headIndex %= _items.Length; // Wrap around head index

            return item;
        }

        public T this[int index]
        {
            get
            {
                if (IsEmpty() || index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException("Invalid index.");
                }

                int actualIndex = (_headIndex + index) % _items.Length;
                return _items[actualIndex];
            }
        }

        private bool IsEmpty()
        {
            return _headIndex == _tailIndex;
        }

        private bool IsFull()
        {
            return (_tailIndex + 1) % _items.Length == _headIndex;
        }

        public int Count
        {
            get
            {
                if (_tailIndex >= _headIndex)
                {
                    return _tailIndex - _headIndex;
                }
                else
                {
                    return _items.Length - _headIndex + _tailIndex;
                }
            }
        }
    }
    internal class Program
    {
      
        static void Main(string[] args)
        {
            //Question 1
            Storage<int> storage = new Storage<int>();
            storage.item = 123;
            Console.WriteLine("Stored Integer is : " + storage.item);

            Storage<string> storage2 = new Storage<string>();
            storage2.item = "Hello World!";
            Console.WriteLine("Stored String is : "+ storage2.item);

            Storage<double> storage3 = new Storage<double>();
            storage3.item = 3.145;
            Console.WriteLine("Stored Double value is : " + storage3.item);


            //Question 2
            Pair<int, string> pair1 = new Pair<int, string>(1, "One");
            pair1.PrintPair();
  
            Pair<string, double> pair2 = new Pair<string, double>("Pi", 3.14);
            pair2.PrintPair();
 
            Pair<double, bool> pair3 = new Pair<double, bool>(2.718, true);
            pair3.PrintPair();

            //Question 4
            Stack<int> integerStack = new Stack<int>();
            integerStack.Push(10);
            integerStack.Push(20);
            integerStack.Push(30);

            Console.WriteLine(integerStack[0]); 
            Console.WriteLine(integerStack[1]); 
            Console.WriteLine(integerStack.Pop());

            //Question 5
            Queue<string> stringQueue = new Queue<string>();
            stringQueue.Enqueue("Hello");
            stringQueue.Enqueue("World!");

            Console.WriteLine(stringQueue[0]); 
            Console.WriteLine(stringQueue.Dequeue());

            Console.ReadLine();

        }
    }
}

using System;

namespace Lesson18
{
    class MyDictionary<Tkey, Tval>
    {
        private int counter = 0;
        private Tkey[] keysArray = null;
        private Tval[] valsArray = null;

        public int Counter
        {
            get { return this.counter; }
        }

        public void Add(Tkey key, Tval val)
        {
            this.counter++;

            Array.Resize(ref keysArray, counter);
            keysArray[counter - 1] = key;

            Array.Resize(ref valsArray, counter);
            valsArray[counter - 1] = val;
        }

        public Tval this[Tkey key]
        {
            get
            {
                int ind = 0;
                for (int i = 0; i < keysArray.Length; i++)
                {
                    if (key.Equals(keysArray[i]))
                        ind = i;
                }

                return valsArray[ind];
            }
        }
    }

    class MyList<T>
    {
        private T[] myList = null;

        public T this[int index]
        {
            get { return myList[index]; }
            set { myList[index] = value; }
        }

        public MyList()
        {
            myList = new T[1];
        }

        public MyList(int count)
        {
            myList = new T[count];
        }

        public void Add(T item)
        {
            T[] extendedList = new T[myList.Length + 1];
            extendedList[extendedList.Length - 1] = item;
            myList = extendedList;
        }

        public int Capacity
        {
            get { return myList.Length; }
        }

        public int Count
        {
            get
            {
                int count = 0;
                for (int i = 0; i < myList.Length; i++)
                {
                    if (myList[i].ToString() != null)
                    {
                        count++;
                    }
                }

                return count;
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> mylist = new MyList<int>(5);
            mylist[0] = 1;
            Console.WriteLine("Емкость списка: {0} элемент(-ов)", mylist.Capacity);
            Console.WriteLine("Список фактически содержит: {0} элемент(-ов)", mylist.Count);
            mylist.Add(15);
            Console.WriteLine("Емкость списка: {0} элемент(-ов)", mylist.Capacity);

            MyDictionary<int, string> mydictionary = new MyDictionary<int, string>();
            mydictionary.Add(1,"Dear");
            mydictionary.Add(2,"De");
            Console.WriteLine(mydictionary.Counter);
            Console.WriteLine($"Выбор по индексу [1]: \n{mydictionary[1]}");
            Console.ReadKey();
        }
    }
}
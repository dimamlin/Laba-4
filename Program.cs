using System;

namespace laba_4_
{
    static class StatisticOperation
    {
        public static int WordCount(this string str, char c)
        {
            int counter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                    counter++;
            }
            return counter;
        }
    }
    class DATA
    {
        public string dataName = "дата создания 06.10.2019"; // дата создания
    }
    class A
    {
        public override string ToString()
        {
            return "Объекты класса MyArr:";
        }
    }
    class MyArr : DATA
    {
        const string name = "My arr"; // название
        private int[] Arr = null;
        public int data = 0;
        public readonly int ID;
        static int counter = 0;

        public MyArr() {  Console.WriteLine("конструктор по умолчанию"); }


        public MyArr(int _val, int val)
        {
            Console.WriteLine("конструктор с параметрами");
            data = _val;
            for (int i = 0; i < data; i++)
            {
                counter = counter + 1;
            }
            Console.WriteLine("Колличество оъектов:" + counter);
            //Конструктор  
            Arr = new int[data];
            for (int i = 0; i < data; i++)
                Arr[i] = val;
            // генерация ID
            int sum = 0;
            for (int i = 0; i < data; i++)
            {
                sum += Arr[i];
                ID = sum * 2;
                counter = counter + 1;
            }

        }

        public MyArr(int _val)
        {
            data = _val;
            Arr = new int[data];
            for (int i = 0; i < data; i++)
            {
                Random rand = new Random();
                int value = rand.Next();
                Arr[i] = (value + _val) / _val;
            }
            // генерация ID
            int sum = 0;
            for (int i = 0; i < data; i++)
            {
                sum += Arr[i];
                ID = sum * 2;
            }
        }

        public void Random(int a, int b)
        {
            for (int i = 0; i < data; i++)
            {
                Random rand = new Random();
                int value = rand.Next();
                Arr[i] = ((value + a) + (a / b)) * a;
            }
        }

        public void Print()
        {
            Console.WriteLine(dataName);
            Console.WriteLine("ID:" + ID);
            Console.WriteLine("Название массива:" + name);
            Console.WriteLine("Элементы массива:");
            for (int i = 0; i < data; i++)
            {
                Console.WriteLine("" + Arr[i]);
            }
            Console.WriteLine();
        }

        public int this[int index]
        {
            get
            {
                if (index >= 0)
                { return Arr[index]; }
                else
                    Console.WriteLine("Попытка обращения за пределы массива");
                return index;
            }
            set { Arr[index] = value; }

        }

        // перегрузка операторов

        public static int operator +(MyArr c1, int val)
        {
            return c1.data + val;
        }
        ///////////////////////////////////////////
        public static int operator *(MyArr c1, int val)
        {
            return c1.data * val;
        }
        ///////////////////////////////////////////
        public static MyArr operator +(MyArr c1, MyArr c2)
        {
            return new MyArr { data = c1.data + c2.data };
        }
        ///////////////////////////////////////////
        public static MyArr operator *(MyArr c1, MyArr c2)
        {
            return new MyArr { data = c1.data * c2.data };
        }
        ///////////////////////////////////////////
        public static bool operator >(MyArr c1, MyArr c2)
        {
            return c1.data > c2.data;
        }
        ///////////////////////////////////////////
        public static bool operator <(MyArr c1, MyArr c2)
        {
            return c1.data < c2.data;
        }
        ///////////////////////////////////////////
        public static bool operator ==(MyArr arr1, MyArr arr2)
        {
            if (arr1.data == arr2.data)
            {
                for (var i = 0; i < arr1.data; i++)
                {
                    if (arr1[i] != arr2[i])
                        return false;
                }
                return true;
            }
            else
                return false;
        }
        ///////////////////////////////////////////
        public static bool operator !=(MyArr arr1, MyArr arr2)
        {
            if (arr1.data == arr2.data)
            {
                for (int i = 0; i < arr1.data; i++)
                {
                    if (arr1[i] != arr2[i])
                        return true;
                }
                return false;
            }
            else
                return true;
        }

        ///////////////////////////////////////////
        public static bool operator true(MyArr c1)
        {
            return c1.data != 0;
        }
        ///////////////////////////////////////////
        public static bool operator false(MyArr c1)
        {
            return c1.data == 0;
        }
        ///////////////////////////////////////////
        public void ArrSize()
        {
            for (int i = 0; i < data; i++)
            {
                counter = counter + 1;

            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Колличество оъектов:" + counter);
        }

        // сравнение массивов 
        public override bool Equals(object obj)
        {
            if (obj is MyArr)
            {
                if (this.data == ((MyArr)obj).data)

                    return true;
                else
                    return false;
            }
            return false;
        }

        //хэшкод
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public void ContainsZero(int counter, int insert)
        {
            for (int i = 0; i < data; i++)
            {
                counter++;
                if (Arr[i] < 0)
                { Console.WriteLine("элемент " + counter + " меньше нуля"); Arr[i] = insert; }
                else
                { Console.WriteLine("элемент " + counter + " больше  нуля"); }
            }
        }




    }



    class Program
    {
        


        static void Main(string[] args)
        {
            A userA = new A();
            Console.WriteLine(userA);
            MyArr arr = new MyArr(10, 7);
            arr.Random(-3, 6);
            arr.ContainsZero(0, 0);
            arr.Equals(5);
            arr.Print();



            MyArr c1 = new MyArr(1);
            MyArr c2 = new MyArr(1);
            MyArr c3 = c1 + c2;
            Console.WriteLine(c3.data);

            if (c1.data == c2.data)
            { Console.WriteLine("Массивы равны"); }
            else
            { Console.WriteLine("Массивы не равны"); }



            MyArr c4 = new MyArr(1);
            MyArr c5 = new MyArr(1);

            if (object.Equals(c4, c5))
            {
                Console.WriteLine("Массивы равны ");
            }
            else
                Console.WriteLine("Массивы не равны ");
        }
    }
}
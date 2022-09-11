using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] Jesus = new int[6];
            int sort = 0;
            Random Random = new Random();
            for (int i = 0; i < Jesus.Length; i++)
            {
                Jesus[i] = Random.Next(0, 22);
            }
            Console.WriteLine("Неотсортированный массив: ");
            foreach (int i in Jesus)
            {
                System.Console.Write("{0} ", i);
            }
            int max = Jesus[0];  // максимальный элемент
            for (int i = 1; i < Jesus.Length; ++i)
                if (Jesus[i] > max) max = Jesus[i];
            Console.WriteLine("");
            Console.WriteLine("Выберите метод сортировки: ");
            Console.WriteLine("1.Сортировка пузырьком");
            Console.WriteLine("2.Сортировка перемешиванием");
            Console.WriteLine("3.Сортировка расческой");
            Console.WriteLine("4.Сортировка вставками");
            Console.WriteLine("5.Сортировка выбором");
            Console.WriteLine("6.Быстрая сортировка");
            Console.WriteLine("7.Сортировка слиянием");
            Console.WriteLine("8.Пирамидальная сортировка");
            sort = Convert.ToInt32(Console.ReadLine());
            switch (sort)
            {
                case 1:
                    BubbleSort(ref Jesus);
                    foreach (int i in Jesus)
                    {
                        System.Console.Write("{0} ", i);
                    }
                    break;
                case 2:
                    ShakerSort(Jesus);
                    foreach (int i in Jesus)
                    {
                        System.Console.Write("{0} ", i);
                    }
                    break;
                case 3:
                    CombSort(ref Jesus);
                    foreach (int i in Jesus)
                    {
                        System.Console.Write("{0} ", i);
                    }
                    break;
                case 4:
                    Insertion(Jesus);
                    foreach (int i in Jesus)
                    {
                        System.Console.Write("{0} ", i);
                    }
                    break;
                case 5:
                    SelectionSort(Jesus);
                    foreach (int i in Jesus)
                    {
                        System.Console.Write("{0} ", i);
                    }
                    break;
                case 6:
                    QuickSort(Jesus, 0, 5);
                    foreach (int i in Jesus)
                    {
                        System.Console.Write("{0} ", i);
                    }
                    break;
                case 7:
                    MainMerge(Jesus, 0, 2, 5);
                    SortMerge(Jesus, 0, 5);
                    foreach (int i in Jesus)
                    {
                        System.Console.Write("{0} ", i);
                    }
                    break;
                case 8:
                    heapSort(Jesus, Jesus.Length);
                    heapify(Jesus, Jesus.Length, max);
                    foreach (int i in Jesus)
                    {
                        System.Console.Write("{0} ", i);
                    }
                    break;
            }




            Console.ReadKey();
        }

        static void BubbleSort(ref int[] Gospod)
        {
            for (int i = 0; i < Gospod.Length; i++)
            {
                for (int j = 0; j < Gospod.Length - 1; j++)
                {
                    if (Gospod[j] > Gospod[j + 1])
                    {
                        int Vazhniy = Gospod[j];
                        Gospod[j] = Gospod[j + 1];
                        Gospod[j + 1] = Vazhniy;
                    }
                }
            }
        }

        static void ShakerSort(int[] myint)
        {
            int left = 0,
                right = myint.Length - 1,
                count = 0;

            while (left <= right)
            {
                for (int i = left; i < right; i++)
                {
                    count++;
                    if (myint[i] > myint[i + 1])
                        Swap(myint, i, i + 1);
                }
                right--;

                for (int i = right; i > left; i--)
                {
                    count++;
                    if (myint[i - 1] > myint[i])
                        Swap(myint, i - 1, i);
                }
                left++;
            }

        }


        static void Swap(int[] myint, int i, int j)
        {
            int glass = myint[i];
            myint[i] = myint[j];
            myint[j] = glass;
        }

        static void Insertion(int[] Gospod) // Sorting by Insertion style
        {
            int n = Gospod.Length, i, j, val, flag;
            for (i = 1; i < n; i++)
            {
                val = Gospod[i];
                flag = 0;
                for (j = i - 1; j >= 0 && flag != 1;)
                {
                    if (val < Gospod[j])
                    {
                        Gospod[j + 1] = Gospod[j];
                        j--;
                        Gospod[j + 1] = val;
                    }
                    else flag = 1;
                }
            }
        }

        static void QuickSort(int[] Gospod, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int pivo = Part(Gospod, start, end);
            QuickSort(Gospod, start, pivo - 1);
            QuickSort(Gospod, pivo + 1, end);
        }

        static int Part(int[] Gospod, int start, int end)
        {
            int Pomoshnik;
            int marker = start;
            for (int i = start; i <= end; i++)
            {
                if (Gospod[i] < Gospod[end])
                {
                    Pomoshnik = Gospod[marker];
                    Gospod[marker] = Gospod[i];
                    Gospod[i] = Pomoshnik;
                    marker += 1;
                }
            }
            Pomoshnik = Gospod[marker];
            Gospod[marker] = Gospod[end];
            Gospod[end] = Pomoshnik;
            return marker;
        }

        static void CombSort(ref int[] Gospod)
        {
            double gap = Gospod.Length;
            bool swaps = true;

            while (gap > 1 || swaps)
            {
                gap /= 1.247330950103979;

                if (gap < 1)
                    gap = 1;

                int i = 0;
                swaps = false;
                while (i + gap < Gospod.Length)
                {
                    int igap = i + (int)gap;
                    if (Gospod[i] > Gospod[igap])
                    {
                        int temp = Gospod[i];
                        Gospod[i] = Gospod[igap];
                        Gospod[igap] = temp;
                        swaps = true;
                    }
                    ++i;
                }
            }
        }

        static void SelectionSort(int[] Gospod)
        {
            int n = Gospod.Length;
            int temp, smallest;
            for (int i = 0; i < n - 1; i++)
            {
                smallest = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (Gospod[j] < Gospod[smallest])
                    {
                        smallest = j;
                    }
                }
                temp = Gospod[smallest];
                Gospod[smallest] = Gospod[i];
                Gospod[i] = temp;
            }
        }

        static public void MainMerge(int[] Gospod, int left, int mid, int right)
        {
            int[] temp = new int[25];
            int i, eol, num, pos;
            eol = (mid - 1);
            pos = left;
            num = (right - left + 1);

            while ((left <= eol) && (mid <= right))
            {
                if (Gospod[left] <= Gospod[mid])
                    temp[pos++] = Gospod[left++];
                else
                    temp[pos++] = Gospod[mid++];
            }
            while (left <= eol)
                temp[pos++] = Gospod[left++];
            while (mid <= right)
                temp[pos++] = Gospod[mid++];
            for (i = 0; i < num; i++)
            {
                Gospod[right] = temp[right];
                right--;
            }
        }

        static public void SortMerge(int[] Gospod, int left, int right)
        {
            int mid;
            if (right > left)
            {
                mid = (right + left) / 2;
                SortMerge(Gospod, left, mid);
                SortMerge(Gospod, (mid + 1), right);
                MainMerge(Gospod, left, (mid + 1), right);
            }
        }

        static void heapSort(int[] Gospod, int n)
        {
            for (int i = n / 2 - 1; i >= 0; i--)
                heapify(Gospod, n, i);
            for (int i = n - 1; i >= 0; i--)
            {
                int temp = Gospod[0];
                Gospod[0] = Gospod[i];
                Gospod[i] = temp;
                heapify(Gospod, i, 0);
            }
        }
        static void heapify(int[] Gospod, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < n && Gospod[left] > Gospod[largest])
                largest = left;
            if (right < n && Gospod[right] > Gospod[largest])
                largest = right;
            if (largest != i)
            {
                int swap = Gospod[i];
                Gospod[i] = Gospod[largest];
                Gospod[largest] = swap;
                heapify(Gospod, n, largest);
            }

        }
    }
}

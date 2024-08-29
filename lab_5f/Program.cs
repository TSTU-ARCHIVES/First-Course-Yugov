using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Program
{
    class pro
    {
        //для начала объявим пару констант и глобальный массив, а также переменную, тоже глобальную, которая 
        //обозначает что он существует, это пригодится позже для обработки ошибок
        public static int[]? mass;
        public static int massExists = 0;
        const int MAX_NUMBERS_IN_ARRAY = 50;
        const int MIN_NUMBER_IN_ARRAY = -100;
        const int MAX_NUMBER_IN_ARRAY = 100;

        //далее пойдут маленькие полезные функции, которые выполняют одну задачу
        //эта проверяет, попадает ли число с в диапозон [a,b]
        static int chkDp(int a, int b, int c)
        {
            if (c >= a & c <= b)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        //эта выводит заданный массив на экран
        public static void mprint(Array arr)
        {
            string abc = "";
            foreach (var elem in arr)
            {
                abc += " ";
                abc += elem.ToString().PadRight(4);

            }
            Console.WriteLine(abc);
        }
        //эта меняет два элемента в массиве местами
        static void obmen(int[] arr, int a, int b)
        {
            int v = arr[a];
            arr[a] = arr[b];
            arr[b] = v;
        }
        //эта делает то же самое, но через ref
        static void swap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;
        }
        //теперь основные функции - эта заполняет массив числами
        public static void feel()
        {
            massExists = 1;
            var ran = new Random();
            int a, b, c;
            Console.WriteLine("ВВЕДИТЕ КОЛИЧЕСТВО ЧИСЕЛ (1 .. 50)");
            a = int.Parse(Console.ReadLine());
            int[] masp = new int[a];
            Console.WriteLine("ВВЕДИТЕ НАИМЕНЬШЕЕ ВОЗМОЖНОЕ ЗНАЧЕНИЕ (-100 .. 100)");
            b = int.Parse(Console.ReadLine());
            Console.WriteLine("ВВЕДИТЕ НАИБОЛЬШЕЕ ВОЗМОЖНОЕ ЗНАЧЕНИЕ (-100 .. 100)");
            c = int.Parse(Console.ReadLine());
            if (chkDp(1, MAX_NUMBERS_IN_ARRAY, a) + chkDp(MIN_NUMBER_IN_ARRAY, MAX_NUMBER_IN_ARRAY, b) + chkDp(MIN_NUMBER_IN_ARRAY, MAX_NUMBER_IN_ARRAY, c) != 3)
            {
                Console.WriteLine("ОДНО ИЗ ВВЕДЕННЫХ ЗНАЧЕНИЙ НЕ ВХОДИТ В ДИАПОЗОН");
                return;
            }
            for (int i = 0; i < a; i++)
            {
                masp[i] = ran.Next(b, c + 1);
            }
            mass = masp;
            mprint(mass);
            return;
        }
        //эта сортирует массив пузырьком
        static void bubble()
        {
            if (massExists == 0)
            {
                Console.WriteLine("МАССИВ НЕ СОЗДАН");
                return;
            }

            int s;
            Console.WriteLine("ВЫБЕРИТЕ НАПРАВЛЕНИЕ СОРТИРОВКИ(0 - убывание.. 1 - возрастание)");
            s = int.Parse(Console.ReadLine());
            var msc = new int[mass.Length];
            Array.Copy(mass, msc, mass.Length);
            if (chkDp(0, 1, s) == 0)
            {
                Console.WriteLine("НЕВЕРНЫЙ ВЫБОР");
                return;
            };
            mprint(msc);
            if (s == 1)
            {
                for (int i = 0; i <= msc.Length; i++)
                {
                    for (int j = 0; j < msc.Length - 1; j++)
                    {
                        if (msc[j] > msc[j + 1])
                        {
                            obmen(msc, j, j + 1);

                        }
                    }
                    mprint(msc);
                };
            };
            if (s == 0)
            {
                for (int i = 0; i <= msc.Length; i++)
                {
                    for (int j = 0; j < msc.Length - 1; j++)
                    {
                        if (msc[j] < msc[j + 1])
                        {
                            obmen(msc, j, j + 1);

                        }
                    }
                    mprint(msc);
                };
            }
            mass = msc;
            Console.WriteLine("МАССИВ ОТСОРТИРОВАН");
        }
        //эта сортирует массив выбором
        static void vybor()
        {
            if (massExists == 0)
            {
                Console.WriteLine("МАССИВ НЕ СОЗДАН");
                return;
            }

            int s;
            Console.WriteLine("ВЫБЕРИТЕ НАПРАВЛЕНИЕ СОРТИРОВКИ(0 - убывание.. 1 - возрастание)");
            s = int.Parse(Console.ReadLine());
            var msc = new int[mass.Length];
            Array.Copy(mass, msc, mass.Length);
            if (chkDp(0, 1, s) == 0)
            {
                Console.WriteLine("НЕВЕРНЫЙ ВЫБОР");
                return;
            };
            mprint(msc);
            if (s == 1)
            {
                for (int i = 0; i < msc.Length; i++)
                {
                    int x = msc[i];
                    int y = 101;
                    int yind = 0;
                    for (int j = i; j < msc.Length; j++)
                    {
                        if (msc[j] < y)
                        {
                            yind = j;
                            y = msc[j];
                        }
                    }
                    obmen(msc, i, yind);
                    mprint(msc);

                }
            }
            if (s == 0)
            {
                for (int i = 0; i < msc.Length; i++)
                {
                    int x = msc[i];
                    int y = -101;
                    int yind = 0;
                    for (int j = i; j < msc.Length; j++)
                    {
                        if (msc[j] > y)
                        {
                            yind = j;
                            y = msc[j];
                        }
                    }
                    obmen(msc, i, yind);
                    mprint(msc);

                }
            }
            mass = msc;

            Console.WriteLine("МАССИВ ОТСОРТИРОВАН");

        }
        //эта сортирует массив вставками
        static void vstavka()
        {
            if (massExists == 0)
            {
                Console.WriteLine("МАССИВ НЕ СОЗДАН");
                return;
            }

            int s;
            Console.WriteLine("ВЫБЕРИТЕ НАПРАВЛЕНИЕ СОРТИРОВКИ(0 - убывание.. 1 - возрастание)");
            s = int.Parse(Console.ReadLine());
            var msc = new int[mass.Length];
            Array.Copy(mass, msc, mass.Length);
            if (chkDp(0, 1, s) == 0)
            {
                Console.WriteLine("НЕВЕРНЫЙ ВЫБОР");
                return;
            };
            int x, y;
            mprint(msc);
            if (s == 0)
            {
                for (int i = 1; i < msc.Length; i++)
                {
                    x = msc[i];
                    y = i;
                    while ((y > 0) && msc[y - 1] < x)
                    {
                        obmen(msc, y, y - 1);
                        y = y - 1;

                    }
                    msc[y] = x;
                    mprint(msc);
                }
            }
            if (s == 1)
            {
                for (int i = 1; i < msc.Length; i++)
                {
                    x = msc[i];
                    y = i;
                    while ((y > 0) && msc[y - 1] > x)
                    {
                        obmen(msc, y, y - 1);
                        y = y - 1;

                    }
                    msc[y] = x;
                    mprint(msc);
                }
            }
            mass = msc;

            Console.WriteLine("МАССИВ ОТСОРТИРОВАН");
        }
        // и самая кривая - она сортирует массив подсчетом. ничего лучше такого адски сложного алгоритма не придумал
        // зато сделал сам и попрактиковался в сишарпе
        static void sortC()
        {
            if (massExists == 0)
            {
                Console.WriteLine("МАССИВ НЕ СОЗДАН");
                return;
            }

            int s;
            Console.WriteLine("ВЫБЕРИТЕ НАПРАВЛЕНИЕ СОРТИРОВКИ(0 - убывание.. 1 - возрастание)");
            s = int.Parse(Console.ReadLine());
            var msc = new int[mass.Length];
            var res = new int[mass.Length];
            Array.Copy(mass, msc, mass.Length);
            if (chkDp(0, 1, s) == 0)
            {
                Console.WriteLine("НЕВЕРНЫЙ ВЫБОР");
                return;
            };
            if (s == 1)
            {
                var ind = new int[mass.Length];
                for (int i = 0; i < msc.Length; i++)
                {
                    int num = 0;
                    for (int j = 0; j < msc.Length; j++)
                    {
                        if (msc[i] > msc[j])
                        {
                            num++;
                        }
                    }
                    ind[i] = num;
                }
                for (int i = 0; i < msc.Length; i++)
                {
                    int c = 0;
                    for (int j = 0; j < msc.Length; j++)
                    {
                        if (ind[j] == i)
                        {
                            ind[j] += c;
                            c++;
                        }
                    }
                }
                for (int i = 0; i < ind.Length; i++)
                {
                    res[ind[i]] = msc[i];
                }
            }
            if (s == 0)
            {
                var ind = new int[mass.Length];
                for (int i = 0; i < msc.Length; i++)
                {
                    int num = 0;
                    for (int j = 0; j < msc.Length; j++)
                    {
                        if (msc[i] < msc[j])
                        {
                            num++;
                        }
                    }
                    ind[i] = num;
                }
                for (int i = 0; i < msc.Length; i++)
                {
                    int c = 0;
                    for (int j = 0; j < msc.Length; j++)
                    {
                        if (ind[j] == i)
                        {
                            ind[j] += c;
                            c++;
                        }
                    }
                }
                for (int i = 0; i < ind.Length; i++)
                {
                    res[ind[i]] = msc[i];
                }
            }
            mprint(res);
            mass = res;
            Console.WriteLine("МАССИВ ОТСОРТИРОВАН");
        }

        //это обертка функции, которая сортирует пирамидально
        static void piramida()
        {
            if (massExists == 0)
            {
                Console.WriteLine("МАССИВ НЕ СОЗДАН");
                return;
            }

            int s;
            Console.WriteLine("ВЫБЕРИТЕ НАПРАВЛЕНИЕ СОРТИРОВКИ(0 - убывание.. 1 - возрастание)");
            s = int.Parse(Console.ReadLine());
            var msc = new int[mass.Length];
            Array.Copy(mass, msc, mass.Length);
            if (chkDp(0, 1, s) == 0)
            {
                Console.WriteLine("НЕВЕРНЫЙ ВЫБОР");
                return;
            };
            mprint(mass);
            if (s == 0)
            {
                HeapSort(mass, mass.Length, 0);
            }
            else
            {
                HeapSort(mass, mass.Length, 1);
            }
            Console.WriteLine("МАССИВ ОТСОРТИРОВАН");
            return;
        }
        //а далее общая функция сортировки и вспомогательная
        static void HeapSort(int[] M, int N, int mode)
        {
            for (int i = N / 2 - 1; i >= 0; i--)
            {
                if (mode == 0)
                {
                    HeapifyU(M, N, i);
                }
                else
                {
                    Heapify(M, N, i);
                }
                mprint(M);
            }
            Console.WriteLine("ПОСТРОЕНИЕ КУЧИ ЗАВЕРШЕНО");
            for (int i = N - 1; i >= 0; i--)
            {
                swap(ref M[0], ref M[i]);
                if (mode == 0)
                {
                    HeapifyU(M, i, 0);
                }
                else
                {
                    Heapify(M, i, 0);
                }
                mprint(M);
            }
            return;
        }

        static void Heapify(int[] M, int N, int i)
        {
            int iM = i;
            int L = 2 * i + 1, R = 2 * i + 2;
            if (L < N && (M[L] > M[iM]))
            {
                iM = L;
            }
            if (R < N && (M[R] > M[iM]))
            {
                iM = R;
            }
            if (i != iM)
            {
                swap(ref M[i], ref M[iM]);
                Heapify(M, N, iM);
            }
            return;
        }

        static void HeapifyU(int[] M, int N, int i)
        {
            int iM = i;
            int L = 2 * i + 1, R = 2 * i + 2;
            if (L < N && (M[L] < M[iM]))
            {
                iM = L;
            }
            if (R < N && (M[R] < M[iM]))
            {
                iM = R;
            }
            if (i != iM)
            {
                swap(ref M[i], ref M[iM]);
                HeapifyU(M, N, iM);
            }
            return;
        }

        //обертка сортировки слиянием
        static void sliyanie()
        {
            if (massExists == 0)
            {
                Console.WriteLine("МАССИВ НЕ СОЗДАН");
                return;
            }

            int s;
            Console.WriteLine("ВЫБЕРИТЕ НАПРАВЛЕНИЕ СОРТИРОВКИ(0 - убывание.. 1 - возрастание)");
            s = int.Parse(Console.ReadLine());
            var msc = new int[mass.Length];
            var res = new int[mass.Length];
            Array.Copy(mass, msc, mass.Length);
            if (chkDp(0, 1, s) == 0)
            {
                Console.WriteLine("НЕВЕРНЫЙ ВЫБОР");
                return;
            };
            mprint(mass);
            _ = s == 0 ? mass = mergesort(mass, 0, mass.Length - 1, 0) : mass = mergesort(mass, 0, mass.Length - 1, 1);
            Console.Write("\n");
            mprint(mass);
            return;
        }
        //основная функция сортировки слиянием
        static int[] mergesort(int[] a, int l, int r, int mode)
        {
            if (l < r)
            {
                int m = (r + l) / 2;
                Console.Write($"[{l} - {r}");
                if (mode == 1)
                {
                    mergesort(a, l, m, 1);
                    mergesort(a, m + 1, r, 1);
                    merge(a, l, r);
                }
                else
                {
                    mergesort(a, l, m, 0);
                    mergesort(a, m + 1, r, 0);
                    mergeu(a, l, r);
                }
                Console.Write("]");
            }
            return a;
        }
        //вспомогательная функция соритровки слиянием
        static void merge(int[] a, int l, int r)
        {
            int m = l + (r - l) / 2;
            int[] la = new int[m - l + 1];
            int[] ra = new int[r - m];
            int i, j;
            for (i = 0; i < la.Length; ++i)
                la[i] = a[l + i];
            for (j = 0; j < ra.Length; ++j)
                ra[j] = a[m + 1 + j];
            i = 0;
            j = 0;
            int t = l;
            while (i < la.Length && j < ra.Length)
            {
                if (la[i] <= ra[j])
                {
                    a[t] = la[i];
                    i++;
                }
                else
                {
                    a[t] = ra[j];
                    j++;
                }
                t++;
            }
            while (i < la.Length)
            {
                a[t] = la[i];
                i++;
                t++;
            }
            while (j < ra.Length)
            {
                a[t] = ra[j];
                j++;
                t++;
            }
        }
        //и вспомогательная для сортировки по убыванию
        static void mergeu(int[] a, int l, int r)
        {
            int m = l + (r - l) / 2;
            int[] la = new int[m - l + 1];
            int[] ra = new int[r - m];
            int i, j;
            for (i = 0; i < la.Length; ++i)
                la[i] = a[l + i];
            for (j = 0; j < ra.Length; ++j)
                ra[j] = a[m + 1 + j];
            i = 0;
            j = 0;
            int t = l;
            while (i < la.Length && j < ra.Length)
            {
                if (la[i] >= ra[j])
                {
                    a[t] = la[i];
                    i++;
                }
                else
                {
                    a[t] = ra[j];
                    j++;
                }
                t++;
            }
            while (i < la.Length)
            {
                a[t] = la[i];
                i++;
                t++;
            }
            while (j < ra.Length)
            {
                a[t] = ra[j];
                j++;
                t++;
            }
        }
        //обертка быстрой сортировки
        static void fastsort()
        {
            if (massExists == 0)
            {
                Console.WriteLine("МАССИВ НЕ СОЗДАН");
                return;
            }

            int s;
            Console.WriteLine("ВЫБЕРИТЕ НАПРАВЛЕНИЕ СОРТИРОВКИ(0 - убывание.. 1 - возрастание)");
            s = int.Parse(Console.ReadLine());
            if (chkDp(0, 1, s) == 0)
            {
                Console.WriteLine("НЕВЕРНЫЙ ВЫБОР");
                return;
            };

            mprint(mass);
            _ = s == 0 ? qsrangeu(mass, 0, mass.Length - 1) : qsrange(mass, 0, mass.Length - 1);
            Console.Write("\n");
            mprint(mass);
            return;
        }

        //вспомогательная быстрой соритровки
        static int[] qsrange(int[] a, int l, int r)
        {
            int i = l;
            int j = r;
            Console.Write($" [{l}-{r}");
            int pivot = a[(l + r) / 2];
            while (i <= j)
            {
                while (a[i] < pivot)
                {
                    i++;
                }

                while (a[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    obmen(a, i, j);
                    i++;
                    j--;
                }
            }

            if (l < j)
            {
                qsrange(a, l, j);
            }
            if (i < r)
            {
                qsrange(a, i, r);
            }

            Console.Write($"]");
            return a;
        }
        //вспомогательная быстрой сортировки по убыванию
        static int[] qsrangeu(int[] a, int l, int r)
        {
            int i = l;
            int j = r;
            Console.Write($" [{l}-{r}");
            int pivot = a[(l + r) / 2];
            while (i <= j)
            {
                while (a[i] > pivot)
                {
                    i++;
                }

                while (a[j] < pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    obmen(a, i, j);
                    i++;
                    j--;
                }
            }

            if (l < j)
            {
                qsrangeu(a, l, j);
            }
            if (i < r)
            {
                qsrangeu(a, i, r);
            }
            Console.Write($"]");
            return a;
        }

        //эта функция бинарно ищет числа    
        static void fnd()
        {
            if (massExists == 0)
            {
                Console.WriteLine("МАССИВ НЕ СОЗДАН");
                return;
            }
            int s;
            Console.WriteLine("ВВЕДИТЕ ИСКОМОЕ ЗНАЧЕНИЕ (-1000..1000)");
            s = int.Parse(Console.ReadLine());
            if (chkDp(-1000, 1000, s) == 0)
            {
                Console.WriteLine("ЗНАЧЕНИЕ ВЫХОДИТ ИЗ ДИАПАЗОНА");
                return;
            };

            for (int i = 1; i < mass.Length; i++)
            {
                if (mass[i] < mass[i - 1])
                {
                    Console.WriteLine("МАССИВ НЕ ОТСОРТИРОВАН ПО ВОЗРАСТАНИЮ");
                    return;
                }
            }

            int left = 0;
            int right = mass.Length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (s < mass[mid])
                {
                    right = mid - 1;
                }
                else if (s > mass[mid])
                {
                    left = mid + 1;
                }
                else if (s == mass[mid])
                {
                    Console.WriteLine($"Число найдено на позиции {mid + 1}");
                    return;
                }
            }
            Console.WriteLine("ЧИСЛО НЕ НАЙДЕНО.");
            return;

        }
        
        // а эта ищет k-ую статистику
        static void stitistica()
        {
            if (massExists == 0)
            {
                Console.WriteLine("МАССИВ НЕ СОЗДАН");
                return;
            }
            mprint(mass);
            Console.WriteLine($"Введите номер статистики k(1 .. {mass.Length}): ");
            int c = int.Parse(Console.ReadLine());
            if (chkDp(0, mass.Length, c) == 0)
            {
                Console.WriteLine("ЗНАЧЕНИЕ ВЫХОДИТ ИЗ ДИАПАЗОНА");
                return;
            };
            Console.WriteLine($"Значение порядковой статистики: {KthOrder(c-1, mass)}");
            mprint(mass);
            return;
        }

        static int KthOrder(int k, int[] arr)
        {
            return KthOrderRange(0, arr.Length - 1, k, arr);
        }

        static int PartitionLomuto(int left, int right, int[] arr)
        {
            Random R = new Random();
            swap(ref arr[R.Next(left, right)], ref arr[right]);
            int p = arr[right];
            int i = left;
            for (int j = left; j < right; j++)
            {
                if (arr[j] <= p)
                {
                    swap(ref arr[i++], ref arr[j]);
                }
            }
            swap(ref arr[i], ref arr[right]);
            return i;
        }

        static int KthOrderRange(int left, int right, int k, int[] arr)
        {
            int p = PartitionLomuto(left, right, arr);
            if (p - left == k)
                return arr[p];
            if (p - left > k)
                return KthOrderRange(left, p - 1, k, arr);
            return KthOrderRange(p + 1, right, k - p + left - 1, arr);
        }
        //эта функция перемешивает массив
        static void peremeshat()
        {
            if (massExists == 0)
            {
                Console.WriteLine("МАССИВ НЕ СОЗДАН");
                return;
            }
            Console.WriteLine("ИСХОДНЫЙ МАССИВ:");
            mprint(mass);
            Shuffle(mass);
            Console.WriteLine("ПЕРЕМЕШАННЫЙ МАССИВ:");
            mprint(mass);
            return;
        }
        static void Shuffle(int[] arr)
        {
            Random R = new Random();
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int j = R.Next(i, arr.Length);
                swap(ref arr[i], ref arr[j]);
            }
            return;
        }
        //и наконец основная функция с основным циклом, обернутым в try catch
        private static void Main()
        {
            Console.WriteLine(System.Environment.Version);
            try
            {
                int slct = 15;
                while (slct != 12)
                {

                    Console.WriteLine("ВВЕДИТЕ НОМЕР ОПЕРАЦИИ (1...12): ");
                    int n = 0;
                    object[] menu = new object[12] 
                    { 
                        "Заполнение массива", "Пузырьковая сортировка", "Сортировка выбором", 
                        "Сортировка вставками",  "Сортировка подсчётом", "Быстрая сортировка", 
                        "Сортировка слиянием", "Пирамидальная сортировка", "Двоичный поиск значения", 
                        "Поиск порядковой статистики","Перемешивание массива","Выход" 
                    };
                    foreach (var item in menu)
                    {
                        n = n + 1;
                        Console.WriteLine($"{n}.{item}.");
                    };
                    slct = int.Parse(Console.ReadLine());
                    if (chkDp(1, 12, slct) == 0)
                    {
                        Console.WriteLine("ВВЕДЕННОЕ ЗНАЧЕНИЕ ВЫХОДИТ ИЗ ДИАПОЗОНА");

                    };

                    switch (slct)
                    {
                        case 1:
                            Console.WriteLine("ЗАПОЛНЕНИЕ МАССИВА");
                            feel();
                            continue;
                        case 2:
                            Console.WriteLine("СОРТИРОВКА ПУЗЫРЬКОМ");
                            bubble();
                            continue;
                        case 3:
                            Console.WriteLine("CОРТИРОВКА ВЫБОРОМ");
                            vybor();
                            continue;
                        case 4:
                            Console.WriteLine("СОРТИРОВКА ВСТАВКАМИ");
                            vstavka();
                            continue;
                        case 5:
                            Console.WriteLine("СОРТИРОВКА ПОДСЧЕТОМ");
                            sortC();
                            continue;
                        case 6:
                            Console.WriteLine("БЫСТРАЯ СОРТИРОВКА");
                            fastsort();
                            continue;
                        case 7:
                            Console.WriteLine("СОРТИРОВКА СЛИЯНИЕМ");
                            sliyanie();
                            continue;
                        case 8:
                            Console.WriteLine("ПИРАМИДАЛЬНАЯ СОРТИРОВКА");
                            piramida();
                            continue;
                        case 9:
                            Console.WriteLine("ДВОИЧНЫЙ ПОИСК ЗНАЧЕНИЯ");
                            fnd();
                            continue;
                        case 10:
                            Console.WriteLine("ПОИСК ПОРЯДКОВОЙ СТАТИСТИКИ");
                            stitistica();
                            continue;
                        case 11:
                            Console.WriteLine("ПЕРЕМЕШИВАНИЕ МАССИВА");
                            peremeshat();
                            continue;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("НЕПРАВИЛЬНЫЙ ВВОД");
                Main();
            }


        }
    }
}
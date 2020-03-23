using System;
using System.Linq;

namespace HomeWork5
{
    class Program
    {
        static void Main(string[] args)
        {
            ////////////////////////////////////////////////////////
            // НЕОБХОДИМО РАСКОММЕНТИРОВАТЬ НУЖНОЕ ПЕРЕД ЗАПУСКОМ //
            ////////////////////////////////////////////////////////


            //Задание 1


            //int[,] myMatrix = createMatrix2D(5);
            //showMatrix2D(myMatrix);
            //Console.ReadLine();
            //multiplyMatrixByNumber(myMatrix, 5);
            //showMatrix2D(myMatrix);
            //Console.ReadLine();
            //Console.WriteLine("Умножаем на саму себя\n");
            //myMatrix = multiplyMatrix2Dx2D(myMatrix, myMatrix);
            //showMatrix2D(myMatrix);
            //Console.ReadLine();
            //myMatrix = matrixPlusOrMinus(myMatrix, myMatrix, "+");
            //showMatrix2D(myMatrix);
            //Console.ReadLine();


            //Задание 2


            string predlozhenie;
            Console.Write("Введите предложение: ");
            predlozhenie = Console.ReadLine();
            CheckMinMaxWord(predlozhenie);
            Console.ReadLine();


            //Задание 3


            //string myStroka;
            //Console.Write("Введите строку с повторяющимися символами: ");
            //myStroka = Console.ReadLine();
            //string normalStroka = DeleteDoubleSymbols(myStroka);
            //Console.WriteLine($"Ваша строка без повторяющихся символов: {normalStroka}");
            //Console.ReadLine();


            //Задание 4


            //isItProgress(1, 2, 3, 4, 5);
            //isItProgress(1, 2, 4, 8, 16);
            //isItProgress(1, 2, 352, 4, 5);
            //Console.ReadLine();


            //Задание 5


            //int AkkResult;
            //AkkResult = Akkerman(2, 5);
            //Console.WriteLine($"{AkkResult}");
            //AkkResult = Akkerman(1, 2);
            //Console.WriteLine($"{AkkResult}");
            //Console.ReadLine();
        }

        /// <summary>
        /// Рекурсивный метод для вычисления функции Аккермана
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int Akkerman(int m, int n)
        {
            if (m < 0 || n < 0) { Console.WriteLine("Значения не могут быть меньше 0!"); return 0; }
            if (m == 0)
                return n + 1;
            else if (n == 0 && m > 0)
                return Akkerman(m - 1, 1);
            else
                return Akkerman(m - 1, Akkerman(m, n - 1));
        }

        /// <summary>
        /// Метод для опознования математических и геометрических прогрессий
        /// </summary>
        /// <param name="numbline">Последовательность чисел</param>
        public static void isItProgress(params int[] numbline)
        {
            bool arifmethic = false;
            bool geometric = false;
            int o = 0;
            int u = numbline[2] - numbline[1];              //общий член числовой последовательности
            for (int v = 0; v < numbline.Length - 1; v++)
            {
                if (numbline[v] == numbline[v + 1] - u) //если каждый n+1 член последовательности больше n члена на равное число,
                {
                    arifmethic = true;                  //то это арифметическая прогрессия
                }
                else if (numbline[v] == numbline[v + 1] / u)   //если каждый n член последовательности меньше в u раз последующего,
                {
                    arifmethic = false;
                    geometric = true;                   //то это геометрическая прогрессия
                }
                else
                {
                    arifmethic = false;                 //если перебор не обнаружил прогрессию
                    geometric = false;
                    o = v;                              //запоминаем шаг
                    break;                              //выходим из цикла
                }
            }
            if (arifmethic)                             //Вывод информации 
            {
                Console.WriteLine("Это арифметическая прогрессия");
            }
            else if (geometric)
            {
                Console.WriteLine("Это геометрическая прогрессия");
            }
            else
                Console.WriteLine($"Прогрессия нарушена на {o + 1} шаге");
        }

        /// <summary>
        /// Метод для удаления повторяющихся символов в строке
        /// </summary>
        /// <param name="stroka">Строка для обработки</param>
        /// <returns></returns>
        public static string DeleteDoubleSymbols(string stroka)
        {
            string result = "";   //строка для внесения неповторяющихся символов
            for (int i = 1; i < stroka.Length; i++)
            {
                while (stroka[i - 1] == stroka[i] && stroka[i - 1] == ' ') //пока соседние символы равны либо пробел - 
                    i++;                                                   //продолжаем перебор
                if (stroka[i - 1] != stroka[i] || i + 1 == stroka.Length && stroka[i] != ' ') //если символы различаются или это конец строки и это не пробел
                {
                    result += stroka[i - 1].ToString();                     //вносим в result символ
                }
            }
            return result;
        }

        public static Random r = new Random();
        /// <summary>
        /// Метод для создания двумерной матрицы
        /// </summary>
        /// <param name="r1">Длина строны</param>
        public static int[,] createMatrix2D(int r1)
        {
            int[,] matrix2D = new int[r1, r1];

            for (int i = 0; i < matrix2D.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2D.GetLength(1); j++)
                {
                    matrix2D[i, j] = r.Next(1, 50);
                }
            }
            return matrix2D;
        }

        /// <summary>
        /// Метод для вывода на консоль двумерного массива
        /// </summary>
        /// <param name="matrix2D">Двумерный массив для вывода</param>
        public static void showMatrix2D(int[,] matrix2D)
        {
            for (int i = 0; i < matrix2D.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2D.GetLength(1); j++)
                {
                    Console.Write($"{matrix2D[i, j],8}");
                }
                Console.WriteLine("\n");
            }
        }

        /// <summary>
        /// Метод умножения матрицы на число
        /// </summary>
        /// <param name="matrix">Матрица</param>
        /// <param name="numb">Число</param>
        /// <returns></returns>
        public static int[,] multiplyMatrixByNumber(int[,] matrix, int numb)
        {
            Console.WriteLine($"Умножаем на {numb}\n");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] *= numb;
                }
            }
            return matrix;
        }

        ///<summary>
        /// Метод для перемножения двумерных массивов (матриц)
        /// </summary>
        /// <param name="matrix1">Первая матрица</param>
        /// <param name="matrix2">Вторая матрица</param>
        /// <returns></returns>
        public static int[,] multiplyMatrix2Dx2D(int[,] matrix1, int[,] matrix2)
        {
            int[,] resultMAtrix = new int[matrix1.GetLength(0), matrix2.GetLength(1)];

            for (int i = 0; i < resultMAtrix.GetLength(0); i++)          //i - строки
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    for (int k = 0; k < matrix2.GetLength(0); k++)
                    {
                        resultMAtrix[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }
            return resultMAtrix;
        }

        ///<summary>
        /// Метод сложения и вычитания двумерных массивов (матриц)
        /// </summary>
        /// <param name="matrix1">Первая матрица</param>
        /// <param name="matrix2">Вторая матрица</param>
        /// <param name="oper">Оператор</param>
        /// <returns></returns>
        public static int[,] matrixPlusOrMinus(int[,] matrix1, int[,] matrix2, string oper)
        {
            if (oper == "+") Console.WriteLine("Складываем\n");
            if (oper == "-") Console.WriteLine("Вычитаем\n");
            int[,] Itog = new int[matrix1.GetLength(0), matrix1.GetLength(1)];

            switch (oper)
            {
                case "+":
                    for (int i = 0; i < matrix1.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix1.GetLength(1); j++)
                        {
                            Itog[i, j] = matrix1[i, j] + matrix2[i, j];
                        }
                    }
                    break;
                case "-":
                    for (int i = 0; i < matrix1.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix1.GetLength(1); j++)
                        {
                            Itog[i, j] = matrix1[i, j] - matrix2[i, j];
                        }
                    }
                    break;
            }
            return Itog;
        }

        /// <summary>
        /// Поиск самого длинного и самого короткого слова с помощью перебора символов исходной строки.
        /// </summary>
        /// <param name="s">Строка со словами, разделенными пробелом.</param>
        public static void CheckMinMaxWord(string s)
        {
            s = s.Trim();
            if (s.Length == 0)
                return;

            int maxlen = int.MinValue, minlen = int.MaxValue, len = 0;
            string word = "", minWord = "", maxWord = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ' ')
                {
                    ++len;
                    word += s[i];
                }
                else if (len > 0)
                {
                    CheckMinMax();
                    len = 0;
                    word = "";
                }
            }
            CheckMinMax();

            Console.WriteLine($"Самое короткое слово: {minWord}");
            Console.WriteLine($"Самое длинное слово: {maxWord}");
            
            void CheckMinMax()
            {
                if (len > maxlen)
                {
                    maxlen = len;
                    maxWord = word;
                }
                if (len < minlen)
                {
                    minlen = len;
                    minWord = word;
                }
            }
        }
    }
}

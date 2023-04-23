void NewTask()
{
    System.Console.WriteLine("Нажмите Enter для продолжения и перехода к следующей задаче");
    Console.ReadLine();
    Console.Clear();
}
int[,] GetMatrix(int rows, int columns, int min = 0, int max = 9)
{
    int[,] array = new int[rows, columns];
    Random rand = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = rand.Next(min, max + 1);
        }
    }
    return array;
}
void PrintMatrix(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            System.Console.Write($"{array[i, j]} ");
        }
        System.Console.WriteLine();
    }
}
void SortRowsInMatrix(int[,] array)
{
    int max;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1) - 1; j++)
        {
            for (int k = 1; k < array.GetLength(1) - j; k++)
            {
                max = array[i, j];
                if (array[i, j] < array[i, j + k])
                {
                    max = array[i, j + k];
                    array[i, j + k] = array[i, j];
                    array[i, j] = max;
                }
            }
        }
    }
}
int GetValue(string text)
{
    System.Console.Write($"Введите {text}: ");
    int value = Convert.ToInt32(Console.ReadLine());
    return value;
}
System.Console.WriteLine("Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.");
int rows = GetValue("количество строк");
int columns = GetValue("количество столбцов");
int[,] array = GetMatrix(rows, columns);
PrintMatrix(array);
SortRowsInMatrix(array);
System.Console.WriteLine();
PrintMatrix(array);
NewTask();
System.Console.WriteLine("Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.");
void GetSumInRows(int[,] array)
{
    int maximum = 0;
    int row = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        int sum = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sum += array[i, j];
        }
        if (sum > maximum)
        {
            maximum = sum;
            row = i;
        }

    }
    System.Console.WriteLine($"Наибольшая сумма чисел {maximum} в строке {row + 1}");
}
void CheckRowsAndColumns()
{
    int rows = GetValue("количество строк");
    int columns = GetValue("количество столбцов");
    if (rows == columns)
    {
        System.Console.WriteLine("Количество строк и столбцов должно отличаться.");
        CheckRowsAndColumns();
    }
    else
    {
        int[,] array = GetMatrix(rows, columns);
        PrintMatrix(array);
        GetSumInRows(array);
    }

}
CheckRowsAndColumns();
NewTask();
System.Console.WriteLine("Задача 58. Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.");
rows = GetValue("количество строк первой матрицы");
columns = GetValue("количество столбцов первой матрицы");
int rowsSecond = GetValue("количество столбцов второй матрицы");
array = GetMatrix(rows, columns);
int[,] matrix = GetMatrix(columns, rowsSecond);
System.Console.WriteLine("Первая матрица:");
PrintMatrix(array);

System.Console.WriteLine("Вторая матрица:");
PrintMatrix(matrix);
System.Console.WriteLine("Результат умножения двух матриц:");
int[,] result = new int[rows, rowsSecond];

for (int i = 0; i < array.GetLength(0); i++)
{

    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        int sum = 0;
        for (int r = 0; r < matrix.GetLength(0); r++)
        {
            sum += array[i, r] * matrix[r, j];
        }
        result[i, j] = sum;

    }
}
PrintMatrix(result);
NewTask();

System.Console.WriteLine("Сформируйте трёхмерный массив из неповторяющихся двузначных чисел." +
"Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.");


int GetRandomValue(int min, int max)
{
    Random rand = new Random();
    int random = rand.Next(min, max + 1);
    return random;
}

int[,,] GetArray(int rows, int columns, int deep, int min = 10, int max = 99)
{
    int[,,] array = new int[rows, columns, deep];

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                array[i, j, k] = GetRandomValue(min, max);
                while (CheckArray(array, array[i, j, k]) == true)
                {
                    array[i, j, k] = GetRandomValue(min, max);
                }
            }
        }
    }
    return array;
}
void PrintArray(int[,,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                System.Console.Write($"{array[i, j, k]} ({i}, {j}, {k}) ");
            }
            System.Console.WriteLine();
        }
    }
}
bool CheckArray(int[,,] array, int check)
{
    int count = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                if (check == array[i, j, k])
                    count++;
            }
        }
    }
    if (count > 1) return true;
    else return false;
}
rows = GetValue("количество строк");
columns = GetValue("количество столбцов");
int deep = GetValue("третье измерение массива");
if (rows * columns * deep > 90) System.Console.WriteLine("Нельзя составить массив из неповторяющихся двузначных чисел при данных значениях, т. к. они будут повторяться");
else
{
    int[,,] arrayInThreeDemensions = GetArray(rows, columns, deep);
    PrintArray(arrayInThreeDemensions);
}
NewTask();

System.Console.WriteLine("Задача 62. Напишите программу, которая заполнит спирально массив . Размер вводит юзер");
rows = GetValue("количество строк");
columns = GetValue("количество столбцов");
void MakeSpiral(int[,] matrix, int i, int j, int value)
{
    while (matrix[i, j] == 0)
    {
        matrix[i, j] = value;
        j++;
        value++;
        if (j == matrix.GetLength(1) - 1 || matrix[i, j + 1] != 0) break;
    }
    while (matrix[i, j] == 0)
    {
        matrix[i, j] = value;
        i++;
        value++;
        if (i == matrix.GetLength(0) - 1 || matrix[i + 1, j] != 0) break;
    }

    while (matrix[i, j] == 0)
    {
        matrix[i, j] = value;
        j--;
        value++;
        if (j == 0 || matrix[i, j - 1] != 0) break;
    }

    while (matrix[i, j] == 0)
    {
        matrix[i, j] = value;
        i--;
        value++;
        if (i == 0) break;
        if (matrix[i - 1, j] != 0) break;
    }
    if (i != 0)
    {
        if (matrix[i, j] == 0 || matrix[i - 1, j] == 0 || matrix[i, j + 1] == 0)
        {
            MakeSpiral(matrix, i, j, value);
        }
    }
}
int[,] FillMatrix(int rows, int columns)
{
    int[,] matrix = new int[rows, columns];
    int i = 0;
    int j = 0;
    int value = 1;
    MakeSpiral(matrix, i, j, value);
    return matrix;

}
void PrintSpiralMatrix(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            System.Console.Write(String.Format("{0:00} ", array[i, j]));
        }
        System.Console.WriteLine();
    }
}
int[,] matr = FillMatrix(rows, columns);
PrintSpiralMatrix(matr);

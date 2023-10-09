namespace S06C80;

internal static class Program
{
    private static void Main(string[] args)
    {
        short size = GetSize();
        int[,] matrix = GetData(size);
        PrintDiagonal(matrix);
        PrintHowManyNegativeNumbers(matrix);
    }

    private static short GetSize()
    {
        Console.Write("Qual o tamanho da matriz quadrada? ");
        short size = short.Parse(Console.ReadLine()!);

        while (size <= 2 || size > 10)
        {
            Console.Write("Tamanho inválido! Mínimo de 2 e máximo de 10: ");
            size = short.Parse(Console.ReadLine()!);
        }

        return size;
    }

    private static int[,] GetData(short size)
    {
        int[,] matrix = new int[size, size];

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write($"Elemento [{i}, {j}]: ");
                matrix[i, j] = int.Parse(Console.ReadLine()!);
            }
        }

        return matrix;
    }

    private static void PrintDiagonal(int[,] matrix)
    {
        Console.WriteLine("Main diagonal:");
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            Console.Write($"{matrix[i, i]} ");
        }
        Console.WriteLine();
    }

    private static void PrintHowManyNegativeNumbers(int[,] matrix)
    {
        int negativeNumbersCount = 0;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < 0) negativeNumbersCount++;
            }
        }
        Console.WriteLine($"Negative numbers: {negativeNumbersCount}");
    }
}
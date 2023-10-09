namespace S06C81;

internal static class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Entre com a dimensão da matrix [n, m]: ");
        string[] dimensions = Console.ReadLine()!.Trim().Split(' ');

        int n = int.Parse(dimensions[0]);
        int m = int.Parse(dimensions[1]);

        int[,] matrix = new int[n, m];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Linha {i}: ");
            string[] line = Console.ReadLine()!.Trim().Split(' ');
            for (int j = 0; j < m; j++)
            {
                matrix[i, j] = int.Parse(line[j]);
            }
        }

        Console.Write("Entre com o número de referência: ");
        int number = int.Parse(Console.ReadLine()!);

        int count = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (matrix[i, j] == number)
                {
                    count++;
                    Console.WriteLine($"\nPosição [{i}, {j}]:");
                    if (j > 0) Console.WriteLine($"Esquerda: {matrix[i, j - 1]}");
                    if (j < m - 1) Console.WriteLine($"Direita: {matrix[i, j + 1]}");
                    if (i > 0) Console.WriteLine($"Acima: {matrix[i - 1, j]}");
                    if (i < n - 1) Console.WriteLine($"Abaixo: {matrix[i + 1, j]}");
                }
            }
        }

        if (count > 0) Console.WriteLine($"\nNúmero de ocorrências: {count}");
        else Console.WriteLine("\nNenhuma ocorrência encontrada na matrix!");
    }
}
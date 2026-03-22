public static class Helpers
{
    public static void PrintSeparator(string title)
    {
        string line = new string('=', 62);
        Console.WriteLine($"\n{line}");
        Console.WriteLine($" {title}");
        Console.WriteLine($"{line}\n");
    }

    public static void PrintMatrix(int[,] m)
    {
        int rows = m.GetLength(0);
        int cols = m.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            Console.Write(" |");
            for (int j = 0; j < cols; j++)
                Console.Write($" {m[i, j],3}");
            Console.WriteLine(" |");
        }
    }

    public static void PrintArray(string name, int[] arr)
    {
        Console.Write($" {name}: [ ");
        for (int i = 0; i < arr.Length; i++)
            Console.Write($"{arr[i],3}{(i < arr.Length - 1 ? "," : " ")}");
        Console.WriteLine("]");
    }

    public static void PrintJaggedArray(string name, int[][] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write($" {name}[{i}]: [ ");
            for (int j = 0; j < arr[i].Length; j++)
                Console.Write($"{arr[i][j],3}{(j < arr[i].Length - 1 ? "," : " ")}");
            Console.WriteLine("]");
        }
    }

    public static int CountNonZero(int[,] m)
    {
        int count = 0;

        for (int i = 0; i < m.GetLength(0); i++)
            for (int j = 0; j < m.GetLength(1); j++)
                if (m[i, j] != 0)
                    count++;

        return count;
    }

    public static bool MatricesEqual(int[,] a, int[,] b)
    {
        if (a.GetLength(0) != b.GetLength(0) || a.GetLength(1) != b.GetLength(1))
            return false;

        for (int i = 0; i < a.GetLength(0); i++)
            for (int j = 0; j < a.GetLength(1); j++)
                if (a[i, j] != b[i, j])
                    return false;

        return true;
    }
}

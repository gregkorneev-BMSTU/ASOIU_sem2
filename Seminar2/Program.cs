// ============================================================
// ТЕСТОВАЯ МАТРИЦА ДЛЯ COO
// ============================================================

// Тестовая матрица для COO (5 строк × 6 столбцов)
// Всего элементов: 5×6 = 30, ненулевых: 6
// Порог COO: 30/3 = 10 -> COO эффективен (6 < 10)
int[,] matrixCOO = {
    { 1, 0, 0, 0, 0, 1 },
    { 0, 2, 0, 0, 0, 0 },
    { 3, 0, 0, 0, 0, 0 },
    { 0, 0, 0, 0, 0, 4 },
    { 0, 0, 5, 0, 0, 0 }
};

// ============================================================
// ЗАДАНИЕ 1: COO
// ============================================================

PrintSeparator("ЗАДАНИЕ 1: COO - КООРДИНАТНЫЙ ФОРМАТ ХРАНЕНИЯ");

int rCOO = matrixCOO.GetLength(0);
int cCOO = matrixCOO.GetLength(1);
int nCOO = CountNonZero(matrixCOO);

Console.WriteLine("Исходная плотная матрица (Рисунок 1, 5x6):");
PrintMatrix(matrixCOO);

Console.WriteLine("\n--- Анализ эффективности COO ---");
Console.WriteLine($"Размерность матрицы: {rCOO} x {cCOO} = {rCOO * cCOO} ячеек (плотное хранение)");
Console.WriteLine($"Ненулевых элементов (N): {nCOO}");
Console.WriteLine($"COO хранение (N*3): {nCOO}*3 = {nCOO * 3} ячеек");
Console.WriteLine($"Порог эффективности R*C/3: {rCOO}*{cCOO}/3 = {(double)(rCOO * cCOO) / 3:F2}");
Console.WriteLine($"Условие (N*3 < R*C): {nCOO * 3} < {rCOO * cCOO} => isCOOEffective = {isCOOEffective(matrixCOO)}");

Console.WriteLine("\n--- Преобразование Dense -> COO ---");
DenseToCOO(matrixCOO, out int[] rowCOO, out int[] colCOO, out int[] dataCOO);
PrintArray("Row", rowCOO);
PrintArray("Column", colCOO);
PrintArray("Data", dataCOO);

Console.WriteLine("\n--- Преобразование COO -> Dense ---");
int[,] restoredCOO = COOToDense(rowCOO, colCOO, dataCOO, rCOO, cCOO);
PrintMatrix(restoredCOO);

Console.WriteLine($"\nМатрица восстановлена верно: {MatricesEqual(matrixCOO, restoredCOO)}");

// ============================================================
// ВСПОМОГАТЕЛЬНЫЕ ФУНКЦИИ
// ============================================================

static void PrintSeparator(string title)
{
    string line = new string('=', 62);
    Console.WriteLine($"\n{line}");
    Console.WriteLine($" {title}");
    Console.WriteLine($"{line}\n");
}

static void PrintMatrix(int[,] m)
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

static void PrintArray(string name, int[] arr)
{
    Console.Write($" {name}: [ ");
    for (int i = 0; i < arr.Length; i++)
        Console.Write($"{arr[i],3}{(i < arr.Length - 1 ? "," : " ")}");
    Console.WriteLine("]");
}

static int CountNonZero(int[,] m)
{
    int count = 0;

    for (int i = 0; i < m.GetLength(0); i++)
        for (int j = 0; j < m.GetLength(1); j++)
            if (m[i, j] != 0)
                count++;

    return count;
}

static bool MatricesEqual(int[,] a, int[,] b)
{
    if (a.GetLength(0) != b.GetLength(0) || a.GetLength(1) != b.GetLength(1))
        return false;

    for (int i = 0; i < a.GetLength(0); i++)
        for (int j = 0; j < a.GetLength(1); j++)
            if (a[i, j] != b[i, j])
                return false;

    return true;
}

// ============================================================
// СТАТИЧЕСКИЕ ФУНКЦИИ — COO
// ============================================================

static void DenseToCOO(int[,] dense, out int[] row, out int[] col, out int[] data)
{
    int rows = dense.GetLength(0);
    int cols = dense.GetLength(1);
    int count = CountNonZero(dense);

    row = new int[count];
    col = new int[count];
    data = new int[count];

    int idx = 0;

    for (int i = 0; i < rows; i++)
        for (int j = 0; j < cols; j++)
            if (dense[i, j] != 0)
            {
                row[idx] = i;
                col[idx] = j;
                data[idx] = dense[i, j];
                idx++;
            }
}

static int[,] COOToDense(int[] row, int[] col, int[] data, int numRows, int numCols)
{
    int[,] dense = new int[numRows, numCols];

    for (int k = 0; k < data.Length; k++)
        dense[row[k], col[k]] = data[k];

    return dense;
}

static bool isCOOEffective(int[,] dense)
{
    int r = dense.GetLength(0);
    int c = dense.GetLength(1);
    int n = CountNonZero(dense);

    return n * 3 < r * c;
}

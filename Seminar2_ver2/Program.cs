// ============================================================
// ТЕСТОВЫЕ МАТРИЦЫ
// ============================================================

int[,] matrixCOO = {
    { 1, 0, 0, 0, 0, 1 },
    { 0, 2, 0, 0, 0, 0 },
    { 3, 0, 0, 0, 0, 0 },
    { 0, 0, 0, 0, 0, 4 },
    { 0, 0, 5, 0, 0, 0 }
};

int[,] matrixLIL = {
    { 0, 1, 0, 2, 0, 0 },
    { 0, 0, 0, 0, 0, 3 },
    { 4, 0, 5, 0, 0, 0 },
    { 0, 0, 0, 6, 0, 0 }
};

int[,] matrixCSR = {
    { 8, 0, 2, 0, 0 },
    { 0, 0, 5, 0, 0 },
    { 0, 0, 0, 0, 0 },
    { 0, 0, 0, 0, 0 },
    { 0, 0, 7, 1, 2 },
    { 0, 0, 0, 0, 0 },
    { 0, 0, 0, 9, 0 }
};

// ============================================================
// ЗАДАНИЕ 1: COO
// ============================================================

Helpers.PrintSeparator("ЗАДАНИЕ 1: COO - КООРДИНАТНЫЙ ФОРМАТ ХРАНЕНИЯ");

int rCOO = matrixCOO.GetLength(0);
int cCOO = matrixCOO.GetLength(1);
int nCOO = Helpers.CountNonZero(matrixCOO);

Console.WriteLine("Исходная плотная матрица (Рисунок 1, 5x6):");
Helpers.PrintMatrix(matrixCOO);

Console.WriteLine("\n--- Анализ эффективности COO ---");
Console.WriteLine($"Размерность матрицы: {rCOO} x {cCOO} = {rCOO * cCOO} ячеек (плотное хранение)");
Console.WriteLine($"Ненулевых элементов (N): {nCOO}");
Console.WriteLine($"COO хранение (N*3): {nCOO}*3 = {nCOO * 3} ячеек");
Console.WriteLine($"Порог эффективности R*C/3: {rCOO}*{cCOO}/3 = {(double)(rCOO * cCOO) / 3:F2}");
Console.WriteLine($"Условие (N*3 < R*C): {nCOO * 3} < {rCOO * cCOO} => isCOOEffective = {CooFormat.IsCOOEffective(matrixCOO)}");

Console.WriteLine("\n--- Преобразование Dense -> COO ---");
CooFormat.DenseToCOO(matrixCOO, out int[] rowCOO, out int[] colCOO, out int[] dataCOO);
Helpers.PrintArray("Row", rowCOO);
Helpers.PrintArray("Column", colCOO);
Helpers.PrintArray("Data", dataCOO);

Console.WriteLine("\n--- Преобразование COO -> Dense ---");
int[,] restoredCOO = CooFormat.COOToDense(rowCOO, colCOO, dataCOO, rCOO, cCOO);
Helpers.PrintMatrix(restoredCOO);

Console.WriteLine($"\nМатрица восстановлена верно: {Helpers.MatricesEqual(matrixCOO, restoredCOO)}");

// ============================================================
// ЗАДАНИЕ 2: LIL
// ============================================================

Helpers.PrintSeparator("ЗАДАНИЕ 2: LIL - ХРАНЕНИЕ В ФОРМЕ СВЯЗНЫХ СПИСКОВ");

int rLIL = matrixLIL.GetLength(0);
int cLIL = matrixLIL.GetLength(1);
int nLIL = Helpers.CountNonZero(matrixLIL);

Console.WriteLine("Исходная плотная матрица (Рисунок 2, 4x6):");
Helpers.PrintMatrix(matrixLIL);

Console.WriteLine("\n--- Анализ эффективности LIL ---");
Console.WriteLine($"Размерность матрицы: {rLIL} x {cLIL} = {rLIL * cLIL} ячеек (плотное хранение)");
Console.WriteLine($"Ненулевых элементов (N): {nLIL}");
Console.WriteLine($"LIL хранение (N*2): {nLIL}*2 = {nLIL * 2} ячеек");
Console.WriteLine($"Порог эффективности R*C/2: {rLIL}*{cLIL}/2 = {(double)(rLIL * cLIL) / 2:F2}");
Console.WriteLine($"Условие (N*2 < R*C): {nLIL * 2} < {rLIL * cLIL} => isLILEffective = {LilFormat.IsLILEffective(matrixLIL)}");

Console.WriteLine("\n--- Преобразование Dense -> LIL ---");
LilFormat.DenseToLIL(matrixLIL, out int[][] rowsLIL, out int[][] dataLIL);

Console.WriteLine("Rows[i] — индексы столбцов ненулевых элементов строки i:");
Helpers.PrintJaggedArray("Rows", rowsLIL);

Console.WriteLine("Data[i] — значения ненулевых элементов строки i:");
Helpers.PrintJaggedArray("Data", dataLIL);

Console.WriteLine("\n--- Преобразование LIL -> Dense ---");
int[,] restoredLIL = LilFormat.LILToDense(rowsLIL, dataLIL, rLIL, cLIL);
Helpers.PrintMatrix(restoredLIL);

Console.WriteLine($"\nМатрица восстановлена верно: {Helpers.MatricesEqual(matrixLIL, restoredLIL)}");

// ============================================================
// ЗАДАНИЕ 3: CSR
// ============================================================

Helpers.PrintSeparator("ЗАДАНИЕ 3: CSR - СЖАТОЕ ХРАНЕНИЕ ПО СТРОКАМ");

int rCSR = matrixCSR.GetLength(0);
int cCSR = matrixCSR.GetLength(1);
int nCSR = Helpers.CountNonZero(matrixCSR);

Console.WriteLine("Исходная плотная матрица (Рисунок 3, 7x5):");
Helpers.PrintMatrix(matrixCSR);

Console.WriteLine("\n--- Анализ эффективности CSR ---");
Console.WriteLine($"Размерность матрицы: {rCSR} x {cCSR} = {rCSR * cCSR} ячеек (плотное хранение)");
Console.WriteLine($"Ненулевых элементов (N): {nCSR}");
Console.WriteLine($"CSR хранение (2N + R + 1): 2*{nCSR} + {rCSR} + 1 = {2 * nCSR + rCSR + 1} ячеек");
Console.WriteLine($"Условие (2N+R+1 < R*C): {2 * nCSR + rCSR + 1} < {rCSR * cCSR} => isCSREffective = {CsrFormat.IsCSREffective(matrixCSR)}");

Console.WriteLine("\n--- Преобразование Dense -> CSR ---");
CsrFormat.DenseToCSR(matrixCSR, out int[] dataCSR, out int[] indicesCSR, out int[] ipCSR);
Helpers.PrintArray("Data", dataCSR);
Helpers.PrintArray("Indices", indicesCSR);
Helpers.PrintArray("IndexPointers", ipCSR);

Console.WriteLine("\n--- Пошаговое декодирование строк из CSR ---");
for (int i = 0; i < rCSR; i++)
{
    int start = ipCSR[i];
    int end = ipCSR[i + 1];

    Console.Write($" Row {i}: IP[{i}]={start}, IP[{i + 1}]={end} => ");

    if (start == end)
    {
        Console.WriteLine("(пустая строка)");
    }
    else
    {
        for (int k = start; k < end; k++)
            Console.Write($"matrix[{i},{indicesCSR[k]}]={dataCSR[k]} ");
        Console.WriteLine();
    }
}

Console.WriteLine("\n--- Преобразование CSR -> Dense ---");
int[,] restoredCSR = CsrFormat.CSRToDense(dataCSR, indicesCSR, ipCSR, rCSR, cCSR);
Helpers.PrintMatrix(restoredCSR);

Console.WriteLine($"\nМатрица восстановлена верно: {Helpers.MatricesEqual(matrixCSR, restoredCSR)}");
Console.WriteLine("\n=== ПРОГРАММА ЗАВЕРШЕНА ===");

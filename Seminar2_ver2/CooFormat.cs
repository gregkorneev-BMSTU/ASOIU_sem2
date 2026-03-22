public static class CooFormat
{
    public static void DenseToCOO(int[,] dense, out int[] row, out int[] col, out int[] data)
    {
        int rows = dense.GetLength(0);
        int cols = dense.GetLength(1);
        int count = Helpers.CountNonZero(dense);

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

    public static int[,] COOToDense(int[] row, int[] col, int[] data, int numRows, int numCols)
    {
        int[,] dense = new int[numRows, numCols];

        for (int k = 0; k < data.Length; k++)
            dense[row[k], col[k]] = data[k];

        return dense;
    }

    public static bool IsCOOEffective(int[,] dense)
    {
        int r = dense.GetLength(0);
        int c = dense.GetLength(1);
        int n = Helpers.CountNonZero(dense);

        return n * 3 < r * c;
    }
}

public static class LilFormat
{
    public static void DenseToLIL(int[,] dense, out int[][] rows, out int[][] data)
    {
        int numRows = dense.GetLength(0);
        int numCols = dense.GetLength(1);

        rows = new int[numRows][];
        data = new int[numRows][];

        for (int i = 0; i < numRows; i++)
        {
            int count = 0;

            for (int j = 0; j < numCols; j++)
                if (dense[i, j] != 0)
                    count++;

            rows[i] = new int[count];
            data[i] = new int[count];

            int idx = 0;

            for (int j = 0; j < numCols; j++)
                if (dense[i, j] != 0)
                {
                    rows[i][idx] = j;
                    data[i][idx] = dense[i, j];
                    idx++;
                }
        }
    }

    public static int[,] LILToDense(int[][] rows, int[][] data, int numRows, int numCols)
    {
        int[,] dense = new int[numRows, numCols];

        for (int i = 0; i < rows.Length; i++)
            for (int k = 0; k < rows[i].Length; k++)
                dense[i, rows[i][k]] = data[i][k];

        return dense;
    }

    public static bool IsLILEffective(int[,] dense)
    {
        int r = dense.GetLength(0);
        int c = dense.GetLength(1);
        int n = Helpers.CountNonZero(dense);

        return n * 2 < r * c;
    }
}

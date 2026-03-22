public static class CsrFormat
{
    public static void DenseToCSR(int[,] dense, out int[] data, out int[] indices, out int[] indexPointers)
    {
        int numRows = dense.GetLength(0);
        int numCols = dense.GetLength(1);
        int n = Helpers.CountNonZero(dense);

        data = new int[n];
        indices = new int[n];
        indexPointers = new int[numRows + 1];

        int idx = 0;

        for (int i = 0; i < numRows; i++)
        {
            indexPointers[i] = idx;

            for (int j = 0; j < numCols; j++)
                if (dense[i, j] != 0)
                {
                    data[idx] = dense[i, j];
                    indices[idx] = j;
                    idx++;
                }
        }

        indexPointers[numRows] = n;
    }

    public static int[,] CSRToDense(int[] data, int[] indices, int[] indexPointers, int numRows, int numCols)
    {
        int[,] dense = new int[numRows, numCols];

        for (int i = 0; i < numRows; i++)
        {
            int start = indexPointers[i];
            int end = indexPointers[i + 1];

            for (int k = start; k < end; k++)
                dense[i, indices[k]] = data[k];
        }

        return dense;
    }

    public static bool IsCSREffective(int[,] dense)
    {
        int r = dense.GetLength(0);
        int c = dense.GetLength(1);
        int n = Helpers.CountNonZero(dense);

        return 2 * n + r + 1 < r * c;
    }
}

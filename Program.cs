//*****************************************************************************
//** 3446. Sort Matrix by Diagonals                                 leetcode **
//*****************************************************************************

/**
 * Return an array of arrays of size *returnSize.
 * The sizes of the arrays are returned as *returnColumnSizes array.
 * Note: Both returned array and *columnSizes array must be malloced, assume caller calls free().
 */
static int icmp(const void* a, const void* b)
{
    int x = *(const int*)a;
    int y = *(const int*)b;
    return (x > y) - (x < y); 
}

int** sortMatrix(int** grid, int gridSize, int* gridColSize,
                 int* returnSize, int** returnColumnSizes)
{
    int n = gridSize;
    int* tmp = (int*)malloc(n * sizeof(int));
    if (!tmp)
    {
        *returnSize = gridSize;
        *returnColumnSizes = (int*)malloc(gridSize * sizeof(int));
        for (int r = 0; r < gridSize; r++) (*returnColumnSizes)[r] = gridColSize[r];
        return grid;
    }

    for (int k = n - 2; k >= 0; k--)
    {
        int i = k, j = 0, len = 0;
        while (i < n && j < n) tmp[len++] = grid[i++][j++];
        if (len > 1) qsort(tmp, len, sizeof(int), icmp);

        --i; --j;
        for (int t = 0; t < len; t++) grid[i--][j--] = tmp[t];
    }

    for (int k = n - 2; k > 0; k--)
    {
        int i = k, j = n - 1, len = 0;
        while (i >= 0 && j >= 0) tmp[len++] = grid[i--][j--];
        if (len > 1) qsort(tmp, len, sizeof(int), icmp);

        ++i; ++j;
        for (int t = 0; t < len; t++) grid[i++][j++] = tmp[t];
    }

    free(tmp);

    *returnSize = gridSize;
    *returnColumnSizes = (int*)malloc(gridSize * sizeof(int));
    for (int r = 0; r < gridSize; r++) (*returnColumnSizes)[r] = gridColSize[r];

    return grid;
}
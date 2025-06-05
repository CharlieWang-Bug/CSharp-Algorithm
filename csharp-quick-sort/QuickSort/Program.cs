using System;
/***
 * 

1. **主方法 (`Main`)**:
   - 创建一个整型数组 `array`，并初始化一些整数。
   - 打印原数组。
   - 调用 `QuickSort` 方法对数组进行排序。
   - 打印排序后的数组。

2. **`QuickSort` 方法**:
   - 是快速排序的主体函数，它接收参数 `array`, `low`, `high`，分别表示待排序数组，当前排序的开始下标和结束下标。
   - 首先检查 `low` 是否小于 `high`，以确保有元素需要排序。如果条件成立，调用 `Partition` 方法获取中轴的索引。
   - 使用中轴索引递归地对中轴左边和右边的子数组进行排序。

3. **`Partition` 方法**:
   - 选择数组的最后一个元素作为中轴（pivot）。
   - 初始化一个指针 `i`，它表示小于中轴元素的最后一个元素的索引。
   - 遍历数组，检查每个元素，如果元素小于或等于中轴，则增加 `i` 并与当前元素交换。
   - 在循环结束后，将中轴元素置于其最终位置，并返回其新的索引。

4. **`Swap` 方法**:
   - 交换数组中两个指定位置的元素。

5. **`PrintArray` 方法**:
   - 打印数组的所有元素，以便在控制台上观察结果。

### 快速排序的复杂度
- **时间复杂度**: 平均为 O(n log n)，最坏情况下为 O(n²)（例如已经有序的数组）。
- **空间复杂度**: O(log n) (由于递归调用的堆栈空间)。

快速排序算法是一种高效且常用的排序算法，适合处理大量的数据。

 * 
***/
class QuickSortDemo
{
    public static void Main(string[] args)
    {
        int[] array = { 5, 2, 9, 1, 5, 6 };

        Console.WriteLine("原数组：");
        PrintArray(array);

        QuickSort(array, 0, array.Length - 1);

        Console.WriteLine("排序后数组：");
        PrintArray(array);
    }

    // 快速排序方法
    public static void QuickSort(int[] array, int low, int high)
    {
        if (low < high)
        {
            // 获取中轴索引
            int pivotIndex = Partition(array, low, high);

            // 递归排序中轴左边和右边的子数组
            QuickSort(array, low, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, high);
        }
    }

    // 分区方法
    public static int Partition(int[] array, int low, int high)
    {
        // 选择最后一个元素作为中轴
        int pivot = array[high];
        int i = low - 1; // 小于中轴的元素的最后索引

        for (int j = low; j < high; j++)
        {
            // 如果当前元素小于或等于中轴
            if (array[j] <= pivot)
            {
                i++; // 增加小于中轴的元素的索引
                Swap(array, i, j); // 交换元素
            }
        }

        // 将中轴元素放到正确的位置
        Swap(array, i + 1, high);
        return i + 1; // 返回中轴的索引
    }

    // 交换数组中两个元素
    public static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    // 打印数组
    public static void PrintArray(int[] array)
    {
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitDevelop.Algorithm
{
    public class Sort
    {
        #region----------快速排序--------
        public static void QuickSort(int[] array, int low, int high)
        {
            if (low >= high)
                return;
            /*完成一次单元排序*/
            int index = SortUnit(array, low, high);
            /*对左边单元进行排序*/
            QuickSort(array, low, index - 1);
            /*对右边单元进行排序*/
            QuickSort(array, index + 1, high);
        }
        private static int SortUnit(int[] array, int low, int high)
        {
            int key = array[low];
            while (low < high)
            {
                /*从后向前搜索比key小的值*/
                while (array[high] >= key && high > low)
                    --high;
                /*比key小的放左边*/
                array[low] = array[high];
                /*从前向后搜索比key大的值，比key大的放右边*/
                while (array[low] <= key && high > low)
                    ++low;
                /*比key大的放右边*/
                array[high] = array[low];
            }
            /*左边都比key小，右边都比key大。//将key放在游标当前位置。//此时low等于high */
            array[low] = key;
            return high;
        }

        #endregion
        #region----------堆排序----------
        public static void HeapSort(int[] values)
        {
            int size = values.Length;
            BuildMaxHeap(values, size);
            for (int i = size - 1; i >= 0; i--)
            {
                Swap(values, 0, i);
                size -= 1;
                Heapify(values, 0, size);
            }
        }
        public static void Heapify(int[] arrays, int i, int len)
        {
            //左子树和右字数的位置
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int largest = i;
            if(left<len && arrays[left]>arrays[largest])
            {
                largest = left;
            }
            if(right<len && arrays[right]>arrays[largest])
            {
                largest = right;
            }
            if(largest!=i)
            {
                Swap(arrays, i, largest);
                Heapify(arrays, largest, len);
            }
        }
        public static void Swap(int[] arrays,int i,int j)
        {
            int temp = arrays[i];
            arrays[i] = arrays[j];
            arrays[j] = temp;
        }
        public static void BuildMaxHeap(int[] arrays, int size)
        {
            // 从数组的尾部开始，直到第一个元素(角标为0)
            for (int i = size/2; i >= 0; i--) //i==size-1
            {
                Heapify(arrays, i, size);
            }
        }
        #endregion
        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="values"></param>
        public static void BubbleSort(int[] values)
        {
            for(int i =0;i<values.Length-1;i++)
            {
                for (int j = 0; j < values.Length - 1-i; j++)
                {
                    if(values[j]> values[j+1])
                    {
                        int temp = values[j];
                        values[j] = values[j + 1];
                        values[j + 1] = temp;
                    }
                }
            }
        }
        /// <summary>
        /// 插入排序
        /// </summary>
        /// <param name="values"></param>
        public static void InsertSort(List<double> values)
        {
            for(int i=1; i< values.Count;i++)
            {
                double currentValue = values[i];
                int j = i - 1;
                for(;j>=0;j--)
                {
                    if(values[j]> currentValue)
                    {
                        values[j + 1] = values[j];
                    }
                    else
                    {
                        break;
                    }
                }
                values[j + 1] = currentValue;
            }
        }
        public static void MergeSort(int[] a, int f, int e)
        {
            if (f < e)
            {
                int mid = (f + e) / 2;
                MergeSort(a, f, mid);
                MergeSort(a, mid + 1, e);
                MergeMethid(a, f, mid, e);
            }
        }
        private static void MergeMethid(int[] a, int f, int mid, int e)
        {
            int[] t = new int[e - f + 1];
            int m = f, n = mid + 1, k = 0;
            while (n <= e && m <= mid)
            {
                if (a[m] > a[n])
                {
                    t[k++] = a[n++];
                }                    
                else
                {
                    t[k++] = a[m++];
                } 
            }
            while (n < e + 1)
            {
                t[k++] = a[n++];
            }
            while (m < mid + 1)
            {
                t[k++] = a[m++];
            }
            for (k = 0, m = f; m < e + 1; k++, m++)
            {
                a[m] = t[k];
            }
        }
    }
}

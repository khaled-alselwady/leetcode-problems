using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public static void Main(string[] args)
    {
        int[] nums1 = { };
        int[] nums2 = { 1 };

        Console.WriteLine(FindMedianSortedArrays(nums1, nums2));
        Console.WriteLine(FindMedianSortedArraysUsingBinarySearch(nums1, nums2));

        Console.ReadKey();
    }

    private static double _GetMedian(double min, double max)
        => min + ((max - min) / 2);

    private static bool _IsEven(int num)
        => (num % 2 == 0);

    #region Approach 1
    public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        if (nums1 == null || nums2 == null)
        {
            return double.NaN;
        }

        List<int> list1 = new List<int>(nums1);
        List<int> list2 = new List<int>(nums2);

        var list3 = list1.Concat(list2).OrderBy(x => x).ToList();

        int listCount = list3.Count;

        if (_IsEven(listCount))
        {
            int lastIndexInMedian = listCount / 2;
            int firstIndexMedian = lastIndexInMedian - 1;

            return _GetMedian(list3[firstIndexMedian], list3[lastIndexInMedian]);
        }
        else
        {
            return list3[listCount / 2];
        }
    }
    #endregion

    #region Approach 2
    private static double _PerformBinarySearchToGetResult(int[] nums1, int[] nums2)
    {
        int m = nums1.Length;
        int n = nums2.Length;
        int total = m + n;
        int half = (total + 1) / 2;
        int left = 0;
        int right = m;
        double result = 0.0;
        while (left <= right)
        {
            int middle = left + (right - left) / 2;
            int j = half - middle;
            int left1 = (middle > 0) ? nums1[middle - 1] : int.MinValue;
            int right1 = (middle < m) ? nums1[middle] : int.MaxValue;
            int left2 = (j > 0) ? nums2[j - 1] : int.MinValue;
            int right2 = (j < n) ? nums2[j] : int.MaxValue;

            if (left1 <= right2 && left2 <= right1)
            {
                if (_IsEven(total))
                {
                    result = (Math.Max(left1, left2) + Math.Min(right1, right2)) / 2.0;
                }
                else
                {
                    result = Math.Max(left1, left2);
                }
                break;
            }
            else if (left1 > right2)
            {
                right = middle - 1;
            }
            else
            {
                left = middle + 1;
            }
        }
        return result;
    }

    public static double FindMedianSortedArraysUsingBinarySearch(int[] nums1, int[] nums2)
    {
        if (nums1.Length <= 0 && nums2.Length == 1)
        {
            return nums2[0];
        }
        if (nums2.Length <= 0 && nums1.Length == 1)
        {
            return nums1[0];
        }

        if (nums1.Length > nums2.Length)
        {
            // swapping
            (nums1, nums2) = (nums2, nums1);
            //return FindMedianSortedArrays(nums2, nums1);
        }

        return _PerformBinarySearchToGetResult(nums1, nums2);
    }
    #endregion
}


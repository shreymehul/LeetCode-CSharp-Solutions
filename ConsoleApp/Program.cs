public class Program
{
    public static void Main(string[] args)
    {
        int[] nums1 = new int[] { 1, 2 };

        int[] nums2 = new int[] { 3, 4 };

        //Console.WriteLine(FindMedianSortedArrays(nums1, nums2));

        //Console.WriteLine(MySqrt(2147395599));
    }
    //MySqrt
    public static int MySqrt(int x)
    {
        if (x == 0)
        {
            return 0;
        }
        if (x == 1 || x == 2 || x == 3)
        {
            return 1;
        }
        int l, r, s;
        l = 0; r = x;
        while (l <= r)
        {

            if (l == (r - 1))
            {
                return l;
            }
            else
            {
                s = l + ((r - l) / 2);
                if (s * s < x)
                {
                    l = s;
                }
                else if (s * s > x)
                {
                    r = s;
                }
                else
                {
                    return s;
                }
            }
        }
        return l;
    }
    //FindMedianSortedArrays
    public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        int pos;
        if (nums1 != null && nums2 != null)
            pos = (nums1.Length + nums2.Length) / 2;
        else if (nums1 != null)
            pos = (nums1.Length) / 2;
        else
            pos = (nums2.Length) / 2;
        int i = 0, j = 0;
        while (i < nums1.Length && j < nums2.Length && (i + j) < (pos - 1))
        {
            if (nums1[i] <= nums2[j])
            {
                i++;
            }
            else
            {
                j++;
            }
        }
        while (j < nums2.Length - 1 && (i + j) < (pos - 1))
        {
            j++;
        }
        while (i < nums1.Length - 1 && (i + j) < (pos - 1))
        {
            i++;
        }
        if ((nums1.Length + nums2.Length) % 2 != 0)
        {
            if (i < nums1.Length - 1 && nums1[i] < nums2[j])
                i++;
            else if (j < nums2.Length - 1)
                j++;
            if (i < nums1.Length - 1 && nums1[i] < nums2[j])
                return nums1[i];
            else
                return nums2[j];
        }
        else
        {
            double v1, v2;
            if (i < nums1.Length - 1 && nums1[i] < nums2[j])
                v1 = nums1[i++];
            else
                v1 = nums2[j++];
            if (i < nums1.Length - 1 && nums1[i] < nums2[j])
                v2 = nums1[i];
            else
                v2 = nums2[j];
            //Console.WriteLine (v1+ "-v1 " + v2 +"-v2");
            return (v1 + v2) / 2;
        }
    }
}

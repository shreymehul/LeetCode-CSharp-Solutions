namespace LeetCodeCSharpSolution
{
    internal class MySqrtSolution
    {
        //69. Sqrt(x)
        //Given a non-negative integer x, compute and return the square root of x.
        //Since the return type is an integer, the decimal digits are truncated, and only the integer part of the result is returned.
        //Note: You are not allowed to use any built-in exponent function or operator, such as pow(x, 0.5) or x ** 0.5.
        public int MySqrt(int x)
        {
            if (x == 0)
            {
                return 0;
            }
            if (x == 1 || x == 2 || x == 3)
            {
                return 1;
            }
            int left, right, sqrt;
            left = 1; right = x;
            while (left <= right)
            {
                if (left == (right - 1))
                {
                    break;
                }
                else
                {
                    sqrt = left + ((right - left) / 2);
                    if (sqrt < x / sqrt)
                    {
                        left = sqrt;
                    }
                    else if (sqrt > x / sqrt)
                    {
                        right = sqrt;
                    }
                    else
                    {
                        return sqrt;
                    }
                }
            }
            return left;
        }
    }
}

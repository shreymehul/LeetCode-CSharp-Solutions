//190. Reverse Bits
//Reverse bits of a given 32 bits unsigned integer.
public class Solution
{
    public uint reverseBits(uint n)
    {
        uint res = 0;

        for (int i = 0; i < 32; i++)
        {
            res += (n & 1) << (31 - i);
            n = n >> 1;
        }
        return res;
    }
}

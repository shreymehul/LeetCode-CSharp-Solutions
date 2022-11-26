// 93. Restore IP Addresses
// A valid IP address consists of exactly four integers separated by single dots. Each integer is between 0 and 255 (inclusive) and cannot have leading zeros.
// For example, "0.1.2.201" and "192.168.1.1" are valid IP addresses, but "0.011.255.245", "192.168.1.312" and "192.168@1.1" are invalid IP addresses.
// Given a string s containing only digits, return all possible valid IP addresses that can be formed by inserting dots into s. You are not allowed to reorder or remove any digits in s. You may return the valid IP addresses in any order.
// Example 1:
// Input: s = "25525511135"
// Output: ["255.255.11.135","255.255.111.35"]
// Example 2:
// Input: s = "0000"
// Output: ["0.0.0.0"]
// Example 3:
// Input: s = "101023"
// Output: ["1.0.10.23","1.0.102.3","10.1.0.23","10.10.2.3","101.0.2.3"]

public IList<string> RestoreIpAddresses(string s)
{
    IList<string> result = new List<string>();
    string ip = "";
    //Though there are 3 loops, entire string will be iterated 3*3*3 i.e 27 times only.
    for (int i = 1; i < 4; i++)
    {
        for (int j = 1; j < 4; j++)
        {
            for (int k = 1; k < 4; k++)
            {
                if (i + j + k < s.Length) //to ensure size of D is atleast 1
                {
                    //Converting in int first will ensure each part has maximum onr 0's.
                    int A = Int32.Parse(s.Substring(0, i));
                    int B = Int32.Parse(s.Substring(i, j));
                    int C = Int32.Parse(s.Substring(i + j, k));
                    long D = Int64.Parse(s.Substring(i + j + k, s.Length - (i + j + k))); //making it long as last part value make exceed 32 bits.
                    if (A <= 255 && B <= 255 &&
                        C <= 255 && D <= 255)
                    {
                        ip = A + "." + B + "." + C + "." + D;
                        //re-checking length as in case of multiple 0's in single part, length will get reduced, and this value should be droped;
                        if (ip.Length == s.Length + 3) 
                            result.Add(ip);
                    }
                }
            }
        }
    }
    return result;
}
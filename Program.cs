/*
//adding 2 binary numbers and printing its sum
*/

using System;

class Program
{
    

    static string trimleadzeros(string s)               // starting from left side
    {
        int firstind = s.IndexOf('1');
        return (firstind == -1) ? "0" : s.Substring(firstind);
    }
  
    static string addBinary(string s1, string s2)       // adds 2 binary string and returns result as another string
    {

        
        s1 = trimleadzeros(s1);                          // method call for trimming leading zeroes
        s2 = trimleadzeros(s2);

        int n = s1.Length;
        int m = s2.Length;

      
        if (n < m)                  // swap if legth of s1 is less than length of s2
        {
            return addBinary(s2, s1);
        }

        int j = m - 1;          // starts from right side of the string
        int carry = 0;
        char[] result = new char[n];

       
        for (int i = n - 1; i >= 0; i--)            // Traversing from right side
        {
   
            int bit1 = s1[i] - 48;             
            int sum = bit1 + carry;
    
                                 // If there are remaining bits in s2, add them to the sum
            if (j >= 0)
            {

                int bit2 = s2[j] - 48;
                sum =sum+bit2;
                j--;
            }

           
            int bit = sum % 2;              //calculating result and carry 
            carry = sum / 2;

            
            result[i] = (char)(bit + 48);
        }

      
        if (carry > 0)
        {
            return '1' + new string(result);
        }

        return new string(result);
    }

    public static void Main(string[] args)
    {
        string s1 = "1101";
        string s2 = "111";
        Console.WriteLine(addBinary(s1, s2));
        string binary = addBinary(s1, s2);
        int number = Convert.ToInt32(binary,2);
        Console.WriteLine(number);
    }
   
}

using System;

class Question3
{
    
    static string FloatToBinary(float number)
    {
        byte[] bytes = BitConverter.GetBytes(number);     
        Array.Reverse(bytes); // make MSB first

        // suppose binary:01000000  10100000  00000000  00000000  (binary)
        //bytes[] = it will store it as
        //[0] =   (00000000)
        //[1] = (00000000)
        //[2] = (10100000)
        //[3] = (01000000)

        string binary = "";
        foreach (byte b in bytes)
            binary += Convert.ToString(b, 2).PadLeft(8, '0');
        return binary;
    }

   
    static float BinaryToFloat(string binary)   //bin to float
    {
        byte[] bytes = new byte[4];
        for (int i = 0; i < 4; i++)
            bytes[3 - i] = Convert.ToByte(binary.Substring(i * 8, 8), 2);   // (i*8) -->gives the starting position and 8 is length
        return BitConverter.ToSingle(bytes, 0);
    }

  
    static string AddBinary(string a, string b)
    {
        string result = "";
        int carry = 0;

        int i = a.Length - 1, j = b.Length - 1;

        while (i >= 0 || j >= 0 || carry == 1)
        {
            int sum = carry;
            if (i >= 0)
            {
                sum = sum + a[i] - 48;
                i--;
            }
            if (j >= 0)
            {
                sum = sum + b[j] - 48;
                j--;
            }

            result = (sum % 2) + result;
            carry = sum / 2;
        }

        
        return result.PadLeft(32, '0').Substring(result.Length - 32);
    }

    static void Main()
    {
        Console.Write("Enter float1: ");
        float n = float.Parse(Console.ReadLine());

        Console.Write("Enter float2: ");
        float m = float.Parse(Console.ReadLine());

        string binN = FloatToBinary(n);
        string binM = FloatToBinary(m);

        Console.WriteLine("Binary of n: " + binN);
        Console.WriteLine("Binary of m: " + binM);

        string binSum = AddBinary(binN, binM);

        float sum = BinaryToFloat(binSum);

        Console.WriteLine("Binary Sum: " + binSum);
        Console.WriteLine("Float Result: " + sum);
    }
}

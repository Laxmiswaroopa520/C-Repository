using System;


namespace assignement1
{
    using System;

    class Floataddition
    {
        static void Main()
        {
            
            Console.Write("Enter a float number1: ");
            float x = float.Parse(Console.ReadLine());
            string binary1 = FloatToBinary(x);

            ExtractExponentMantissa(binary1, out int exponent, out float mantissa);
            Console.WriteLine("Binary representation: " + binary1);
            Console.WriteLine("Exponent: " + exponent);
            Console.WriteLine("Mantissa: " + mantissa);

            Console.Write("Enter a float number2: ");
            float y = float.Parse(Console.ReadLine());
            string binary2 = FloatToBinary(y);

            ExtractExponentMantissa(binary2, out int exponent2, out float mantissa2);
            Console.WriteLine("Binary representation: " + binary2);
            Console.WriteLine("Exponent: " + exponent2);
            Console.WriteLine("Mantissa: " + mantissa2);



        }

        // Convert float to 32-bit binary string (MSB first)
        static string FloatToBinary(float number)
        {
            byte[] bytes = BitConverter.GetBytes(number);
            Array.Reverse(bytes); // MSB first

            string binary = "";
            foreach (byte b in bytes)
                binary += Convert.ToString(b, 2).PadLeft(8, '0');
            return binary;
        }

        static void ExtractExponentMantissa(string binary, out int exponent, out float mantissa)
        {
            string exponentBits = binary.Substring(1, 8);// exponent bits (1-8)
            exponent = Convert.ToInt32(exponentBits, 2) - 127; // remove bias    // supoose 130-127=3

          
            string mantissaBits = binary.Substring(9, 23);   // mantissa bits(9-23)

           
            mantissa = 1; // implicit leading 1
            for (int i = 0; i < mantissaBits.Length; i++)
            {
                if (mantissaBits[i] == '1')
                    mantissa += (float)Math.Pow(2, -(i + 1));
            }
        }
    }
}


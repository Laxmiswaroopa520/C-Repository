
using System;
namespace assignement1
{
     class Floatsum22
    {
 
            static void Main()
            {
                // Input first float
                Console.Write("Enter float number 1: ");
                float x = float.Parse(Console.ReadLine());
                string binary1 = FloatToBinary(x);
                ExtractExponentMantissa(binary1, out int exponent1, out float mantissa1, out int sign1);
                Console.WriteLine($"Binary1: {binary1}  Exponent: {exponent1}  Mantissa: {mantissa1}  Sign: {sign1}");

                // Input second float
                Console.Write("Enter float number 2: ");
                float y = float.Parse(Console.ReadLine());
                string binary2 = FloatToBinary(y);
                ExtractExponentMantissa(binary2, out int exponent2, out float mantissa2, out int sign2);
                Console.WriteLine($"Binary2: {binary2}  Exponent: {exponent2}  Mantissa: {mantissa2}  Sign: {sign2}");

                
                if (exponent1 > exponent2)      // exponents should be equal
                {
                    int diff = exponent1 - exponent2;
                    mantissa2 /= (float)Math.Pow(2, diff);
                    exponent2 = exponent1;
                }
                else if (exponent2 > exponent1)
                {
                    int diff = exponent2 - exponent1;
                    mantissa1 /= (float)Math.Pow(2, diff);
                    exponent1 = exponent2;
                }

               
                float resultMantissa = sign1 * mantissa1 + sign2 * mantissa2;       // finding resultmantissa like adding 2 manitssas


                int resultSign = resultMantissa >= 0 ? 1 : -1;              // finding sign of resultmantissa
                resultMantissa = Math.Abs(resultMantissa);

                
                int resultExponent = exponent1;                             // normalize resultmantissa because >=2 and <1
                while (resultMantissa >= 2)                                 // mantissa range [1,2)
                {
                    resultMantissa /= 2;
                    resultExponent++;
                }
                while (resultMantissa < 1 && resultMantissa != 0)
                {
                    resultMantissa *= 2;
                    resultExponent--;
                }

                
                float result = resultSign * resultMantissa * (float)Math.Pow(2, resultExponent);            // findingfinal result

                Console.WriteLine($"\nResult of addition: {result}");
            }



            static string FloatToBinary(float number)               // float to binary conversion method
            {
                byte[] bytes = BitConverter.GetBytes(number);
                Array.Reverse(bytes); // MSB first

                string binary = "";
                foreach (byte b in bytes)
                    binary += Convert.ToString(b, 2).PadLeft(8, '0');
                return binary;
            }

            // Extract exponent, mantissa, and sign
            static void ExtractExponentMantissa(string binary, out int exponent, out float mantissa, out int sign)
            {
                sign = binary[0] == '1' ? -1 : 1;

                string exponentBits = binary.Substring(1, 8);
                exponent = Convert.ToInt32(exponentBits, 2) - 127;

                string mantissaBits = binary.Substring(9, 23);
                mantissa = 1; // implicit 1   
                for (int i = 0; i < mantissaBits.Length; i++)
                    if (mantissaBits[i] == '1')
                        mantissa += (float)Math.Pow(2, -(i + 1));
            }
        }
    }


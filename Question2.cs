/*2. Find the four adjacent digits in any given number that have the greatest product.
 What is the value of this product?

i/p: 1234568987458744574664554 (input can be any)
o/p: 8*9*8*7=4032
*/




using System;
using System.Numerics;


namespace assignement1
{
     class Question2
    {
        public static void Main(String[] args)
        {
            //  Int32 n = Convert.ToInt32(Console.ReadLine());
            string str = Console.ReadLine();
            int maxpr = 1;

            for(int i=0;i<str.Length-4;i++)
            {
                int product = 1;
                for(int j=i;j<i+4;j++)
                {
                    int a = str[j] - 48;
                    product = product * a; 
                  
                }
                if(product>maxpr)
                {
                    maxpr = product;
                }
            }
            Console.WriteLine(maxpr);
        }
    }
}

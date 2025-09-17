/*1.Take two strings as input and check whether the second string is a sub-string of the first or
 * not. If yes, print the number of times occurred in S1 and print the index positions where the string appeared]

 
i/p : S1 = “abcdabcabd”
        S2 = “ab”
o/p: No.of times occurred = 3
        Index positions = 0 4 7
*/
using System;


namespace assignement1
{
     class Question1
    {
        public static void Main(string[] args)
        {
            string str1 = Console.ReadLine();
            string str2 = Console.ReadLine();
            bool b = str1.Contains(str2);
            if(b)
            {
                int count = 0;
                int index = 0;

                
                while ( (index=str1.IndexOf(str2,index)) != -1)
                {
                    Console.WriteLine(index + " "); 
                    count++;
                    index ++; // Move to next character to allow overlapping matches
                }

                if (count > 0)
                {
                    Console.WriteLine("\nNo. of times occurred = " + count);
                }
                else
                {
                    Console.WriteLine("Substring not found.");
                }
            }
        }
    }
        }
    

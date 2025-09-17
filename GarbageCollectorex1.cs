using System;
using System.Diagnostics;

class MyClass6
{
    public int Id { get; set; }
}

class Program6
{
    static void Main()
    {

        Stopwatch sw = new Stopwatch();


        MyClass6 survivor = new MyClass6 { Id = 100 };

        Console.WriteLine($"Initially: Survivor is in Gen {GC.GetGeneration(survivor)}");

        for (int i = 0; i < 100000; i++)
        {
            // Create short-lived objects (die quickly in Gen0)
            MyClass6 temp = new MyClass6 { Id = i };


            if (i % 20000 == 0 && i > 0)
            {
                sw.Restart();
                GC.Collect();

                GC.WaitForPendingFinalizers();
                sw.Stop();

                Console.WriteLine($"Iteration {i}, GC ran in {sw.ElapsedMilliseconds} ms");
                Console.WriteLine($"   Survivor is now in Gen {GC.GetGeneration(survivor)}");
            }
        }

        // Final full GC
        sw.Restart();
        GC.Collect(2);
        GC.WaitForPendingFinalizers();
        sw.Stop();

        Console.WriteLine("\nAfter Full GC:");
        Console.WriteLine($"Survivor is in Gen {GC.GetGeneration(survivor)}");
        Console.WriteLine($"Final GC took {sw.ElapsedMilliseconds} ms");
    }
}

using System;

class MyClass
{
    public int Id { get; set; }
}

class GarbageCollectorex2
{
    static void Main()
    {
        // Step 1: Create objects
        MyClass obj1 = new MyClass { Id = 1 };
        MyClass obj2 = new MyClass { Id = 2 };

        Console.WriteLine("Initially:");
        Console.WriteLine($"Obj1 is in Generation: {GC.GetGeneration(obj1)}");
        Console.WriteLine($"Obj2 is in Generation: {GC.GetGeneration(obj2)}");


        GC.Collect(0);
        GC.WaitForPendingFinalizers();
        obj1 = null;
        Console.WriteLine("\nAfter Gen 0 Collection:");
        // Console.WriteLine($"Obj1 is in Generation: {GC.GetGeneration(obj1)}");
        Console.WriteLine($"Obj2 is in Generation: {GC.GetGeneration(obj2)}");


        /*   GC.Collect(1);
           GC.WaitForPendingFinalizers();

           Console.WriteLine("\nAfter Gen 1 Collection:");
           Console.WriteLine($"Obj1 is in Generation: {GC.GetGeneration(obj1)}");
           Console.WriteLine($"Obj2 is in Generation: {GC.GetGeneration(obj2)}");


           GC.Collect(2);
           GC.WaitForPendingFinalizers();

           Console.WriteLine("\nAfter Gen 2 Collection (Full GC):");
           Console.WriteLine($"Obj1 is in Generation: {GC.GetGeneration(obj1)}");
           Console.WriteLine($"Obj2 is in Generation: {GC.GetGeneration(obj2)}");

           Console.WriteLine("\nEnd of program."); */
    }
}

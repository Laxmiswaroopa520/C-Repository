using System;

class Counter
{
    public static int StaticCount = 0;


    public int InstanceCount = 0;

    public Counter()
    {
        StaticCount++;
        InstanceCount++;
    }

    public void ShowCounts(string name)
    {
        Console.WriteLine($"{name} StaticCount: {StaticCount}, InstanceCount: {InstanceCount}");
    }
}

class ScopeOfStatic
{
    static void Main()
    {

        Counter obj1 = new Counter();
        obj1.ShowCounts("Object1");


        Counter obj2 = new Counter();
        obj2.ShowCounts("Object2");


        Counter obj3 = new Counter();
        obj3.ShowCounts("Object3");
    }
}

using System.Reflection;


class Program

{
    public static void Main()
    {
        Assembly asm = Assembly.LoadFrom("E:\\C# Labs\\.dll");
        Console.WriteLine(asm.GetName().Name);

    }
}

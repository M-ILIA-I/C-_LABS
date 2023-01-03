using System;
using System.Reflection;
using System.Collections.Generic;


namespace lab6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Assembly asm = null;
            try
            {
                asm = Assembly.LoadFrom("FileServiceLibrary.dll");
            }
            catch
            {
                Console.WriteLine("Dll not found");
                Environment.Exit(1);
            }
            Type fileServiceType = asm.GetType("FileServiceLibrary.FileService`1", true, true).MakeGenericType(new Type[] { typeof(Employee) });
            object fileService = Activator.CreateInstance(fileServiceType);
            MethodInfo read = fileServiceType.GetMethod("ReadFile");
            MethodInfo save = fileServiceType.GetMethod("SaveData");

            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Katya", 500, true));
            employees.Add(new Employee("Anna", 300, false));
            employees.Add(new Employee("Vova", 700, true));
            employees.Add(new Employee("Maksim", 600, true));
            employees.Add(new Employee("Lola", 500, false));
            string filename = "newFile";

            save.Invoke(fileService, new object[] { employees, filename });
            var newCollection = (List<Employee>)read.Invoke(fileService, new object[] { filename });
            foreach (Employee employee in newCollection)
            {
                Console.WriteLine(employee);
            }
        }
    }
}
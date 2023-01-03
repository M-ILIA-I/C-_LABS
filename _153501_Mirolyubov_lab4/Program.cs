using _153501_Mirolyubov_lab4;
class Program


{
    static void Main()
    {

        //Initialization cars list

        string path = "E:\\C# Labs\\_153501_Mirolyubov_lab4\\MyTest\\MyTest.txt";
        List<Car> cars = new List<Car>();
        cars.Add(new Car("Opel", 199, 2013));
        cars.Add(new Car("Lada", 100, 1996));
        cars.Add(new Car("Mazda", 222, 2020));
        cars.Add(new Car("BMW", 200, 2003));
        cars.Add(new Car("Mercedes", 100, 1993));
        cars.Add(new Car("Ferari", 300, 2021));

        FileService fs = new FileService();

        if (File.Exists(path))
        {
            File.Delete(path);
        }
        File.Create(path).Close();
        fs.SaveData(cars, path);

        string newName = "NewTest";

        if (File.Exists(path))
        {
            File.Create(newName).Close();
            File.Copy(path, newName, true);
            File.Delete(path);
        }

        List<Car> newCars = new List<Car>();

        foreach(Car i in fs.ReadFile(newName))
        {
            newCars.Add(i);
        }
        
        newCars.Sort(new MyCustomComparer());

        Console.WriteLine("Name" + " " + "Horse pover");
        foreach(Car i in cars)
        {
            Console.Write(i.Name + " ");
            Console.WriteLine(i.HorsePower);
        }
        Console.WriteLine("===========================");

        Console.WriteLine("Name" + " " + "Horse pover");
        foreach (Car i in newCars)
        {
            Console.Write(i.Name + " ");
            Console.WriteLine(i.HorsePower);
        }

        var powerfullModels = from i in cars
                              orderby i.HorsePower descending
                              select i;

        Console.WriteLine("Name" + " " + "Horse pover");
        Console.WriteLine("===========================");
        foreach (Car i in powerfullModels)
        {
            Console.Write(i.Name + " ");
            Console.WriteLine(i.HorsePower);
        }
    }

}


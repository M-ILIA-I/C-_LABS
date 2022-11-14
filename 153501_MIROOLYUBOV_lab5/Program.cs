using _153501_MIROOLYUBOV_lab5.Entities;

class program
{
    public static void Main()
    {
        Bank tink = new Bank("Tinkoff");
        tink.Registrated += (string message) => Console.WriteLine(message);
        Journal journal = new Journal();
        tink.Changed += journal.TakeNewNote;
        Client anton = new Client("Anton");
        Client dima = new Client("DIMA");
        Client oleg = new Client("Oleg");

        tink.AddNewClient(anton, 200, 30);
        tink.NewDeposit(anton, 400, 10);
        tink.AddNewClient(dima, 300, 10);
        tink.NewDeposit(dima, 70, 30);

        Console.WriteLine($"dima new dep = {dima.deposit[0].Remains}");
        Console.WriteLine($"Anton remain is {anton.deposit[0].Remains} and Dima's ID = {dima.ID}");
        Console.WriteLine($"general payment summ for dima = {tink.GeneralPayment(dima)}");
        //journal.PrintJournal();



    }
}


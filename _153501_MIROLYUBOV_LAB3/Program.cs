using _153501_MIROLYUBOV_LAB3;

class Programm
{
    public static void Main()
    {
        Banks tinkoff = new Banks();
        Journal journal = new Journal();
        tinkoff.Change += journal.TakeNewNote;
        tinkoff.Registration += (string message) => Console.WriteLine(message);
        Client anton = new Client("Anton", 300, 12, "smallProcent");
        Client vasya = new Client("Vasiliy", 2300, 62, "middleProcent");
        Client petya = new Client("Petr", 3003, 92, "highProcent");
        tinkoff.AddClient(petya);
        tinkoff.AddClient(vasya);
        tinkoff.AddClient(anton);
        
        Console.WriteLine($"General bank deposit {tinkoff.GetGeneralBankDeposit()}" );
        Console.WriteLine($"General bank percent {tinkoff.GetGeneralPercent()}");
        Console.WriteLine($"Name client with highest deposit is {tinkoff.GetVipClient()}");
        Console.WriteLine($"Count Clients Who Pay More Summ {tinkoff.CountClientsWhoPayMoreConsSumm(2000)}");

        Console.WriteLine($"List remains each client");
        tinkoff.CummonClientProcentGroup().ForEach(Console.WriteLine);

    }

}

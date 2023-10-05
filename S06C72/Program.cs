namespace S06C72;

using System.Globalization;

internal static class Program
{
    private const short AVAILABLE_ROMS = 10;

    private static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Renter[] renters = new Renter[AVAILABLE_ROMS];

        short numberOfRooms = RequestNumberOfRooms();

        for (short index = 0; index < numberOfRooms; index++)
        {
            Console.WriteLine($"\nAluguel #{index + 1}");

            Console.Write("Nome: ");
            string name = Console.ReadLine()!;

            Console.Write("Email: ");
            string email = Console.ReadLine()!;

            short roomNumber = RequestRoom(renters);

            renters[roomNumber] = new Renter { Name = name, Email = email };
        }

        Console.WriteLine("\nQuartos ocupados:\n");
        for (short index = 0; index < renters.Length; index++)
        {
            if (renters[index] != null)
            {
                Console.WriteLine($"{index}: {renters[index]}");
            }
        }
    }

    private static short RequestNumberOfRooms()
    {
        Console.Write("Quantos quartos serão alugados? ");
        short numberOfRooms = short.Parse(Console.ReadLine()!);

        while (numberOfRooms <= 0 || numberOfRooms > AVAILABLE_ROMS)
        {
            Console.WriteLine($"A quantidade de quartos requisitados '{numberOfRooms}' é inválida!");
            Console.Write($"Quantidade disponível: {AVAILABLE_ROMS}. Escolha novamente: ");
            numberOfRooms = short.Parse(Console.ReadLine()!);
        }

        return numberOfRooms;
    }

    private static short RequestRoom(Renter[] renters)
    {
        List<short> availableRoomsList = new();

        for (short index = 0; index < renters.Length; index++)
        {
            if (renters[index] == null)
            {
                availableRoomsList.Add(index);
            }
        }

        string availabeRooms = String.Join(", ", availableRoomsList);

        Console.Write("Quarto: ");
        short roomNumber = short.Parse(Console.ReadLine()!);

        /// while (roomNumber < 0 || roomNumber >= renters.Length || renters[roomNumber] != null)
        while (!availableRoomsList.Contains(roomNumber))
        {
            Console.WriteLine($"O quarto '{roomNumber}' é inválido ou já está ocupado!");
            Console.Write($"Quartos disponíveis: {availabeRooms}. Escolha um quarto: ");
            roomNumber = short.Parse(Console.ReadLine()!);
        }

        return roomNumber;
    }
}
// I DO NOT KNOW WHAT I AM DOING PLEASE HELP
// Sorry Zach :(

Hotel.RegisterClient("Garfield");
LoyaltyProgramClient DoubleGarfield = Hotel.RegisterClient("Garfield", 200);

Client Heathcliffe = new LoyaltyProgramClient(200, "Heathcliffe");
Client Odie = new Client("Odie");

Console.WriteLine(Odie.SayHello());
Console.WriteLine(Heathcliffe.SayHello());

Room room101 = new Room(101);
Room room102 = new Room(102);
Room room103 = new Room(103);
Room suite105 = new Suite(105, 3);

Hotel.Rooms.Add(suite105);

Hotel.ShowSuites();
static class Hotel
{
    public static HashSet<Client> Clients { get; set; } = new HashSet<Client>();
    public static HashSet<Room> Rooms { get; set; } = new HashSet<Room>();
    public static HashSet<Reservation> Reservations { get; set; } = new HashSet<Reservation>();
    public static Client RegisterClient(string name)
    {
        Client newClient = new Client(name);
        Clients.Add(newClient);
        return newClient;
    }

    public static LoyaltyProgramClient RegisterClient(string name, int points)
    {
        return new LoyaltyProgramClient(points, name);
    }

    public static void ShowSuites()
    {
        foreach (Room r in Rooms)
        {
            if (r.GetType().FullName == "Suite")
            {
                Console.WriteLine($"{r.Number} is a suite");
            }
        }
    }
}

class Reservation
{
    public bool IsCurrent { get; set; } = true;
    public Client Client { get; set; }
    public Room Room { get; set; }
    public Reservation(Client Client, Room room)
    {
        Client = Client;
        Room = room;
    }
}

class Client
{
    public string Name { get; set; }
    public HashSet<Reservation> Reservations { get; set; }

    public virtual string SayHello()
    {
        return $"Hello, my name is {Name}";
    }
    public Client(string name)
    {
        Name = name;
        Reservations = new HashSet<Reservation>();
    }
}

class LoyaltyProgramClient : Client
{
    public override string SayHello()
    {
        string message = base.SayHello();
        message += ($". I have {Points} points");
        return message;
    }
    public int Points { get; set; }
    public LoyaltyProgramClient(int initialPoints, string name) : base(name)
    {
        Points = initialPoints;
    }
}

class Room
{
    public int Number { get; set; }
    public ICollection<Reservation> Reservations { get; set; }

    public Room(int number)
    {
        Number = number;
        Reservations = new HashSet<Reservation>();
    }
}

class Suite : Room
{
    public int Size { get; set; }
    public Suite(int number, int size) : base(number)
    {
        Size = size;
    }
}
// I DO NOT KNOW WHAT I AM DOING
// Sorry Zach :(

Client Mark = new Client("Mark");
Client John = new Client("John");
Client Harry = new Client("Harry");
Hotel.Clients.Add(Mark);
Hotel.Clients.Add(John);
Hotel.Clients.Add(Harry);

Console.WriteLine(Hotel.GetClient(1));
Console.WriteLine(Hotel.GetVacantRooms());

Room room101 = new Room("101", 2);
Room room102 = new Room("102", 2);
Room room103 = new Room("103", 2);
Hotel.Rooms.Add(room101);
Hotel.Rooms.Add(room102);
Hotel.Rooms.Add(room103);



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

    // Lab 1 Methods
    public static Client GetClient(int clientID)
    {
        Client client;
        client = Clients.First(id => id.ClientID == clientID);
        return client;
    }

    public static Reservation GetReservation(int ID)
    {
        Reservation reservation;
        reservation = Reservations.First(id => id.ReservationId == ID);
        return reservation;

    }

    public static Room GetRoom(string roomNumber)
    {
        Room room;
        room = Rooms.First(number => number.Number == roomNumber);
        return room;

    }

    public static List<Room> GetVacantRooms()
    {
        List<Room> rooms = new List<Room>();
        foreach (Room r in Rooms)
        {
            if (!r.Occupied)
            {
                rooms.Add(r);
            }
        }
        return rooms;

    }

    public static List<Client> TopThreeClients()
    {
        List<Client> clients = new List<Client>();
        foreach (Client c in Clients)
        {
            int initalCount = 0;
            int reserveCounter = c.Reservations.Count;
            if (reserveCounter > initalCount)
            {
                clients.Add(c);
            }
        }

        return clients;

    }

    public static Reservation AutomaticReservation(int clientID, int occupants)
    {
        Reservation reservation = new Reservation();
        foreach (Room r in Rooms)
        {
            if (r.Capacity >= occupants && r.Occupied == false)
            {
                return reservation;
            }
        }
        return reservation;
    }
}

class Reservation
{
    public int ReservationId { get; set; }
    public DateTime Date { get; set; }
    public int Occupants { get; set; }
    public bool IsCurrent { get; set; }
    public Client Client { get; set; }
    public Room Room { get; set; }


    // CONSTRUCTORS
    public Reservation() { }
    public Reservation(int occupants, Client client, Room room)
    {
        Date = DateTime.Now;
        Occupants = occupants;
        IsCurrent = true;
        Client = client;
        Room = room;
    }
}

class Client
{
    public int ClientID { get; set; } = 1;
    public string Name { get; set; }
    public int CreditCard { get; set; }
    public List<Reservation> Reservations { get; set; }

    public Client()
    {
        ClientID = ClientID++;
        Reservations = new List<Reservation>();
    }

    public Client(string name)
    {
        Name = name;
        ClientID = ClientID++;
        Reservations = new List<Reservation>();
    }

    public Client(string name, int creditCard)
    {
        Name = name;
        ClientID = ClientID++;
        CreditCard = creditCard;
        Reservations = new List<Reservation>();
    }
}

class Room
{
    public string Number { get; set; }
    public int Capacity { get; set; }
    public bool Occupied { get; set; }
    public List<Reservation> Reservations { get; set; }

    public Room()
    {
        Reservations = new List<Reservation>();
    }

    public Room(string number, int capacity)
    {
        Number = number;
        Capacity = capacity;
        Occupied = false;
        Reservations = new List<Reservation>();
    }
}
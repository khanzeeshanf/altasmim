using System;

namespace BobTheBuilderCartoonTheme
{
    // Product class
    public class House
    {
        public int Rooms { get; set; }
        public int Bathrooms { get; set; }
        public bool Kitchen { get; set; }
        public bool DiningRoom { get; set; }
        public bool SwimmingPool { get; set; }
        public bool Garden { get; set; }

        public void ShowHouse()
        {
            Console.WriteLine("House Details:");
            Console.WriteLine($"Rooms: {Rooms}");
            Console.WriteLine($"Bathrooms: {Bathrooms}");
            Console.WriteLine($"Kitchen: {Kitchen}");
            Console.WriteLine($"Dining Room: {DiningRoom}");
            Console.WriteLine($"Swimming Pool: {SwimmingPool}");
            Console.WriteLine($"Garden: {Garden}");
        }
    }

    // Builder interface
    public interface IHouseBuilder
    {
        void BuildRooms(int number);
        void BuildBathrooms(int number);
        void BuildKitchen(bool hasKitchen);
        void BuildDiningRoom(bool hasDiningRoom);
        void BuildSwimmingPool(bool hasSwimmingPool);
        void BuildGarden(bool hasGarden);
        House GetHouse();
    }

    // Concrete Builder
    public class HouseBuilder : IHouseBuilder
    {
        private House _house = new House();

        public void BuildRooms(int number)
        {
            _house.Rooms = number;
        }

        public void BuildBathrooms(int number)
        {
            _house.Bathrooms = number;
        }

        public void BuildKitchen(bool hasKitchen)
        {
            _house.Kitchen = hasKitchen;
        }

        public void BuildDiningRoom(bool hasDiningRoom)
        {
            _house.DiningRoom = hasDiningRoom;
        }

        public void BuildSwimmingPool(bool hasSwimmingPool)
        {
            _house.SwimmingPool = hasSwimmingPool;
        }

        public void BuildGarden(bool hasGarden)
        {
            _house.Garden = hasGarden;
        }

        public House GetHouse()
        {
            return _house;
        }
    }

    // Director class
    public class BobTheBuilder
    {
        private IHouseBuilder _houseBuilder;

        public BobTheBuilder(IHouseBuilder houseBuilder)
        {
            _houseBuilder = houseBuilder;
        }

        public void ConstructHouse(int rooms, int bathrooms, bool kitchen, bool diningRoom, bool swimmingPool, bool garden)
        {
            _houseBuilder.BuildRooms(rooms);
            _houseBuilder.BuildBathrooms(bathrooms);
            _houseBuilder.BuildKitchen(kitchen);
            _houseBuilder.BuildDiningRoom(diningRoom);
            _houseBuilder.BuildSwimmingPool(swimmingPool);
            _houseBuilder.BuildGarden(garden);
        }

        public House GetHouse()
        {
            return _houseBuilder.GetHouse();
        }
    }

    // Client code
    class Program
    {
        static void Main(string[] args)
        {
            IHouseBuilder builder = new HouseBuilder();
            BobTheBuilder bob = new BobTheBuilder(builder);

            bob.ConstructHouse(3, 2, true, true, false, true);
            House house = bob.GetHouse();
            house.ShowHouse();
        }
    }
}
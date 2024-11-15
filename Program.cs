namespace Iterator_Example
{
    class Car
    {
        public string Model { get; set; }
        public string Brand { get; set; }
    }

    class CarCollection
    {
        private List<Car> cars = new List<Car>();

        public void AddCar(Car car)
        {
            cars.Add(car);
        }

        public IIterator CreateIterator()
        {
            return new CarIterator(this);
        }

        public int Count
        {
            get { return cars.Count; }
        }

        public Car GetCar(int index)
        {
            return cars[index];
        }
    }

    interface IIterator
    {
        bool HasNext();
        Car Next();
    }

    class CarIterator : IIterator
    {
        private CarCollection collection;
        private int index;

        public CarIterator(CarCollection collection)
        {
            this.collection = collection;
            this.index = 0;
        }

        public bool HasNext()
        {
            return index < collection.Count;
        }

        public Car Next()
        {
            Car car = collection.GetCar(index);
            index++;
            return car;
        }
    }
    class Program
    {
        static void Main()
        {
            CarCollection carCollection = new CarCollection();

            carCollection.AddCar(new Car { Brand = "Honda", Model = "Civic" });
            carCollection.AddCar(new Car { Brand = "Toyota", Model = "Prius" });
            carCollection.AddCar(new Car { Brand = "Volkswagen", Model = "Golf" });

            IIterator iterator = carCollection.CreateIterator();

            while (iterator.HasNext())
            {
                Car car = iterator.Next();
                Console.WriteLine("Brand: " + car.Brand + ", Model: " + car.Model);
            }
        }
    }
}

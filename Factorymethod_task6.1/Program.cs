using System;

namespace FactoryMethodExample
{
    public interface ITransport
    {
        void Deliver();
    }

    public class Car : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("Доставка пасажирів автомобілем по місту.");
        }
    }

    public class Truck : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("Доставка великого вантажу вантажівкою по трасі.");
        }
    }

    public class Bicycle : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("Швидка доставка їжі велосипедом через затори.");
        }
    }

    public abstract class TransportFactory
    {
        public abstract ITransport CreateTransport();
    }

    public class CarFactory : TransportFactory
    {
        public override ITransport CreateTransport()
        {
            return new Car();
        }
    }

    public class TruckFactory : TransportFactory
    {
        public override ITransport CreateTransport()
        {
            return new Truck();
        }
    }

    public class BicycleFactory : TransportFactory
    {
        public override ITransport CreateTransport()
        {
            return new Bicycle();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            TransportFactory carFactory = new CarFactory();
            ITransport car = carFactory.CreateTransport();
            car.Deliver();

            TransportFactory truckFactory = new TruckFactory();
            ITransport truck = truckFactory.CreateTransport();
            truck.Deliver();

            TransportFactory bikeFactory = new BicycleFactory();
            ITransport bike = bikeFactory.CreateTransport();
            bike.Deliver();

            Console.ReadKey();
        }
    }
}
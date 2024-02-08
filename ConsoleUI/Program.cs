using Business.Concrete;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI;

public class Program
{
    static void Main(string[] args)
    {
        CarManager carManager = new CarManager(new InMemoryCarDal());

        foreach (var car in carManager.GetAll()) 
        {
            Console.WriteLine(car.Description);
        }

        foreach (var cars in carManager.GetById(3))
        {
            Console.WriteLine(cars.DailyPrice);
        }
    }
}

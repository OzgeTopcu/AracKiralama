using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI;

public class Program
{
    static void Main(string[] args)
    {
        CarTest();

    }

    private static void CarTest()
    {
        CarManager carManager = new CarManager(new EfCarDal());

        var result = carManager.GetCarDetails();
        if (result.Success)
        {
            foreach (var product in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(product.ModelYear + "/" + product.DailyPrice);
            }

        }
        else
        {
            Console.WriteLine(result.Message);
        }
    }
}

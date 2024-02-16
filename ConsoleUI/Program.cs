using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI;

public class Program
{
    public static void Main(string[] args)
    {
        ICarService carManager = new CarManager(new EfCarDal());
        ICustomerService customerManager = new CustomerManager(new EfCustomerDal());
        IUserService userManager = new UserManager(new EfUserDal());
        IRentalService rentalManager = new RentalManager(new EfRentalDal());
        //AddDeleteTest(carManager);
        //GetCarDetailsTest(carManager);
        //GetCarDetailsTest(carManager);
        //CustomerTest(customerManager)
        //UserTest(userManager);
        //customerManager.Add(new Customer {UserId = 1,CompanyName = "Microsoft"});
        //RentalTest(rentalManager);




    }

    private static void RentalTest(IRentalService rentalManager)
    {
        foreach (var rental in rentalManager.GetAll().Data)
        {
            Console.WriteLine(rental.CarId + " " + rental.CustomerId);
        }
    }

    private static void UserTest(IUserService userManager)
    {
        userManager.Add(new User { Id = 1, FirstName = "Ali", LastName = "Yılmaz", Email = "aliyilmaz@hotmail.com", Password = "123123123" });
        foreach (var user in userManager.GetAll().Data)
        {
            Console.WriteLine(user.FirstName + " " + user.LastName);
        }
    }

    private static void CustomerTest(ICustomerService customerManager)
    {
        foreach (var customer in customerManager.GetAll().Data)
        {
            Console.WriteLine(customer.CompanyName);
        }
    }

    private static void GetCarDetailsTest(ICarService carManager)
    {
        var result = carManager.GetCarDetails();

        foreach (var car in result.Data)
        {
            Console.WriteLine(car.CarName + " | " + car.ColorName + " | " + car.BrandName + " | " + car.DailyPrice);
            Console.WriteLine(result.Message);
        }
    }

    private static void AddDeleteTest(ICarService carManager)
    {
        carManager.Add(new Car { Id = 6, BrandId = 2, ColorId = 2, DailyPrice = 500, ModelYear = 2018, Description = "Wolkswagen passat" });
        GetCarsTest(carManager);
        Console.WriteLine("----------------");
        carManager.Delete(6);
        GetCarsTest(carManager);
    }

    private static void GetCarsTest(ICarService carManager)
    {
        var result = carManager.GetCarDetails();

        int i = 1;
        foreach (var car in result.Data)
        {
            Console.WriteLine($"CAR {i}");
            Console.WriteLine(car.CarName);
            Console.WriteLine(car.ColorName);
            Console.WriteLine(car.DailyPrice);
            Console.WriteLine("----------");
            i++;
        }
    }
}

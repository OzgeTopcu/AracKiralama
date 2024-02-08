﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI;

public class Program
{
    static void Main(string[] args)
    {
        CarManager carManager = new CarManager(new EfCarDal());

        foreach (var car in carManager.GetAll()) 
        {
            Console.WriteLine(car.ModelYear);
        }

    
    }
}

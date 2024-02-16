using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,CarRentalContext>,ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Car
                             join b in context.Brand
                             on c.BrandId equals b.BrandId
                             join clr in context.Color
                             on c.ColorId equals clr.ColorId
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 ColorName=clr.ColorName,
                                 BrandName = b.BrandName,
                                 Description=c.Description,
                                 DailyPrice = c.DailyPrice,
                                 
                              
                             };
                return result.ToList();
            }
        }
    }
}

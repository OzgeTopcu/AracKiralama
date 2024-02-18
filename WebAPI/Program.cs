using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;


namespace apý
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<ICarService, CarManager>();
            builder.Services.AddSingleton<ICarDal,EfCarDal>();
            builder.Services.AddSingleton<ICustomerService, CustomerManager>();
            builder.Services.AddSingleton<ICustomerDal,EfCustomerDal>();
            builder.Services.AddScoped<IBrandService, BrandManager>();
            builder.Services.AddScoped<IBrandDal, EfBrandDal>();
            builder.Services.AddScoped<IColorService, ColorManager>();
            builder.Services.AddScoped<IColorDal, EfColorDal>();
            builder.Services.AddScoped<IRentalService, RentalManager>();
            builder.Services.AddScoped<IRentalDal, EfRentalDal>();
            builder.Services.AddScoped<IUserService, UserManager>();
            builder.Services.AddScoped<IUserDal, EfUserDal>();




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

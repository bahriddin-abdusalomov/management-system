using Demo.Configurations;
using Microsoft.EntityFrameworkCore;
using Services.AutoMapper;
using Services.DataContext;
using Services.Interfaces;
using Services.Services;

namespace Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddDbContext<AppDbContext>(options => 
                options.UseNpgsql(builder.Configuration.GetConnectionString("Connect")));

             //builder.Services.AddAutoMapper(typeof(DemoProfile));

            builder.Services.AddTransient<ICompanyRepository,CompanyRepository>();
            builder.Services.AddTransient<IEmplyeeRepository,EmplyeeRepository>();
            builder.Services.AddTransient<IStaffRepository,StaffRepository>();

            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            //app.Run(async (contexts) =>
            //{
            //    name += "a";
            //    await contexts.Response.WriteAsync("This is not Found Page bro !" + name);
            //});


            app.Run();
        }
    }
}
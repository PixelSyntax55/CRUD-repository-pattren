using Microsoft.AspNetCore.OpenApi;
using lastoneapi.Data;
using lastoneapi.studu;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using lastoneapi.School.Repositories;

namespace pushpushpush
{
    public class Program
    {
        public static void Main(string[] args)
        {



            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressInferBindingSourcesForParameters = true;
    });

            builder.Services.AddDbContext<DataBase>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            

            builder.Services.AddScoped<IRepositoryPattern, RepositoryImplementation>();

            
            builder.Services.AddEndpointsApiExplorer();


            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
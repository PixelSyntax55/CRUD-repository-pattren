using lastoneapi.Data;
using lastoneapi.repo;
using lastoneapi.studu;
using Microsoft.EntityFrameworkCore;

namespace pushpushpush
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.PropertyNamingPolicy = null)
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressInferBindingSourcesForParameters = true;
    });

            builder.Services.AddDbContext<DataBase>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            
            builder.Services.AddScoped<IRepositoryPattern, RepositoryImplementation>();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddOpenApi();

            var app = builder.Build();

            app.MapOpenApi();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
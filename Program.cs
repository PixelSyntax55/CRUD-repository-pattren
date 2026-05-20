using lastoneapi.Data;
using lastoneapi.repo;
using lastoneapi.studu;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;


namespace pushpushpush
{

    public class program
    {
        public static void Main(string[] args)
        {
            var gogo = WebApplication.CreateBuilder(args);

            gogo.Services.AddControllers();

            gogo.Services.AddDbContext<Db>(options => options.UseSqlServer(gogo.Configuration.GetConnectionString("Defualt Conection")));

            var popo = gogo.Build();

            popo.UseHttpsRedirection();

            popo.UseAuthorization();

            popo.MapControllers();

            popo.Run();
        }
    }
}
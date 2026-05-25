using Microsoft.EntityFrameworkCore;

using lastoneapi.studu;

namespace lastoneapi.Data
    {
        public class DataBase : DbContext

        {
            public DataBase(DbContextOptions<DataBase> options) : base(options) { }

            public DbSet<Student> students { get; set; }

        }

    }

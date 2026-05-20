using Microsoft.EntityFrameworkCore;

using lastoneapi.studu;

namespace lastoneapi.Data
    {
        public class Db : DbContext

        {
            public Db(DbContextOptions<Db> options) : base(options) { }

            public DbSet<input> input { get; set; }

        }

    }

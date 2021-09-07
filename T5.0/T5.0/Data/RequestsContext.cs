using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T5._0.Data
{
    public class RequestsContext : DbContext
    {
        public RequestsContext(DbContextOptions<RequestsContext> options)
            : base(options)
        {
        }

        public DbSet<T5._0.Models.Request> Request { get; set; }
    }
}

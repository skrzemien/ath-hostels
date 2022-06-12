using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ath_hostels.Models;

namespace ath_hostels.Data
{
    public class ath_hostelsContext : DbContext
    {
        public ath_hostelsContext (DbContextOptions<ath_hostelsContext> options)
            : base(options)
        {
        }

        public DbSet<ath_hostels.Models.Hostel>? Hostel { get; set; }

        public DbSet<ath_hostels.Models.Room>? Room { get; set; }
    }
}

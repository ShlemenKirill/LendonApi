using LendonApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LendonApi
{
    public class HotelApiDbContext : DbContext
    {
        public DbSet<RoomEntity> Rooms { get; set; }
        public HotelApiDbContext(DbContextOptions options) : base(options)
        { }
           
    }
    
}

using Microsoft.EntityFrameworkCore;
using webHome_HomeAPI.Models;

namespace webHome_HomeAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Home> Homes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Home>().HasData(
                new Home()
                {
                    Id = 1,
                    Name = "Home 1",
                    Details = "Et egestas quis ipsum suspendisse ultrices. Volutpat est velit egestas dui id ornare arcu.",
                    ImageUrl = "https://images.pexels.com/photos/106399/pexels-photo-106399.jpeg",
                    Occupancy = 5,
                    Rate = 200,
                    Sqft = 550,
                    Amenity = "",
                    CreatedDate = DateTime.Now,
                },
                new Home()
                {
                    Id = 2,
                    Name = "Home 2",
                    Details = "Et egestas quis ipsum suspendisse ultrices. Volutpat est velit egestas dui id ornare arcu.",
                    ImageUrl = "https://images.pexels.com/photos/276724/pexels-photo-276724.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    Occupancy = 3,
                    Rate = 240,
                    Sqft = 350,
                    Amenity = "",
                    CreatedDate = DateTime.Now,
                },
                new Home()
                {
                    Id = 3,
                    Name = "Home 3",
                    Details = "Et egestas quis ipsum suspendisse ultrices. Volutpat est velit egestas dui id ornare arcu.",
                    ImageUrl = "https://images.pexels.com/photos/259588/pexels-photo-259588.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    Occupancy = 1,
                    Rate = 500,
                    Sqft = 120,
                    Amenity = "",
                    CreatedDate = DateTime.Now,
                },
                new Home()
                {
                    Id = 4,
                    Name = "Home 4",
                    Details = "Et egestas quis ipsum suspendisse ultrices. Volutpat est velit egestas dui id ornare arcu.",
                    ImageUrl = "https://images.pexels.com/photos/2102587/pexels-photo-2102587.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    Occupancy = 10,
                    Rate = 50,
                    Sqft = 120,
                    Amenity = "",
                    CreatedDate = DateTime.Now,
                },
                new Home()
                {
                    Id = 5,
                    Name = "Home 5",
                    Details = "Et egestas quis ipsum suspendisse ultrices. Volutpat est velit egestas dui id ornare arcu.",
                    ImageUrl = "https://images.pexels.com/photos/323780/pexels-photo-323780.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    Occupancy = 2,
                    Rate = 500,
                    Sqft = 240,
                    Amenity = "",
                    CreatedDate = DateTime.Now,
                }
                );
        }
    }
}

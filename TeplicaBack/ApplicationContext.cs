using Microsoft.EntityFrameworkCore;
using TeplicaBack.Models;

namespace TeplicaBack
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<ControllerModel> Controllers { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData
                (
                    new User("qwe", "rty"),
                    new User("asd", "fgh")
                );
            modelBuilder.Entity<ControllerModel>().HasData
                (
                    new ControllerModel(10,"Temperature"),
                    new ControllerModel(20,"Illumination"),
                    new ControllerModel(30, "Moisture"),
                    new ControllerModel(40,"Illumination"),
                    new ControllerModel(120, "Moisture"),
                    new ControllerModel(40, "Illumination"),
                    new ControllerModel(4320, "Moisture"),
                    new ControllerModel(40, "Illumination"),
                    new ControllerModel(4320, "Moisture"),
                    new ControllerModel(40, "Illumination"),
                    new ControllerModel(430, "Moisture"),
                    new ControllerModel(40, "Illumination"),
                    new ControllerModel(440, "Illumination"),
                    new ControllerModel(40, "Temperature"),
                    new ControllerModel(450, "Temperature"),
                    new ControllerModel(410, "Temperature"),
                    new ControllerModel(460, "Moisture"),
                    new ControllerModel(40, "Illumination"),
                    new ControllerModel(440, "Moisture"),
                    new ControllerModel(40, "Illumination"),
                    new ControllerModel(410, "Moisture"),
                    new ControllerModel(40, "Illumination"),
                    new ControllerModel(4230, "Illumination"),
                    new ControllerModel(40, "Illumination"),
                    new ControllerModel(440, "Illumination"),
                    new ControllerModel(420, "Temperature")
                );
        }
    }
}

using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TruckApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public bool? DarkTheme { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<LoadConfirmation> LoadConfirmations { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<HazMatStatus> HazMatStatuses { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<PriorityDelivery> PriorityDeliveries { get; set; }
        public DbSet<PriorityEntry> PriorityEntries { get; set; }
        public DbSet<Dispatch> Dispatches { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Stop> Stops { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Leg> Legs { get; set; }
        public DbSet<UserAction> UserActions { get; set; }



        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
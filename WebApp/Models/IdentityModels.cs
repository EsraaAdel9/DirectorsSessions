using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication1.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
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
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<WebApp.Models.NewSession> NewSessions { get; set; }

        public System.Data.Entity.DbSet<WebApp.Models.SessionSubjects> SessionSubjects { get; set; }

        public System.Data.Entity.DbSet<WebApp.Models.MemoTypes> MemoTypes { get; set; }

        public System.Data.Entity.DbSet<WebApp.ViewModel.MemoViewModel> MemoViewModels { get; set; }

        public System.Data.Entity.DbSet<WebApp.Models.SessionReport> SessionReports { get; set; }

        public System.Data.Entity.DbSet<WebApp.Models.SessionSchedule> SessionSchedules { get; set; }

        public System.Data.Entity.DbSet<WebApp.Models.SessionInstructions> SessionInstructions { get; set; }
    }
}
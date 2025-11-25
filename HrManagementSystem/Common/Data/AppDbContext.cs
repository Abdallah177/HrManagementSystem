using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common.Entities.FeatureSope;
using HrManagementSystem.Common.Entities.Location;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Common.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Break> Breaks { get; set; }
        public DbSet<Disability> Disability { get; set; }
        public DbSet<OverTime> OverTime { get; set; }
        public DbSet<Probation> Probations { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Vacation> Vacations { get; set; }

        public DbSet<ScopeBase> Scopes { get; set; }

        public DbSet<BreakScope> BreakScope { get; set; }
        public DbSet<DisabilityScope> DisabilityScope { get; set; }
        public DbSet<OverTimeScope> OverTimeScopes { get; set; }
        public DbSet<ProbationScope> ProbationScopes { get; set; }
        public DbSet<RequestScope> RequestScopes { get; set; }
        public DbSet<ShiftScope> ShiftScopes { get; set; }
        public DbSet<VacationScope> VacationScopes { get; set; }
        public DbSet<PublicHoliday> PublicHolidays { get; set; }







    }
}

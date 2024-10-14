using IMF.DAL.Configuration;
using IMF.DAL.Identity;
using IMF.DAL.Models.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Http;
using IMF.DAL.Models.HR;
using System.Reflection.Emit;

namespace IMF.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DbSet<Company> Company { get; set; }
        public DbSet<Documents> Documents { get; set; }
        public DbSet<PayScale> PayScale { get; set; }
        public DbSet<Designation> Designation { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<JobHistory> JobHistory { get; set; }

        public ApplicationDbContext() { }
        public ApplicationDbContext(IHttpContextAccessor httpContextAccessor, DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(CompanyConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(EmployeeConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(DocumentsConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(PayScaleConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(DesignationConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(DepartmentConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(JobHistoryConfiguration).Assembly);

            //builder.Entity<Department>().HasData(
            //    new Department { Id = 1, DepartmentName = "Finance", DisplayOrder = 1 },
            //    new Department { Id = 2, DepartmentName = "HR", DisplayOrder = 2 },
            //    new Department { Id = 3, DepartmentName = "Procurement", DisplayOrder = 3 },
            //    new Department { Id = 4, DepartmentName = "IT", DisplayOrder = 4 }
            //    );

            //builder.Entity<Designation>().HasData(
            //    new Designation { Id = 1, DesignationName = "CEO", DisplayOrder = 1 },
            //    new Designation { Id = 2, DesignationName = "Manager", DisplayOrder = 2 },
            //    new Designation { Id = 3, DesignationName = "Assistant Manager", DisplayOrder = 3 },
            //    new Designation { Id = 4, DesignationName = "Office Assistant", DisplayOrder = 4 }
            //    );
        }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddTimestamps();
            return await base.SaveChangesAsync();
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is AuditableBaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((AuditableBaseEntity)entity.Entity).CreatedOn = DateTime.Now;
                    ((AuditableBaseEntity)entity.Entity).CreatedBy = _httpContextAccessor.HttpContext.User.Identity.GetUserId();//HttpContext.Current.User.Identity.GetUserId();
                    ((AuditableBaseEntity)entity.Entity).IsActive = true;
                }
                else if (entity.State == EntityState.Modified)
                {
                    ((AuditableBaseEntity)entity.Entity).LastModified = DateTime.Now;
                    ((AuditableBaseEntity)entity.Entity).LastModifiedBy = _httpContextAccessor.HttpContext.User.Identity.GetUserId();//HttpContext.Current.User.Identity.GetUserId();
                }
            }
        }

    }
}


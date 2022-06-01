using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Simphonis.CvTheque.Candidates;

namespace Simphonis.CvTheque.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class CvThequeDbContext :
    AbpDbContext<CvThequeDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */
    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<Skill> Skills { get; set; }

    //We don't need to add 'CandidateSkills' because we access it through 'Candidates'.

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public CvThequeDbContext(DbContextOptions<CvThequeDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureIdentityServer();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();


        builder.Entity<Candidate>(c =>
        {
            c.ToTable(CvThequeConsts.DbTablePrefix + "Candidates", CvThequeConsts.DbSchema);
            c.ConfigureByConvention(); //auto configure for the base class props
            c.Property(x => x.Name).HasMaxLength(60).IsRequired();
            c.Property(x => x.LastName).HasMaxLength(60).IsRequired();
            c.Property(x => x.Email).HasMaxLength(100).IsRequired();
        });

        builder.Entity<Skill>(s =>
        {
            s.ToTable(CvThequeConsts.DbTablePrefix + "Skills", CvThequeConsts.DbSchema);
            s.ConfigureByConvention();
            s.Property(x => x.SkillName).HasMaxLength(70).IsRequired();
        });

       builder.Entity<CandidateSkill>(c =>
        {
            c.ToTable(CvThequeConsts.DbTablePrefix + "CandidateSkills", CvThequeConsts.DbSchema);
            c.ConfigureByConvention();
            c.HasKey(t => new { t.CandidateId, t.SkillId });

        });
        
    }
}

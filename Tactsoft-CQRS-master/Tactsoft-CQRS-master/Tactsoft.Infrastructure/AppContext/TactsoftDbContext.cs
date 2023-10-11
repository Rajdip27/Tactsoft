using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Reflection;
using Tactsoft.Domain.Base;
using Tactsoft.Domain.EntityLogs;
using Tactsoft.Infrastructure.Extensions;
using Tactsoft.Infrastructure.Healper.Acls;
using static Tactsoft.Domain.Identities.IdentityModel;

namespace Tactsoft.Infrastructure.AppContext;

public class TactsoftDbContext : IdentityDbContext<User, Role, long, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
{
    private readonly ISignInHelper SignInHelper;
    public TactsoftDbContext(DbContextOptions<TactsoftDbContext> options, ISignInHelper signInHelper) : base(options)
    {
        SignInHelper = signInHelper;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.RelationConvetion();
        modelBuilder.DateTimeConvention();
        modelBuilder.DecimalConvention();
        modelBuilder.PluralzseTableNameConventions();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.LogTo(Console.WriteLine);
        optionsBuilder.LogTo(message => WriteSqlQueryLog(message));
        optionsBuilder.UseLoggerFactory(new LoggerFactory(new[] { new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider() }));
    }

    public DbSet<AuditLog> AuditLogs { get; set; }

    private static void WriteSqlQueryLog(string query, StoreType storeType = StoreType.Output)
    {
        if (storeType == StoreType.Output)
            Debug.WriteLine(query);
        else if (storeType == StoreType.Db)
        {
            // store in db
        }
        else if (storeType == StoreType.File)
        {
            // store & append in file
            //new StreamWriter("mylog.txt", append: true);
        }

    }

    private void Audit()
    {
        long userId = 0;
        var now = DateTimeOffset.UtcNow;

        if (SignInHelper.IsAuthenticated)
            userId = (long)SignInHelper.UserId;

        foreach (var entry in base
            .ChangeTracker.Entries<BaseEntity>()
            .Where(e => e.State == EntityState.Added
                     || e.State == EntityState.Modified))
        {
            if (entry.State != EntityState.Added)
            {
                entry.Entity.UpdatedDate ??= now;
                entry.Entity.UpdatedBy ??= userId;
            }
            else
            {
                entry.Entity.CreatedBy = entry.Entity.CreatedBy != 0 ? entry.Entity.CreatedBy : userId;
                entry.Entity.CreatedDate = entry.Entity.CreatedDate == DateTimeOffset.MinValue ? now : entry.Entity.CreatedDate;
            }
        }
    }

    private void AuditTrail()
    {
        long userId = 0;

        if (SignInHelper.IsAuthenticated)
            userId = (long)SignInHelper.UserId;

        ChangeTracker.DetectChanges();
        var auditEntries = new List<AuditEntry>();
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.Entity is BaseEntity
                || entry.Entity is AuditLog
                || entry.State == EntityState.Detached
                || entry.State == EntityState.Unchanged)
                continue;

            var auditEntry = new AuditEntry(entry)
            {
                TableName = entry.Entity.GetType().Name,
                UserId = userId
            };
            auditEntries.Add(auditEntry);
            foreach (var property in entry.Properties)
            {
                string propertyName = property.Metadata.Name;
                if (property.Metadata.IsPrimaryKey())
                {
                    auditEntry.KeyValues[propertyName] = property.CurrentValue;
                    continue;
                }
                switch (entry.State)
                {
                    case EntityState.Added:
                        auditEntry.AuditType = AuditType.Create;
                        auditEntry.NewValues[propertyName] = property.CurrentValue;
                        break;
                    case EntityState.Deleted:
                        auditEntry.AuditType = AuditType.Delete;
                        auditEntry.OldValues[propertyName] = property.OriginalValue;
                        break;
                    case EntityState.Modified:
                        if (property.IsModified)
                        {
                            auditEntry.ChangedColumns.Add(propertyName);
                            auditEntry.AuditType = AuditType.Update;
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                        }
                        break;
                }
            }
        }
        foreach (var auditEntry in auditEntries)
        {
            AuditLogs.Add(auditEntry.ToAuditLog());
        }
    }


}

public enum StoreType
{
    Db,
    File,
    Output
}
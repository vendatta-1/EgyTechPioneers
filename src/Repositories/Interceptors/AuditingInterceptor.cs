using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Threading;
using System.Threading.Tasks;
using Common;
using Common.Services.Interfaces;

namespace Repository.Interceptors
{
    public class AuditSaveChangesInterceptor(ICurrentUserService currentUserService) : SaveChangesInterceptor
    {
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            ApplyAudit(eventData.Context);
            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            ApplyAudit(eventData.Context);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private void ApplyAudit(DbContext? context)
        {
            if (context == null) return;

            var entries = context.ChangeTracker.Entries<Entity>();
            var now = DateTime.UtcNow;
            var userId = _currentUserService.UserId;
            var userName = _currentUserService.UserName;

            foreach (var entry in entries)
            {
                //  Ensure identity/sequence columns are never updated to avoid any related errors
              

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreateDateTime = now;
                    entry.Entity.CreateUserId = userId;
                    entry.Entity.CreateUserName = userName;
                    entry.Entity.IsDeleted = false;
                    entry.Entity.IsNotActive = false;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.ModifiedDate = now;
                    entry.Entity.ModifiedBy = userName;
                }

                if (entry.State == EntityState.Deleted)
                { 
                    entry.State = EntityState.Modified;
                    entry.Entity.IsDeleted = true;
                    entry.Entity.DeletedDate = now;
                    entry.Entity.DeletedBy = userName;
                    entry.Entity.IsNotActive = true;
                }
                
                foreach (var prop in entry.Properties)
                {
                    if (prop.Metadata.ValueGenerated == ValueGenerated.OnAdd)
                    {
                        prop.IsModified = false;
                    }
                }
            }
        }
    }
}

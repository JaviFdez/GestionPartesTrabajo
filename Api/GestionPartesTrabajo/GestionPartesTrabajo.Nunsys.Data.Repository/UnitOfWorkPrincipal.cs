using NunsysCore.IT.Excepciones;
using GestionPartesTrabajo.Nunsys.Domain;
using System;
using System.Data.Entity;
using System.Linq;
using GestionPartesTrabajo.Nunsys.Data.Interfaces;

namespace GestionPartesTrabajo.Nunsys.Data.Repository
{
    public class UnitOfWorkPrincipal : DbContext, IUnitOfWorkPrincipal
    {
        public UnitOfWorkPrincipal() : base("name=AuthContext")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ObjectMapping<Customers>());
            modelBuilder.Configurations.Add(new ObjectMapping<Imputations>());
            modelBuilder.Configurations.Add(new ObjectMapping<Projects>());
            modelBuilder.Configurations.Add(new ObjectMapping<ProjectTasks>());
            modelBuilder.Configurations.Add(new ObjectMapping<Users>());
            modelBuilder.Configurations.Add(new ObjectMapping<WorkOrders>());

            // ------------------------------------------
            // CLAVES FORANEAS
            // NOTA: las claves siempre seran establecidas de 1 a * para evitar duplicados en otros modelos


            modelBuilder.Entity<Customers>()
                .HasMany(e => e.Projects)
                .WithRequired(e => e.Customers)
                .HasForeignKey(e => e.IdCustomer)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<Projects>()
                .HasMany(e => e.ProjectTasks)
                .WithRequired(e => e.Projects)
                .HasForeignKey(e => e.IdProyect)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<ProjectTasks>()
                .HasMany(e => e.Imputations)
                .WithRequired(e => e.ProjectTasks)
                .HasForeignKey(e => e.IdProjectTask)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProjectTasks>()
                .HasMany(e => e.WorkOrders)
                .WithRequired(e => e.ProjectTasks)
                .HasForeignKey(e => e.IdProjectTask)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<Users>()
                .HasMany(e => e.Imputations)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.IdUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.WorkOrders)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.IdUser)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<WorkOrders>()
                .HasMany(e => e.Imputations)
                .WithOptional(e => e.WorkOrders)
                .HasForeignKey(e => e.IdWorkOrder);

            // TODO: definir mas ...            

        }

        public IDbSet<TEntity> CreateSet<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public void Attach<TEntity>(TEntity item) where TEntity : class
        {
            base.Entry<TEntity>(item).State = EntityState.Unchanged;
        }

        public void SetModified<TEntity>(TEntity item) where TEntity : class
        {
            base.Entry<TEntity>(item).State = EntityState.Modified;
        }

        public void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : class
        {
            base.Entry<TEntity>(original).CurrentValues.SetValues(current);
        }

        public void Commit()
        {
            try
            {
                base.SaveChanges();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException)
            {
                throw new DatosErrorConcurrencia();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RollbackChanges()
        {
            base.ChangeTracker.Entries()
                              .ToList()
                              .ForEach(entry => entry.State = EntityState.Unchanged);
        }
    }
}

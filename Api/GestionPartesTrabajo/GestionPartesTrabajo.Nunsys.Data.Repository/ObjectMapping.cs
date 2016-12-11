using NunsysCore.Dominio;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GestionPartesTrabajo.Nunsys.Data.Repository
{
    internal class ObjectMapping<T> : EntityTypeConfiguration<T> where T : BaseEntity
    {

        public ObjectMapping()
        { }

        public ObjectMapping(string tableName)
        {
            Configure(tableName);
        }
        public ObjectMapping(string tableName, string columnName)
        {
            Configure(tableName, columnName);
        }

        protected void Configure(string tableName)
        {
            this.HasKey(t => t.Id);

            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.SisVersion)
                .IsRequired().IsConcurrencyToken().HasColumnType("timestamp").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            this.ToTable(tableName);
        }

        protected void Configure(string tableName, string columnName)
        {
            this.HasKey(t => t.Id);

            this.Property(t => t.Id)
                .HasColumnName(columnName)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.SisVersion)
                .IsRequired().IsConcurrencyToken().HasColumnType("timestamp").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            this.ToTable(tableName);
        }

    }
}

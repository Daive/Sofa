using System.Data.Entity;
using Ben.Entity;



namespace Ben.DAL
{
    public class SofaContext : DbContext
    {
        public SofaContext() : base("SofaContext") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> UserGroups { get; set; }
        public DbSet<UserConfig> UserConfigs { get; set; }
        public DbSet<UserRoleRelation> UserRoleRelations { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }
         //
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}
    }
}
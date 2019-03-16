using Microsoft.EntityFrameworkCore;
using Nop.Data;
using Nop.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nop.Plugin.Widgets.PromoSlider.Data
{
    public class PromoSliderObjectContext : DbContext, IDbContext
    {
        public PromoSliderObjectContext(DbContextOptions<PromoSliderObjectContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PromoSliderMap());
            modelBuilder.ApplyConfiguration(new PromoImageMap());
            base.OnModelCreating(modelBuilder);
        }

        public virtual string GenerateCreateScript()
        {
            return this.Database.GenerateCreateScript();
        }

        public void Install()
        {
            //create tables
            this.ExecuteSqlScript(this.GenerateCreateScript());
        }

        DbSet<TEntity> IDbContext.Set<TEntity>()
        {
            throw new NotImplementedException();
        }

        int IDbContext.SaveChanges()
        {
            throw new NotImplementedException();
        }

        string IDbContext.GenerateCreateScript()
        {
            throw new NotImplementedException();
        }

        IQueryable<TQuery> IDbContext.QueryFromSql<TQuery>(string sql)
        {
            throw new NotImplementedException();
        }

        IQueryable<TEntity> IDbContext.EntityFromSql<TEntity>(string sql, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        int IDbContext.ExecuteSqlCommand(RawSqlString sql, bool doNotEnsureTransaction, int? timeout, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        void IDbContext.Detach<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}

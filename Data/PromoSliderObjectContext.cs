using Microsoft.EntityFrameworkCore;
using Nop.Core;
using Nop.Data;
using Nop.Data.Extensions;
using Nop.Plugin.Widgets.PromoSlider.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nop.Plugin.Widgets.PromoSlider.Data
{
    public class PromoSliderObjectContext : DbContext, IDbContext
    {
        #region Ctor

        public PromoSliderObjectContext(DbContextOptions<PromoSliderObjectContext> options) : base(options)
        {

        }

        #endregion

        #region Utilities

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PromoSliderMap());
            modelBuilder.ApplyConfiguration(new PromoImageMap());
            base.OnModelCreating(modelBuilder);
        }

        #endregion

        #region Methods

        public virtual new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        public virtual string GenerateCreateScript()
        {
            return this.Database.GenerateCreateScript();
        }

        public virtual IQueryable<TQuery> QueryFromSql<TQuery>(string sql) where TQuery : class
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<TEntity> EntityFromSql<TEntity>(string sql, params object[] parameters) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }

        public virtual int ExecuteSqlCommand(RawSqlString sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters)
        {
            using (var transaction = this.Database.BeginTransaction())
            {
                var result = this.Database.ExecuteSqlCommand(sql, parameters);
                transaction.Commit();

                return result;
            }
        }

        public virtual void Detach<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }

        public void Install()
        {
            //create tables
            this.ExecuteSqlScript(this.GenerateCreateScript());
        }

        public void UnInstall()
        {
            //drop the table
            this.DropPluginTable(nameof(PromoImageRecord));
            this.DropPluginTable(nameof(PromoSliderRecord));
        }

        #endregion
    }
}

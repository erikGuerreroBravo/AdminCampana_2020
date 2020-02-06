using AdminCampana_2020.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminCampana_2020.Repository.Infraestructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RC2020Entities _dbContext;

        public UnitOfWork()
        {
            _dbContext = new RC2020Entities();
        }

        public DbContext Db
        {
            get { return _dbContext; }
        }

        public void Dispose()
        {
        }
    }
}

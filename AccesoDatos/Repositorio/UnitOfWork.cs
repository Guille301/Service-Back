using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Repositorio
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly LibreriaContext _context;
        private IDbContextTransaction _transaction;

        public UnitOfWork(LibreriaContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _transaction?.Commit();
            }
            finally
            {
                _transaction?.Dispose();
            }
        }

        public void Rollback()
        {
            try
            {
                _transaction?.Rollback();
            }
            finally
            {
                _transaction?.Dispose();
            }
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();

        }







    }
}

using Common.Interfaces;
using DAL.Context.EF;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly BECPContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(BECPContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
    }
}

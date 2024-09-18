using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager.Models;

namespace TaskManager.Repository
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly TaskMContext _context;
        public ITareaRepository TareaRepository { get; private set; }

        public UnitOfWork(TaskMContext context)
        {
            _context = context;
            TareaRepository = new TareaRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}
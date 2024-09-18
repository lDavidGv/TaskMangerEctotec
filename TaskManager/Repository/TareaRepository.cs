using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager.Models;

namespace TaskManager.Repository
{
    public class TareaRepository : Repository<Tareas>, ITareaRepository
    {
        public TareaRepository(TaskMContext context) : base(context)
        {
        }

        public Tareas Get(int id)
        {
            return Context.Set<Tareas>().Find(id);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;

namespace TaskManager.Repository
{
    interface ITareaRepository : IRepository<Tareas>
    {
        Tareas Get(int id);

    }
}

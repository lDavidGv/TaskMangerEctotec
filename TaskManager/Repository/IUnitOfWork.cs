﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Repository
{
    interface IUnitOfWork : IDisposable
    {
        ITareaRepository TareaRepository { get; }

        int Complete();


    }
}

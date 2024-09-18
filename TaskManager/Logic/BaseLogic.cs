using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager.Models;

namespace TaskManager.Logic
{
    public class BaseLogic
    {
        protected readonly TaskMContext _context;

        public BaseLogic()
        {
            _context = new TaskMContext();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.Common.Exceptions
{
    public class NotExistsException : Exception
    {
        public NotExistsException() : base("La Tarea que solicitó no existe. Intente con otro ID.")
        {

        }
    }
}
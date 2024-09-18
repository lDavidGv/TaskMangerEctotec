using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager.Logic;
using TaskManager.Models;

namespace TaskManager.Repository
{
    public class tareasLogic : BaseLogic
    {
        private UnitOfWork unitOfWork;

        public tareasLogic()
        {
            unitOfWork = new UnitOfWork(_context);
        }

        //Constructor for UnitTests with Moq
        public tareasLogic(TaskMContext context)
        {

        }

        public Tareas Get(int Id)
        {
            var customerFinded = unitOfWork.TareaRepository.Get(Id);
            return customerFinded;
        }

        public IEnumerable<Tareas> GetAll()
        {
            var customersList = unitOfWork.TareaRepository.GetAll();
            return customersList;
        }

        public void Add(Tareas tarea)
        {
            unitOfWork.TareaRepository.Add(tarea);
            unitOfWork.Complete();
        }

        public void Update(Tareas tarea)
        {
            var modifiedCustomer = Get(tarea.Id);
            modifiedCustomer.Titulo = tarea.Titulo;
            modifiedCustomer.Estado = tarea.Estado;
            modifiedCustomer.FechaCreacion = tarea.FechaCreacion;
            modifiedCustomer.Descripcion = tarea.Descripcion;

            unitOfWork.Complete();

        }

        public void Delete(Tareas tarea)
        {
            unitOfWork.TareaRepository.Delete(tarea);
            unitOfWork.Complete();
        }
    }
}
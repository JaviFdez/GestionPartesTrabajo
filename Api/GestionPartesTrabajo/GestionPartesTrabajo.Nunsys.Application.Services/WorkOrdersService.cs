using GestionPartesTrabajo.Nunsys.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionPartesTrabajo.Nunsys.Application.Adapters.Dto;
using GestionPartesTrabajo.Nunsys.Application.Adapters.Model;
using GestionPartesTrabajo.Nunsys.Data.Interfaces;
using AutoMapper;
using GestionPartesTrabajo.Nunsys.Domain;
using System.Data.Entity;

namespace GestionPartesTrabajo.Nunsys.Application.Services
{
    public class WorkOrdersService : IWorkOrdersService
    {
        
        private IWorkOrdersRepository _workOrdersRepository;

        public WorkOrdersService(IWorkOrdersRepository workOrdersRepository)
        {
            this._workOrdersRepository = workOrdersRepository;
        }

        public int countWorkOrders()
        {
            int countWorkOrder = _workOrdersRepository.countWorkOrders();
            return countWorkOrder;   
        }

        public WorkOrderDtoAmp deleterWorkOrder(int id)
        {
            var configDtoToEdm = new MapperConfiguration(cfg => cfg.CreateMap<WorkOrderDtoAmp, WorkOrders>()).CreateMapper();
            WorkOrderDtoAmp workOrderDto = null;
            WorkOrders workOrderEdm = _workOrdersRepository.GetFirstElementFiltered(item => item.Id == id);
            if (workOrderEdm != null && workOrderEdm.Imputations.Count == 0)
            {
                _workOrdersRepository.Remove(workOrderEdm);
            }

            workOrderEdm = configDtoToEdm.Map<WorkOrders>(workOrderDto);

            _workOrdersRepository.UnitOfWork.Commit();
            return workOrderDto;
        }

        public IList<WorkOrderDtoAmp> getPageWorkOrders(FiltrosWorkOrdersModel filtros, int sizePage, int actualPage)
        {
            IList<WorkOrderDtoAmp> resultado = _workOrdersRepository.getPageWorkOrders(filtros, sizePage, actualPage);
            return resultado;
        }

        public WorkOrderDtoAmp getWorkOrder(int id)
        {
            WorkOrderDtoAmp workOrder = _workOrdersRepository.getWorkOrder(id);
           
            return workOrder;
        }

        public IList<WorkOrderDtoAmp> getWorkOrders()
        {
            IList<WorkOrderDtoAmp> resultado = new List<WorkOrderDtoAmp>();
            IList<WorkOrders> workOders = _workOrdersRepository.GetAll();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<WorkOrders, WorkOrderDtoAmp>()).CreateMapper();

            foreach (WorkOrders workOder in workOders)
            {


                resultado.Add(config.Map<WorkOrderDtoAmp>(workOder));
            }

            resultado = config.Map<IList<WorkOrderDtoAmp>>(resultado);
            
            return resultado;
        }

        public WorkOrderDtoAmp saveWorkOrder(WorkOrderDtoAmp workOrder)
        {
            bool isNew = workOrder.Id == null;
            WorkOrders WorkOrderEdm = null;

            var configDtoToEdm = new MapperConfiguration(cfg => cfg.CreateMap<WorkOrderDtoAmp, WorkOrders>()).CreateMapper();
            var configEdmToDto = new MapperConfiguration(cfg => cfg.CreateMap<WorkOrders, WorkOrderDtoAmp>()).CreateMapper();
            
            if (isNew)
            {

                WorkOrderEdm = configDtoToEdm.Map<WorkOrders>(workOrder);
                this._workOrdersRepository.Add(WorkOrderEdm);
            }
            else
            {

                // opcion 1
                WorkOrderEdm = _workOrdersRepository.GetFirstElementFiltered(item => item.Id == workOrder.Id);
                WorkOrderEdm.OTCode = workOrder.OTCode;
                WorkOrderEdm.Description = workOrder.Description;
                WorkOrderEdm.IdProjectTask = workOrder.IdProjectTask;
                WorkOrderEdm.IdUser = workOrder.IdUser;
                WorkOrderEdm.PlannedDate = workOrder.PlannedDate;
                WorkOrderEdm.EstimatedDuration = workOrder.EstimatedDuration;
                WorkOrderEdm.RemainingDuration = workOrder.RemainingDuration;
                WorkOrderEdm.WorkOrderStatus = workOrder.WorkOrderStatus;

                /*
                //opcion 3
                 customerEdm = Mapper.Map<Customers>(customer);
                */


            }
            this._workOrdersRepository.UnitOfWork.Commit();
            workOrder = configEdmToDto.Map<WorkOrderDtoAmp>(WorkOrderEdm);
            return workOrder;
        }
    }
}

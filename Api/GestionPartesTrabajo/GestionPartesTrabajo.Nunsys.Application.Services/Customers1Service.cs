using GestionPartesTrabajo.Nunsys.Application.Adapters.Dto;

using GestionPartesTrabajo.Nunsys.Domain;
using GestionPartesTrabajo.Nunsys.Application.Interfaces;
using GestionPartesTrabajo.Nunsys.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GestionPartesTrabajo.Nunsys.Data.Repository;

namespace GestionPartesTrabajo.Nunsys.Application.Services
{
  public  class Customers1Service : ICustomers1Service
    {
        private ICustomers1Repository _customersRepository;

        public Customers1Service(ICustomers1Repository _customersRepository)
        {
            this._customersRepository = _customersRepository;
        }

        public int countCustomers()
        {
            int totalCustomers = _customersRepository.countCustomers();
            return totalCustomers;
        }

        public CustomerDto getCustomer(int id)
        {
            CustomerDto customer = null;
            Customers customerEdm = _customersRepository.GetFirstElementFiltered(item => item.Id == id);
            if (customerEdm != null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Customers, CustomerDto>()).CreateMapper();
                customer = config.Map<CustomerDto>(customerEdm); //mapear un objeto en otro
            }


            return customer;
        }


        public IList<CustomerDto> getCustomers(int sizePage, int actualPage)
        {
            IList<CustomerDto> resultado = _customersRepository.getPageCustomers(sizePage, actualPage);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Customers, CustomerDto>()).CreateMapper();
            
            return resultado;
        }

        public IList<CustomerDto> getCustomers()
        {
            IList<CustomerDto> resultado = new List<CustomerDto> ();
            IList<Customers> customers = _customersRepository.GetAll();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Customers, CustomerDto>()).CreateMapper();

            foreach (Customers customer in customers) {
   

                resultado.Add(config.Map<CustomerDto>(customer));
            }


            resultado = config.Map<IList<CustomerDto>>(resultado);



            return resultado;
        }

        public CustomerDto saveCustomer(CustomerDto customer)
        {
           bool isNew = customer.Id == null;
           Customers customerEdm = null;
         
           var configDtoToEdm = new MapperConfiguration(cfg => cfg.CreateMap<CustomerDto, Customers>()).CreateMapper();
           var configEdmToDto = new MapperConfiguration(cfg => cfg.CreateMap<Customers, CustomerDto>()).CreateMapper();
  


            if (isNew)
            {
                customerEdm = configDtoToEdm.Map<Customers>(customer);
                this._customersRepository.Add(customerEdm);

            } else
            {
                
                // opcion 1
                 customerEdm = _customersRepository.GetFirstElementFiltered(item => item.Id == customer.Id);
                customerEdm.Name = customer.Name;
                customerEdm.Number = customer.Number;

                /*
                //opcion 3
                 customerEdm = Mapper.Map<Customers>(customer);
     */
                

            }
            this._customersRepository.UnitOfWork.Commit();
            customer = configEdmToDto.Map<CustomerDto>(customerEdm);
            return customer;
            
        }

       
        public CustomerDto deleterCustomer(int id)
        {

            var configDtoToEdm = new MapperConfiguration(cfg => cfg.CreateMap<CustomerDto, Customers>()).CreateMapper();
            var configEdmToDto = new MapperConfiguration(cfg => cfg.CreateMap<Customers, CustomerDto>()).CreateMapper();
            CustomerDto customerDto = null;
            Customers customerEdm = _customersRepository.GetFirstElementFiltered(item => item.Id == id);
            if (customerEdm != null && customerEdm.Projects == null) {
                customerEdm = configDtoToEdm.Map<Customers>(customerDto);
            }
            _customersRepository.Remove(customerEdm);

            _customersRepository.UnitOfWork.Commit();
            return customerDto; 
        }
    }
}

using AutoMapper;
using GestionPartesTrabajo.Nunsys.Application.Adapters.Dto;
using GestionPartesTrabajo.Nunsys.Application.Interfaces;
using GestionPartesTrabajo.Nunsys.Data.Interfaces;
using GestionPartesTrabajo.Nunsys.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPartesTrabajo.Nunsys.Application.Services
{
    public class Users1Service : IUsers1Service
    {
        private IUsers1Repository _users1Repository;

        public Users1Service(IUsers1Repository users1Repository)
        {
            _users1Repository = users1Repository;
        }

        public IList<UserDto> getUsers()
        {
            IList<UserDto> resultado = new List<UserDto>();
            IList<Users> users = _users1Repository.GetAll();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Users, UserDto>()).CreateMapper();

            foreach (Users user in users)
            {


                resultado.Add(config.Map<UserDto>(user));
            }

            resultado = config.Map<IList<UserDto>>(resultado);

            return resultado;
        }

        public UserDto saveUser(UserDto user)
        {
            bool isNew = user.Id == null;
            Users userEdm = null;

            var configDtoToEdm = new MapperConfiguration(cfg => cfg.CreateMap<UserDto, Users>()).CreateMapper();
            var configEdmToDto = new MapperConfiguration(cfg => cfg.CreateMap<Users, UserDto>()).CreateMapper();



            if (isNew)
            {

                userEdm = configDtoToEdm.Map<Users>(user);
                this._users1Repository.Add(userEdm);
            }
            else
            {

                // opcion 1
                userEdm = _users1Repository.GetFirstElementFiltered(item => item.Id == user.Id);
                userEdm.Name = user.Name;
                userEdm.Surname1 = user.Surname1;
                userEdm.Surname2 = user.Surname2;
                userEdm.IdNetUser = user.IdNetUser;


                /*
                //opcion 3
                 customerEdm = Mapper.Map<Customers>(customer);
                */


            }
            this._users1Repository.UnitOfWork.Commit();
            user = configEdmToDto.Map<UserDto>(userEdm);
            return user;
        }
    }
}

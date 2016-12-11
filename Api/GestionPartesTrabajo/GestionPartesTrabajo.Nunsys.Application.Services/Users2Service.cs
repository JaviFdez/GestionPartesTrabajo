using GestionPartesTrabajo.Nunsys.Application.Interfaces;
using GestionPartesTrabajo.Nunsys.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPartesTrabajo.Nunsys.Application.Services
{
    // : IUsers2Service
    public class Users2Service
    {

        private IUsers2Repository _users2Repository;

        public Users2Service(IUsers2Repository users2Repository)
        {
            _users2Repository = users2Repository;
        }


        int createUser(int param1)
        {

        }

        public UserDto saveUser(UserDto user)
        {
            Users userEdm = this._users2Repository.GetFirstElementFiltered(item => item.Id == user.Id);
            if (null == userEdm)
            {
                userEdm = new Users()
                {
                    IdNetUser = "1",
                    Name = "nombre",
                    Surname1 = "asdfg",
                    Surname2 = "sijsi",
                };
                this._user2Repository.Add(userEdm);
            }
            else
            {
                userEdm.IdNetUser = user.IdNetUser;
                userEdm.Name = user.Name;
                userEdm.Surname1 = user.Surname1;
                userEdm.Surname2 = user.Surname2;

                if (null != user.Sysversion)
                {
                    userEdm.Sisversion = System.Convert.FromBase64String(NunsysCore.IT.CrossCutting.SerializadorCampoVersion.Serializar(user.Sysversion));
                }
            }

            this._users2Repository.UnitOfWork.Commit();

            var config = new MapperConfiguration(cfg => cfg.Createmap<Users, UsersDto>()).CreateMapper;
            UsersDto result = config.Map<Users>(userEdm);

            return userEdm;

            

        }
    }
}

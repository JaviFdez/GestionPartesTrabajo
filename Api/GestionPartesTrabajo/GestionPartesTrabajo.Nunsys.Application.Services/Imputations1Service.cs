using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionPartesTrabajo.Nunsys.Application.Interfaces;
using GestionPartesTrabajo.Nunsys.Data.Interfaces;
using GestionPartesTrabajo.Nunsys.Application.Adapters.Dto;
using GestionPartesTrabajo.Nunsys.Domain;
using AutoMapper;

namespace GestionPartesTrabajo.Nunsys.Application.Services
{
    public class Imputations1Service : IImputations1Service
    {

        private IImputations1Repository _imputations1Repository;

        public Imputations1Service(IImputations1Repository imputations1Repository)
        {
            _imputations1Repository = imputations1Repository;
        }

        public ImputationDto saveImputation(ImputationDto imputation)
        {
            var configDtoToEdm = new MapperConfiguration(cfg => cfg.CreateMap<ImputationDto, Imputations>()).CreateMapper();
            var configEdmToDto = new MapperConfiguration(cfg => cfg.CreateMap<Imputations, ImputationDto>()).CreateMapper();
            Imputations ImputationEdm = this._imputations1Repository.GetFirstElementFiltered(item => item.Id == imputation.Id);


            if (null == ImputationEdm)
            {
                this._imputations1Repository.Add(ImputationEdm);
            }

         
            ImputationEdm = configDtoToEdm.Map<Imputations>(imputation);

            if (null != imputation.SysVersion)
            {
                imputation.SysVersion = Convert.FromBase64String(NunsysCore.IT.CrossCutting.SerializadorCampoVersion.Serializar(imputation.SysVersion));
            }

            this._imputations1Repository.UnitOfWork.Commit();

            return configEdmToDto.Map<ImputationDto>(ImputationEdm);

        }

        public ImputationDto search(ImputationDto imputation)
        {
            throw new NotImplementedException();
        }

        public ImputationDto searchImputation(ImputationDto imputation)
        {
            Imputations ImputationEdm = this._imputations1Repository.GetFirstElementFiltered(item => item.Id == imputation.Id);
            return imputation;
        }
    }
}

using GestionPartesTrabajo.Nunsys.Domain;
using GestionPartesTrabajo.Nunsys.IT.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using GestionPartesTrabajo.Nunsys.Data.Interfaces;
using System;
using System.Linq;
using NunsysCore.IT.CrossCutting;
using System.Collections.Generic;
using GestionPartesTrabajo.Nunsys.Application.Interfaces;
using GestionPartesTrabajo.Nunsys.Data.Repository;
using GestionPartesTrabajo.Nunsys.Application.Adapters.Dto;
using AutoMapper;

namespace GestionPartesTrabajo.Nunsys.Application.Services
{
    public class Imputations2Service : IImputations2Service
    {
        private IImputations2Repository _imputationsRepository;

        public ImputationDto getImputation(int id)
        {
            ImputationDto imputation = null;
            Imputations imputationEdm = _imputationsRepository.GetFirstElementFiltered(item => item.Id == id);
            if (null != imputationEdm)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Imputations, ImputationDto>()).CreateMapper();
                imputation = config.Map<ImputationDto>(imputationEdm);
            }

            return imputation;
        }

        public IList<ImputationDto> getImputations()
        {
            IList<ImputationDto> result = new List<ImputationDto>();
            IList<Imputations> imputations = _imputationsRepository.GetAll();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Imputations, ImputationDto>());
            foreach (Imputations imputation in imputations)
            {
                ImputationDto resultDto = config.CreateMapper().Map<ImputationDto>(imputation);
                result.Add(resultDto);
            }

            return result.ToList();
        }
        public ImputationDto saveImputation(ImputationDto imputation)
        {
            Imputations imputationEdm = _imputationsRepository.GetFirstElementFiltered(item => item.Id == imputation.Id);

            if (null != imputationEdm)
            {
                imputationEdm = new Imputations()
                {
                    Id = imputation.Id,
                    IdUser = imputation.IdUser,
                    IdWorkOrder = imputation.IdWorkOrder,
                    IdProjectTask = imputation.IdProjectTask,
                    Description = imputation.Description,
                    StartDateTime = imputation.StartDateTime,
                    EndDateTime = imputation.EndDateTime,
                    Hours = imputation.Hours,
                    SisVersion = imputation.SysVersion
                };

                _imputationsRepository.Add(imputationEdm);
            }
            else
            {
                imputationEdm.Id = imputation.Id;
                imputationEdm.IdUser = imputation.IdUser;
                imputationEdm.IdWorkOrder = imputation.IdWorkOrder;
                imputationEdm.IdProjectTask = imputation.IdProjectTask;
                imputationEdm.Description = imputation.Description;
                imputationEdm.StartDateTime = imputation.StartDateTime;
                imputationEdm.EndDateTime = imputation.EndDateTime;
                imputationEdm.Hours = imputation.Hours;
                imputationEdm.SisVersion = imputation.SysVersion;

                if (null != imputation.SysVersion)
                {
                    imputationEdm.SisVersion = System.Convert.
                                                FromBase64String(
                                                    NunsysCore.IT.CrossCutting.SerializadorCampoVersion.Serializar(imputation.SysVersion)
                                                );
                }
            }

            _imputationsRepository.UnitOfWork.Commit();

            return imputation;
        }

        public ImputationDto deleteImputation(int id)
        {
            ImputationDto imputationDto = null;
            Imputations imputationEdm = _imputationsRepository.GetFirstElementFiltered(item => item.Id == id);

            if (null != imputationEdm)
            {
                imputationDto = new ImputationDto()
                {
                    Id = imputationEdm.Id,
                    IdUser = imputationEdm.IdUser,
                    IdWorkOrder = imputationEdm.IdWorkOrder,
                    IdProjectTask = imputationEdm.IdProjectTask,
                    Description = imputationEdm.Description,
                    StartDateTime = imputationEdm.StartDateTime,
                    EndDateTime = imputationEdm.EndDateTime,
                    Hours = imputationEdm.Hours,
                    SysVersion = imputationEdm.SisVersion
                };

                _imputationsRepository.UnitOfWork.Commit();
            }

            return imputationDto;
        }
    }
}

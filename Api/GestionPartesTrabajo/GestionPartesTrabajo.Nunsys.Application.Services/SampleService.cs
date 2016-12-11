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

namespace GestionPartesTrabajo.Nunsys.Application.Services
{
    public class SampleService : ISampleService
    {
        private ISampleRepository _sampleRepository;

        public SampleService(ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }


        public int sampleMethod(int param1)
        {
            throw new NotImplementedException();
        }
    }
}

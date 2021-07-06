using AutoMapper;
using CasELMS.DbClasses;
using CasELMS.MappingClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasELMS.ViewModal
{
    public class ViewClass:Profile
    {
        public ViewClass()
        {
            CreateMap<StudentModal, StudentRegistration>().ReverseMap();
        }
    }
}

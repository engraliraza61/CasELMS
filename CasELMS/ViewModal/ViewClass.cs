using AutoMapper;
using CasELMS.DbClasses;
using CasELMS.DBViewModel;
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
            CreateMap<RoleModal, Roles>().ReverseMap();
            CreateMap<PermissionModal, Permissions>().ReverseMap();
            CreateMap<UpdatePermissionModal, Permissions>().ReverseMap();
            CreateMap<DeletePermissionModal, Permissions>().ReverseMap();
            CreateMap<UpdateRoleModal, Roles>().ReverseMap();
            CreateMap<DeleteRoleModal, Roles>().ReverseMap();
            CreateMap<StudentLoginModal, StudentRegistration>().ReverseMap();
        }
    }
}

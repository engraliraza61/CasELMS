using AutoMapper;
using CasELMS.Context;
using CasELMS.DbClasses;
using CasELMS.DBViewModel;
using CasELMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasELMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleAPIController : ControllerBase
    {
        ProjectContext _project;
        IConfiguration _config;
        IMapper _map;
        public RoleAPIController(ProjectContext project, IConfiguration config, IMapper map)
        {
            _project = project;
            _config = config;
            _map = map;
        }


        [HttpPost]
        [Route("InsertRole")]
        public async Task<ActionResult> InsertRole(RoleModal role)
        {
            await Task.Delay(0);
            Response res = new Response();
            try
            {
                Roles newUser = _map.Map<Roles>(role);
                newUser.RoleStatus = 1;
                _project.Role.Add(newUser);
                _project.SaveChanges();
                res.Status = "Role Added";


            }
            catch (Exception ex)
            {
                res.Status = ex.Message;
            }
            return Ok(res);
        }

        [HttpPost]
        [Route("UpdateRole")]
        public async Task<ActionResult> UpdateRole(UpdateRoleModal obj)
        {
            await Task.Delay(0);
            Response res = new Response();
            try
            {
                var newRole = _project.Role.Find(obj.RoleId);
                newRole.RoleStatus = 1;
                newRole.RoleTitle = obj.RoleTitle;

                _project.Role.Update(newRole);
                _project.SaveChanges();
                res.Status = "Updated successfull";


            }
            catch (Exception ex)
            {
                res.Status = ex.Message;
            }
            return Ok(res);
        }
        [HttpPost]
        [Route("DeleteRole")]
        public async Task<ActionResult> DeleteRole(DeleteRoleModal obj)
        {
            await Task.Delay(0);
            Response res = new Response();
            try
            {
                var newRole = _project.Role.Find(obj.RoleId);
                newRole.RoleStatus = 0;
                _project.Role.Update(newRole);
                _project.SaveChanges();
                res.Status = "Delete successfull";
            }
            catch (Exception ex)
            {
                res.Status = ex.Message;
            }
            return Ok(res);
        }





        [HttpGet]
        [Route("GetRole")]
        public async Task<ActionResult> GetRole()
        {
            await Task.Delay(0);
            try
            {
                List<Roles> RoleList = _project.Role.ToList();


                return Ok(RoleList);
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}

using AutoMapper;
using CasELMS.Context;
using CasELMS.DbClasses;
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
    public class CourseAPIController : ControllerBase
    {
        ProjectContext _dbo;
        IMapper _map;
        IConfiguration config;
        public CourseAPIController(ProjectContext contextObject, IMapper mapObject, IConfiguration myconfig)
        {
            _dbo = contextObject;
            _map = mapObject;
            config = myconfig;
        }
        [HttpPost]
        [Route("CourseRegister")]
        public Response CourseRegister(Course Obj)
        {
            Response res = new Response();
            try
            {
                Obj.Status = "available";
                _dbo.Course.Add(Obj);
                _dbo.SaveChanges();
                res.Status = "Courses Inserted Successfully";
                res.id = Obj.CourseId;
            }
            catch (Exception ex)
            {
                res.Status = ex.Message;
            }
            return res;
        }
        [HttpGet]
        [Route("GetAllCourse")]
        public List<Course> GetAllCourse()
        {
            List<Course> CourseList = _dbo.Course.ToList();
            return CourseList;
        }
    }
}

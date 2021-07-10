using AutoMapper;
using CasELMS.Context;
using CasELMS.DbClasses;
using CasELMS.ManagementClasses;
using CasELMS.MappingClasses;
using CasELMS.Models;
using Microsoft.AspNetCore.Authorization;
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
    public class StudentAPIController : ControllerBase
    {
        ProjectContext _dbo;
        IMapper _map;
        IConfiguration config;
        public StudentAPIController(ProjectContext contextObject, IMapper mapObject,IConfiguration myconfig)
        {
            _dbo = contextObject;
            _map = mapObject;
            config = myconfig;
        }
        [HttpPost]
        [Route("Registration")]
        public Response Registration(StudentModal std)
        {
            Response res = new Response();
            try
            {
                StudentRegistration newStd = _map.Map<StudentRegistration>(std);
                string s = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                newStd.InsertionDate = Convert.ToDateTime(s);
                _dbo.StudentRegistration.Add(newStd);
                _dbo.SaveChanges();
                res.Status = "Inserted Successfully";
            }
            catch (Exception ex)
            {
                res.Status = ex.Message;
            }
            return res;
        }
        [HttpGet]
        [Route("GetAllStudent")]
        public List<StudentRegistration> GetAllStudent()
        {
            List<StudentRegistration> StudentList = _dbo.StudentRegistration.ToList();
            return StudentList;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public Response Login(StudentRegistration std)
        {
            Response res = new Response();
            try
            {
                StudentRegistration newStd = _dbo.StudentRegistration.Where(r=>r.Email.Equals(std.Email) && r.Password.Equals(std.Password)).FirstOrDefault();
                if (newStd == default)
                {
                    res.Status = "Invalid UserName / Password";
                }
                else
                {
                    res.Status = "login successfully";
                    res.Token = JWT.GenerateJSONWebToken(std, config);
                }
            }
            catch (Exception ex)
            {
                res.Status = ex.Message;
            }
            return res;
        }
        [HttpPost]
        [Route("UpdatedStudent")]
        public List<StudentRegistration> UpdatedStudent(StudentRegistration std)
        {
                    List<StudentRegistration> StudentList = _dbo.StudentRegistration.Where(r => r.StudentId.Equals(std.StudentId)).ToList();
                    return StudentList;
        }
        [HttpPut]
        [Route("updateStudent")]
        public Response updateStudent(StudentRegistration obj)
        {
            Response res = new Response();
            try
            {
                StudentRegistration newList = _dbo.StudentRegistration.Find(obj.StudentId);
                newList.FirstName = obj.FirstName;
                newList.LastName = obj.LastName;
                newList.UserName = obj.UserName;
                newList.Email = obj.Email;
                newList.StudentPhoneNumber = obj.StudentPhoneNumber;
                newList.PostalCode = obj.PostalCode;
                newList.Class = obj.Class;
                newList.Adress = obj.Adress;
                _dbo.StudentRegistration.Update(newList);
                _dbo.SaveChanges();
                res.Status = "update Successfully";
            }
            catch (Exception ex)
            {
                res.Status = ex.Message;
            }
            return res;
        }
    }
}

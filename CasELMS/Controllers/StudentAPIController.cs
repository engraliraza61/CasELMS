using AutoMapper;
using CasELMS.Context;
using CasELMS.DbClasses;
using CasELMS.DBViewModel;
using CasELMS.EncryptionDecryption;
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
    public class StudentAPIController : ControllerBase
    {
        ProjectContext _dbo;
        IConfiguration _config;
        IMapper _map;
        public StudentAPIController(ProjectContext dbo, IConfiguration config, IMapper map)
        {
            _dbo = dbo;
            _config = config;
            _map = map;
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
                newStd.Password = EncryptDecrypt.Encrypt(std.Password);
                newStd.Status = 1;
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
        [HttpPost]
        [Route("updatedStudent")]
        public List<StudentRegistration> updatedStudent(StudentRegistration obj)
        {
            List<StudentRegistration> StudentList = _dbo.StudentRegistration.Where(r=>r.StudentId==obj.StudentId).ToList();
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
                newList.Adress = obj.Adress;
                newList.PostalCode = obj.PostalCode;
                newList.Class = obj.Class;
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
       
        [HttpPut]
        [Route("RemoveStudent")]
        public Response RemoveStudent(StudentRegistration obj)
        {
            Response res = new Response();
            try
            {
                StudentRegistration newList = _dbo.StudentRegistration.Find(obj.StudentId);
                newList.Status = 0;
                _dbo.StudentRegistration.Update(newList);
                _dbo.SaveChanges();
                res.Status = "remove Successfully";
            }
            catch (Exception ex)
            {
                res.Status = ex.Message;
            }
            return res;
        }
        [HttpPost]
        [Route("LoginStudent")]
        public Response LoginStudent(StudentLoginModal stdObject)
        {
            Response res = new Response();
            try
            {
                StudentRegistration std = _map.Map<StudentRegistration>(stdObject);
                StudentRegistration newstd = _dbo.StudentRegistration.Where(std => std.Email.Equals(stdObject.Email) && std.Password.Equals(EncryptDecrypt.Encrypt(stdObject.Password))).FirstOrDefault(); 
                if (newstd == default)
                {
                    res.Status = "Invalid UserName / Password";
                }
                else
                {
                    res.Status = "login successfully";
                }
            }
            catch
            {
                res.Status = "Failed";
            }

            return res;
        }
        [HttpPost]
        [Route("EmailCheck")]
        public Response EmailCheck(StudentRegistration stdObject)
        {
            Response res = new Response();
            try
            {
                StudentRegistration newstd = _dbo.StudentRegistration.Where(std => std.Email.Equals(stdObject.Email)).FirstOrDefault();
                if (newstd == default)
                {
                    res.Status = "Email verified";
                }
                else
                {
                    res.Status = "Email already exist";
                }
            }
            catch
            {
                res.Status = "Failed";
            }

            return res;
        }
    }
}

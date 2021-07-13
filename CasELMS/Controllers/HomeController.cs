using CasELMS.Context;
using CasELMS.DbClasses;
using CasELMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CasELMS.Controllers
{
    public class HomeController : Controller
    {
        IWebHostEnvironment MyHostingPath;
        ProjectContext _dbo;
        public HomeController(IWebHostEnvironment currentHosting, ProjectContext contextObject)
        {
            MyHostingPath = currentHosting;
            _dbo = contextObject;
        }
        [HttpPost]
        public IActionResult fileUploadingCourses()
        {
            string CourseId = Request.Form["CourseId"].ToString();
            MyHostingPath.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            if (Request.Form.Files.Count > 0)
            {
                string FileCompletePath = "";
                string FileExtention = "";
                string UniqueId = "";
                string BAsePath = "";
                for (int i = 0; i < Request.Form.Files.Count; i++)
                {
                    BAsePath = MyHostingPath.WebRootPath + "/UserFiles/";
                    UniqueId = Guid.NewGuid().ToString();
                    FileExtention = Path.GetExtension(Request.Form.Files[i].FileName);
                    FileCompletePath = BAsePath + UniqueId + FileExtention;

                    using (var FileUploadingStream = new FileStream(FileCompletePath, FileMode.Create))
                    {
                        Request.Form.Files[i].CopyTo(FileUploadingStream);
                    }
                    try
                    {
                        Course newList = _dbo.Course.Find(CourseId);
                        newList.CoursePicture = FileCompletePath;
                        _dbo.Course.Add(newList);
                        _dbo.SaveChanges();
                    }
                    catch(Exception ex)
                    {
                        return Json(ex.Message);
                    }

                }
                return Json("File Uploaded successfully");
            }
            else
            {
                return Json("No File Uploaded");
            }
        }
        public IActionResult Index()
        {
            return View();
            //if (Request.Cookies["userIdentity"] == null)
            //{
            //    return RedirectToActionPermanent("LoginPage");
            //}
            //else
            //{
            //    return View();
            //}
        }
        public IActionResult Pricing()
        {
            return View();
        }
        public IActionResult TimeLine()
        {
            return View();
        }
        public IActionResult LoginPage()
        {
            return View();
        }
        public IActionResult RegisterPage()
        {
            return View();
        }
        public IActionResult LockScreenPage()
        {
            return View();
        }
        public IActionResult UserProfile ()
        {
            return View();
        }
        public IActionResult AllStudent()
        {
            return View();
        }
        public IActionResult AddStudent()
        {
            return View();
        }

        public IActionResult UpdateStudent(string id)
        {
            ViewBag.id = id;
            return View();
        }
        public IActionResult AllCourses()
        {
            return View();
        }
        public IActionResult AddCourses()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

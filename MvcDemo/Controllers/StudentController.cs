using MvcDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemo.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Student(string studentId)
        {
            PrepareViewBag();
            ClassmateViewModel student = new ClassmateViewModel();

            //student = studentService.Get(studentId);

            student.StudentID = studentId;
            student.Name = "張曉明";
            student.Year = 105;
            //student.LeaveDate = new DateTime(2013, 12, 5);

            return View(student);
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Student(ClassmateViewModel model)
        {
            PrepareViewBag();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //update 資料

            return View(model);
        }

        private void PrepareViewBag()
        {
            List<SelectListItem> yearList = new List<SelectListItem>();

            for (int i = 99; i < DateTime.Now.Year - 1911 + 1; i++)
            {
                yearList.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }

            ViewBag.YearList = new SelectList(yearList, "Text", "Value");
        }
    }
}
using MvcDemo.Areas.MSG.Models;
using MvcDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MvcDemo.Areas.MSG.Report;
using System.Data;
using System.IO;

namespace MvcDemo.Areas.MSG.Controllers
{
    public class APL02Controller : Controller
    {
        private readonly twd_demoEntities sqlDb = new twd_demoEntities();

        // GET: MSG/APL02
        public ActionResult Index()
        {
            //Include 需要  using System.Data.Entity;
            var query = sqlDb.Course.Include(m => m.Student).Select(m => new CourseVM
            {
                CurseId = m.id,
                Name = m.name,
                TeacherId = m.teacher,
                TeacherName = m.teachername,
                Hours = m.hours ?? 0,
                Students = m.Student.Select(b => new StudentVM
                {
                    Id = b.id,
                    Name = b.name
                })
            });

            return View(query);
        }

        public ActionResult Detail(string courseId)
        {
            var query = sqlDb.Course.Where(m => m.id == courseId);

            if (!query.Any())
                return HttpNotFound();

            var firstData = query.FirstOrDefault();

            //DB to ViewModel
            CourseVM model = new CourseVM
            {
                CurseId = firstData.id,
                Name = firstData.name,
                TeacherId = firstData.teacher,
                TeacherName = firstData.teachername,
                Hours = firstData.hours ?? 0,
                Students = firstData.Student.Select(b => new StudentVM
                {
                    Id = b.id,
                    Name = b.name
                })
            };

            return View(model);
        }

        public ActionResult Print()
        {
            var query = sqlDb.Course.Select(m => new CourseVM
            {
                CurseId = m.id,
                Name = m.name,
                TeacherId = m.teacher,
                TeacherName = m.teachername,
                Hours = m.hours ?? 0,
                Students = m.Student.Select(b => new StudentVM
                {
                    Id = b.id,
                    Name = b.name
                })
            });

            using (var report = new Report01())
            {
                Report.XML.Course dataset = new Report.XML.Course();

                foreach (var course in query)
                {

                    foreach (var data in query)
                    {
                        var row = dataset._Course.NewRow();

                        row["CourseId"] = data.CurseId;
                        row["Name"] = data.Name;
                        row["TeacherName"] = data.TeacherName;
                        row["Hours"] = data.Hours;
                        row["StudentCount"] = data.Students.Count();
                    }
                }

                report.SetDataSource(dataset);

                Stream stream = report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);

                return File(stream, "application/pdf", "課程總攬.pdf");
            }
        }
    }
}
using MvcDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDemo.Areas.MSG.Models
{
    /// <summary>
    /// 課程
    /// </summary>
    public class CourseVM
    {
        public string CurseId { get; set; }
        public string Name { get; set; }
        public string TeacherId { get; set; }
        public string TeacherName { get; set; }
        public int Hours { get; set; }

        /// <summary>
        /// 修課學生
        /// </summary>
        public virtual IEnumerable<StudentVM> Students { get; set; }

        public Course ConverToEntity()
        {
            return new Course
            {
                id = this.CurseId,
                name = this.Name,
                teacher = this.TeacherId,
                teachername = this.TeacherName,
                hours = this.Hours,
                //Student = 
            };
        }
    }
}
using MvcDemo.Areas.MSG.Models;
using MvcDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDemo.Repository
{
    public class CourseRepository : EFRepository<Course, CourseVM>
    {
    }
}
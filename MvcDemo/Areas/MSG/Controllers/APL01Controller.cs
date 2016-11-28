using MvcDemo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace MvcDemo.Areas.MSG.Controllers
{
    public class APL01Controller : Controller
    {
        private readonly twd_demoEntities sqlDb = new twd_demoEntities();

        // GET: MSG/APL01
        public ActionResult Index()
        {
            //select * from MSGD01_1 where MD0101_APLNO='105B1000000001'
            /*
             * select * from MSGD01_1
             * inner join MSGD01_2 on MD0101_APLNO=MD0102_APLNO
             * where MD0101_APLNO='105B1000000001'
             */
            IQueryable<MSGD01_1> query = from msgd01_1 in sqlDb.MSGD01_1
                                         //join msgd01_2 in sqlDb.MSGD01_2 on new { Aplno = msgd01_1.MD0101_APLNO } equals new { Aplno = msgd01_2.MD0102_APLNO} into temp1
                                         //from msgd01_2 in temp1.DefaultIfEmpty()
                                         where msgd01_1.MD0101_APLNO == "105B1000000001"
                                         orderby msgd01_1.MD0101_TITLE
                                         select msgd01_1;

            query.Include(m => m.MSGD01_2s).Include(m => m.MSGD01_3s);

            List<MSGD01_1> templist = query.ToList();

            IQueryable<MSGD01_1> query2 = sqlDb.MSGD01_1.Where(m => m.MD0101_APLNO == "105B1000000001").OrderBy(m => m.MD0101_TITLE);

            Debug.WriteLine("Linq 表示法1");

            if (1 == 2)
                query = from src in query
                        where src.MD0101_TITLE.Contains("A")
                        select src;
            if (2 == 2)
                query = query.Where(m => m.MD0101_TITLE.Contains("B"));

            foreach (var item in templist)
                Debug.WriteLine(item.MSGD01_2s.Count(m => m.MD0102_READTYPE.Value));

            Debug.WriteLine("Linq 表示法2");

            foreach (var item in query2)
                Debug.WriteLine(item.MD0101_SENDERNAME);

            return View();
        }
    }
}
using MvcDemo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MvcDemo.Areas.MSG.Models;

namespace MvcDemo.Areas.MSG.Controllers
{
    public class APL01Controller : Controller
    {
        private readonly twd_demoEntities sqlDb = new twd_demoEntities();

        // GET: MSG/APL01
        public ActionResult Index()
        {
            IQueryable<MessageMasterVM> query = sqlDb.MSGD01_1.Select(m => new MessageMasterVM
            {
                Aplno = m.MD0101_APLNO,
                SenderName = m.MD0101_SENDERNAME,
                Title = m.MD0101_TITLE,
                IsAllMember = m.MD0101_ALLMEMBER ?? false,
            });

            return View(query);
        }

        public ActionResult Insert()
        {
            MessageMasterVM model = new MessageMasterVM();

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Insert(MessageMasterVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            //Update Db
            try
            {
                var dbModel = sqlDb.MSGD01_1.Create();

                dbModel.MD0101_APLNO = model.Aplno;
                dbModel.MD0101_SENDERNAME = model.SenderName;
                dbModel.MD0101_TITLE = model.Title;
                dbModel.MD0101_ALLMEMBER = model.IsAllMember;

                sqlDb.MSGD01_1.Add(dbModel);
                sqlDb.SaveChanges();

                ModelState.AddModelError("", "新增成功");

                return View(model);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

                ModelState.AddModelError("", "發生例外事件(" + ex.Message + ")");

                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Delete(string aplno)
        {
            //Update Db
            try
            {
                //var dbModel = sqlDb.MSGD01_1.FirstOrDefault(m => m.MD0101_APLNO == aplno);
                var dbModel = new MSGD01_1
                {
                    MD0101_APLNO = aplno
                };

                sqlDb.MSGD01_1.Attach(dbModel);
                sqlDb.MSGD01_1.Remove(dbModel);

                sqlDb.SaveChanges();

                return Json(new
                {
                    Success = true,
                    Message = "刪除成功"
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

                return Json(new
                {
                    Success = false,
                    Message = "發生例外事件(" + ex.Message + ")"
                });
            }
        }

        /// <summary>
        /// Linq 練習1
        /// </summary>
        private void LinqPractice()
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
        }

        public ActionResult Detail(string aplno)
        {
            var query = sqlDb.MSGD01_1.Where(m => m.MD0101_APLNO == aplno);

            if (!query.Any())
                return HttpNotFound();

            var firstData = query.FirstOrDefault();

            //DB to ViewModel
            MessageMasterVM model = new MessageMasterVM();

            model.Aplno = firstData.MD0101_APLNO;
            model.SenderName = firstData.MD0101_SENDERNAME;
            model.Title = firstData.MD0101_TITLE;
            model.IsAllMember = firstData.MD0101_ALLMEMBER ?? false;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Detail(MessageMasterVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            //Update Db
            try
            {
                var dbModel = sqlDb.MSGD01_1.FirstOrDefault(m => m.MD0101_APLNO == model.Aplno);

                dbModel.MD0101_SENDERNAME = model.SenderName;
                dbModel.MD0101_TITLE = model.Title;
                dbModel.MD0101_ALLMEMBER = model.IsAllMember;

                sqlDb.SaveChanges();

                ModelState.AddModelError("", "修改成功");

                return View(model);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

                ModelState.AddModelError("", "發生例外事件(" + ex.Message + ")");

                return View(model);
            }

        }

        public ActionResult _Detail(string aplno)
        {
            var query = sqlDb.MSGD01_1.Where(m => m.MD0101_APLNO == aplno);

            if (!query.Any())
                return HttpNotFound();

            var firstData = query.FirstOrDefault();

            //DB to ViewModel
            MessageMasterVM model = new MessageMasterVM();

            model.Aplno = firstData.MD0101_APLNO;
            model.SenderName = firstData.MD0101_SENDERNAME;
            model.Title = firstData.MD0101_TITLE;
            model.IsAllMember = firstData.MD0101_ALLMEMBER ?? false;

            return PartialView(model);
        }

        public void GroupBy()
        {
            var group = from d02 in sqlDb.MSGD01_2
                        group d02 by new { Aplno = d02.MD0102_APLNO, D02Type = d02.MD0102_TYPE } into g
                        let test = g.Sum(m => m.MD0102_ID)
                        orderby g.Key.Aplno, g.Key.D02Type
                        //let first = g.OrderBy(m => m.MD0102_ID).FirstOrDefault()
                        select new
                        {
                            Aplno = g.Key.Aplno,
                            D02Type = g.Key.D02Type,
                            Count = g.Count(),
                            Data = g.Select(m => new { User = m.MD0102_UNDERTAKERNAME, Test = m.MD0102_SENDTYPE })
                        };
            //select MD0101_APLNO, MD0101_SENDERNAME from MSGD01_1
            var list = sqlDb.MSGD01_1
                .Select(m => new  {
                    m.MD0101_APLNO,
                    m.MD0101_SENDERNAME
                })
                .ToList();

            foreach (var m in list)
            {
                if (m.MD0101_SENDERNAME != "李嘉杰")
                    continue;

                var dbModel = new MSGD01_1 { MD0101_APLNO = m.MD0101_APLNO };

                sqlDb.MSGD01_1.Attach(dbModel);

                dbModel.MD0101_CONTENT = "AAA";
                sqlDb.SaveChanges();
            }
        }
    }
}
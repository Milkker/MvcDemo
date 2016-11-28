using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcDemo.Models
{
    /// <summary>
    /// 學生資料
    /// </summary>
    public class ClassmateViewModel
    {
        /// <summary>
        /// 學生編號
        /// </summary>
        [Required]
        [Display(Name = "學生編號")]
        public string StudentID { get; set; }

        /// <summary>
        /// 學生姓名
        /// </summary>
        [Required]
        [Display(Name = "學生名稱")]
        public string Name { get; set; }

        /// <summary>
        /// 入學年度
        /// </summary>
        [Display(Name = "入學年度")]
        [Range(99, int.MaxValue, ErrorMessage="本校由99年創立，請輸入正確的入學年度。")]
        public int Year { get; set; }

        /// <summary>
        /// 離校日期
        /// </summary>
        [UIHint("_DateTime")]
        [Display(Name = "離校日期")]
        public DateTime? LeaveDate { get; set; }

        /// <summary>
        /// 離校日期(僅顯示)
        /// </summary>
        [Display(Name = "離校日期")]
        public string ShowLeaveDate
        {
            get
            {
                if (LeaveDate == null)
                    return "";
                return string.Format("{0}/{1}/{2}", LeaveDate.Value.Year, LeaveDate.Value.Month, LeaveDate.Value.Date);
            }
        }

        /// <summary>
        /// Textbox
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// RadioBox
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// CheckBox
        /// </summary>
        public bool IsLeave { get; set; }

    }
}
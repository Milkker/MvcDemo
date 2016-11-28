using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDemo.Areas.MSG.Models
{
    public class MessageMasterVM
    {
        /// <summary>
        /// 申請單號
        /// </summary>
        public string  Aplno { get; set; }

        /// <summary>
        /// 發送人員
        /// </summary>
        public string SenderGuid { get; set; }

        /// <summary>
        /// 發送人員名稱
        /// </summary>
        public string SenderName { get; set; }

        /// <summary>
        /// 主旨
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 全體人員
        /// </summary>
        public bool IsAllMember { get; set; }
    }
}
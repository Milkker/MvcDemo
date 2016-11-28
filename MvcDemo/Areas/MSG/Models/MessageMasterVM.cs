using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDemo.Areas.MSG.Models
{
    /// <summary>
    /// 公務訊息主檔
    /// </summary>
    public class MessageMasterVM
    {
        /// <summary>
        /// *申請單號(14)
        /// </summary>
        public string  Aplno { get; set; }

        /// <summary>
        /// *發送人員名稱(4個字)
        /// </summary>
        public string SenderName { get; set; }

        /// <summary>
        /// *主旨(500/TextArea)
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 全體人員
        /// </summary>
        public bool IsAllMember { get; set; }
    }
}
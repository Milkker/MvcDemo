//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcDemo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MSGD01_3
    {
        public long MD0103_ID { get; set; }
        public Nullable<long> MD0103_MD0102_ID { get; set; }
        public string MD0103_APLNO { get; set; }
        public string MD0103_TYPE { get; set; }
        public Nullable<System.DateTime> MD0103_REPLYDATE { get; set; }
        public string MD0103_REPLY { get; set; }
        public string MD0103_REPLYNAME { get; set; }
        public string MD0103_REPLYDEPT { get; set; }
        public string MD0103_REPLYDEPTNAME { get; set; }
        public string MD0103_REPLYTITLE { get; set; }
        public string MD0103_REPLYTITLENAME { get; set; }
        public string MD0103_CONTENT { get; set; }
        public Nullable<System.DateTime> MD0103_UPDDATE { get; set; }
        public string MD0103_UPDUSER { get; set; }
    
        public virtual MSGD01_1 MSGD01_1 { get; set; }
        public virtual MSGD01_2 MSGD01_2 { get; set; }
    }
}
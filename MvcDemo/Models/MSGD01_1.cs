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
    
    public partial class MSGD01_1
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MSGD01_1()
        {
            this.MSGD01_2s = new HashSet<MSGD01_2>();
            this.MSGD01_3s = new HashSet<MSGD01_3>();
        }
    
        public string MD0101_APLNO { get; set; }
        public string MD0101_TYPE { get; set; }
        public string MD0101_SENDER { get; set; }
        public string MD0101_SENDERNAME { get; set; }
        public string MD0101_SENDERDEPT { get; set; }
        public string MD0101_SENDERDEPTNAME { get; set; }
        public string MD0101_SENDERTITLE { get; set; }
        public string MD0101_SENDERTITLENAME { get; set; }
        public Nullable<System.DateTime> MD0101_SENDDATE { get; set; }
        public Nullable<bool> MD0101_ISSEND { get; set; }
        public Nullable<bool> MD0101_ALLMEMBER { get; set; }
        public string MD0101_TITLE { get; set; }
        public string MD0101_CONTENT { get; set; }
        public Nullable<int> MD0101_LIMITBEGINDATE { get; set; }
        public Nullable<int> MD0101_LIMITENDDATE { get; set; }
        public Nullable<System.DateTime> MD0101_UPDDATE { get; set; }
        public string MD0101_UPDUSER { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MSGD01_2> MSGD01_2s { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MSGD01_3> MSGD01_3s { get; set; }
    }
}

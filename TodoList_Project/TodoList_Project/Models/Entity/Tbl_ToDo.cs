//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TodoList_Project.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_ToDo
    {
        public int ID { get; set; }
        public string BASLIK { get; set; }
        public string NOTLAR { get; set; }
        public Nullable<System.DateTime> TARIH { get; set; }
        public Nullable<int> KATEGORI { get; set; }
        public Nullable<int> ISLEM { get; set; }
        public Nullable<int> UYEID { get; set; }
    
        public virtual Tbl_Islem Tbl_Islem { get; set; }
        public virtual Tbl_Kategori Tbl_Kategori { get; set; }
        public virtual Tbl_Uye Tbl_Uye { get; set; }
    }
}

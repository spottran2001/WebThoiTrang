//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebThoiTrang.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CartDetail
    {
        public string MAGH { get; set; }
        public string MASP { get; set; }
        public Nullable<int> GIA { get; set; }
        public int SOLUONG { get; set; }
        public int Id { get; set; }
    
        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}

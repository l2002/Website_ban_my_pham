//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bán_Mỹ_Phẩm.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PhanQuyen
    {
        public PhanQuyen()
        {
            this.Nguoidungs = new HashSet<Nguoidung>();
        }
    
        public int IDQuyen { get; set; }
        public string TenQuyen { get; set; }
    
        public virtual ICollection<Nguoidung> Nguoidungs { get; set; }
    }
}

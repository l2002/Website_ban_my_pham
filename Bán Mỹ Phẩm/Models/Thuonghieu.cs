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
    
    public partial class ThuongHieu
    {
        public ThuongHieu()
        {
            this.SanPhams = new HashSet<SanPham>();
        }
    
        public string MaTH { get; set; }
        public string TenTH { get; set; }
    
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}

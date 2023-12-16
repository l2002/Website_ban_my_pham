using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bán_Mỹ_Phẩm.Models
{
    public class GioHang
    {
        QL_MyPham_DAEntities3 db = new QL_MyPham_DAEntities3();

        public string iMasp { get; set; }
        public string sTensp { get; set; }
        public string sAnhBia { get; set; }
        public decimal dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public int iKhuyenMai { get; set; }

        public virtual KhuyenMai KhuyenMai { get; set; }

        public decimal? ThanhTien
        {
            get { return iSoLuong * dDonGia - iSoLuong * dDonGia * iKhuyenMai/100; }
        }

        //Hàm tạo cho giỏ hàng
        public GioHang(string Masp)
        {
            iMasp = Masp;
            SanPham sp = db.SanPhams.Single(n => n.MaSP == iMasp);
            sTensp = sp.TenSP;
            sAnhBia = sp.HinhAnh;
            dDonGia = decimal.Parse(sp.GiaBan.ToString());
            iKhuyenMai = int.Parse(sp.KhuyenMai.TenKM.ToString());
            iSoLuong = 1;
        }
    }
}
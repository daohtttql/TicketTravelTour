using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_lý_Tour_du_lịch.BUS
{
    class daoDatVe
    {
        TravelTourEntities1 db;
        public  daoDatVe()
        {
            db = new TravelTourEntities1();
        }
        //hiển thị ảnh tại mỗi lần chọn tour
        public void hienThiAnh(int ma, Panel p)
        {
            TOUR t = db.TOUR.First(s => s.MATOUR.Equals(ma));
            MemoryStream stream = new MemoryStream(t.HINHANH.ToArray());
            Image img = Image.FromStream(stream);
            p.BackgroundImage = img;
        }
        public dynamic layDS_KhachHang()
        {
            var ds = db.KHACHHANG.Select(s => new
            {
                s.MAKH,
                s.TENKH,
                s.SDT
            }).ToList();
            return ds;
        }
        public dynamic layDS_Tour()
        {
            var ds = db.TOUR.Where(s => s.NGAYBD > DateTime.Now && s.SOLUONGVE > 0)
                .Select(s => new
                {
                    s.MATOUR,
                    s.DIADIEMDEN,
                    s.GIA,
                    s.HINHANH,
                    s.MOTA

                }).ToList();

            return ds;
        }
        public dynamic layDS_Ve()
        {
            var ds = db.VEDAT.Select(s => new
            { 
                s.MAVE,
                s.TOUR.DIEMDI,
                s.TOUR.DIADIEMDEN,
                s.TOUR.NGAYBD,
                s.TOUR.NGAYKT,
                s.TOUR.GIA,
                s.KHACHHANG.TENKH,
                s.KHACHHANG.SDT,
                s.NgayDat,
                s.TOUR.HINHANH
                
            }).ToList();
            return ds;
        }
        //Phần Reporting
        public List<veBan_Result> report_Ve(DateTime tu, DateTime den)
        {
            var ds = db.veBan(tu,den).ToList();
            return ds;
        }
        //In vé
        public ObjectResult<ttVe_Result> In_Ve(int maVe)
        {
            var v = db.ttVe(maVe);
            return v;
        }
        //trc khi thêm cần kt tuor này khách hàng đã tùng đặt chưa
        public int? KT_Tour_Khach(VEDAT v)
        {
            int? sl;
            sl = db.sp_ktTourKH(v.MATOUR, v.MAKH).FirstOrDefault();
            
            return sl;
        }

        public void Dat(VEDAT ve)
        {
                ve.NgayDat = DateTime.Now;
                db.VEDAT.Add(ve);
                db.SaveChanges(); 
        }

        public bool Huy(int ma)
        {
            bool timThay = false;
            try
            {
                VEDAT ve = db.VEDAT.Where(s => s.TOUR.NGAYBD > DateTime.Now).First(s => s.MAVE.Equals(ma));
                timThay = true;
                db.VEDAT.Remove(ve);
                db.SaveChanges();
            }
            catch (Exception)
            {

                timThay = false;
            }
            return timThay;
        }
    }
}

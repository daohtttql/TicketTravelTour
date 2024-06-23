using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_Tour_du_lịch.DAO
{
    
    class daoKhachHang
    {
        TravelTourEntities1 db;
        public  daoKhachHang()
        {
            db = new TravelTourEntities1();
        }
        //Lấy dữ liệu đưa vào dataGV
        public dynamic LayDSKH()
        {
            var ds = db.KHACHHANG.Select(s => new
            {
                s.MAKH,
                s.TENKH,
                s.GIOITINH,
                s.DIACHI,
                s.SDT
                
            }).ToList();
            return ds;
        }
        

        //Thêm sửa xóa
        public void Them( KHACHHANG k)
        {
            db.KHACHHANG.Add(k);
            db.SaveChanges();
        }

        public bool Sua(KHACHHANG khach)
        {
            bool timThay = false;
            KHACHHANG d = new KHACHHANG();
            try
            {
                d = db.KHACHHANG.
                        First(s => s.MAKH == khach.MAKH);
                timThay = true;

                d.TENKH = khach.TENKH;
                d.GIOITINH = khach.GIOITINH;
                d.DIACHI = khach.DIACHI;
                d.SDT = khach.SDT;

                db.SaveChanges();
            }
            catch (Exception)
            {

                timThay = false;
            }
            return timThay;
        }
        public void Xoa(int ma)
        {
            KHACHHANG k = db.KHACHHANG.First(s => s.MAKH.Equals(ma));
            db.KHACHHANG.Remove(k);
            db.SaveChanges();
        }
    }
}

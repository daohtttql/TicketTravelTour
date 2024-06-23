using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_Tour_du_lịch.DAO
{
    class daoNhanVien
    {
        TravelTourEntities1 db;
        public daoNhanVien()
        {
            db = new TravelTourEntities1();
        }
        //Lấy dữ liệu đưa vào dataGV
        public dynamic LayDSNV()
        {
            var ds = db.NHANVIEN.Select(s => new
            {
                s.MAHDV,   
                s.TENHDV,
                s.GIOITINH,
                s.DIACHI,
                s.SDT,
            }).ToList();
            return ds;
        }

        //Thêm sửa xóa
        public void Them(NHANVIEN nv)
        {
            db.NHANVIEN.Add(nv);
            db.SaveChanges();
        }
        public bool Sua(NHANVIEN nhanvien)
        {
            bool timThay = false;
            NHANVIEN d = new NHANVIEN();
            try
            {
                d = db.NHANVIEN.
                        First(s => s.MAHDV == nhanvien.MAHDV);
                timThay = true;

                d.TENHDV = nhanvien.TENHDV;
                d.GIOITINH = nhanvien.GIOITINH;
                d.DIACHI = nhanvien.DIACHI;
                d.SDT = nhanvien.SDT;

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
            NHANVIEN n = db.NHANVIEN.First(s => s.MAHDV.Equals(ma));
            db.NHANVIEN.Remove(n);
            db.SaveChanges();
        }
    }
}

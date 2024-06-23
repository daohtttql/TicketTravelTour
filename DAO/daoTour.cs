using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_lý_Tour_du_lịch.DAO
{
    class daoTour
    {
        TravelTourEntities1 db;
        public daoTour()
        {
            db = new TravelTourEntities1();
        }
        //Lấy dữ liệu đưa vào dataGV
        public dynamic LayDS()
        {
            var ds = db.TOUR.Select(s => new
            {
                s.MATOUR,//cột mã là 0
                s.DIEMDI,
                s.DIADIEMDEN,//cột địa điểm,
                s.NGAYBD,
                s.NGAYKT,
                s.GIA,   //cột giá
                s.SOLUONGVE,// cột sl véD,
                s.NHANVIEN.TENHDV,//cột hdv
                //s.HINHANH,
                s.MOTA
            }).ToList();
            return ds;  
        }
        //Lấy dl vào cb
        public dynamic LayDS_NhanVien()
        {
            var ds = db.NHANVIEN.Select(s => new
            {
                s.TENHDV,
                s.MAHDV
            }).ToList();
            return ds;
        }
        public void luuAnh(PictureBox pictureBox, int maTour)
        {
            MemoryStream stream = new MemoryStream();
            pictureBox.Image.Save(stream, ImageFormat.Jpeg);
            TOUR t = db.TOUR.First(s => s.MATOUR.Equals(maTour));
            t.HINHANH = stream.ToArray();
            db.SaveChanges();
        }
        public void layAnh(OpenFileDialog openFileDialogAnh, PictureBox pictureBox)
        {
            openFileDialogAnh.ShowDialog();
            string fN = openFileDialogAnh.FileName;
            if (string.IsNullOrEmpty(fN))
            {
                return;
            }


            Image im = Image.FromFile(fN);
            pictureBox.Image = im;
        }
        public void hienThiAnh(int ma, PictureBox b)
        {
            TOUR t = db.TOUR.First(s => s.MATOUR.Equals(ma));
            MemoryStream stream = new MemoryStream(t.HINHANH.ToArray());
            Image img = Image.FromStream(stream);
            b.Image = img;
        }

        //Thêm sửa xóa
        public void Them(TOUR t)
        {
            db.TOUR.Add(t);
            db.SaveChanges();
        }

        public bool Sua(TOUR t)
        {
            bool timThay = false;
            TOUR d = new TOUR();
            try
            {
                d = db.TOUR.
                        First(s => s.MATOUR == t.MATOUR);
                timThay = true;

                d.MAHDV = t.MAHDV;
                d.DIEMDI = t.DIEMDI;
                d.DIADIEMDEN = t.DIADIEMDEN;
                d.NGAYBD = t.NGAYBD;
                d.NGAYKT = t.NGAYKT;
                d.GIA = t.GIA;
                d.SOLUONGVE = t.SOLUONGVE;
                d.MOTA = t.MOTA;

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
            TOUR t = db.TOUR.First(s => s.MATOUR.Equals(ma));
            db.TOUR.Remove(t);
            db.SaveChanges();
        }
    }                   
}

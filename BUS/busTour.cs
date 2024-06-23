using Quản_lý_Tour_du_lịch.DAO;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lý_Tour_du_lịch.BUS
{
    class busTour
    {
        daoTour da;
        public busTour()
        {
            da = new daoTour();
        }

        public void layDSTour(DataGridView dg)
        {
            dg.DataSource = da.LayDS();
        }
        public void ThucHienLay_dsNV(ComboBox cb)
        {
            cb.DataSource = da.LayDS_NhanVien();
            cb.DisplayMember = "TENHDV";
            cb.ValueMember = "MAHDV";
        }
        public void layAnh(OpenFileDialog openFileDialogAnh, PictureBox pictureBox)
        {
            try
            {
                da.layAnh(openFileDialogAnh, pictureBox);

            }
            catch (Exception e)
            {
                MessageBox.Show("Bạn vẫn chưa chọn ảnh! " + e.Message.ToString());
            }        
        }
        public void luuAnh(PictureBox pictureBox, int t)
        {
            try
            {
                da.luuAnh(pictureBox, t);
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message.ToString());
            }
        }
        public void hienThiAnh(int ma, PictureBox b)
        {
            try
            {
                da.hienThiAnh(ma, b);
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message.ToString());
                return;
            }
        }

            //Them sửa xóa
            public void ThucHienThem(TOUR t)
        {

            try
            {
                da.Them(t);
                MessageBox.Show("Tạo tour thành công ! ");
            }
            catch (Exception e)
            {

                MessageBox.Show("Tạo tour thất bại :(" + e.Message.ToString());
            }
        }

        public void ThucHienSua(TOUR t)
        {
            if (!da.Sua(t))
                MessageBox.Show("Lỗi Không tìm thấy ! :(");
            if (da.Sua(t))
                MessageBox.Show("Sửa chi tiết của tour thành công. :) ");
        }
        public void ThucHienXoa(int ma)
        {
            try
            {
                da.Xoa(ma);
                MessageBox.Show("Xóa thành công. ");
            }
            catch (Exception e)
            {
                MessageBox.Show(" Đã xảy ra lỗi khi xóa đơn hàng! " + e.Message.ToString());
            }
        }
    }
}

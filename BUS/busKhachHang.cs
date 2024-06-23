using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quản_lý_Tour_du_lịch.DAO;

namespace Quản_lý_Tour_du_lịch.BUS
{
    class busKhachHang
    {
        daoKhachHang da;
        public busKhachHang()
        {
            da = new daoKhachHang();
        }
        public void ThucHienLay_dsKH(DataGridView dg)
        {
            dg.DataSource = da.LayDSKH();
        }

        //Them sửa xóa
        public void ThucHienThem(KHACHHANG k)
        {

            try
            {
                da.Them(k);
                MessageBox.Show("Thêm khách hàng thành công ! ");
            }
            catch (Exception e)
            {
                MessageBox.Show("Thêm khách hàng thất bại :(" + e.Message.ToString());
            }
        }

        public void ThucHienSua_KH(KHACHHANG khach)
        {
            if (!da.Sua(khach))
                MessageBox.Show("Lỗi Không tìm thấy khách hàng! :(");
            if (da.Sua(khach))
                MessageBox.Show("Sửa chi tiết khách hàng thành công. :) ");
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

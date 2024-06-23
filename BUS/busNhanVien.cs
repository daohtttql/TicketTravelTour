using Quản_lý_Tour_du_lịch.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_lý_Tour_du_lịch.BUS
{
    class busNhanVien
    {
        daoNhanVien da;
        public busNhanVien()
        {
            da = new daoNhanVien();
        }
        public void ThucHienLay_dsNV(DataGridView dg)
        {
            dg.DataSource = da.LayDSNV();
        }
        

        //Them sửa xóa
        public void ThucHienThem(NHANVIEN t)
        {

            try
            {
                da.Them(t);
                MessageBox.Show("Thêm nhân viên thành công ! ");
            }
            catch (Exception e)
            {

                MessageBox.Show("Thêm nhân viên thất bại :(" + e.Message.ToString());
            }

        }

        public void ThucHienSua_NV(NHANVIEN nhanvien)
        {
            if (!da.Sua(nhanvien))
                MessageBox.Show("Lỗi Không tìm thấy nhân viên này! :(");
            if (da.Sua(nhanvien))
                MessageBox.Show("Sửa chi tiết nhân viên thành công. :) ");
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

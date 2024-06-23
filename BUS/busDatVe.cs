using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_lý_Tour_du_lịch.BUS
{
    class busDatVe
    {
        daoDatVe dao;
        public busDatVe()
        {
            dao = new daoDatVe();
        }

        //hiển thị ảnh
        public void anhTour(int ma, Panel p)
        {
            try
            {
                dao.hienThiAnh(ma, p);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ThucHienLay_dsKH(ComboBox cb)
        {
            cb.DataSource = dao.layDS_KhachHang();
            cb.DisplayMember = "TENKH";
            cb.ValueMember = "MAKH";
        }
        public void ThucHienLay_dsTour(ComboBox cb, Label lbMota, TextBox txtGia)
        {
            cb.DataSource = dao.layDS_Tour();
            cb.DisplayMember = "DIADIEMDEN";
            cb.ValueMember = "MATOUR";

            //biding:
            txtGia.DataBindings.Clear();
            lbMota.DataBindings.Clear();
            txtGia.DataBindings.Add(new Binding("Text", cb.DataSource, "GIA"));
            lbMota.DataBindings.Add(new Binding("Text", cb.DataSource, "MOTA"));

        }

        public void layDSVe(DataGridView dg)
        {
            dg.DataSource = dao.layDS_Ve();
        }
        //Phần Reporting
        public List<veBan_Result> Report_Ve(DateTime tu, DateTime den)
        {
            try
            {
                return dao.report_Ve(tu,den);
            }
            catch (Exception e)
            {
                MessageBox.Show("Không bán được vé nào trong khoảng thời gian từ " + tu.ToString() + " đến " + den.ToString() + "\n" + e.Message.ToString());

                return null;
            }
        }
        //In vé
        public ObjectResult<ttVe_Result> In_Ve(int ma)
        {
            try
            {
                return dao.In_Ve(ma);
            }
            catch (Exception e)
            {
                MessageBox.Show("In vé thất bại " + "\n" + e.Message.ToString());

                return null;
            }
        }
        public void ThucHienThem_Ve(VEDAT ve)
        {

            try
            {
                int? sl = dao.KT_Tour_Khach(ve);
                if (sl == 0)
                {
                    dao.Dat(ve);
                    MessageBox.Show("Đặt vé thành công ! ");
                }
                else
                {
                    DialogResult dlr;
                    dlr = MessageBox.Show("Bạn đã đặt " + sl + " vé này. Bạn có muốn đặt thêm một vé nữa không? ", "Khách hàng đã đặt vé", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(dlr == DialogResult.Yes)
                    {
                        dao.Dat(ve);
                        MessageBox.Show("Đặt vé thành công ! ");
                    }    
                }
            }
            catch (Exception e)
            {

                MessageBox.Show("Đã hết vé :(" + e.Message.ToString());
            }
        }
        public void ThucHienHuy_Ve(int ve)
        {

            if(dao.Huy(ve))
            {
                
                MessageBox.Show("Hủy vé thành công ! ");
            }
            else
            {

                MessageBox.Show("Hủy vé thất bại ! " );
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace QUANLY_HS_GV
{
    public partial class HocSinh : Form
    {
        public HocSinh()
        {
            InitializeComponent();
        }

        bool check = true;

        private void HocSinh_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qUANLY_HS_GVDataSet.HocSinh' table. You can move, or remove it, as needed.
            //this.hocSinhTableAdapter.Fill(this.qUANLY_HS_GVDataSet.HocSinh);
            // TODO: This line of code loads data into the 'qUANLY_HS_GVDataSet1.HocSinh' table. You can move, or remove it, as needed.
            //this.hocSinhTableAdapter1.Fill(this.qUANLY_HS_GVDataSet1.HocSinh);
            // TODO: This line of code loads data into the 'qUANLY_HS_GVDataSet.HocSinh' table. You can move, or remove it, as needed.
            //this.hocSinhTableAdapter.Fill(this.qUANLY_HS_GVDataSet.HocSinh);

        }

        private int KTTrung(string a)
        {
            for (int i = 0; i < dgvHocsinh.Rows.Count; i++)
            {
                if (Convert.ToString(dgvHocsinh.Rows[i].Cells[0].Value) == a)
                {
                    return 1;
                }
            }
            return 2;
        }

        void Reset(object sender, EventArgs e)
        {
            txtIDHs.Text = "";
            txtTenHS.Text = "";
            cboGioitinh.Text = "";
            dtNgaysinh.Text = "";
            cbo_Lop.Text = "";
            cbo_Monhoc.Text = "";
        }

    }
}

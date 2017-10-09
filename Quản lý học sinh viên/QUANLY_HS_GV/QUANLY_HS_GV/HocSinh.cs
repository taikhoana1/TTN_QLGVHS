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

        private void btnShow_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection("Data Source=UBUNTU-PC\\SQLEXPRESS;Initial Catalog=QUANLY_HS_GV;Integrated Security=True");
            SqlConnection con = new SqlConnection(Connect.getconnect());
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    if (check) MessageBox.Show("Load data success!");
                    else MessageBox.Show("Save DataBase success!");
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "LoadHS";
                    com.CommandType = CommandType.StoredProcedure;
                    com.Connection = con;
                    SqlDataAdapter adap = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    adap.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        dgvHocsinh.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Data is empty!");
                        dgvHocsinh.Visible = false;
                    }
                }
                else
                {
                    throw new Exception("Connection crashed!");
                }
            }
            catch
            {

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (KTTrung(txtTenHS.Text) == 1 && check)
            {
                MessageBox.Show("Dữ Liệu nhập thiếu Hoặc Mã Nhập Đã Bị Trùng! Vui Lòng Nhập Lại...");
            }
            else
            {
                //SqlConnection con = new SqlConnection(@"Data Source=(local);Initial Catalog=QUANLY_HS_GV;Integrated Security=True");
                SqlConnection con = new SqlConnection(Connect.getconnect());
                con.Open();
                SqlCommand com = new SqlCommand("Add_HS", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id_hs", txtIDHs.Text.Trim());
                com.Parameters.AddWithValue("@Hoten", txtTenHS.Text.Trim());
                com.Parameters.AddWithValue("@quequan", txtquequan.Text.Trim());
                com.Parameters.AddWithValue("@Gt", cboGioitinh.Text.Trim());
                com.Parameters.AddWithValue("@Ngaysinh", Convert.ToDateTime(dtNgaysinh.Text.Trim()));
                com.Parameters.AddWithValue("@Id_lop", cbo_Lop.Text.Trim());
                com.Parameters.AddWithValue("@Id_monhoc", cbo_Monhoc.Text.Trim());
                com.ExecuteNonQuery();
                com.Dispose();
                btnShow_Click(sender, e);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvHocsinh.SelectedRows.Count == 0)
            {
                MessageBox.Show("Chọn Dòng Cần Sửa!...", "Thông Báo");
            }

            else
            {

                //SqlConnection con = new SqlConnection(@"Data Source=(local);Initial Catalog=QUANLY_HS_GV;Integrated Security=True");
                SqlConnection con = new SqlConnection(Connect.getconnect());
                con.Open();
                SqlCommand com = new SqlCommand("dbo.Edit_HS", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id_hs", txtIDHs.Text.Trim());
                com.Parameters.AddWithValue("@Hoten", txtTenHS.Text.Trim());
                com.Parameters.AddWithValue("@quequan", txtquequan.Text.Trim());
                com.Parameters.AddWithValue("@Gt", cboGioitinh.Text.Trim());
                com.Parameters.AddWithValue("@Ngaysinh", Convert.ToDateTime(dtNgaysinh.Text.Trim()));
                com.Parameters.AddWithValue("@Id_lop", cbo_Lop.Text.Trim());
                com.Parameters.AddWithValue("@Id_monhoc", cbo_Monhoc.Text.Trim());
                com.Parameters.AddWithValue("@kq", 1);
                com.ExecuteNonQuery();
                com.Dispose();
                btnShow_Click(sender, e);
            }
        }

    }
}

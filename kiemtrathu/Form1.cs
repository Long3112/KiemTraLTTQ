using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kiemtrathu
{
    public partial class Form1 : Form
    {
        ProcessDataBase pd = new ProcessDataBase();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            DataGridView();
            dataGridView1.Columns[0].HeaderText = "Mã tác phẩm";
            dataGridView1.Columns[1].HeaderText = "Tên tác phẩm";
            dataGridView1.Columns[2].HeaderText = "Tên tác giả";
            dataGridView1.Columns[3].HeaderText = "Loại";
        }
        public void DataGridView()
        {
            dataGridView1.DataSource = pd.DocBang("select * from KiemTra");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtMaTacPham.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtTenTacPham.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtTenTacGia.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txtLoaiTacPham.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string sql = "insert into KiemTra(MaTP,TenTacPham,TenTacGia,Loai) values"+
                "('" + txtMaTacPham.Text +
                "',N'" + txtTenTacPham.Text +
                "',N'" + txtTenTacGia.Text +
                "',N'" + txtLoaiTacPham.Text + "')";
            pd.CapNhat(sql);
            DataGridView();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int.TryParse(txtMaTacPham.Text, out int maTacPham);
            string sql3 = "update KiemTra "+
              " set TenTacPham='" + txtTenTacPham.Text +"',"+
              " TenTacGia='" + txtTenTacGia.Text + "'," +
              " Loai='" + txtLoaiTacPham.Text + "'" +
              "where MaTP=" + txtMaTacPham.Text ;
            pd.CapNhat(sql3);
            DataGridView();

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaTacPham.Text = "";
            txtTenTacPham.Text = "";
            txtTenTacGia.Text = "";
            txtLoaiTacPham.Text = "";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int.TryParse(txtMaTacPham.Text, out int maTacPham);
           

            string sql = "delete from KiemTra where MaTP='" + txtMaTacPham.Text + "'";

            pd.CapNhat(sql);
            DataGridView();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = pd.DocBang("select * from KiemTra where TenTacPham like'%" + txtTenTacPham.Text + "%'");

          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridView();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlServer_Crud
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void yenile()

        { dataGridView1.DataSource = crud.list("select * from customers"); }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            yenile();
        }
        void temizle()
        {
            foreach (Control item in this.panel2.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }

            }
            dateTimePicker1.Value = DateTime.Now;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = crud.list("select * From Customers Where Adi like'%" + txtAra.Text + "%' or Soyadi like '%" + txtAra.Text + "%'");
        }
        SqlCommand komut;

        private void btnekle_Click(object sender, EventArgs e)
        {
            string sql = "insert into Customers(Adi,Soyadi,Telefon,Maasi,Tarih) values ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtTelefon.Text + "', @Maas,@Tarih'" + "')";
            komut = new SqlCommand();
            crud.ESG(sql, komut);
            komut.Parameters.Add("@Maas", SqlDbType.Decimal).Value = decimal.Parse(txtMaas.Text);
            komut.Parameters.Add("@Tarih", SqlDbType.Date).Value = dateTimePicker1.Value;
            yenile();
            temizle();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtTelefon.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtMaas.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {

            string sql = "update Customers set Adi='"+txtAd.Text+"',Soyadi='"+txtSoyad.Text+"',Telefon = '"+txtTelefon.Text+"',Maasi=@Maasi,Tarih=@Tarih   where ID='"+txtID.Text+"'";
            komut = new SqlCommand();
            crud.ESG(sql, komut);
            komut.Parameters.Add("@Maas", SqlDbType.Decimal).Value = decimal.Parse(txtMaas.Text);
            komut.Parameters.Add("@Tarih", SqlDbType.Date).Value = dateTimePicker1.Value;
            yenile();
            temizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Kayıt silinsin mi?","UYARI",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);


            if (dialog == DialogResult.Yes)
            {
                string sql = "delete from * customers where ID='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                komut = new SqlCommand();
                crud.ESG(sql, komut);
                yenile();
                temizle(); 
            }

        }
    }
}

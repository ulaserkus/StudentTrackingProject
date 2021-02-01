using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentTrackingProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txt_username.Text == "admin" && txt_password.Text == "12345")
            {
                new Dashboard().Show();
            }
            else
            {
                MessageBox.Show("Bilgileri Kontrol ediniz", "Hatalı giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentTrackingProject
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            string fileContent = GetContent();
            string filePath = GetFile();
            File.WriteAllText("students/"+filePath,fileContent);
            MessageBox.Show("Kayıt Başarılı", "Kayıt", MessageBoxButtons.OK,MessageBoxIcon.Information);
            listBox1.Items.Add(txt_name.Text + " " + txt_surname.Text);
        }

        private string GetFile()
        {
            string[] files = Directory.GetFiles("students");
            if (files.Length == 0)
            {
                return "1.txt";
            }
            else
            {
                return (fileStats(files)+1)+".txt";
            }
        }

        private int fileStats(string[] files)
        {
            int biggestNumber = 0;
            foreach (var item in files)
            {
                string last = getLast(item);//2.txt , 3.txt
                int lastNumber = int.Parse(last.Replace(".txt",""));//2 , 3
              
                if (lastNumber>biggestNumber)
                {
                    biggestNumber = lastNumber;
                }

            }

            return biggestNumber;
        }

        private string getLast(string path)
        {
            string[] parts = path.Split('\\');
            return parts[parts.Length - 1];

        }

        private string GetContent()
        {
            string content = txt_name.Text;
            content += Environment.NewLine;
            content += txt_surname.Text;
            content += Environment.NewLine;
            content += comboBox1.Text;
            content += Environment.NewLine;
            content += DateTime.Today.ToShortDateString();
            return content;

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedStudent= (string)listBox1.SelectedItem;
            string[] StudentFiles = Directory.GetFiles("students");
            
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;

            foreach (var item in StudentFiles )
            {
                string[] lines = File.ReadAllLines(item);
                if(lines[0]+" "+ lines[1] == selectedStudent)
                {
                    lbl_name.Text = lines[0];
                    lbl_surname.Text = lines[1];
                    lbl_class.Text = lines[2];
                    break;
                }


            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Öğrenci Seçilmedi");
            }
            else
            {
                string selectedStudent = (string)listBox1.SelectedItem;
                string[] StudentFiles = Directory.GetFiles("students");

                foreach (var item in StudentFiles)
                {
                    string[] lines = File.ReadAllLines(item);
                    if (lines[0] + " " + lines[1] == selectedStudent)
                    {
                        listBox1.Items.Remove(selectedStudent);
                        File.Delete(item);
                        break;
                    }


                }

            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            lbl_name.Text = "";
            lbl_surname.Text = "";
            lbl_class.Text = "";

            string[] Students = Directory.GetFiles("students");
            foreach (var item in Students)
            {
                string[] lines =File.ReadAllLines(item);
                string name = lines[0];
                string surname = lines[1];

                listBox1.Items.Add(name + " " + surname);
            }
        }

        private void btn_clean_Click(object sender, EventArgs e)
        {
            txt_name.Clear();
            txt_surname.Clear();
            comboBox1.Text = null;
        }
    }
    
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG282_1
{
    public partial class UpdateStudent : Form
    {
        public UpdateStudent()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UpdateStudent_Load(object sender, EventArgs e)
        {
            DataHandler dataHandler = new DataHandler();
            DataTable dt = new DataTable();
            dt = dataHandler.GetStudents();
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataHandler dataHandler = new DataHandler();

            string firstname, surname, gender, phone, address, date;
            int studentNumber;

            studentNumber = int.Parse(textBox1.Text);
            firstname = textBox3.Text;
            surname = textBox6.Text;
            gender = domainUpDown1.Text;
            phone = textBox2.Text;
            address = textBox4.Text;
            date = dateTimePicker1.Text;


           Students students = new Students(firstname, surname, gender, phone, address, date, studentNumber);

            dataHandler.UpdateStudents(students);

            MessageBox.Show($"{firstname} {surname} has been updated");
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

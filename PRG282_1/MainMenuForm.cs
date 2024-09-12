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
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddStudent addStudentForm = new AddStudent();
            addStudentForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SearchStudent searchStudent = new SearchStudent();
            searchStudent.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateStudent updateForm = new UpdateStudent();
            updateForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DeleteStudent deleteStudentForm = new DeleteStudent();
            deleteStudentForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            DataHandler dataHandler = new DataHandler();
            DataTable dt = new DataTable();
            dt = dataHandler.GetStudents();
            dataGridView1.DataSource = dt;
        }
    }
}

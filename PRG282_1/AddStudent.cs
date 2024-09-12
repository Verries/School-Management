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

namespace PRG282_1
{
    public partial class AddStudent : Form
    {

        public AddStudent()
        {
            InitializeComponent();
        }

        private void AddStudent_Load(object sender, EventArgs e)
        {
            DataHandler dataHandler = new DataHandler();
            DataTable dt = dataHandler.GetStudents();
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataHandler dataHandler = new DataHandler();

            string firstname, surname, gender, phone, address, dateOfBirth;
            int studentNumber;

            // Parsing inputs from the textboxes
            studentNumber = int.Parse(textBox1.Text);  // Student Number
            if (dataHandler.DoesStudentExist(studentNumber))
            {
                MessageBox.Show($"A student with Student Number {studentNumber} already exists.");
                return; // Exit the method to avoid adding a duplicate
            }

            firstname = textBox3.Text;  // First Name
            surname = textBox6.Text;    // Surname
            gender = domainUpDown1.Text;  // Gender
            phone = textBox2.Text;      // Phone
            address = textBox4.Text;    // Address
            dateOfBirth = dateTimePicker1.Value.ToString("yyyy-MM-dd"); // Date of Birth

            // Create a student object
            Students student = new Students(firstname, surname, gender, phone, address, dateOfBirth, studentNumber); 

            // Save student data using the DataHandler
            dataHandler.AddStudents(student);

            // Display success message
            MessageBox.Show($"{firstname} {surname} has been added to the Database");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

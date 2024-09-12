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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            // Check if both fields are filled
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            // Define the path to the text file
            string path = @"C:\Users\Vernon\Downloads\PRG282_1\TextFiles\Lecturers.txt";

            try
            {
                // Append the new credentials to the file
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine($"{username},{password}");
                }

                MessageBox.Show("Registration successful! You can now log in with your new account.");

                // Optionally, clear the textboxes after successful registration
                textBox1.Clear();
                textBox2.Clear();

                // Close the registration form (optional)
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing to file: {ex.Message}");
            }
        }
    }
}


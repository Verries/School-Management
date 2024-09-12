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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            
            
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string accountName, password;
            string path = @"C:\Users\Vernon\Downloads\PRG282_1\TextFiles\Lecturers.txt";
            List<string> arr = new List<string>();

            DataHandler dataHandler = new DataHandler();
            arr = dataHandler.GetLecturers(path);

            accountName = textBox1.Text;
            password = textBox2.Text;


            BusinessOpperations businessOpperations = new BusinessOpperations();
            if (businessOpperations.ValidateLogin(accountName, password, arr))
            {
                MainMenuForm mainMenuForm = new MainMenuForm();
                mainMenuForm.Show();
           
            }
            else
            {
                MessageBox.Show("Your password is incorrect or your account does not exist");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegisterForm form = new RegisterForm();
            form.Show();
          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

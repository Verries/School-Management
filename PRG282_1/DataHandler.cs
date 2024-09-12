using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG282_1
{
    internal class DataHandler
    {
        private string connection = @"Data Source=DESKTOP-52BRTVJ;Initial Catalog=BelgiumCampusDataBase;Integrated Security=True";

        public DataTable GetStudents()
        {
            try
            {
                string query = @"SELECT * FROM Students";

                SqlDataAdapter sqlAdapter = new SqlDataAdapter(query, connection);

                DataTable dt = new DataTable();
                sqlAdapter.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SearchStudents(int number)
        {
            try
            {
                string query = $"SELECT * FROM Students WHERE StudentNumber = {number}";
                SqlDataAdapter sql = new SqlDataAdapter(query, connection);

                DataTable dt = new DataTable();
                sql.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteStudents(int number)
        {
            try
            {
                string query = $"DELETE FROM Students WHERE StudentNumber = {number}";
                SqlCommand cmd = new SqlCommand(query, new SqlConnection(connection));

                // Open the connection and execute the query
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Student has been deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while deleting the student: " + ex.Message);
            }
        }

        public bool DoesStudentExist(int studentNumber)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                string query = "SELECT COUNT(*) FROM Students WHERE StudentNumber = @StudentNumber";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentNumber", studentNumber);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public void AddStudents(Students students)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                string query = "INSERT INTO Students (StudentNumber, FirstName, Surname, DOB, Gender, Phone, StudentAddress) " +
                               "VALUES (@StudentNumber, @FirstName, @Surname, @DOB, @Gender, @Phone, @StudentAddress)";

                SqlCommand cmd = new SqlCommand(query, conn);

                // Add parameters for student data
                cmd.Parameters.AddWithValue("@StudentNumber", students.StudentNumber);
                cmd.Parameters.AddWithValue("@FirstName", students.Firstname);
                cmd.Parameters.AddWithValue("@Surname", students.Surname);
                cmd.Parameters.AddWithValue("@DOB", students.Date);
                cmd.Parameters.AddWithValue("@Gender", students.Gender);
                cmd.Parameters.AddWithValue("@Phone", students.Phone);
                cmd.Parameters.AddWithValue("@StudentAddress", students.Address);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("An error occurred while adding the student: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void UpdateStudents(Students students)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                string query = "UPDATE Students SET FirstName = @FirstName, Surname = @Surname, DOB = @DOB, " +
                               "Gender = @Gender, Phone = @Phone, StudentAddress = @StudentAddress WHERE StudentNumber = @StudentNumber";

                SqlCommand cmd = new SqlCommand(query, conn);

                // Add parameters with correct column names
                cmd.Parameters.AddWithValue("@StudentNumber", students.StudentNumber);
                cmd.Parameters.AddWithValue("@FirstName", students.Firstname);
                cmd.Parameters.AddWithValue("@Surname", students.Surname);
                cmd.Parameters.AddWithValue("@DOB", students.Date); // Assuming the Date is already in correct format
                cmd.Parameters.AddWithValue("@Gender", students.Gender);
                cmd.Parameters.AddWithValue("@Phone", students.Phone);
                cmd.Parameters.AddWithValue("@StudentAddress", students.Address);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student has been updated successfully");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("An error occurred while updating the student: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public List<string> GetLecturers(string path)
        {
            List<string> arr = new List<string>();
            try
            {
                if (!File.Exists(path))
                {
                    MessageBox.Show("File not found: " + path);
                    return arr;
                }

                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        arr.Add(line);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading file: {ex.Message}");
            }

            return arr;
        }

        public void AddLecturers(string path, List<string> arr)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (string line in arr)
                {
                    writer.WriteLine(line);
                }
            }
            MessageBox.Show("Account Registered");
        }
    }
}

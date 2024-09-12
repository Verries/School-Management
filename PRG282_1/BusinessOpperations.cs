using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG282_1
{
    internal class BusinessOpperations
    {
        public Boolean Validate(string pass1, string pass2)
        {

            if (pass1 == pass2)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public Boolean ValidateLogin(string acc, string pass, List<string> arr)
        {

            foreach (string line in arr)
            {
                // Split the line by the comma to get the username and password
                string[] credentials = line.Split(',');

                if (credentials.Length == 2) // Ensure the line has both username and password
                {
                    string storedAcc = credentials[0];
                    string storedPass = credentials[1];

                    // Compare the provided username and password with the stored ones
                    if (acc == storedAcc && pass == storedPass)
                    {
                        return true; // Login successful
                    }
                }
            }

            return false; // Login failed (no match found)
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace StudentData
{
    public partial class Form3 : Form
    {
        string StudentName;
        string EnrollNo;
        string Sem;
        string Dob;
        string contact;
        string Email;
        string Spi;
        private OleDbConnection connection = new OleDbConnection();

        public Form3()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ASHWATHY. J. NAIR\Documents\StudentForm.accdb;
Persist Security Info=False;";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query="select * from StudentDetail where Enrollment='" + textBox2.Text + "'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                reader.Read();
                StudentName = reader.GetString(0);
                EnrollNo = reader.GetString(1);
                Sem = reader.GetString(2);
                Dob = reader.GetString(3);
                contact = reader.GetString(4);
                Email = reader.GetString(5);
                Spi = reader.GetString(6);
                MessageBox.Show("Student Name:" + StudentName + "\n" + "Enrollment No:" + EnrollNo + "\n" + "Semester:" + Sem + "\n" + "DOB:" + Dob + "\n" + "Contact:" + contact + "\n" + "Email:" + Email + "\n" + "Spi:" + Spi);
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

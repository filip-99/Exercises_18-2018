using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercises_18_2018
{
    public partial class Form1 : Form
    {
        private string konekcijaString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=FacultyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                sqlConnection.ConnectionString = konekcijaString;

                List<ExerciseResult> listaStudenata = new List<ExerciseResult>();


                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM ExerciseResults";
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    ExerciseResult student = new ExerciseResult();
                    student.Id = sqlDataReader.GetInt32(0);
                    student.StudentName = sqlDataReader.GetString(1);
                    student.StudentIndex = sqlDataReader.GetString(2);
                    student.Points = sqlDataReader.GetInt32(3);
                    listaStudenata.Add(student);
                }

                sqlConnection.Close();

                foreach (ExerciseResult er in listaStudenata)
                {
                    listBoxExerciseResults.Items.Add(er.Id + "\t" + er.StudentName + "\t" + er.StudentIndex + "\t" + er.Points);
                }
            }
            catch
                {
                MessageBox.Show("Greska pri konekciji");
                }
            finally
            {
                sqlConnection.Close();
            }

        }
       

        

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI_Assignment_2.Domain;
using System.Data;
using Microsoft.Data.SqlClient;

namespace UI_Assignment_2.TechnicalServices
{
    public class Students
    {
        public bool AddStudent(Student acceptedStudent, string programCode)
        {
            bool Success = false;

            SqlConnection MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False;Integrated Security=True;Database=ptrninkov1;server=(localDB)\MSSQLLocalDB;";
            MyDataSource.Open();

            SqlCommand AddCommand = new()
            {
                Connection = MyDataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "AddStudent"
            };

            SqlParameter AddCommandParameter = new()
            {
                ParameterName = "@StudentID",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = acceptedStudent.StudentID
            };

            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new()
            {
                ParameterName = "@FirstName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = acceptedStudent.FirstName
            };

            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new()
            {
                ParameterName = "@LastName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = acceptedStudent.LastName
            };

            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new()
            {
                ParameterName = "@Email",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = acceptedStudent.Email
            };

            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommandParameter = new()
            {
                ParameterName = "@ProgramCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = programCode
            };

            AddCommand.Parameters.Add(AddCommandParameter);

            AddCommand.ExecuteNonQuery();

            Success = true;

            MyDataSource.Close();
            return Success;
        }

        public Student GetStudent(string studentID)
        {
            Student EnrolledStudent = new();
            SqlConnection DataSource = new();
            DataSource.ConnectionString = @"Persist Security Info=False;Integrated Security=True;Database=ptrninkov1;server=(LocalDB)\MSSQLLocalDB";
            DataSource.Open();

            SqlCommand GetStudent = new()
            {
                Connection = DataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetStudent"
            };

            SqlParameter GetStudentParameter = new()
            {
                ParameterName = "StudentID",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = studentID
            };
            GetStudent.Parameters.Add(GetStudentParameter);

            SqlDataReader DataReader = GetStudent.ExecuteReader();

            if (DataReader.HasRows)
            {
                DataReader.Read();

                EnrolledStudent.StudentID = DataReader["StudentID"].ToString();
                EnrolledStudent.FirstName = DataReader["FirstName"].ToString();
                EnrolledStudent.LastName = DataReader["LastName"].ToString();
                EnrolledStudent.Email = DataReader["Email"].ToString();
                EnrolledStudent.ProgramCode = DataReader["ProgramCode"].ToString();
            }

            DataReader.Close();
            DataSource.Close();
            return EnrolledStudent;
        }

        public bool UpdateStudent(Student enrolledStudent)
        {
            bool Success = false;
            SqlConnection DataSource = new();
            DataSource.ConnectionString = @"Persist Security Info=False;Integrated Security=True;Database=ptrninkov1;server=(LocalDB)\MSSQLLocalDB";
            DataSource.Open();

            SqlCommand UpdateStudent = new()
            {
                Connection = DataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "UpdateStudent"
            };

            SqlParameter UpdateStudentParameter = new()
            {
                ParameterName = "StudentID",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = enrolledStudent.StudentID
            };
            UpdateStudent.Parameters.Add(UpdateStudentParameter);

            UpdateStudentParameter = new()
            {
                ParameterName = "FirstName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = enrolledStudent.FirstName
            };
            UpdateStudent.Parameters.Add(UpdateStudentParameter);

            UpdateStudentParameter = new()
            {
                ParameterName = "LastName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = enrolledStudent.LastName
            };
            UpdateStudent.Parameters.Add(UpdateStudentParameter);

            UpdateStudentParameter = new()
            {
                ParameterName = "Email",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = enrolledStudent.Email
            };
            UpdateStudent.Parameters.Add(UpdateStudentParameter);

            UpdateStudent.ExecuteNonQuery();

            Success = true;

            DataSource.Close();
            return Success;
        }

        public bool DeleteStudent(string studentID)
        {
            bool Success = false;
            SqlConnection DataSource = new();
            DataSource.ConnectionString = @"Persist Security Info=False;Integrated Security=True;Database=ptrninkov1;server=(LocalDB)\MSSQLLocalDB";
            DataSource.Open();

            SqlCommand DeleteStudent = new()
            {
                Connection = DataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "DeleteStudent"
            };

            SqlParameter DeleteStudentParameter = new()
            {
                ParameterName = "StudentID",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = studentID
            };
            DeleteStudent.Parameters.Add(DeleteStudentParameter);

            DeleteStudent.ExecuteNonQuery();

            Success = true;
            DataSource.Close();
            return Success;
        }

        public List<Student> GetStudents(string programCode)
        {
            List<Student> EnrolledStudents = new List<Student>();

            SqlConnection DataSource = new();
            DataSource.ConnectionString = @"Persist Security Info=False;Integrated Security=True;Database=ptrninkov1;server=(LocalDB)\MSSQLLocalDB";
            DataSource.Open();

            SqlCommand GetStudents = new()
            {
                Connection = DataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetStudentsByProgram"
            };

            SqlParameter GetStudentsParameter = new()
            {
                ParameterName = "ProgramCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = programCode
            };
            GetStudents.Parameters.Add(GetStudentsParameter);

            SqlDataReader DataReader = GetStudents.ExecuteReader();

            if (DataReader.HasRows)
            {
                while (DataReader.Read())
                {

                    Student TempStudent = new();

                    TempStudent.FirstName = (string)DataReader["FirstName"];
                    TempStudent.LastName = (string)DataReader["LastName"];
                    TempStudent.Email = String.IsNullOrEmpty(DataReader["Email"].ToString()) ? "N/A" : (string)DataReader["Email"];

                    EnrolledStudents.Add(TempStudent);

                }
            }

            DataReader.Close();
            DataSource.Close();
            return EnrolledStudents;
        }
    }
}

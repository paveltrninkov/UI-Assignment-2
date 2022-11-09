using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using UI_Assignment_2.Domain;

namespace UI_Assignment_2.TechnicalServices
{
    public class Programs
    {
        public bool AddProgram(string programCode, string descripition)
        {
            bool Success = false;
            SqlConnection DataSource = new();
            DataSource.ConnectionString = @"Persist Security Info=False;Integrated Security=True;Database=ptrninkov1;server=(localDB)\MSSQLLocalDB";
            DataSource.Open();

            SqlCommand AddProgram = new()
            {
                Connection = DataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "AddProgram"
            };

            SqlParameter AddProgramParameter = new()
            {
                ParameterName = "ProgramCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = programCode
            };
            AddProgram.Parameters.Add(AddProgramParameter);

            AddProgramParameter = new()
            {
                ParameterName = "Description",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = descripition
            };
            AddProgram.Parameters.Add(AddProgramParameter);

            AddProgram.ExecuteNonQuery();
            Success = true;

            DataSource.Close();
            return Success;
        }

        public Domain.Program GetProgram(string programCode)
        {
            SqlConnection DataSource = new();
            DataSource.ConnectionString = @"Persist Security Info=False;Integrated Security=True;Database=ptrninkov1;server=(LocalDB)\MSSQLLocalDB";
            DataSource.Open();

            SqlCommand GetProgram = new()
            {
                Connection = DataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetProgram"
            };

            SqlParameter GetProgramParameter = new()
            {
                ParameterName = "ProgramCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = programCode
            };
            GetProgram.Parameters.Add(GetProgramParameter);

            Students StudentManager = new();
            List<Student> EnrolledStudents = new List<Student>();
            EnrolledStudents = StudentManager.GetStudents(programCode);

            Domain.Program ActiveProgram = new();
            ActiveProgram.Description = GetProgram.ExecuteScalar().ToString();
            ActiveProgram.ProgramCode = programCode;

            foreach (Student student in EnrolledStudents)
            {
                ActiveProgram.EnrolledStudents.Add(student);
            }


            DataSource.Close();
            return ActiveProgram;
        }
    }
}

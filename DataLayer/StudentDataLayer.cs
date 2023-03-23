using Assignment.DapperContext;
using Assignment.Models;
using Dapper;
using System.Data;

namespace Assignment.DataLayer
{
    public class StudentDataLayer
    {
        private readonly StudentDbContext context;

        public StudentDataLayer(IConfiguration configuration)
        {
            this.context = new StudentDbContext(configuration);
        }

        public IEnumerable<Student> GetStudents()
        {
            var query = "SELECT * FROM student";

            using (var connection = context.CreateConnection())
            {
                var students = connection.Query<Student>(query);
                return students.ToList();
            }
        }

        public bool CreateStudent(Student student)
        {
            bool output = false;
            var query = "INSERT INTO Student (s_name, s_age, s_address, s_mobno, s_gender, s_dob) " +
                "VALUES (@Name, @Age, @Address, @Mobno, @Gender, @Dob)";

            var parameters = new DynamicParameters();
            parameters.Add("Name", student.s_name, DbType.String);
            parameters.Add("Address", student.s_address, DbType.String);
            parameters.Add("Age", student.s_age, DbType.String);
            parameters.Add("Mobno", student.s_mobno, DbType.String);
            parameters.Add("Gender", student.s_gender, DbType.String);
            parameters.Add("Dob", student.s_dob, DbType.Date);

            using (var connection = context.CreateConnection())
            {
                var result = connection.Execute(query, parameters); 
                output = result > 0 ? true : false;
            }
            return output;
        }

        public bool UpdateStudent(int id, Student student)
        {
            bool output = false;
            var query = "Update Student set s_name = @Name, s_age = @Age, s_address = @Address,s_mobno = @Mobno,s_gender= @Gender," +
                "s_dob= @Dob  WHERE s_id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Name", student.s_name, DbType.String);
            parameters.Add("Address", student.s_address, DbType.String);
            parameters.Add("Age", student.s_age, DbType.String);
            parameters.Add("Mobno", student.s_mobno, DbType.String);
            parameters.Add("Gender", student.s_gender, DbType.String);
            parameters.Add("Dob", student.s_dob, DbType.Date);
            parameters.Add("Id", id, DbType.Int32);
            using (var connection = context.CreateConnection())
            {
                var result = connection.Execute(query, parameters);
                output = result > 0 ? true : false;
            }
            return output;
        }
        public bool DeleteStudent(int id)
        {

            bool output = false;
            var query = "DELETE FROM Student WHERE s_Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            using (var connection = context.CreateConnection())
            {
                var result = connection.Execute(query, parameters);
                output = result > 0 ? true : false;
            }
            return output;
        }
    }
}

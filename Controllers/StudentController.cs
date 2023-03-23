using Assignment.DataLayer;
using Assignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDataLayer studentDataLayer;
        public StudentController(IConfiguration configuration)
        {
            studentDataLayer = new StudentDataLayer(configuration);
        }

        [HttpGet]
        public IEnumerable<Student> GetStudents()
        {
            return studentDataLayer.GetStudents();
        }


        [HttpPost]
        public string CreateStudent(Student student)
        {
            if (studentDataLayer.CreateStudent(student))
                return "Data Inserted Successfully";
            else
                return "Data Insertion Failed";
        }


        [HttpPut]
        public string UpdateStudent([FromBody]Student student,[FromQuery] int id)
        {
            if(studentDataLayer.UpdateStudent(id, student))
                return "Data Updated Successfully";
            else
                return "Data Updation Failed";
        }


        [HttpDelete]
        public string DeleteStudent([FromQuery]int id)
        {
            if (studentDataLayer.DeleteStudent(id))
                return "Data Deleted Successfully";
            else
                return "Data Deletion Failed";
        }



    }
}

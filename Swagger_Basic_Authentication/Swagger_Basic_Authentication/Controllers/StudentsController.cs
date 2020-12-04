using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swagger_Basic_Authentication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Swagger_Basic_Authentication.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        List<Student> lstStudent = new List<Student>();

        public StudentsController()
        {
            lstStudent = new List<Student>();
            for (int i = 0; i < 9; i++)
            {
                lstStudent.Add(new Student()
                {
                    StudentId = i,
                    Name = "Student" + i,
                    Roll = "Roll" + i,
                    Message = "Message" + i

                });

            }

        }
        // GET: api/<StudentsController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return lstStudent;
        }


    }
}

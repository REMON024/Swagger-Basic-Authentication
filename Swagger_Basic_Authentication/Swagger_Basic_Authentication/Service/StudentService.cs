using Swagger_Basic_Authentication.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swagger_Basic_Authentication.Service
{
    public class StudentService : IStudentService
    {
        public bool checkUser(string username, string password)
        {
            return username.Equals("remon") && password.Equals("123456");
        }
    }
}

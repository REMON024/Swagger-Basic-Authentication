using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swagger_Basic_Authentication.IService
{
    public interface IStudentService
    {
        bool checkUser(string username, string password);
    }
}

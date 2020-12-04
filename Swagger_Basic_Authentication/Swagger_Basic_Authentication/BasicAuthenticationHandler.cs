using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swagger_Basic_Authentication.IService;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System.Text.Encodings.Web;

namespace Swagger_Basic_Authentication
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public readonly IStudentService _studentService;

        public BasicAuthenticationHandler(
            IStudentService studentService,
            IOptionsMonitor<AuthenticationSchemeOptions> optionsMonitor,
            ILoggerFactory loggerFactory,
            UrlEncoder urlEncoder,
            ISystemClock systemClock

            ) : base(optionsMonitor, loggerFactory, urlEncoder, systemClock)
        {
            _studentService = studentService;

        }
        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            throw new NotImplementedException();
        }
    }
}

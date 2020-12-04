using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swagger_Basic_Authentication.IService;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System.Text.Encodings.Web;
using System.Net.Http.Headers;
using System.Text;
using System.Security.Claims;

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

        protected override Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            Response.Headers["WWW-Authenticate"] = "Basic";
            return base.HandleChallengeAsync(properties);
        }
        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string username = null;
            try
            {
                var authheader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authheader.Parameter)).Split(':');
                username = credentials[0];
                var password = credentials[1];
                if (!_studentService.checkUser(username, password))
                {
                    throw new ArgumentException("invalid username or password");
                }
            }
            catch (Exception ex)
            {
                return AuthenticateResult.Fail(ex.Message);

            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name,username)
            };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);


            return AuthenticateResult.Success(ticket);
        }
    }
}

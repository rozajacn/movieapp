using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace MoviesApp.Api
{
    public class HardcodedTokenAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private const string HardcodedToken = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public HardcodedTokenAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // Get the token from the request
            string token = Request.Headers["Authorization"];

            // Validate the token
            if (token == null || token != $"Bearer {HardcodedToken}")
            {
                return AuthenticateResult.Fail("Invalid token");
            }

            // Create claims for the authenticated user
            var claims = new[] { new Claim(ClaimTypes.Name, "authenticated-user") };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}


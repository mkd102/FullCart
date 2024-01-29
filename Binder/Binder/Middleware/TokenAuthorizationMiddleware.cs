using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace Binder.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class TokenAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenAuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {

            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token == null)
            {
                return _next(context);
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("ABC@123456789Feb2024");

            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = (jwtToken.Claims.First(x => x.Type == "unique_name").Value);
            if (!String.IsNullOrEmpty(userId))
                context.Items["User"] = userId;


            return _next(context);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class TokenAuthorizationMiddlewareExtensions
    {
        public static IApplicationBuilder UseTokenAuthorizationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TokenAuthorizationMiddleware>();
        }
    }
}

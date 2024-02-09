using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RocketseatAuctionAPI.Repositories;

namespace RocketseatAuctionAPI.Filters;

public class AuthenticationUserAttributes : AuthorizeAttribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        try
        {
            var token = TokenOnRequest(context.HttpContext);
            var repository = new RockeatseatAuctionDbContext();
            var email = FromBase64(token);

            var exist = repository.Users.Any(user => user.Email.Equals(email));
            if (!exist)
            {
                context.Result = new UnauthorizedObjectResult("Email not valid.");
            }
        }
        catch (Exception ex)
        {
            context.Result = new UnauthorizedObjectResult(ex.Message);
        }
        
    }

    private string TokenOnRequest(HttpContext context)
    {
        var authorization = context.Request.Headers.Authorization.ToString();
        if (string.IsNullOrEmpty(authorization))
        {
            throw new Exception("Token is missing.");
        }
        return authorization["Bearer ".Length..];
    }

    private string FromBase64(string Base64)
    {
        var data = Convert.FromBase64String(Base64);

        return System.Text.Encoding.UTF8.GetString(data);
    }
}

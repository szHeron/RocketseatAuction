using RocketseatAuctionAPI.Entities;
using RocketseatAuctionAPI.Repositories;

namespace RocketseatAuctionAPI.Services;

public class LoggedUser
{
    private readonly IHttpContextAccessor _httpContext;

    public LoggedUser(IHttpContextAccessor context) 
    {
        _httpContext = context;
    }

    public User User()
    {
        var repository = new RockeatseatAuctionDbContext();

        var token = TokenOnRequest();
        var email = FromBase64(token);

        return repository.Users.First(user => user.Email.Equals(email));
    }
    private string TokenOnRequest()
    {
        var authorization = _httpContext.HttpContext!.Request.Headers.Authorization.ToString();

        return authorization["Bearer ".Length..];
    }

    private string FromBase64(string Base64)
    {
        var data = Convert.FromBase64String(Base64);

        return System.Text.Encoding.UTF8.GetString(data);
    }
}

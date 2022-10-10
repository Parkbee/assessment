using Microsoft.AspNetCore.Authentication;

namespace ApI.Middleware;

public class ApiKeyAuthenticationOptions : AuthenticationSchemeOptions
{
    public const string DefaultScheme = "ClientKey";
        public const string HeaderName = "x-api-key";
}
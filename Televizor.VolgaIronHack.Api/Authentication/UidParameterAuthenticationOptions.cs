using Microsoft.AspNetCore.Authentication;


namespace Televizor.VolgaIronHack.Authentication;

public class UidParameterAuthenticationOptions : AuthenticationSchemeOptions
{
    public string ParameterName { get; set; }
    
    public UidParameterSource ParameterSource { get; set; }
}
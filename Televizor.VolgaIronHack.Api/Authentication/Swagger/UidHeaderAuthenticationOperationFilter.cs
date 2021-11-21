using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Televizor.VolgaIronHack.Authentication.Swagger;

public class UidHeaderAuthenticationOperationFilter : IOperationFilter
{
    private UidParameterAuthenticationOptions _options;

    public UidHeaderAuthenticationOperationFilter(IOptionsMonitor<UidParameterAuthenticationOptions> options)
        => _options = options.CurrentValue;

    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        operation.Parameters ??= new List<OpenApiParameter>();
        
        operation.Parameters.Add(new OpenApiParameter
        {
            Name = _options.ParameterName,
            In = _options.ParameterSource switch
            {
                UidParameterSource.Header => ParameterLocation.Header,
                UidParameterSource.Cookie => ParameterLocation.Cookie,
                UidParameterSource.Query => ParameterLocation.Query,
                _ => throw new ArgumentOutOfRangeException()
            },
            AllowEmptyValue = false,
            Description = "User ID",
        });
    }
}
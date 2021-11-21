using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Televizor.VolgaIronHack.Authentication;
using Televizor.VolgaIronHack.Authentication.Swagger;
using Televizor.VolgaIronHack.Entities;
using Televizor.VolgaIronHack.Users;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICurrentUserProvider, CurrentUserProvider>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.OperationFilter<UidHeaderAuthenticationOperationFilter>());
builder.Services.AddHttpContextAccessor();
builder.Services.AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<Program>());
builder.Services.AddAutoMapper(options => options.AddMaps(typeof(Program)));
builder.Services.AddLogging(options => options.AddDebug());

builder.Services.AddDbContextPool<VolgaIronHackDbContext>(options => options.UseNpgsql(
    new NpgsqlConnectionStringBuilder
        {
            Host = "localhost",
            Port = 5432,
            Database = "rzd_delivery",
            Username = "postgres",
            Password = "postgres"
        }
        .ConnectionString));


builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultScheme = UidHeaderAuthentication.Scheme;
    })
    .AddScheme<UidParameterAuthenticationOptions, UidHeaderAuthenticationHandler<User>>(
        UidHeaderAuthentication.Scheme, opts =>
        {
            opts.ParameterSource = UidParameterSource.Query;
            opts.ParameterName = "X-User-Id";
        });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
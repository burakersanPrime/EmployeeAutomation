
using Microsoft.EntityFrameworkCore;
using em.Persistence.Context;
using em.Application.Interface;
using EmployeeAutomation.Health;
using System.Reflection;
using Newtonsoft.Json;
using EmployeeAutomation.Controllers;
using em.Application.AuthInterface;
using em.Persistence.AuthRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Configuration;
using System.Data.Entity;
using System.Text;
using Microsoft.OpenApi.Models;
using System.Security;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using AutoWrapper;

namespace EmployeeAutomation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //-
            var builder = WebApplication.CreateBuilder(args);

            Log.Logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(builder.Configuration)
                    .Enrich.FromLogContext()
                    .CreateLogger();
            builder.Host.UseSerilog(Log.Logger);
            

            //-

            // Add services to the container.       

            builder.Services.AddControllers();

            builder.Services.AddHealthChecks().AddCheck<HealthCheck>("HealthCheck");


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });   //Add.swaggergen içini doldurucaz.





            builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();
            builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddTransient<IPermissionRepository, PermissionRepository>();
            builder.Services.AddTransient<IReasonRepository, ReasonRepository>();
            builder.Services.AddTransient<IRolesRepository, RolesRepository>();
            builder.Services.AddTransient<IAuthorizedPersonRepository, AuthorizedPersonRepository>();
            builder.Services.AddTransient<ILoginRepository, LoginRepository>();

            builder.Services.AddMvc()
           .AddNewtonsoftJson(
            options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });


            builder.Services.AddDbContext<conDBContext>(o =>
            {
                o.UseSqlServer("Data Source=DESKTOP-C7O29VT\\SQLEXPRESS;Initial Catalog=PersonelOtomasyon;Integrated Security=True");
            });


            builder.Services.AddAuthentication().AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                    builder.Configuration.GetSection("AppSettings:Token").Value!))
                };
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.MapHealthChecks("_health");

            app.UseApiResponseAndExceptionWrapper();

            app.Run();
        }
    }
}
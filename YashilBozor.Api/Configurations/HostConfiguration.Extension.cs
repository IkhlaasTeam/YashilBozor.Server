using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;
using YashilBozor.Api.Middlewares;
using YashilBozor.Api.Models;
using YashilBozor.DAL.DbContexts;
using YashilBozor.DAL.IRepositories.Categories;
using YashilBozor.DAL.IRepositories.Categories.Assets;
using YashilBozor.DAL.IRepositories.Commons;
using YashilBozor.DAL.IRepositories.Users;
using YashilBozor.DAL.Repositories.Categories;
using YashilBozor.DAL.Repositories.Categories.Assets;
using YashilBozor.DAL.Repositories.Common;
using YashilBozor.DAL.Repositories.Users;
using YashilBozor.Service.Commons.Settings;
using YashilBozor.Service.Interfaces.Categories;
using YashilBozor.Service.Interfaces.Categories.Assets;
using YashilBozor.Service.Interfaces.Identity;
using YashilBozor.Service.Services.Categories;
using YashilBozor.Service.Services.Categories.Assets;
using YashilBozor.Service.Services.Identity;

namespace HHD.API.Configurations;

public static partial class HostConfiguration
{
    private static readonly ICollection<Assembly> Assemblies;

    static HostConfiguration()
    {
        Assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load).ToList();
        Assemblies.Add(Assembly.GetExecutingAssembly());
    }

    private static WebApplicationBuilder AddValidators(this WebApplicationBuilder builder)
    {
        builder.Services.AddValidatorsFromAssemblies(Assemblies);

        //validating
        builder.Services
            .Configure<ValidationSettings>(builder.Configuration.GetSection(nameof(ValidationSettings)));

        //verification
        builder.Services
            .Configure<VerificationSettings>(builder.Configuration.GetSection(nameof(VerificationSettings)));

        //identity
        builder.Services
            .Configure<JwtSettings>(builder.Configuration.GetSection(nameof(JwtSettings)));

        //notification
        builder.Services
            .Configure<SmtpSettings>(builder.Configuration.GetSection(nameof(SmtpSettings)));

        return builder;
    }

    private static WebApplicationBuilder AddMappers(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(Assemblies);

        return builder;
    }

    private static WebApplicationBuilder AddBusinessLogic(this WebApplicationBuilder builder)
    {
        var s = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        //Identity
        builder.Services
            .AddScoped<IPasswordHasherService, PasswordHasherService>();

        //Services
        builder.Services
            .AddScoped<ICategoryService, CategoryService>()
            .AddScoped<IProductService, ProductService>()
            .AddScoped<IProductAssetService, ProductAssetService>();

        //Reposiotories
        builder.Services
            .AddScoped(typeof(IRepository<>), typeof(Repository<>))
            .AddScoped<ICategoryRepository, CategoryRepository>()
            .AddScoped<IProductService, ProductService>()
            .AddScoped<IProductAssetRepository, ProductAssetRepository>()
            .AddScoped<IProductRepository, ProductRepository>();



        return builder;
    }

    private static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        
        builder.Services.AddControllers().AddNewtonsoftJson();//options =>
        //{
        //    options.Conventions.Add(new RouteTokenTransformerConvention(
        //                                        new ConfigurationApiUrlName()));
        //}

        return builder;
    }

    private static WebApplicationBuilder AddCors(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(
            options => { 
                options.AddDefaultPolicy(
                policyBuilder => 
                { 
                    policyBuilder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader(); 
                }
                ); 
            }
        );

        return builder;
    }
    private static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        return builder;
    }

    private static WebApplicationBuilder AddLogger(this WebApplicationBuilder builder)
    {
        var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .Enrich.FromLogContext()
            .CreateLogger();

        builder.Logging.ClearProviders();

        builder.Logging.AddSerilog(logger);

        return builder;
    }
    private static WebApplicationBuilder AddConfigurationApiUrlName(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers(options =>
        {
            options.Conventions.Add(new RouteTokenTransformerConvention(
                                                new ConfigurationApiUrlName()));
        });

        return builder;
    }
    private static WebApplication UseExposers(this WebApplication app)
    {
        app.MapControllers();

        return app;
    }

    private static WebApplication UseDevTools(this WebApplication app) 
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }

    private static WebApplication UseCustomMiddleWare(this WebApplication app)
    {
        app.UseMiddleware<ExceptionHandlerMiddleWare>();
        return app;
    }
}

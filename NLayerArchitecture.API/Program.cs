using DataHub.Repository.Repositories;
using DataHub.Repository.UnitOfWorks;
using DataHub.Repository;
using DataHub.Service.Mapping;
using DataHub.Service.Services;
using Microsoft.EntityFrameworkCore;
using NLayerArchitecture.Core.Repositories;
using NLayerArchitecture.Core.Services;
using NLayerArchitecture.Core.UnitOfWorks;
using System.Reflection;
using NLayerArchitecture.Repository.Repositories;
using NLayerArchitecture.Service.Services;
using FluentValidation.AspNetCore;
using NLayerArchitecture.Service.Validations;
using NLayerArchitecture.API.Filters;
using Microsoft.AspNetCore.Mvc;
using NLayerArchitecture.API.Middlewares;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using NLayerArchitecture.API.Modules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribute())).AddFluentValidation(x =>
x.RegisterValidatorsFromAssemblyContaining<CompanyDtoValidator>());

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(NotFoundFilter<>));

builder.Services.AddAutoMapper(typeof(MapProfile));


builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), options =>
    {
        options.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});

builder.Host.UseServiceProviderFactory
    (new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCustomExpection();

app.UseAuthorization();

app.MapControllers();

app.Run();

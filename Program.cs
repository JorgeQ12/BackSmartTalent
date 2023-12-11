using BackSmartTalent;
using BackSmartTalent.Application.Services.Interfaces.Login;
using BackSmartTalent.Application.Services.Interfaces.ManagementAdmin;
using BackSmartTalent.Application.Services.Interfaces.ManangementTravel;
using BackSmartTalent.Application.Services.Login;
using BackSmartTalent.Application.Services.ManagementAdmin;
using BackSmartTalent.Application.Services.ManangementTravel;
using BackSmartTalent.Automapper;
using BackSmartTalent.Domain.Services.Interfaces.Login;
using BackSmartTalent.Domain.Services.Interfaces.ManangementTravel;
using BackSmartTalent.Domain.Services.Login;
using BackSmartTalent.Domain.Services.ManangementTravel;
using BackSmartTalent.Resources;
using BackSmartTalent.Validators;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Ruta al archivo XML de documentación
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    // Incluir el archivo XML de documentación en Swagger
    c.IncludeXmlComments(xmlPath);
});
builder.Services.AddAutoMapper(typeof(GlobalMapper));
builder.Services.AddDbContext<DbContextSmartTalent>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConeccionSQL")));

builder.Services.AddScoped<ILoginAppServices, LoginAppServices>();
builder.Services.AddScoped<ILoginDomainServices, LoginDomainServices>();

builder.Services.AddScoped<IManagementAdminAppServices, ManagementAdminAppServices>();
builder.Services.AddScoped<IManagementAdminDomainServices, ManagementAdminDomainServices>();

builder.Services.AddScoped<IManangementTravelAppServices, ManangementTravelAppServices>();
builder.Services.AddScoped<IManangementTravelDomainServices, ManangementTravelDomainServices>();

builder.Services.AddTransient<GlobalValidator>();
builder.Services.AddTransient<SendEmail>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

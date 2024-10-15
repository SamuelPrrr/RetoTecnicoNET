using RetoTecnico.Automappers;
using RetoTecnico.DTOs;
using RetoTecnico.Models;
using RetoTecnico.Repository;
using RetoTecnico.Services;
using RetoTecnico.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


//Mappers
builder.Services.AddAutoMapper(typeof(MappingProfile));

//Inyeccion de Repositorios

builder.Services.AddScoped<IRepository<Cliente>, ClienteRepository>();

// Add services to the container.
builder.Services.AddScoped<ICommonService<ClienteDto, ClienteInsertDto, ClienteUpdateDto>, ClienteService>();



//Validators                      //modelo a validar  //Validador
builder.Services.AddScoped<IValidator<ClienteInsertDto>, ClienteInsertValidator>();
builder.Services.AddScoped<IValidator<ClienteUpdateDto>, ClienteUpdateValidator>();

// Añadir controladores
builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();



//Conexion:
//Inyección de contexto por Entity Framework que se encarga de mapear una base de datos
builder.Services.AddDbContext<DBContext>(options=>
{
    //Aqui estamos usando MySQL no SQL Server
    options.UseMySql(builder.Configuration.GetConnectionString("DBConnection"),
    // se utiliza para detectar automáticamente la versión del servidor MySQL al que te estás conectando, lo cual es útil para que el proveedor de Entity Framework Core pueda optimizar la configuración de la conexión y el comportamiento de las operaciones de base de datos.
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DBConnection")));
});






//Codigo fundamental
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseRouting();
app.UseAuthorization();
app.MapControllers(); // Asegúrate de que esto esté presente

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();


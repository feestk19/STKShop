#region Coment�rios de Manuten��o

/*
 DATA_ATUALIZA��O: 19/12/2024
 MANUTEN��O: Implementa��o inicial da classe Program
 */

/*
 DATA_ATUALIZA��O: 26/12/2024
 MANUTEN��O: Adicionado registro de servi�os no container e ajuste para ignorar refer�ncias c�clicas
 */

#endregion

using Microsoft.EntityFrameworkCore;
using STKShop.ProductApi.Context;
using STKShop.ProductApi.Repositories;
using STKShop.ProductApi.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
                                    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//<Configura��o da string de Conex�o com SQL Server>//
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

//>========================================================================================================================================<//

//<Configura��o dos mapeamentos>//

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// <Registro de Servi�os no Container> //

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();

//>========================================================================================================================================<//


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

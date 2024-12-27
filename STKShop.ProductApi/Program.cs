#region Comentários de Manutenção

/*
 DATA_ATUALIZAÇÃO: 19/12/2024
 MANUTENÇÃO: Implementação inicial da classe Program
 */

/*
 DATA_ATUALIZAÇÃO: 26/12/2024
 MANUTENÇÃO: Adicionado registro de serviços no container e ajuste para ignorar referências cíclicas
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


//<Configuração da string de Conexão com SQL Server>//
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

//>========================================================================================================================================<//

//<Configuração dos mapeamentos>//

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// <Registro de Serviços no Container> //

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

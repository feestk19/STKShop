#region Comentários de Manutenção

/*
 DATA_ATUALIZAÇÃO: 19/12/2024
 MANUTENÇÃO: Implementação inicial da classe Program
 */

#endregion

using Microsoft.EntityFrameworkCore;
using STKShop.ProductApi.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//<Configuração da string de Conexão com SQL Server>//
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
//>========================================================================================================================================<//

//<Configuração dos mapeamentos>//

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

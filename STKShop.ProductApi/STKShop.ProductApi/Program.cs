#region Coment�rios de Manuten��o

/*
 DATA_ATUALIZA��O: 19/12/2024
 MANUTEN��O: Implementa��o inicial da classe Program
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


//<Configura��o da string de Conex�o com SQL Server>//
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
//>========================================================================================================================================<//

//<Configura��o dos mapeamentos>//

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

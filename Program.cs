using AplicacaoEstoque.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

/*builder.Services.AddDbContext<ProdutoContext>(options =>
    options.UseInMemoryDatabase("Produto"));*/

builder.Services.AddDbContext<ProdutoContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("conexaoMySQL"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("conexaoMySQL"))));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseCors(options =>
{
    options.WithOrigins("http://localhost:3000");
    options.AllowAnyHeader();
    options.AllowAnyMethod();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

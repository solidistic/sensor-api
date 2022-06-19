using Microsoft.EntityFrameworkCore;
using SensorApi.Models;
using SensorApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<TodoDatabaseSettings>(
    builder.Configuration.GetSection("TodoDatabase")
);
builder.Services.AddSingleton<TodosService>();

builder.Services.AddControllers();

// builder.Services.AddControllers()
//     .AddJsonOptions(
//         options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
// </snippet_AddControllers>

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
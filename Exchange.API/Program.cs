var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.

//HTTP Client
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapControllers();

app.Run();



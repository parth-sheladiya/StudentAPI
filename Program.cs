using ServiceStack.Data;
using ServiceStack.OrmLite;
using StudentAPI.BL.Interface;
using StudentAPI.BL.Operations;
using StudentAPI.Model;
using StudentAPI.Service;

var builder = WebApplication.CreateBuilder(args);

// ? Add this line to register controller services
builder.Services.AddControllers();

builder.Services.AddSingleton<IDbConnectionFactory>(
    new OrmLiteConnectionFactory(
        builder.Configuration.GetConnectionString("StudentApi"),
        MySqlDialect.Provider // ya SqlServerDialect.Provider, jaise DB ho
    )
);


//builder.Services.AddScoped<Response>();
builder.Services.RegisterStudentService();
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

// ? Map controllers
app.MapControllers();

app.Run();

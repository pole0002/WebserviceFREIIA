using FREIIA_API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// SQLSERVER
//Add services to the container.
builder.Services.AddDbContext<FREIIAContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// SQLITE
//builder.Services.AddDbContext<FREIIAContext>(options =>
//    options.UseSqlite("Datasource = FREIIA.db"));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// establishing Policy requirements: 
builder.Services.AddCors(options => options.AddPolicy("Policy", builder =>
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()));

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseAuthorization();
app.UseCors("MyPolicy");

app.MapControllers().RequireCors("Policy");

app.Run();

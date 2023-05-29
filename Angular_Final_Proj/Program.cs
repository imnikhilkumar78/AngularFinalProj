using Angular_Final_Proj.Models;
using Angular_Final_Proj.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//var connectionString = builder.Configuration.GetConnectionString("ConnStr");
builder.Services.AddDbContext<AngluarProjContext>(options => options.UseSqlServer(builder.Configuration["ConnectionStrings:conString"]));
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<DepartmentService>();
builder.Services.AddCors(options => options.AddPolicy("MyPolicy", builder => { builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader(); }));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"])),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

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

using Business.Managers;
using Business.Services;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.Interfaces;
using Repositories.Repositories;
using WebApplication1.Middlewares;
using Business.Rules;
using Business.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(ApplicationProfile).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register generic repository
builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

// Register service managers
builder.Services.AddScoped<IApplicationService, ApplicationManager>();
builder.Services.AddScoped<IBootcampService, BootcampManager>();
builder.Services.AddScoped<IBlacklistService, BlacklistManager>();

// Register business rules
builder.Services.AddScoped<ApplicationBusinessRules>();
builder.Services.AddScoped<ApplicantBusinessRules>();
builder.Services.AddScoped<BootcampBusinessRules>();
builder.Services.AddScoped<BlacklistBusinessRules>();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>(); 

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run(); 

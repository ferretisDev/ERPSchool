using ERPSchool.IManager;
using ERPSchool.IRepository;
using ERPSchool.Manager;
using ERPSchool.Models;
using ERPSchool.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string dbConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AlfredoDbContext>(p => p.UseSqlServer(dbConnection));

builder.Services.AddScoped<ISexRepository, SexRepository>();
builder.Services.AddScoped<IStateRepository, StateRepository>();
builder.Services.AddScoped<ITownRepository, TownRepository>();
builder.Services.AddScoped<INeighbourhoodRepository, NeighbourhoodRepository>();
builder.Services.AddScoped<IGroupRepository, GroupRepository>();
builder.Services.AddScoped<ISchoolRepository, SchoolRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddScoped<ISexManager, SexManager>();
builder.Services.AddScoped<IStateManager, StateManager>();
builder.Services.AddScoped<ITownManager, TownManager>();
builder.Services.AddScoped<INeighbourhoodManager, NeighbourhoodManager>();
builder.Services.AddScoped<ISchoolManager, SchoolManager>();
builder.Services.AddScoped<IGroupManager, GroupManager>();
builder.Services.AddScoped<IStudentManager, StudentManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

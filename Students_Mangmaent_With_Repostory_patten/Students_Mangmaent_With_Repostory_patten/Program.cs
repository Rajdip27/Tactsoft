using Microsoft.EntityFrameworkCore;
using Students_Mangmaent_With_Repostory_patten.DatabaseContext;
using Students_Mangmaent_With_Repostory_patten.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//database
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Conn")));
builder.Services.AddScoped<IStudent, StudentServices>();
builder.Services.AddScoped<ICource, CourceServices>();
builder.Services.AddScoped<IFaculty, FacultyServices>();
builder.Services.AddScoped<IEmployee, EmployeeServices>();
builder.Services.AddScoped<ICustomer, CustomerServices>();
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

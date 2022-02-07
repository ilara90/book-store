using Microsoft.EntityFrameworkCore;
using WebApplication2.Extetions;

var builder = WebApplication.CreateBuilder();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper();

var app = builder.Build();

app.MapControllerRoute(
"default",
"{controller=Home}/{action=Index}/{id?}");


app.Run();
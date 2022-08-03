// needed for EVERY web application

var builder = WebApplication.CreateBuilder(args);

// ! ALL builder.Services BEFORE app = builder.Build()
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
  name:"default",
  pattern: "{controller=Home}/{action=Index}/{id!}");

app.Run();


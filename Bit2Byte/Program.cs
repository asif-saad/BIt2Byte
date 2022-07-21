using Bit2Byte.Controllers;
using Bit2Byte.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AchievementContext>(options => options.UseSqlServer("Server=.;Database=Bit2Byte;Integrated Security=True"));

// Add services to the container.

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AchievementContext>();

builder.Services.AddControllersWithViews();
#if DEBUG
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();




/* this is disable client side validation
builder.Services.AddRazorPages().AddViewOptions(option =>
{
    option.HtmlHelperOptions.ClientValidationEnabled = false;
});*/
#endif

builder.Services.AddScoped<BookRepository, BookRepository>();

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


app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

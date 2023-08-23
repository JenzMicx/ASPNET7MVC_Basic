using ASPNET7MVCCRUD.Data;
using Microsoft.EntityFrameworkCore;

/*
 file program .cs คือไว้ตั้งค่า services ที่เราจะใช้งาน
 */

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
/*
 * Setting ApplicationDBcontext by add services
   also add services เข้ามาที่ project's สำหรับเชื่อมต่อกับฐานข้อมูล SQLserver ผ่าน ConnectionString ที่มีชื่อว่า DefaultConnection
*/
builder.Services.AddDbContext<ApplicationDBContext> //Services ที่เกี่ยวข้องกับฐานข้อมูล
   (   
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
   );

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
    //pattern: "{controller=Meter}/{action=ShowMeterID}/{id=9000211}");
    pattern: "{controller=Ledger}/{action=Main}/{id?}");

app.Run();

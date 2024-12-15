using Microsoft.EntityFrameworkCore;

using ZenestaMVC.Data;
using ZenestaMVC.Services;

namespace ZenestaMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Add database service
            builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection")));

            // Add session service
            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(10);
                options.Cookie.Name = ".User.Session";
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            builder.Services.AddHttpClient<MLService>();

            builder.Services.AddMvc().AddViewOptions(options => options.HtmlHelperOptions.ClientValidationEnabled = true);

            WebApplication app = builder.Build();

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

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapGet("video", (int id) =>
            {
                string filename = "Apex Legends_03-28-2024_22-5-47-307.mp4";
                //Build the File Path.  
                string path = Path.Combine("wwwroot/", "video/") + filename;  // the video file is in the wwwroot/files folder  

                FileStream filestream = File.OpenRead(path);
                return Results.File(filestream, contentType: "video/mp4", fileDownloadName: filename, enableRangeProcessing: true);
            });

            app.Run();
        }
    }
}

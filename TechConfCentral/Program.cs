using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TechConfCentral.BLL;
using TechConfCentral.DAL;
using TechConfCentral.Models;

namespace TechConfCentral
{
    public class Program
    {
        // Changed to `async task` to prevent synchronous blocking of the application
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            // DbContext
            builder.Services.AddDbContext<TechConfCentralContext>(options =>
                options.UseSqlServer(connectionString));

            // Identity
            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>() // Support for roles
                .AddEntityFrameworkStores<TechConfCentralContext>();

            // Services
            builder.Services.AddScoped<ConferenceRepository>();
            builder.Services.AddScoped<ConferenceService>();

            builder.Services.AddScoped<RoomRepository>();
            builder.Services.AddScoped<RoomService>();

            builder.Services.AddScoped<TrackRepository>();
            builder.Services.AddScoped<TrackService>();

            builder.Services.AddScoped<SpeakerRepository>();
            builder.Services.AddScoped<SpeakerService>();

            builder.Services.AddScoped<TalkRepository>();
            builder.Services.AddScoped<TalkService>();

            builder.Services.AddScoped<SavedTalkRepository>();
            builder.Services.AddScoped<SavedTalkService>();

            // MVC
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Seed roles and admin user right after the app is created cleanly with await
            await SeedRolesAndUsersAsync(app.Services);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
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
            app.MapRazorPages();

            await app.RunAsync();
        }
        static async Task SeedRolesAndUsersAsync(IServiceProvider serviceProvider)
        {
            using (IServiceScope scope = serviceProvider.CreateScope())
            {
                // Get the services instances
                RoleManager<IdentityRole> roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                UserManager<ApplicationUser> userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                // Define the basic roles
                string[] roles = { "Admin", "User" };
                foreach (string role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }

                // Create admin user
                ApplicationUser adminUser = new ApplicationUser
                {
                    UserName = "admin@techconfcentral.com",
                    Email = "admin@techconfcentral.com",
                    EmailConfirmed = true
                };
                if (await userManager.FindByEmailAsync(adminUser.Email) == null)
                {
                    await userManager.CreateAsync(adminUser, "AdminPassword123!");
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }

                // Create basic user
                ApplicationUser basicUser = new ApplicationUser
                {
                    UserName = "aberefejiro@gmail.com",
                    Email = "aberefejiro@gmail.com",
                    EmailConfirmed = true
                };
                if (await userManager.FindByEmailAsync(basicUser.Email) == null)
                {
                    await userManager.CreateAsync(basicUser, "SecurePassword123!");
                    await userManager.AddToRoleAsync(basicUser, "User");
                }
            }
        }
    }
}

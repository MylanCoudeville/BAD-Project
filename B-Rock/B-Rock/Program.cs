using B_Rock.Data;
using B_Rock.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<B_RockUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddScoped<IArtistService, ArtistService>();
builder.Services.AddScoped<IConcertService, ConcertService>();
builder.Services.AddScoped<IInstrumentService, InstrumentService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IStaffService, StaffService>();
builder.Services.AddScoped<ITicketService, TicketService>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policyBuilder => policyBuilder.RequireClaim("IsAdmin"));
    options.AddPolicy("Customer", policyBuilder => policyBuilder.RequireClaim("IsCustomer"));
});

var app = builder.Build();

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

app.UseSession();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetService<UserManager<B_RockUser>>();
    if (userManager.FindByEmailAsync("admin@test.be").Result == null)
    {
        B_RockUser adminUser = new B_RockUser();
        adminUser.FirstName = "Admin";
        adminUser.LastName = "User";
        adminUser.UserName = "admin@test.be";
        adminUser.Email = "admin@test.be";
        adminUser.EmailConfirmed = true;
        var result = userManager.CreateAsync(adminUser, "Admin123!").Result;
        if (result.Succeeded)
        {
            Claim[] claims = new Claim[] {
                new Claim("IsAdmin", string.Empty)
            };
            userManager.AddClaimsAsync(adminUser, claims).Wait();
        }
    }
    if (userManager.FindByEmailAsync("mylan.coudeville@student.odisee.be").Result == null)
    {
        B_RockUser customer = new B_RockUser();
        customer.FirstName = "Mylan";
        customer.LastName = "Coudeville";
        customer.UserName = "mylan.coudeville@student.odisee.be";
        customer.Email = "mylan.coudeville@student.odisee.be";
        customer.EmailConfirmed = true;
        var result = userManager.CreateAsync(customer, "Test123!").Result;
        if (result.Succeeded)
        {
            Claim[] claims = new Claim[] {
                new Claim("IsCustomer", string.Empty)
            };
            userManager.AddClaimsAsync(customer, claims).Wait();
        }
    }
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

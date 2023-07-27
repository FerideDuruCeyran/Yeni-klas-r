using Eticaret.magaza.Services;
using Eticaret.Magaza;
using Eticaret.Magaza.Services;
using Eticaret.Model;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MainDatabaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MainDatabase"));
});

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAuthentication(options => 
{

    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
{
    options.LoginPath = "/auth/login";
});


// Add services to the container.
builder.Services.AddControllersWithViews();

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
app.UseCookiePolicy();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapPost("/security/create-token", (Login login) =>
{
    string issuer = builder.Configuration["Jwt:Issuer"];
    string audience = builder.Configuration["Jwt:Audience"]; 
    byte[] key = Encoding.ASCII.GetBytes(
        builder.Configuration["Jwt:Key"]);
    SecurityTokenDescriptor token = new()
    {
        Subject = new ClaimsIdentity(new[]
        {
           new Claim("Id",login.Id.ToString()),
           new Claim("Email",login.Email),
         }),
        Expires= DateTime.UtcNow.AddDays(7),
        Issuer = issuer,
        Audience= audience,
        SigningCredentials= new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature),

    };
    JwtSecurityTokenHandler handler = new();
    SecurityToken securityToken=handler.CreateToken(token);
    string JwtToken =handler.WriteToken(securityToken);

    return Results.Ok(JwtToken);

});
app.Run();

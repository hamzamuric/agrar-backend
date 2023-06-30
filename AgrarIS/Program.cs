using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AgrarIS.Data;
using AgrarIS.Services;
using AgrarIS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AgrarIS.Mapping;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AgrarISContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));

// Add services to the container.
//builder.Services.AddIdentity<Korisnik, IdentityRole>()
//               .AddEntityFrameworkStores<AgrarISContext>()
//               .AddDefaultTokenProviders();

//builder.Services.AddAuthentication(
//    options =>
//    {
//        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//    })
//    .AddJwtBearer(options =>
//    {
//        options.SaveToken = true;
//        options.RequireHttpsMetadata = false;
//        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
//        {
//            ValidateAudience = true,
//            ValidateIssuer = true,
//            ValidAudience = "https://localhost:5001/",
//            ValidIssuer = "https://localhost:5001/",
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("78fUjkyzfLz56gTq"))
//        };
//    });
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MappingProfile));

//builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddIdentity<Korisnik, KorisnikUserRole>();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.MapControllers();

app.Run();

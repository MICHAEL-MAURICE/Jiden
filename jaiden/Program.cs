using Core.Identity;
using Core.ImagesHandler;
using Core.Interfaces;
using Core.Jwt;
using Core.ImagesHandler;

using Infrastructure.Repo;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Core.Entities;
using Newtonsoft.Json;
using Core.Helper;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


//JsonConvert.SerializeObject(, Formatting.Indented,
//new JsonSerializerSettings
//{
//    ReferenceLoopHandling = ReferenceLoopHandling.Serialize
//});
// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    // Configure JSON settings
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    // Or, to ignore circular references:
    // options.JsonSerializerOptions.ReferenceHandler = null;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//________________AutoMapper_________________
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


//________________________Cores_____________________________

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


//_____________________________________________________________


//_____________________Database____________________________

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TeastingServerDB"),b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

//______________________________________________________________

//______________________JWT___________________________

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
    };
});

//__________________________________________________


//_____________________DP__________________________

builder.Services.AddScoped<IProudect, ProudectRepo>();
builder.Services.AddScoped<IAd,AdRepo>();
builder.Services.AddScoped<IRepositoryImages, ImagesRepository>();
builder.Services.AddScoped<IupdateToken,updateToken>();
builder.Services.AddScoped<IAuth, Auth>();
builder.Services.AddScoped<IOrder, OrderRepo>();

builder.Services.AddScoped<IPayment, Payment>();
builder.Services.AddScoped<ITokenFactory, TokenFactory>();
builder.Services.AddScoped<ITokenDecoder, TokenDecoder>();
builder.Services.AddScoped(typeof(IGeneric<>), typeof(Generic<>));
builder.Services.AddScoped<IUser, User>();
builder.Services.AddScoped<IPricingSettings,PricingSettingsRepo>();
builder.Services.AddScoped<INews, NewsRepo>();



//______________Identity____________________________________

builder.Services.AddIdentityCore<AppUser>(Opt => { })
    .AddEntityFrameworkStores<AppDbContext>()
    .AddSignInManager<SignInManager<AppUser>>();
//____________________________________________________________




builder.Services.AddAuthentication();
builder.Services.AddAuthorization();  



var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();

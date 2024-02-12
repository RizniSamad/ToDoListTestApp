using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using ToDoListTestApp.Data;
using ToDoListTestApp.Entity;
using ToDoListTestApp.Hubs;
using ToDoListTestApp.Repository;
using ToDoListTestApp.Repository.IRepository;
using ToDoListTestApp.Service;
using ToDoListTestApp.Service.IService;
using ToDoListTestApp.TimerFeatures;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(
    opt =>
        opt.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection"),
            b => 
                b.MigrationsAssembly(
                    typeof(ApplicationDbContext).Assembly.FullName
                )
        )
);

builder.Services
            .AddIdentityCore<AppUser>(opt => { opt.SignIn.RequireConfirmedAccount = true; })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddSignInManager<SignInManager<AppUser>>();

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Token:Key"])
            ),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAppUserService, AppUserService>();
builder.Services.AddScoped<IToDoListService, ToDoListService>();
builder.Services.AddScoped<IToDoListTaskService, ToDoListTaskService>();

builder.Services.AddScoped<ITimerManager, TimerManager>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });

    var securitySchema = new OpenApiSecurityScheme
    {
        Description = "JWT Auth Bearer Scheme",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };

    c.AddSecurityDefinition("Bearer", securitySchema);
    var securityRequirement = new OpenApiSecurityRequirement
            {
                { securitySchema, new[] { "Bearer" } }
            };
    c.AddSecurityRequirement(securityRequirement);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

builder.Services.AddSignalR();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
}


app.MapHub<NotificationHub>("/notification");

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

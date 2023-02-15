using AutoMapper;
using Datos;
using Entities.Interface;
using Servicios;
using Servicios.Interface;
using Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var mapperConfig = new MapperConfiguration(m =>
{
    m.AddProfile(new AutoMapperProfiles());
});


IMapper mapper = mapperConfig.CreateMapper();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

#region Inyeccion de dependencias
builder.Services.AddSingleton<IRepositorio, Repositorio>();
builder.Services.AddSingleton<IUsuarioServicio, UsuarioServicio>();
builder.Services.AddSingleton(mapper);
builder.Services.AddScoped(typeof(ITokenHandlerService), typeof(TokenHandlerService));
#endregion

builder.Configuration.AddJsonFile("appsettings.json", false, true);

builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));

var c = builder.Configuration.GetSection("JwtConfig:Secret");
var d = builder.Configuration["JwtConfig:Secret"];

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(jwt =>
    {
        var key = Encoding.ASCII.GetBytes(builder.Configuration["JwtConfig:Secret"]);

        jwt.SaveToken = true;
        jwt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            RequireExpirationTime = false,
            ValidateLifetime = true
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();

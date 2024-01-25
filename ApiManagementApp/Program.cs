using ApiManagementApp.MDmContext;
using ApiManagementApp.Reposetory.Clases;
using ApiManagementApp.Reposetory.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(option =>
option.ReturnHttpNotAcceptable = true
).AddXmlDataContractSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.AddDbContext<ManagmentDbContexts>(Options =>
{
    Options.UseSqlServer(builder.Configuration["ConnectionStrings:connect"]);
});

/*builder.Services.AddControllers(option =>
option.ReturnHttpNotAcceptable = true
).AddXmlDataContractSerializerFormatters();*/

var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });
builder.Services.AddScoped<ICar,CarRepository>();
builder.Services.AddScoped<IPart,PartRepository>();
builder.Services.AddScoped<ICustomer,CustomerRepository>();
builder.Services.AddScoped<ISale,SaleRepository>();
builder.Services.AddScoped<ISupplier,SupplierRepository>();

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

app.MapControllers();

app.Run();



using FOA.BACKEND.DataAccess.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using FOA.BACKEND.Entities;
using FOA.BACKEND.Business.Interfaces;
using FOA.BACKEND.DataAccess.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FOA.BACKEND.Business.Interfaces.Services;
using FOA.BACKEND.Business.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Add services to the container.
builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<FOAContext>();

builder.Services.AddDbContext<FOAContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("FOAContext")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IBaseRepository<User, string>, BaseRepository<User, string>>();
builder.Services.AddScoped<IBaseRepository<Address, int>, BaseRepository<Address, int>>();
builder.Services.AddScoped<IBaseRepository<Announcement, int>, BaseRepository<Announcement, int>>();
builder.Services.AddScoped<IBaseRepository<Apartment, int>, BaseRepository<Apartment, int>>();
builder.Services.AddScoped<IBaseRepository<Contract, int>, BaseRepository<Contract, int>>();
builder.Services.AddScoped<IBaseRepository<Employee, int>, BaseRepository<Employee, int>>();
builder.Services.AddScoped<IBaseRepository<Invoice, int>, BaseRepository<Invoice, int>>();
builder.Services.AddScoped<IBaseRepository<Request, int>, BaseRepository<Request, int>>();
builder.Services.AddScoped<IBaseRepository<WaterConsumption, int>, BaseRepository<WaterConsumption, int>>();


builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IAnnouncementService, AnnouncementService>();
builder.Services.AddScoped<IApartmentService, ApartmentService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<IWaterConsumptionService, WaterConsumptionService>();
builder.Services.AddScoped<IContractService, ContractService>();

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("asdfghjklqwertyuiopzxcvbnm")),
        ValidateAudience = false,
        ValidateIssuer = false
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true) // allow any origin
                                                        //.WithOrigins("https://localhost:44351")); // Allow only this origin can also have multiple origins separated with comma
                    .AllowCredentials());

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapRazorPages();

app.Run();

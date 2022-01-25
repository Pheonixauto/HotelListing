using HotelListing;
using HotelListing.Configruations;
using HotelListing.Datas;
using HotelListing.IRepository;
using HotelListing.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;





var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddNewtonsoftJson(builder =>
builder.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddAutoMapper(typeof(MapperInitializi));

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddDbContext<DataBaseContext>(dbContextOptions =>
dbContextOptions.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"))
);
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
//builder.Services.ConfigureJWT();


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://example.com")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                      });
});

builder.Host.UseSerilog((context, logconfig) =>
{
    logconfig.WriteTo.Console();
    //logconfig.WriteTo.File(path: "logs/log.txt");
});

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

app.UseRouting();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller= Home}/{action=Index}/{id?}");
    endpoints.MapControllers();
});

app.MapControllers();

app.Run();


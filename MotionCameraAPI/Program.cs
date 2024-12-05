using MotionCameraAPI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll",
                      policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddDbContext<LicensePlateDbContext>(options =>
    options.UseSqlServer(Secret.ConnectionString));
builder.Services.AddScoped<LicensePlateRepositoryDB>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<LicensePlateDbContext>();
    db.Database.EnsureCreated(); // Initialiser databasen
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();

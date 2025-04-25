using API.Data;
using API.Middlewares;
using API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


builder.Services.AddDbContext<BackenDbContext>(options =>
    options.UseSqlite("Data Source=backend.db"));

// Add services to the container.
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddJsonOptions(options => { options.JsonSerializerOptions.IncludeFields = true; });
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyMethod()
                          .AllowAnyHeader()
                          .SetIsOriginAllowed(origin => true)
                          .AllowCredentials();
                      });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BackenDbContext>();
    db.Database.Migrate(); 
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();

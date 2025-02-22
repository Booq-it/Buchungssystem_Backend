var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

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

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

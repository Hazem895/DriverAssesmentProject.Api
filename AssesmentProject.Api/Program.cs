using AssesmentProject.Domain.DriversDomain;
using AssesmentProject.Domain.IRepository;
using AssesmentProject.Infrastructure.Sql;
using AssesmentProject.Infrastructure.Sql.Repository.DriversRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("LocalConnectionString")));


#region Register Interface and its implementation
builder.Services.AddScoped<ICrudCommandsRepository<Driver>, DriversRepository>();
# endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(cors =>cors.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
app.UseAuthorization();

app.MapControllers();

app.Run();

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Web.Data;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//для wwwroot
builder.Services.AddRazorPages();


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

//Запуск через SWAGGER 
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Название вашего API", Version = "v1" });

    // Добавить поддержку атрибутов Swagger для документирования кода
    c.EnableAnnotations();
});

//Inject Dbcontext
builder.Services.AddDbContext<SDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//для sagger
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
    });

    //wwwroot
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}


//тоже всё для SWAGGER
app.UseCors("default");

//wwwroot
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

//wwwroot
app.MapRazorPages();

app.MapControllers();

app.Run();

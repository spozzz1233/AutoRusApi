using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Web.Data;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//��� wwwroot
builder.Services.AddRazorPages();


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

//������ ����� SWAGGER 
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "�������� ������ API", Version = "v1" });

    // �������� ��������� ��������� Swagger ��� ���������������� ����
    c.EnableAnnotations();
});

//Inject Dbcontext
builder.Services.AddDbContext<SDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//��� sagger
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


//���� �� ��� SWAGGER
app.UseCors("default");

//wwwroot
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

//wwwroot
app.MapRazorPages();

app.MapControllers();

app.Run();

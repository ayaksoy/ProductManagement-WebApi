
using Microsoft.EntityFrameworkCore;
using Product_git.Data;
using Product_git.Service.Interface;
using Product_git.Service.Model;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var Allow = "Policy";
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(Allow,
            policy =>
            {
                policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
        });


        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Bağlantı");
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString)
        );
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddTransient<ICategoryService, CategoryService>();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseCors(Allow);

        app.MapControllers();

        app.Run();
    }
}
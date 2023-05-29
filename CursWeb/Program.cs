
using CursWeb;
using System.Text.Json.Serialization;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var c = builder.Services.AddControllers();
        c.AddJsonOptions(opt =>
        {
            opt.JsonSerializerOptions.
                ReferenceHandler = ReferenceHandler.Preserve;
        });
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddAuthentication();

        builder.Services.AddSqlServer<Avto_VakzalContext>("server=192.168.200.35;user=user18;password=38024;database=user18");

        //server=192.168.200.35;user=user18;password=38024;database=user18; (колледж)
        //"server=VLADIMIR;database=Avto_Vakzal;Trusted_Connection=True" (дома)
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}

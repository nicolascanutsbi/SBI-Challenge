using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SBI_test.Models;
using AutoMapper;
using System;
using MediatR;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {

        services.AddControllers();

        services.AddAutoMapper(typeof(MappingProfile));

        services.AddMediatR(typeof(GetPostQueryHandler).Assembly);

        services.AddHttpClient("jsonplaceholder", c =>
        {
            c.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            c.DefaultRequestHeaders.Add("User-Agent", "HttpClient");
        });

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "SBI Test API", Version = "v1" });
        });
    }


    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "SBI Test API V1");
        });
    }
}

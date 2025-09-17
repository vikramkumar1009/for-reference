using AspNetCoreRateLimit;
using Dlplone.LMS.Infrastructure;
using Dlplone.LMS.Infrastructure.ExceptionHandler;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMapster();
builder.Services.RegisterService();
Log.Logger = new LoggerConfiguration().CreateBootstrapLogger();
if (builder.Configuration["enableLog"] == "True")
{
    builder.Host.UseSerilog((ctx, lc) => lc.ReadFrom.Configuration(ctx.Configuration));
}
builder.Services.AddHsts(options =>
{
    options.Preload = true;
    options.IncludeSubDomains = true;
    options.MaxAge = TimeSpan.FromDays(60);
});

builder.Services.AddJWTTokenServices(builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder1 =>
        {
            builder1.WithOrigins(builder.Configuration["AllowedDomains"].Split(','))
                   .AllowAnyHeader()
                   .AllowAnyMethod().AllowCredentials();
            Console.WriteLine(builder.Configuration["AllowedDomains"].Split(','));
        });
});
builder.Services.AddControllers(config =>
{
    config.Filters.Add(typeof(CustomExceptionHandler));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Cookie,
        Description = "JWT Authorization header using the Bearer scheme."
    });
    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme {
                    Reference = new Microsoft.OpenApi.Models.OpenApiReference {
                        Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                            Id = "Bearer"
                    }
                },
                new string[] {}
        }
    });
});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
if (builder.Configuration["enableLog"] == "True")
{
    app.UseSerilogRequestLogging();
}
app.UseHsts();
app.UseAuthorization();
app.UseCors();
app.UseIpRateLimiting();
app.MapControllers();
app.Use(async (context, next) =>
{
    context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
    context.Response.Headers.Add("X-Frame-Options", "DENY");
    context.Response.Headers.Add("X-XSS-Protection", "1; mode=block");
    context.Response.Headers.Add("Content-Security-Policy", "default-src 'self'");
    context.Response.Headers.Add("Permissions-Policy", "geolocation=(), camera=(), microphone=()");
    await next();
});
app.Run();

using appapi.Data;
using appapi.GenericRepository;
using appapi.Mapper;
using appapi.Middleware;
using appapi.Seed;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped(typeof(IUserGenericRepository<>), typeof(UserGenericRepository<>));
//builder.Services.AddDbContext<DbContextApi>(ops => ops.UseSqlite(builder.Configuration.GetConnectionString("Default")));
//builder.Services.AddDbContext<DbContextApi>(ops => ops.UseNpgsql(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddDbContext<DbContextApi>(ops => ops.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Mapping
builder.Services.AddAutoMapper(typeof(MapperConfig));
//CORS
/*
var names = "MyPolicy";
builder.Services.AddCors(
    ops => ops.AddPolicy(name:names,
    pol =>pol.WithOrigins("https://localhost:7000/")
    .AllowAnyHeader()
    .AllowAnyMethod()
    )
);*/
//*****************//
var app = builder.Build();
//Seed
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<DbContextApi>();
var logger = services.GetRequiredService<ILogger<Program>>();
try
{
    await DataSeed.SeedAsync(context);
}
catch(Exception ex)
{
    logger.LogError(ex,"An Error Occured during mingraiton.");
}
//**************//



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/*
//// to run a static files such as front end and images
///
*/
app.UseStaticFiles(); /// wwwroot file
app.UseStaticFiles(new StaticFileOptions{
    FileProvider = new PhysicalFileProvider(Path
    .Combine(Directory.GetCurrentDirectory(), "Content")), 
    RequestPath = "/Content"
}); //ex: https://localhost:7000/Content/img1.png link to collect image 
/*---------------------------*/

//// Add middlewear for using Front-end from fallback controller...
app.MapFallbackToController("Index", "Fallback");
///
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(opt => {
    opt.AllowAnyOrigin();
    opt.AllowAnyHeader();
    opt.AllowAnyMethod();
    });
//app.UseCors(names);
/*
app.Use(async (ctx, next)=>{
    ctx.Response.Headers["Access-Control-Allow-Origin"]="https://localhost:7000";
    ctx.Response.Headers["some-custom-Headers"] = "secret!";
    if(HttpMethods.IsOptions(ctx.Request.Method)){
        
        ctx.Response.Headers["Access-Control-Allow-Headers"] = "my-a, my-b";
        ctx.Response.Headers["Access-Control-Allow-Methods"] = "POST, GET, OPTIONS,PUT";
       

        await ctx.Response.CompleteAsync();
        return;
    }
    await next();
});*/

app.Run();

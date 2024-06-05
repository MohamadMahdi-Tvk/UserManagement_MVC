using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyProject.Application.ExtentionMethods;
using MyProject.Application.Services.Users.Queries;
using MyProject.DataAccess.Context;
using MyProject.DataAccess.Repositories.UserRepository;
using MyProject.DataAccess.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

#region MediatR

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetUsersQuery).Assembly));

#endregion 


#region Mapper

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfiles(new List<Profile>
    {
        new MappingProfile()
    });
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

#endregion

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

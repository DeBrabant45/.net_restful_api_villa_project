using Magic_Villa_Web.Domain.Mapping;
using Magic_Villa_Web.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(VillaDTOMapper));
builder.Services.AddHttpClient<IVillaService, VillaSerivce>();
builder.Services.AddScoped<IVillaService, VillaSerivce>();
builder.Services.AddHttpClient<IVillaNumberService, VillaNumberSerivce>();
builder.Services.AddScoped<IVillaNumberService, VillaNumberSerivce>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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

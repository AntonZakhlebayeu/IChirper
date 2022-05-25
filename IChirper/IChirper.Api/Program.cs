using IChirper.ServiceAdd;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext();
builder.Services.AddIdentity();
builder.Services.AddRazorPages();
builder.Services.AddRepositories();
builder.Services.AddEntitiesServices();
builder.Services.AddValidation();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
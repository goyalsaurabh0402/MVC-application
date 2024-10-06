var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // Enable HSTS for non-development environments.
}

// Set up HTTPS redirection with a fallback to HTTP if not configured.
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Configure the app to listen on both HTTP and HTTPS.
app.Urls.Add("http://localhost:5000"); // HTTP port
app.Urls.Add("https://localhost:5001"); // HTTPS port

app.Run();

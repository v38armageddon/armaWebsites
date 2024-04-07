var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.Urls.Add("http://localhost:5218"); // HTTP localhost
app.Urls.Add("https://localhost:7130"); // HTTPS localhost

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();
app.UseRouting();

// When the user navigate to another page, use the GC
app.Use((context, next) =>
{
    GC.Collect();
    GC.WaitForPendingFinalizers();
    return next();
});

app.UseAuthorization();

app.MapRazorPages();

app.Run();

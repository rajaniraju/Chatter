using Chat;
using Chat.Hubs;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSignalR();
builder.Services.AddCors
(options =>
{
options.AddDefaultPolicy(builder=> { builder.WithOrigins("http://localhost:3001").AllowAnyHeader().AllowAnyMethod().AllowCredentials(); });
});
builder.Services.AddSingleton<IDictionary<string, UserConnection>>(options=>new Dictionary<string, UserConnection>());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCors();

app.UseAuthorization();

app.MapRazorPages();
app.MapHub<ChatHub>("/Chat");

app.Run();
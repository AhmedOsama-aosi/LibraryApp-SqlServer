using LibraryApp.Data;
using LibraryApp.Services;
using LibraryApp.SQLite;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Configuration;
using System.Net;
using System.Net.Sockets;




var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<BooksAPI>();
builder.Services.AddSingleton<Notifi>();
builder.Services.AddSingleton<Notifi>();



builder.Services.AddServerSideBlazor().AddHubOptions(options => { options.MaximumReceiveMessageSize = 512 * 1024*1024; });

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
String serverHostName = Dns.GetHostName();
IPHostEntry ipEntry = Dns.GetHostEntry(serverHostName);
IPAddress[] addr = ipEntry.AddressList;
string pip = "";
foreach (IPAddress ip in addr)
{
    if (ip.AddressFamily == AddressFamily.InterNetwork && ip.ToString().StartsWith("192.168.0"))
    {
        pip = "https://" + ip.ToString() + ":3000";
        break;
    }
}
if (pip != "")
{
    app.Urls.Add(pip);
}
app.Run();

//Scaffold-DbContext "Server=(localdb)\ProjectModels;Database=dbt;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Model
//Scaffold-DbContext "Server=localhost\SQLEXPRESS;Database=db;Trusted_Connection=True;Encrypt=False;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Model
//dotnet ef dbcontext scaffold "data source=D:\shamela4_2\database\master.db" Microsoft.EntityFrameworkCore.Sqlite --output-dir SQLite
//  => optionsBuilder.UseSqlServer($"Data Source=localhost\\SQLEXPRESS; AttachDbFilename={Environment.CurrentDirectory}\\database\\db.mdf; Integrated Security=True; Connect Timeout=30;");

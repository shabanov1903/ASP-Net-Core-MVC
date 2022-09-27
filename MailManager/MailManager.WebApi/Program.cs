using MailManager.Data;
using MailManager.Data.Entities;
using MailManager.Data.Interfaces;
using MailManager.Data.SQLServer;
using MailManager.WebApi.Jobs;
using Microsoft.EntityFrameworkCore;
using MailManager.Core.Intarfaces;
using MailManager.Core.Email;
using Quartz;
using Quartz.Impl;
using MailManager.WebApi.Services;
using MailManager.WebApi.Identity;
using MailManager.WebApi.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Add database
builder.Services.AddDbContext<MailContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServer")));
// Add Identity server
builder.Services.AddDbContext<IdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerIdentity")));
// Add services
builder.Services.AddScoped<IRepository<Client>, SQLServerDataBaseClients>();
builder.Services.AddScoped<IRepository<Notice>, SQLServerDataBaseNotices>();
builder.Services.AddScoped<SQLServer>();
// Add Quartz
builder.Services.AddQuartz(q =>
    {
        q.SchedulerName = "MailService";
        q.ScheduleJob<QuartzSender>(trigger => trigger
            .StartAt(DateBuilder.EvenSecondDate(DateTimeOffset.UtcNow.AddSeconds(100)))
            .WithDailyTimeIntervalSchedule(x => x.WithInterval(100, IntervalUnit.Second))
            .WithIdentity("MailKey", "MailGroup"));
        q.UseMicrosoftDependencyInjectionJobFactory();
    }
);
builder.Services.AddQuartzHostedService(options =>
{
    options.WaitForJobsToComplete = true;
});
builder.Services.AddSingleton<IScheduler>(p =>
{
    return new StdSchedulerFactory().GetScheduler("MailService").Result!;
}
);
// Add email service
var options = new MailGatewayOptions
{
    SenderName = "Server",
    SMTPServer = "smtp.yandex.ru",
    Sender = "shabanov-1995@yandex.ru",
    Password = "Neverwinter1!"
};
builder.Services.AddScoped<ISender, MessageGateway>(p => {
    return new MessageGateway(options);
});
// Add Mapper
builder.Services.AddMapper();
//Add Identity
builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<IdentityContext>()
    .AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "MailManager";
    options.Cookie.HttpOnly = true;

    options.LoginPath = "/Accoutn/Login";
    options.LogoutPath = "/Accoutn/Logout";
    options.AccessDeniedPath = "/Accoutn/AccessDenied";

    options.SlidingExpiration = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Mail/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();

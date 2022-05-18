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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Add database
builder.Services.AddDbContext<MailContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServer")));
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
    Sender = "*********@yandex.ru",
    Password = "*********"
};
builder.Services.AddScoped<ISender, MessageGateway>(p => {
    return new MessageGateway(options);
});
// Add Mapper
builder.Services.AddMapper();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Mail}/{action=Index}/{id?}");

app.Run();

using System;
using System.IO;
using System.Text.Json;
using Lesson8.Models;
using dt = Lesson8.Data.Data;

namespace Lesson8.Services
{
    public static class DataServiceExtentions
    {
        public static void AddDataFromJson(this IServiceCollection services)
        {
            services.AddTransient<IData, DataService>();
        }
    }

    public class DataService : IData
    {
        public OfficeModel GetOffice(int id)
        {
            using FileStream fsE = File.OpenRead("./Data/Employees.json");
            var employees = JsonSerializer.Deserialize<dt>(fsE)!
                .Employees!
                .Where(x => x.OfficeId == id);

            using FileStream fsO = File.OpenRead("./Data/Offices.json");
            var offices = JsonSerializer.Deserialize<dt>(fsO)!.Offices!;
            var office = offices.Where(x => x.Id == id).FirstOrDefault()!;

            office.Employees = employees;
            office.Count = offices.Count();
            return office;
        }
    }
}

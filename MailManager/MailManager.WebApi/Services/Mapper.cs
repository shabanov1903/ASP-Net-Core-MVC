using MailManager.Data.Entities;
using MailManager.WebApi.Models;
using Nelibur.ObjectMapper;

namespace MailManager.WebApi.Services
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMapper(this IServiceCollection collection)
        {
            collection.AddSingleton<Mapper>();
        }
    }
    public class Mapper
    {
        public Mapper()
        {
            TinyMapper.Bind<ClientDto, Client>();
            TinyMapper.Bind<NoticeDto, Notice>();
        }
    }
}
